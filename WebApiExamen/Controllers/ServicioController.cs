using Microsoft.AspNetCore.Mvc;
using WebApiExamen.Services;
using ApiWebExamenEf.Models;
namespace WebApiExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicioController : ControllerBase
    {
       IServicioService servicioService;

        public ServicioController(IServicioService sservicioService) 
        {
            servicioService = sservicioService;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            return Ok(servicioService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBodyAttribute] Servicio servico)
        {
            return Ok(servicioService.Post(servico));
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBodyAttribute] Servicio servico, Guid id)
        {
            return Ok(servicioService.Put(servico,id));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(servicioService.Delete(id));
        }
    }
}
