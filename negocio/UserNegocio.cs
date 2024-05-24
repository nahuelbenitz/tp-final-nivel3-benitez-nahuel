using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UserNegocio
    {


        public int insertarNuevo(User nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USERS (nombre, apellido, email, pass, admin) output inserted.Id VALUES(@nombre, @apellido, @email, @pass, 0)");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);

                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public bool Login(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT id, email, pass, urlImagenPerfil, nombre, apellido, admin FROM USERS WHERE email = @email and pass = @pass");

                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagen = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];


                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizar(User user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USERS SET urlImagenPerfil = @imgPerfil, nombre = @nombre, apellido = @apellido WHERE id = @id");
                datos.setearParametro("@imgPerfil", (object)user.UrlImagen ?? DBNull.Value);
                datos.setearParametro("@nombre", string.IsNullOrEmpty(user.Nombre) ? (object)DBNull.Value : user.Nombre);
                datos.setearParametro("@apellido", string.IsNullOrEmpty(user.Apellido) ? (object)DBNull.Value : user.Apellido);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }




}
