using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string identificacion, nombre, sexo;
            int edad;
           

            Console.WriteLine("Digite la Identificacion:");
            identificacion=Console.ReadLine();
            Console.WriteLine("Digite El Nommbre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite el Sexo (F/M):");
            sexo = Console.ReadLine();
            Console.WriteLine("Digite la Edad:");
            edad =int.Parse( Console.ReadLine());

            Persona persona = new Persona(identificacion,nombre,sexo,edad);
            persona.CalcularPulsacion();
            Console.WriteLine($"Su pulsacion es {persona.Pulsacion}");
            Console.ReadKey();

        }
    }
}
