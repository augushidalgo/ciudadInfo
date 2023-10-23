using ciudadInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ciudadInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController:ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CiudadDto>> GetCiudades()
        {
            return Ok(CiudadesDataStore.Actual.Ciudades);
            
            //return new JsonResult(CiudadesDataStore.Actual.Ciudades);

        }
        [HttpGet("{id}")]
        public ActionResult<CiudadDto> GetCiudad(int id)
        {
            // encontrar la ciudad
            var ciudadARetornar = CiudadesDataStore.Actual.Ciudades
                .FirstOrDefault(c => c.Id == id);

            if(ciudadARetornar == null)
            {
                return NotFound();
            }
            
            return Ok(ciudadARetornar);


            //return new JsonResult(
            //    CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c => c.Id == id));
        }
    }
}
