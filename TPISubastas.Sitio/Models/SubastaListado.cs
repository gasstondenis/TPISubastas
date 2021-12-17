using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Dominio;
namespace TPISubastas.Sitio.Models
{
    public class SubastaItem : Subasta
    {
        public SubastaItem()
        { }

        public SubastaItem(Subasta fuente)
        {
            this.Descripcion = fuente.Descripcion;
            this.Duracion = fuente.Duracion;
            this.FechaCierre = fuente.FechaCierre;
            this.FechaCreacion = fuente.FechaCreacion;
            this.FechaInicio = fuente.FechaInicio;
            this.Habilitada = fuente.Habilitada;
            this.IdSubasta = fuente.IdSubasta;
            this.Nombre = fuente.Nombre;
            

        }
        public string FechaInicioStr { get { return string.Format("{0:dd/MM/yyyy}", FechaInicio); } }
        public string FechaCierreStr { get { return string.Format("{0:dd/MM/yyyy}", FechaCierre); } }
    }
    public class SubastaListado
    {
        public List<SubastaItem> Subastas { get; set; }
        public int TotalPaginas { get; set; }
        public int Cantidad { get; set; }
        public int Pagina { get; set; }
    }
}
