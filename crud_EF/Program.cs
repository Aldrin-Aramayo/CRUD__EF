using crud_EF.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;

using var bd = new CRUD_EFContext();
int opcion;
do
{
    Console.WriteLine("MENU");
    Console.WriteLine("1 - Listar");
    Console.WriteLine("2 - Agregar");
    Console.WriteLine("3 - Actualizar");
    Console.WriteLine("4 - Eliminar");
    Console.WriteLine("0 - Salir  v  ");
    opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            {
                List<Persona> personas = await bd.Personas.ToListAsync();
                foreach (Persona p in personas)
                {
                    Console.WriteLine(p.Nombres + " " + p.Edad.ToWords());
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("Agregar nueva persona");
                Console.WriteLine("Ingrese el nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la edad:");
                int edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la dirección:");
                string direccion = Console.ReadLine();
                Persona personaNueva = new Persona()
                {
                    Nombres = nombre,
                    Edad = edad,
                    Direccion = direccion
                };
                await bd.Personas.AddAsync(personaNueva);
                await bd.SaveChangesAsync();
                break;
            }
        case 3:
            {
                Console.Write("Ingrese el ID de la persona a actualizar: ");
                int idPersona = Convert.ToInt32(Console.ReadLine());

                Persona personaBuscar = await bd.Personas.FirstOrDefaultAsync(persona => persona.Id == idPersona);

                if (personaBuscar is null)
                {
                    Console.WriteLine("La persona no existe");
                }
                else
                {
                    Console.Write("Nombre: ");
                    string nombres = Console.ReadLine();
                    Console.Write("Edad: ");
                    int edad = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Direccion: ");
                    string direccion = Console.ReadLine();

                    personaBuscar.Nombres = nombres;
                    personaBuscar.Edad = edad;
                    personaBuscar.Direccion = direccion;

                    bd.Personas.Update(personaBuscar);
                    await bd.SaveChangesAsync();
                    Console.WriteLine("Actualizacion exitosa");
                }
                break;
            }
    }

}
while (opcion != 0);