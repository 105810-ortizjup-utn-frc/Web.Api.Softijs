﻿namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOordenP
    {
        public int NroOrden{ set; get; }
        public string? Tipo { set; get; }
        public string? Estado { set; get; }
        public DateTime Fecha { set; get; }
        public string CreadoPor { set; get; }
        public DateTime FechaCreacion { set; get; }
        public decimal Total { set; get; }



        public DTOordenP(int nroOrden, string tipo, string estado, DateTime fecha, string creadoPor, DateTime FechaCreacion, decimal total)
        {
            this.NroOrden = nroOrden;
            this.Tipo = tipo;
            this.Estado = estado;
            this.Fecha = fecha;
            this.CreadoPor = creadoPor;
            this.FechaCreacion = FechaCreacion;
            this.Total = total;
         
        }

        public DTOordenP()
        {

        }
    }
}
