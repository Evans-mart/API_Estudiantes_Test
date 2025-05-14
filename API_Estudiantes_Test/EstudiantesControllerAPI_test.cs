using Microsoft.AspNetCore.Mvc;
using ControlEscolarCore.Controller;

namespace API_Estudiantes_Test
{
    [ApiController]
    [Route("api/[controller]")] 
    public class EstudiantesControllerAPI_test : ControllerBase
    {
        private readonly EstudiantesController _estudiantesController;
        private readonly ILogger<EstudiantesControllerAPI_test> _logger;
        //Logger para el controlador, este log no se guarda en ningun archivo, se muestra en  consola

        /// <summary>
        /// Constructor para el controlador de estudiantes
        /// </summary>
        /// <param name="estudiantesController"></param>
        /// <param name="logger"></param>
        public EstudiantesControllerAPI_test(EstudiantesController estudiantesController, ILogger<EstudiantesControllerAPI_test> logger)
        {
            _estudiantesController = estudiantesController;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los estudiantes con filtros opcionales
        /// </summary>
        /// <param name="soloActivos">Filtrar solo estudiantes activos</param>
        /// <param name="tipoFecha">1=Fecha nacimiento, 2=Fecha alta, 3=Fecha baja</param>
        /// <param name="fechaInicio">Fecha inicial del rango</param>
        /// <param name="fechaFin">Fecha final del rango</param>
        /// <returns>Lista de estudiantes</returns>
        [HttpGet("list_estudiantes")]  // Ahora tiene una ruta específica
        public IActionResult GetEstudiantes(
             [FromQuery] bool soloActivos = true, // Por defecto, solo estudiantes activos, el from query indica que se espera un valor de la URL
             [FromQuery] int tipoFecha = 0,
             [FromQuery] DateTime? fechaInicio = null,
             [FromQuery] DateTime? fechaFin = null)
        {
            try
            {
                var estudiantes = _estudiantesController.ObtenerEstudiantes(
                    soloActivos,
                    tipoFecha,
                    fechaInicio,
                    fechaFin);

                return Ok(estudiantes); // Devuelve un resultado exitoso con la lista de estudiantes,
                                        // el ok indica que la respuesta es exitosa es un 200
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estudiantes");
                return StatusCode(500, "Error interno del servidor" + ex.Message); // Devuelve un error 500 con el mensaje de error,
                                                                                   // el 500 es un error interno del servidor
            }
        }

    }
}
