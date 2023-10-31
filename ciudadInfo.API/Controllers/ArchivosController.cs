using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ciudadInfo.API.Controllers
{
    [Route("api/archivos")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        // Propiedad privada donde almacenamos el mapeo entre
        // la extension del archivo y su tipo MIME
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public ArchivosController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentException(
                    nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{archivoId}")]
        public ActionResult GetArchivo(int archivoId)
        {
            // busca el archivo actual, dependiendo del archivoId
            var rutaAlArchivo = "carta-estudiante.pdf";

            // revisamos donde existe el archivo
            if (!System.IO.File.Exists(rutaAlArchivo))
            {
                return NotFound();
            }

            // Si no puede ser determinado el tipo de contentido lo pasamos como octet-stream
            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                rutaAlArchivo, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(rutaAlArchivo);
            return File(bytes, contentType, Path.GetFileName(rutaAlArchivo));
        }
    }
}
