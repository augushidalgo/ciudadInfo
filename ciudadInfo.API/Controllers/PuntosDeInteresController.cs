using ciudadInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ciudadInfo.API.Controllers
{
    [Route("api/ciudades/{ciudadId}/puntosdeinteres")]
    [ApiController]
    public class PuntosDeInteresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PuntoDeInteresDto>> GetPuntosDeInteres(int ciudadId)
        {
            var ciudad = CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c  => c.Id == ciudadId);
            if (ciudad == null)
            {
                return NotFound();
            }
            return Ok(ciudad.PuntosDeInteres);
        }

        [HttpGet("{puntodeinteresid}")]
        public ActionResult<PuntoDeInteresDto> GetPuntoDeInteres(
            int ciudadId, int puntoDeInteresID)
        {
            var ciudad = CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c => c.Id == ciudadId);
            if (ciudad == null)
            {
                return NotFound();
            }

            // encontrar el punto de interes
            var puntoDeInteres = ciudad.PuntosDeInteres.FirstOrDefault(c => c.Id == puntoDeInteresID);
            if (puntoDeInteres == null)
            {
                return NotFound();
            }
            return Ok(puntoDeInteres);
        }
    }
}
