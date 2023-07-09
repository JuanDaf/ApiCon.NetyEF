using System.Text.Json.Serialization;

namespace ApiWebExamenEf.Models
{
    public class Servicio
    {

        public Guid ServicioId { get; set; }
        public string NommbreServicio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DescripcionServicio { get; set; }
        //[JsonIgnore]
        public virtual ICollection<DetallePaS> DetallePaSs { get; set; }

    }
}
