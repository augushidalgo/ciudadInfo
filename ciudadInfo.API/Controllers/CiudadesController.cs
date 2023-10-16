using Microsoft.AspNetCore.Mvc;

namespace ciudadInfo.API.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController:ControllerBase
    {
        [HttpGet]
        public JsonResult GetCiudades()
        {
            return new JsonResult(CiudadesDataStore.Actual.Ciudades);
        }
        [HttpGet("{id}")]
        public JsonResult GetCiudad(int id)
        {
            return new JsonResult(
                CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c => c.Id == id));
        }
    }
}
