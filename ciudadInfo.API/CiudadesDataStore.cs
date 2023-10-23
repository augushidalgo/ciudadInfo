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
                Descripcion = "Departamento principal del norte de Nicaragua",
                PuntosDeInteres = new List<PuntoDeInteresDto>()
                {
                    new PuntoDeInteresDto()
                    {
                        Id = 1,
                        Nombre = "Parque central",
                        Descripcion = "Ubicado en el centro del ciudad"
                    },
                    new PuntoDeInteresDto()
                    {
                        Id = 2,
                        Nombre = "Estadio independencia",
                        Descripcion = "Casa del equipo de fútbol Real Estelí"
                    }
                }
            },
            new CiudadDto()
            {
                Id = 2,
                Nombre = "Somoto",
                Descripcion = "Ciudad con gran tradición cultural del norte de Nicaragua",
                PuntosDeInteres = new List<PuntoDeInteresDto>()
                {
                    new PuntoDeInteresDto()
                    {
                        Id = 3,
                        Nombre = "Cañon de Somoto",
                        Descripcion = "Sitio para actividades de turismo"
                    },
                    new PuntoDeInteresDto()
                    {
                        Id = 4,
                        Nombre = "Sitio arqueológico Piedras pintadas",
                        Descripcion = "Patrimonio cultural de mayor importancia en el municipio"
                    }
                }
            },
            new CiudadDto()
            {
                Id = 3,
                Nombre = "Jinotega",
                Descripcion = "Ciudad de montañas del centro de Nicaragua",
                PuntosDeInteres = new List<PuntoDeInteresDto>()
                {
                    new PuntoDeInteresDto()
                    {
                        Id = 5,
                        Nombre = "Lago Apanás",
                        Descripcion = "El primer lago artificial de Nicaragua"
                    },
                    new PuntoDeInteresDto()
                    {
                        Id = 6,
                        Nombre = "Bosawás",
                        Descripcion = "Reserva de biósfera mas grande de la región"
                    }
                }
            }
        };
            
        }
    }
}
