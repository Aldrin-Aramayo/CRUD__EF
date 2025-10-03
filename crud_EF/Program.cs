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
    Console.WriteLine("0 - Salir");
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
                string nombre = Console.ReadLine()!;
                Console.WriteLine("Ingrese la edad:");
                int edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la dirección:");
                string direccion = Console.ReadLine()!;
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

                Persona? personaBuscar = await bd.Personas.FirstOrDefaultAsync(persona => persona.Id == idPersona);

                if (personaBuscar is null)
                {
                    Console.WriteLine("La persona no existe");
                }
                else
                {
                    Console.Write("Nombre: ");
                    string? nombres = Console.ReadLine();
                    Console.Write("Edad: ");
                    int? edad = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Direccion: ");
                    string? direccion = Console.ReadLine();

                    if (string.IsNullOrEmpty(nombres!.Trim()) == false)
                    {
                        personaBuscar.Nombres = nombres;
                    }

                    if (edad.HasValue == true)
                    {
                        personaBuscar.Edad = edad.Value;
                    }

                    if (string.IsNullOrEmpty(direccion) == false)
                    {
                        personaBuscar.Direccion = direccion;
                    }


                    bd.Personas.Update(personaBuscar);
                    await bd.SaveChangesAsync();
                    Console.WriteLine("Actualizacion exitosa");
                }
                break;
            }

        case 4:
            {
                Console.Write("Ingrese el ID de la persona a eliminar: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Persona? personaBuscar = await bd.Personas.FirstOrDefaultAsync(persona => persona.Id == id);

                if (personaBuscar is null)
                {
                    Console.WriteLine("la persona no existe");
                }
                else
                {
                    bd.Personas.Remove(personaBuscar);
                    await bd.SaveChangesAsync();
                }

                Console.WriteLine("Se elemino con exito");

                break;
            }
    }

}
while (opcion != 0);



//using crud_EF.Models;

//Persona persona1 = new Persona()
//{
//    Id = 10,
//    Nombres = "Carlos",
//    Edad = 34,
//    Direccion = "calle 1"
//};

//Persona persona2 = new Persona()
//{
//    Id = 10,
//    Nombres = "Carlos",
//    Edad = 34,
//    Direccion = "calle 1"
//};


//if (persona1.Equals(persona2))
//{
//    Console.WriteLine("parecido");
//}
//else
//{
//    Console.WriteLine("no parecido");
//}

//HashSet<Persona> personas = new HashSet<Persona>();
//personas.Add(persona1);
//personas.Add(persona2);

//foreach (Persona persona in personas)
//{
//    Console.WriteLine(persona);
//}