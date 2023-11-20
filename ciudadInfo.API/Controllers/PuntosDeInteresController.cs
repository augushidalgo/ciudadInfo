using ciudadInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{puntodeinteresid}", Name = "GetPuntoDeInteres")]
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
        [HttpPost]
        public ActionResult<PuntoDeInteresDto> CrearPuntoDeInteres(
            int ciudadId,
            PuntoDeInteresParaCreacionDto puntoDeInteres)
        {
            var ciudad = CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c => c.Id == ciudadId);
            if (ciudad == null)
            {
                return NotFound();
            }

            // para improvisar por ahora
            var maxPuntoDeInteresId = CiudadesDataStore.Actual.Ciudades.SelectMany(
                c => c.PuntosDeInteres).Max(p => p.Id);

            var finalPuntoDeInteres = new PuntoDeInteresDto()
            {
                Id = ++maxPuntoDeInteresId,
                Nombre = puntoDeInteres.Nombre,
                Descripcion = puntoDeInteres.Descripcion
            };

            ciudad.PuntosDeInteres.Add(finalPuntoDeInteres);
            
            return CreatedAtRoute("GetPuntoDeInteres",
                new
                {
                    ciudadId = ciudadId,
                    puntoDeInteresId = finalPuntoDeInteres.Id
                },
                finalPuntoDeInteres);
        }

        [HttpPut("{puntodeinteresid}")]
        public ActionResult ActualizarPuntoDeInteres(int ciudadId, 
            int puntoDeInteresId
            , PuntoDeInteresParaActualizarDto puntoDeInteres)
        {
            var ciudad = CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c => c.Id == ciudadId);
            if (ciudad == null)
            {
                return NotFound();
            }

            // encontrar el punto de interes
            var puntoDeInteresDelAlmacen = ciudad.PuntosDeInteres.FirstOrDefault(c => c.Id == puntoDeInteresId);
            if (puntoDeInteresDelAlmacen == null)
            {
                return NotFound();
            }

            puntoDeInteresDelAlmacen.Nombre = puntoDeInteres.Nombre;
            puntoDeInteresDelAlmacen.Descripcion = puntoDeInteres.Descripcion;

            return NoContent();
        }
        [HttpPatch("{puntodeinteresid}")]
        public ActionResult ActualizacionParcialPuntoDeInteres(
            int ciudadId, int puntoDeInteresId,
            JsonPatchDocument<PuntoDeInteresParaActualizarDto> patchDocument)
        {
            var ciudad = CiudadesDataStore.Actual.Ciudades.FirstOrDefault(c => c.Id == ciudadId);
            if (ciudad == null)
            {
                return NotFound();
            }

            // encontrar el punto de interes
            var puntoDeInteresDelAlmacen = ciudad.PuntosDeInteres.FirstOrDefault(c => c.Id == puntoDeInteresId);
            if (puntoDeInteresDelAlmacen == null)
            {
                return NotFound();
            }

            var puntoDeInteresAParchear =
                new PuntoDeInteresParaActualizarDto()
                {
                    Nombre = puntoDeInteresDelAlmacen.Nombre,
                    Descripcion = puntoDeInteresDelAlmacen.Descripcion
                };
            patchDocument.ApplyTo(puntoDeInteresAParchear, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!TryValidateModel(puntoDeInteresAParchear))
            {
                return BadRequest(ModelState);
            }

            puntoDeInteresDelAlmacen.Nombre = puntoDeInteresAParchear.Nombre;
            puntoDeInteresDelAlmacen.Descripcion = puntoDeInteresAParchear.Descripcion;

            return NoContent();
        }
    }
}
