using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;
namespace Logica
{
    public class PersonaService
    {
        PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guardar(Persona persona) 
        {

            try
            {
                if (personaRepository.BuscarPorIdentificacion(persona.Identificacion)==null)
                {
                    personaRepository.Guardar(persona);
                    return "Datos Guardados Satisfactoriamente";
                }
                return $"La Persona con la Identificacion {persona.Identificacion} ya se encuentra registrada";
              
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }



        public ConsultaResponse Consultar() 
        {
            try
            {
               return new ConsultaResponse(personaRepository.Consultar());
            }
            catch (Exception exception)
            {
                return new ConsultaResponse("Se presentó el siguiente error:" + exception.Message);
            }
        }


        public string Eliminar(string identificacion) 
        {

            try
            {
                if (personaRepository.BuscarPorIdentificacion(identificacion)!=null)
                {
                    personaRepository.Eliminar(identificacion);
                    return $"Se eliminó a la Persona con idnetificacion {identificacion}";
                }
                return $"No se encontró a la persona con Identificacion {identificacion}";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }


        public string Modificar(Persona personaNueva,string identificacion)
        {

            try
            {
                if (personaRepository.BuscarPorIdentificacion(identificacion) != null)
                {
                    personaRepository.Modificar(personaNueva,identificacion);
                    return $"Se Modificó a la Persona con idnetificacion {identificacion}";
                }
                return $"No se encontró a la persona con Identificacion {identificacion}";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }


        public BusquedaReponse Buscar(string identificacion)
        {
            try
            {
                return new BusquedaReponse(personaRepository.BuscarPorIdentificacion(identificacion));
            }
            catch (Exception exception)
            {
                return new BusquedaReponse("Se presentó el siguiente error:" + exception.Message);
            }
        }


    }

    public class ConsultaResponse 
    {
        public List<Persona> Personas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaResponse(List<Persona> personas)
        {
            Personas = personas;
            Error = false;
        }

        public ConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
 
    }


    public class BusquedaReponse 
    {
        public Persona Persona{ get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponse(Persona persona)
        {
            Persona = persona;
            Error = false;
        }

        public BusquedaReponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }

}


