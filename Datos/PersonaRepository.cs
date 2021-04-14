using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class PersonaRepository
    {
        string ruta = "Persona.txt";

        public void Guardar(Persona persona) 
        {
            FileStream file = new FileStream(ruta,FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine(persona.Escribir());
            escritor.Close();
            file.Close();
        }
        public List<Persona> Consultar() 
        {
            List<Persona> personas = new List<Persona>();
            FileStream file = new FileStream(ruta,FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            string linea = "";
            while ((linea = lector.ReadLine())!=null)
            {
                Persona persona = MapearPersona(linea);
                personas.Add(persona);
            }
            lector.Close();
            file.Close();
            return personas;
        }

        private static Persona MapearPersona(string linea)
        {
            string[] datosPersona = linea.Split(';');
            Persona persona = new Persona();
            persona.Identificacion = datosPersona[0];
            persona.Nombre = datosPersona[1];
            persona.Sexo = datosPersona[2];
            persona.Edad = Int32.Parse(datosPersona[3]);
            persona.Pulsacion = Convert.ToDecimal(datosPersona[4]);
           return persona;
        }

        public void Eliminar(string identificacion) 
        {
            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta,FileMode.Create);
            file.Close();
            foreach (var item in personas)
            {
                if (!item.Identificacion.Equals(identificacion))
                {
                    Guardar(item);
                }
            }
        
        
        }

        public void Modificar(Persona personaNuevo, string identificacion) 
        {
            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in personas)
            {
                if (!item.Identificacion.Equals(identificacion))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNuevo);
                }
            }
        }

        public Persona BuscarPorIdentificacion(string  identificacion)
        {

            foreach (var item in Consultar())
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
