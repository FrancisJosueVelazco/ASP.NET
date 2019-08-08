using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Persona
    {
        // LLAMAMOS AL METODO
        public static List<Persona> ObtenerPersona()
        {
            return Capa_Datos.D_Persona.ObtenerPersona();
        }
       
        

        public static Resultado_P RegistrarPersona(Persona request)
        {
            return Capa_Datos.D_Persona.RegistrarPersona(request);
        }

        public static Resultado_P ActualizarPersona(Persona request)
        {
            return Capa_Datos.D_Persona.ActualizarPersona(request);
        }

        public static Persona listarxId(int id)
        {
            return Capa_Datos.D_Persona.ListarxId(id);
        }
        public static Persona EliminiarPersona(int id)
        {
            return Capa_Datos.D_Persona.EliminarPersona(id);
        }


        // LISTO AHORA A LA CAPA PRESENTACION
    }
}
