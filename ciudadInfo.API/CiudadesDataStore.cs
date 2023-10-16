using ciudadInfo.API.Models;

namespace ciudadInfo.API
{
    public class CiudadesDataStore
    {
        public List<CiudadDto> Ciudades { get; set; }
        public static CiudadesDataStore Actual { get; } = new CiudadesDataStore();

        public CiudadesDataStore()
        {
            Ciudades = new List<CiudadDto>()
            {
                new CiudadDto()
            {
                Id = 1,
                Nombre = "Estelí",
                Descripcion = "Departamento principal del norte de Nicaragua"
            },
            new CiudadDto()
            {
                Id = 2,
                Nombre = "Somoto",
                Descripcion = "Ciudad con gran tradición cultural del norte de Nicaragua"
            },
            new CiudadDto()
            {
                Id = 3,
                Nombre = "Jinotega",
                Descripcion = "Ciudad de montañas del centro de Nicaragua"
            }
        };
            
        }
    }
}
