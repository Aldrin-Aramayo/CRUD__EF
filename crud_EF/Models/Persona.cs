using System.ComponentModel.DataAnnotations;

namespace crud_EF.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Persona persona &&
                   Id == persona.Id &&
                   Nombres == persona.Nombres &&
                   Edad == persona.Edad &&
                   Direccion == persona.Direccion;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nombres, Edad, Direccion);
        }

        public override string ToString()
        {
            string texto = $"nombre: {this.Nombres} edad: {this.Edad} dire: {this.Direccion}";
            return texto;
        }
    }
}
