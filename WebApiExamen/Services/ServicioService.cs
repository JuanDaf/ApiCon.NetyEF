using ApiWebExamenEf;
using ApiWebExamenEf.Models;

namespace WebApiExamen.Services
{
    public class ServicioService : IServicioService
    {
        Contexto contexto;

        public ServicioService(Contexto dBcontexto) 
        { 
            contexto = dBcontexto;
        }

        public IEnumerable<Servicio> Get()
        {
            return contexto.servicios;
        }

        public async Task Post(Servicio servicio)
        {
            await contexto.AddAsync(servicio);
            await contexto.SaveChangesAsync();
        }

        public async Task Put(Servicio servicio, Guid id)
        {
            var servicoActual = contexto.servicios.Find(id);
            if (servicoActual != null)
            {
                servicoActual.NommbreServicio = servicio.NommbreServicio;
                servicoActual.DescripcionServicio = servicio.DescripcionServicio;

                await contexto.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var servicoActual = contexto.servicios.Find(id);
            if(servicoActual != null)
            {
                contexto.Remove(servicoActual);
                await contexto.SaveChangesAsync();
            }
        }

    }

    public interface IServicioService
    {
        IEnumerable<Servicio> Get();
        Task Post(Servicio servicio);
        Task Put(Servicio servicio, Guid id);
        Task Delete(Guid id);

    }
}
