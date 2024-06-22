using DAL;
using ENTITES;

namespace BLL
{
    public class loginBLL
    {
        private readonly LoginDAL _loginDAL;


        public loginBLL(LoginDAL loginDAL)
        {
            _loginDAL = loginDAL;
        }

        public Reply IniciarSesion(Credenciales Credencial, String Conexion)
        {
            Reply reply = new Reply();
            try
            {
                var respuesta = _loginDAL.IniciarSesion(Credencial, Conexion);


                if (respuesta.ok) 
                {
                    reply = respuesta;  
                }
                else 
                { 
                    reply.ok = false;
                    reply.Message = respuesta.Message;
                }   

            }
            catch (Exception ex)
            {
                reply.ok = false;
                reply.Message = string.Format("Ha ocurrido un error en la capa BLL, en la capa loginBLL", ex.Message);
            }
            return reply;
        }



    }
}
