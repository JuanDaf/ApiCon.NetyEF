using ApiWebExamenEf.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiExamen.Services;
using WebApiExamen;
using ApiWebExamenEf;

namespace WebApiExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PersonaController : ControllerBase
    {
        IPersonaService personaService;

        public PersonaController(IPersonaService ppersonaService)
        {
            personaService = ppersonaService;
        }
        [HttpGet]
        //[Route("GetPerosna")]
        public ActionResult Get() 
        {
           // personaService.Init();
            return Ok(personaService.Get());
        }

        [HttpPost]
        //[Route("PostPerosna")]
        public IActionResult Post([FromBody] Persona persona)
        {
            personaService.Post(persona);
            return Ok();
        }

        [HttpPut("{id}")]
       //[Route("PutPerosna")]
        public IActionResult Put([FromBody] Persona persona, string id)
        {
            personaService.Put(persona, id);
            return Ok();
        }


        [HttpDelete("{id}")]
        //[Route("DeletePerosna")]
        public IActionResult Delete(string id)
        {
            personaService.Delete(id);
            return Ok();
        }

    }
}
