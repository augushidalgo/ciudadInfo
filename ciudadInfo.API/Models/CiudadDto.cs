namespace ciudadInfo.API.Models
{
    public class CiudadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int NumeroDePuntosDeInteres
        {
            get
            {
                return PuntosDeInteres.Count;
            }
        }
        public ICollection<PuntoDeInteresDto> PuntosDeInteres { get; set; }
        = new List<PuntoDeInteresDto>();
    }
}
