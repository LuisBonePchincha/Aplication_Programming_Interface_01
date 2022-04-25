using System.ComponentModel.DataAnnotations;

namespace Aplication_Programming_Interface_01.Entities
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Clave { get; set; }
        public int estado { get; set; }
        public int PersonaId { get; set; }

        public Personas? Persona { get; set; }
    }
}
