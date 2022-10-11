namespace Web.Api.Softijs.Models.Interfaces;

public interface IAuditable
{
    public string CreadoPor { get; set; }
    public DateTime FechaCreacion { get; set;}
    public string ModificadoPor { get; set;}
    public DateTime FechaModificacion { get; set; }

}
