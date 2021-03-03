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
                personaRepository.Guardar(persona);
                return "Datos Guardados Satisfactoriamente";
            }
            catch (Exception exception)
            {

                return "Acurrieron los siguientes errorer:" + exception.Message;
            }
        }
    }
}
