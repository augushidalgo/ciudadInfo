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
            return new JsonResult(
                new List<object>
                {
                    new {id = 1, nombre = "Estelí"},
                    new {id = 2, nombre = "Ocotal"}
                });
        }
    }
}
