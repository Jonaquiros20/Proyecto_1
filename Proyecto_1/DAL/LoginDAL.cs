using ENTITES;
using Microsoft.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class LoginDAL
    {
        public Reply IniciarSesion(Credenciales Credencial, String Conexion)
        {
            Reply reply = new Reply();

            try
            {
                using (SqlConnection connnection = new SqlConnection(Conexion))
                {
                    connnection.Open();


                    using (SqlCommand command = new SqlCommand("spIniciarSesion", connnection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@pNombre", SqlDbType.NVarChar, 20) { Value = Credencial.Usuario});
                        command.Parameters.Add(new SqlParameter("@pContrasena", SqlDbType.NVarChar, 20) { Value = Credencial.Contrasena });
                        //command.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.NVarChar, 20) { Value = 0 });
                        //command.Parameters.Add(new SqlParameter("@Exito", SqlDbType.Bit) { Value = false });

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Credenciales credencial = new Credenciales
                                {
                                    Usuario = (string)reader["Usuario"],
                                    Exito = (bool)reader["Exito"]   
                                };
                                if (credencial.Exito)
                                {
                                    reply.CredencialUsuario = Credencial;
                                    reply.Message = "Inicio de sesion exitoso";
                                    reply.ok = true;
                                }
                                else
                                {
                                    reply.ok = false;
                                    reply.Message = "El usuario o la contraseña no son correctos";
                                    reply.CredencialUsuario = null;
                                }
                            }
                            
                            
                        
                        }

                    }
                    

                }
            }
            catch (Exception ex)
            {
                reply.ok = false;
                reply.Message = string.Format("Ha ocurrido un error en la capa DAL, en la clase  loginDAL", ex.Message);
            }

            return reply;
        }
    }
}
