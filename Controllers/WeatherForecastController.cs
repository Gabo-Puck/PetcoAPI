using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetcoAPI.Models;

namespace PetcoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            using (petcodbv2Context bd = new())
            {
                Publicacion publi = new Publicacion()
                {
                    Titulo = "I'm good at programming",
                    Descripcion = "I don't think so",
                    Activo = true,
                    ReportesPeso = 10
                };
                Comentario com = new Comentario()
                {
                    Fecha_Envio = DateTime.Now,
                    Texto = ":c",
                    ComentarioPadre = 1,
                    IdPublicacion = 1
                };
                bd.Publicacions.Add(publi);
                bd.SaveChanges();
                bd.Comentarios.Add(com);
                bd.SaveChanges();
            }
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

        }
    }
}
