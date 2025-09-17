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
                    Console.WriteLine(p.Nombres+" "+ p.Edad.ToWords());
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
    }

}
while (opcion != 0);