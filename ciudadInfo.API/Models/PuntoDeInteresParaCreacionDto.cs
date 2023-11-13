using System.ComponentModel.DataAnnotations;

namespace ciudadInfo.API.Models
{
    public class PuntoDeInteresParaCreacionDto
    {
        [Required(ErrorMessage ="Debe incluir el Nombre")]
        [MaxLength(20)]
        public string Nombre { get; set; }=string.Empty;
        [MaxLength(200)]
        public string? Descripcion { get; set; }
    }
}
