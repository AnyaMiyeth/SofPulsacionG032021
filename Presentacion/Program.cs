using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string identificacion, nombre, sexo;
            int edad;

            PersonaService personaService = new PersonaService();
            Console.WriteLine("Digite la Identificacion:");
            identificacion=Console.ReadLine();
            Console.WriteLine("Digite El Nommbre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite el Sexo (F/M):");
            sexo = Console.ReadLine();
            Console.WriteLine("Digite la Edad:");
            edad =int.Parse( Console.ReadLine());

            Persona persona = new Persona()
            {
                Identificacion = identificacion,
                Nombre=nombre,
                Sexo=sexo,
                Edad=edad
            };
            persona.CalcularPulsacion();
            Console.WriteLine($"Su pulsacion es {persona.Pulsacion}");
            Console.WriteLine($"/// Guardando desde Servicio///");
            Console.WriteLine(personaService.Guardar(persona));

            Console.WriteLine($"/// Consultando desde Servicio///");
            ConsultaResponse response = personaService.Consultar();
            if (!response.Error)
            {
                foreach (var item in response.Personas)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(response.Mensaje);
            }

            
           

            Console.ReadKey();

            
            
            
        }
    }
}
