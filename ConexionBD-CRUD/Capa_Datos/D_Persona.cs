using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Persona
    {
        // CREANDO EL METODO OBTENER
        public static List<Persona> ObtenerPersona()
        {
            //DEFINIENDO EL TIPO DE CONEXION Y LOS OBJETOS
            List<Persona> lstPersona = new List<Persona>();
            Conexion cn = new Conexion();
            SqlCommand comando = new SqlCommand();

            // DEFINIR LA CADENA Y LA EJECUCION DEL COMANDO
            try
            {   // DAMOS PERMISOS AL COMANDO DE LA CONEXION
                comando.Connection = cn.cadena;
                // ABRIMOS LOS RECURSOS
                comando.Connection.Open();
                // INDICAMOS EL TIPO DE PROCEDIMIENTO A EJECUTAR
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                // INDICAMOS EL NOMBRE DEL PROCEDIMIENTO
                comando.CommandText = "sp_Obtener";
                // SI EL PROCEDIMIENTO TIENE PARAMETROS AGREGAR LA SIGUIENTE LINEA (EN ESTE CASO NO)
                //comando.Parameters.AddWithValue("", );
                // INDICAMOS AL COMANDO EL TIPO DE EJECUCION
                // USING = USAR RECURSOS O CONSUMIR O LIBERAR
                // DATAREADER ES UN OBJETO DE MODO CONECTADO (ADO.NET)
                using (SqlDataReader lector = comando.ExecuteReader())
                {// UNA VEZ QUE EL COMANDO EJECUTE EL PROCEDIMIENTO, REALIAZAMOS UNA LECTURA
                    while (lector.Read()) // MIENTRAS QUE EXISTAN DATOS -> LEELOS
                    {
                        // INSTANCIAMOS A LA CLASE PERSONA Y REALIZAMOS LA LECTURA
                        Persona objPersona = new Persona();
                        objPersona.codigo = Convert.ToInt32(lector["codigo"]);
                        // SI ENCUENTRA NULOS, TRAEME VACIOS 
                        objPersona.nombres = lector["nombres"] as string ?? "";
                        objPersona.apellidos = lector["apellidos"] as string ?? "";
                        objPersona.edad = Convert.ToInt32(lector["edad"]);
                        objPersona.fecha = Convert.ToDateTime(lector["fecha"]);

                        // UNA VEZ TERMINADO EL RECORRIDO, LO LLENAMOS EN LA LISTA
                        lstPersona.Add(objPersona);

                    }
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            // FINALLY = AL FINALIZAR EL TRY
            finally
            {
                // IMPORTANTE CERRAR LOS RECURSOS 
                cn.cadena.Close();
                comando.Dispose();

            }
            // FINALMENTE RETORNAMOS LOS DATOS ---EL RETORNO PUEDE SER TAMBIEN EN EL TRY, YA QUE SIEMPRE VA A PASAR POR EL FINALLY
            return lstPersona;

        }

        public static Resultado_P RegistrarPersona(Persona request)
        {
            //INSTANCIAR OBJETOS
            Resultado_P response = new Resultado_P();
            Conexion cn = new Conexion();
            SqlCommand cmd = new SqlCommand();

            try
            {
                //Permisos
                cmd.Connection = cn.cadena;
                //Abrir recursos de Conexion
                cmd.Connection.Open();
                //El tipo de Query a ejecutar
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //Nombre de la Query
                cmd.CommandText = "sq_Registrar";
                //Si en caso hay parametros...
                cmd.Parameters.AddWithValue("@nombres", request.nombres ?? "");
                cmd.Parameters.AddWithValue("@apellidos", request.apellidos ?? "");
                cmd.Parameters.AddWithValue("@edad", request.edad);
                cmd.Parameters.AddWithValue("@fecha", request.fecha);


                //SABER USAR EN EL MOMENTO INDICADO

                // EXECUTE READER -> EJECUTA EL COMANDO Y TRAE DATOS PARA UNA LISTA (READ)
                // EXECUTENONQUERY -> EJECUTA EL COMANDO, PERO NO TRAE DATOS. (INSERT, UPDATE, DELETE)
                // EXECUTESCALAR -> EJECUTA EL COMANDO Y MUESTRA LA ULTIMA FILA AFECTADA (WHERE)

                using(SqlDataReader lector = cmd.ExecuteReader()){
                   while(lector.Read()){
                        response.Id = Convert.ToInt32(lector["ID"]);
                        response.Resultado = lector["Mensaje"] as string ?? "";


                    }
                }

                // COLECCION DE PARAMETROS, PARA PODER LEER LOS DATOS EJECUTADOS POR EL COMANDO .VALUE
                //SqlParameterCollection parameters = cmd.Parameters;
                //cmd.ExecuteNonQuery(); // PRIMERO EJECUTA EL COMANDO Y LUEGO LO LEE CON SQLPARAMETERCOLLECITON
                //{
                //    // CONVERSION
                //    //response.Id = Convert.ToInt32(parameters["ID"]);
                //    response.Id = parameters["ID"].Value == DBNull.Value ? 0 : Convert.ToInt32(parameters["ID"].Value);
                //    response.Resultado = parameters["Mensaje"].Value as string ?? "";
                //}


            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                cmd.Dispose();
                cn.cadena.Close();

            }
            return response;

        }

        public static Resultado_P ActualizarPersona(Persona request)
        {
            Resultado_P response = new Resultado_P();
            Conexion cn = new Conexion();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = cn.cadena;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ActualizarPersona";
                cmd.Parameters.AddWithValue("@codigo", request.codigo);
                cmd.Parameters.AddWithValue("@nombres", request.nombres ?? "");
                cmd.Parameters.AddWithValue("@apellidos", request.apellidos ?? "");
                cmd.Parameters.AddWithValue("@edad", request.edad);
                cmd.Parameters.AddWithValue("@fecha", request.fecha);

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        response.Id = Convert.ToInt32(lector["ID"]);
                        response.Resultado = lector["Mensaje"] as string ?? "";


                    }
                }
                //SqlParameterCollection parameters = cmd.Parameters;
                //cmd.ExecuteNonQuery();
                //{
                //    response.Id = parameters["ID"].Value == DBNull.Value ? 0 : Convert.ToInt32(parameters["ID"].Value);
                //    response.Resultado = parameters["Mensaje"].Value as string ?? "";
                //}
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                cmd.Dispose();
                cn.cadena.Close();
            }
            return response;
        }

        public static Persona ListarxId(int id)
        {
            Persona objPersona = new Persona();
            Conexion cn = new Conexion();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = cn.cadena;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarxId";
                cmd.Parameters.AddWithValue("@codigo", id);

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    lector.Read();

                    objPersona.codigo = Convert.ToInt32(lector["codigo"]);
                    objPersona.nombres = lector["nombres"].ToString();
                    objPersona.apellidos = lector["apellidos"].ToString();
                    objPersona.edad = Convert.ToInt32(lector["edad"]);
                    objPersona.fecha = Convert.ToDateTime(lector["fecha"]);


                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                cmd.Dispose();
                cn.cadena.Close();
            }
            return objPersona;
        }
        public static Persona EliminarPersona(int id)
        {
            Persona objPersona = new Persona();
            Conexion cn = new Conexion();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = cn.cadena;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarPersona";
                cmd.Parameters.AddWithValue("@codigo", id);

                using (SqlDataReader lector = cmd.ExecuteReader()) 
                {
                    lector.Read();
                    objPersona.codigo = Convert.ToInt32(lector["codigo"]);
                    objPersona.nombres = lector["nombres"].ToString();
                    objPersona.apellidos = lector["apellidos"].ToString();
                    objPersona.edad = Convert.ToInt32(lector["edad"]);
                    objPersona.fecha = Convert.ToDateTime(lector["fecha"]);
                }

                    cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                cmd.Dispose();
                cn.cadena.Close();
            }
            return objPersona;

        }
    }
}
