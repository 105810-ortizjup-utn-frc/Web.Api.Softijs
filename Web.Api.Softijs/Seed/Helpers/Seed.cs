using Newtonsoft.Json;
using Web.Api.Softijs.DataContext;
using Web.Api.Softijs.Models;
using Web.Api.Softijs.Seed.Entidades_Seed;

namespace Web.Api.Softijs.Seed.Helpers
{
    public class Seed
    {
        public void SeedProvincias(SoftijsDevContext devContext)
        {
            try
            {
                if (!devContext.Provincias.Any())
                {
                    var json = System.IO.File.ReadAllText("Seed/Data/Provincias.json");

                    var provincias = JsonConvert.DeserializeObject<List<ProvinciaSeedDto>>(json);

                    foreach (var provincia in provincias)
                    {
                        devContext.Provincias.Add(new Provincia
                        {
                            Codigo = provincia.Nombre,
                            Descripcion = provincia.Nombrecompleto,
                        });
                    }

                    devContext.SaveChanges("seed-user");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SeedCiudades(SoftijsDevContext devContext)
        {
            try
            {
                if (!devContext.Ciudades.Any())
                {
                    var json = System.IO.File.ReadAllText("Seed/Data/Localidades.json");

                    var localidades = JsonConvert.DeserializeObject<List<LocalidadSeeDto>>(json);

                    foreach (var localidad in localidades.GroupBy(x => new { x.Departamento.Nombre }))
                    {
                        devContext.Ciudades.Add(new Ciudade
                        {
                            CodigoProvincia = localidad.FirstOrDefault().Provincia.Nombre,
                            Codigo = localidad.FirstOrDefault().Departamento.Nombre ?? string.Empty,
                            Descripcion = localidad.FirstOrDefault().Departamento.Nombre ?? string.Empty,
                            Campo = string.Empty,
                        });
                    }

                    foreach (var localidad in localidades)
                    {
                        devContext.Barrios.Add(new Barrio
                        {
                            CodigoCiudad = localidad.Departamento.Nombre,
                            Descripcion = localidad.Nombre
                        });
                    }

                    devContext.SaveChanges("seed-user");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
