using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class FavoritoNegocio
    {
        public List<Favorito> listarFavoritos()
        {
            List<Favorito> lista = new List<Favorito>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, IDUSER, IDARTICULO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Favorito aux = new Favorito();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.IdUser = (int)datos.Lector["IDUSER"];
                    aux.IdArticulo = (int)datos.Lector["IDARTICULO"];

                    lista.Add(aux);
                }

                return lista;
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

        public bool verificarExistencia(Favorito fav, List<Favorito> listaFav)
        {
            foreach (var favorito in listaFav)
            {
                if (fav.IdUser == favorito.IdUser && fav.IdArticulo == favorito.IdArticulo)
                    return true;
            }
                return false;
        }


        public void agregarFavorito(Favorito fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
			{
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (@idUser, @idArticulo)");

                datos.setearParametro("@idUser", fav.IdUser);
                datos.setearParametro("@idArticulo", fav.IdArticulo);

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

        public void eliminarFavorito(Favorito fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE Id = @id");

                datos.setearParametro("@id", fav.Id);

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
