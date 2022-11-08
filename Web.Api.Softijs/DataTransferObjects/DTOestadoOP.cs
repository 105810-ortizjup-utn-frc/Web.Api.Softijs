namespace Web.Api.Softijs.DataTransferObjects
{
    public class DTOestadoOP
    {
        public int nroOrden { set; get; }
        public int estado { set; get; }


        public DTOestadoOP(int nroOrden, int estado)
        {
            nroOrden = nroOrden;
            this.estado = estado;
        }
        public DTOestadoOP()
        {
        }
     

       

    }
}
