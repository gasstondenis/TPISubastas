﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TPISubastas.Sitio.Controllers
{
   public class AccountController : Controller
   {


      private UserManager<Security.SecurityUser> _UserManager;
      private SignInManager<Security.SecurityUser> _SignInManager;
      private Security.SecurityContext _SecurityContext;
      private ContextoSubasta _ContextoSubasta;
      private TokenValidationParameters _ParametrosToken;
      public string LastUrl { get; set; }

      public AccountController(UserManager<Security.SecurityUser> usermanager, SignInManager<Security.SecurityUser> signinmanager, Security.SecurityContext securitycontext, ContextoSubasta contextosubasta, TokenValidationParameters parametrosToken)
      {
         _UserManager = usermanager;
         _SignInManager = signinmanager;
         _SecurityContext = securitycontext;
         _ContextoSubasta = contextosubasta;
         _ParametrosToken = parametrosToken;
      }

      private TokenSeguridad GenerarToken(Security.SecurityUser usuario)
      {
         ClaimsIdentity identidad = new ClaimsIdentity(new GenericIdentity(usuario.UserName, "TokenAuthentication"), new[] { new Claim("UserId", usuario.Id) });
         DateTime expiracion = DateTime.Now.AddMinutes(5);

         var generador = new JwtSecurityTokenHandler();
         var token = generador.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
         {
            Issuer = _ParametrosToken.ValidIssuer,
            Audience = _ParametrosToken.ValidAudience,
            SigningCredentials = new SigningCredentials(_ParametrosToken.IssuerSigningKey, SecurityAlgorithms.HmacSha256Signature),
            Subject = identidad,
            NotBefore = DateTime.Now,
            Expires = expiracion
         });

         return new TokenSeguridad() { Token = generador.WriteToken(token), Expiracion = expiracion };
      }

      [HttpPost]
      public async Task<IActionResult> ObtenerToken([FromBody] CredencialesToken model)
      {
         try
         {
            var resultado = await _SignInManager.PasswordSignInAsync(model.Usuario, model.Contraseña, false, false);
            if (resultado.Succeeded)
            {
               var usuario = await _UserManager.FindByNameAsync(model.Usuario);
               return Json(GenerarToken(usuario));
            }
            else
            {
               return Json(new TokenSeguridad() { Token = "ERROR" });
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      public IActionResult Login()
      {
         return View();
      }


      [ValidateAntiForgeryToken]
      [HttpPost]
      public async Task<IActionResult> Login(Security.SecurityLogin datos, string returnUrl)
      {


         if (!ModelState.IsValid)
         {
            return View(datos);
         }
         var resultado = await _SignInManager.PasswordSignInAsync(datos.Usuario, datos.Contraseña, false, false);
         if (resultado.Succeeded)
         {
            if (string.IsNullOrWhiteSpace(returnUrl))
               return Redirect("/");
            return Redirect(returnUrl);
         }
         else
         {
            ModelState.AddModelError("UserError", "El usuario y/o la contraseña son erroneos");
         }
         return View(datos);
      }

      public async Task<IActionResult> Logout()
      {
         await _SignInManager.SignOutAsync();
         return RedirectToAction("Index", "Home");
      }

      [HttpGet]
      public IActionResult Register()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Register(Security.SecurityRegister datos, string ReturnUrl)
      {

         if (!ModelState.IsValid)
         {
            return View(datos);

         }

         /*
          Si existe en la base de datos de subasta pero no existe en la base 
         de datos de seguridad o no existe en la de subastas
         entonces la creamos
          */

         bool existeensubasta = _ContextoSubasta.Usuario.Any(u => u.Documento == datos.Documento);
         bool existeenseguridad = _SecurityContext.Users.Any(u => u.DNI == datos.Documento);

         using (var transaction = _ContextoSubasta.Database.BeginTransaction())
         {
            IdentityResult resultado = new IdentityResult();

            if (!_ContextoSubasta.Usuario.Any(u => u.Documento == datos.Documento))
            {
               try
               {
                  Dominio.Usuario nusuario = new Dominio.Usuario();

                  nusuario.Nombre = datos.Nombre;
                  nusuario.Apellido = datos.Apellido;
                  nusuario.Documento = datos.Documento;
                  nusuario.Calle = datos.Calle;
                  nusuario.Numero = datos.Numero;
                  nusuario.CodigoPostal = datos.CodigoPostal;
                  nusuario.Ciudad = datos.Ciudad;
                  nusuario.Provincia = datos.Provincia;
                  nusuario.Telefono = datos.Telefono;
                  nusuario.Email = datos.Email;
                  nusuario.FechaNacimiento = datos.FechaNacimiento;
                  nusuario.FechaCreacion = DateTime.Now;

                  await _ContextoSubasta.Usuario.AddAsync(nusuario);
                  await _ContextoSubasta.SaveChangesAsync();

                  Security.SecurityUser nuser = new Security.SecurityUser();

                  nuser.Nombre = datos.Nombre;
                  nuser.Apellido = datos.Apellido;
                  nuser.DNI = datos.Documento;
                  nuser.Email = datos.Email;
                  nuser.EmailConfirmed = true;
                  nuser.IdUsuarioSubasta = nusuario.IdUsuario;
                  nuser.NormalizedEmail = datos.Email.ToLower();
                  nuser.NormalizedUserName = datos.Usuario.ToLower();
                  nuser.PhoneNumber = datos.Telefono;
                  nuser.PhoneNumberConfirmed = true;
                  nuser.UserName = datos.Usuario;


                  resultado = await _UserManager.CreateAsync(nuser, datos.Contraseña);

                  if (resultado.Succeeded)
                  {
                     transaction.Commit();
                     return Redirect("/Account/login");
                  }
                  else
                  {
                     throw new Exception();
                  }
               }
               catch (Exception e)
               {
                  foreach (var item in resultado.Errors)
                  {
                     ModelState.AddModelError(item.Code, item.Description);
                  }
                  transaction.Rollback();
               }

            }
            else
            {
               ModelState.AddModelError("Existente", "Ya existe un usuario registrado con el mismo documento");
            }

            return View(datos);
         }
      }

   }
}
