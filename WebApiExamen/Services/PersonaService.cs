using ApiWebExamenEf;
using ApiWebExamenEf.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiExamen;
namespace WebApiExamen.Services
{
    public class PersonaService : IPersonaService
    {
        Contexto contexto;

        public PersonaService(Contexto dBcontexto)
        {
            contexto = dBcontexto;
            
        }

        public IEnumerable<Persona> Get()
        {
            return contexto.personas;
        }
        public async Task Init()
        {
            await contexto.Database.EnsureCreatedAsync();
        }

        public async Task Post(Persona persona)
        {
            await contexto.AddAsync(persona);
            await contexto.SaveChangesAsync();
        }

        public async Task Put(Persona persona, string id)
        {
            var personaActual = contexto.personas.Find(id);
            if (personaActual != null)
            {
                personaActual.Nombres = persona.Nombres;
                personaActual.Apellidos = persona.Apellidos;
                personaActual.Email = persona.Email;
                personaActual.Direccion = persona.Direccion;
                personaActual.NivelEstrato = persona.NivelEstrato;

                await contexto.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var personaActual = contexto.personas.Find(id);
            if (personaActual != null)
            {
                contexto.Remove(personaActual);
                await contexto.SaveChangesAsync();
            }
        }
    }

    public interface IPersonaService
    {
        IEnumerable<Persona> Get();
        Task Post(Persona persona);
        Task Put(Persona persona, string id);
        Task Delete(string id);
        Task Init();
    }
}
