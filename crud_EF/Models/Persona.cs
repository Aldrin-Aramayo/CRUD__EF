using System.ComponentModel.DataAnnotations;

namespace crud_EF.Models
{
    internal class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
    }
}
