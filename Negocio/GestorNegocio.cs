using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class GestorNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<Registro> registros;
        List<Categoria> categorias;
        string consulta = @"
         SELECT G.ID AS IdGasto, Nombre, Monto, FechaRegistro, G.IdCategoria AS IdCateg, C.Descripcion 
         FROM Gastos G, Categoria C
         WHERE G.IdCategoria = C.Id";

        public List<Registro> ListarRegistros()
        {
            registros = new List<Registro>();

            try
            {
                datos.SetearConsulta(consulta);
                datos.EjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Registro reg = new Registro();
                    reg.ID = (int)datos.Lector["IdGasto"];
                    reg.NombreRegistro = (string)datos.Lector["Nombre"];
                    reg.Monto = (decimal)datos.Lector["Monto"];
                    reg.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];

                    reg.Categoria = new Categoria();
                    reg.Categoria.Id = (int)datos.Lector["IdCateg"];
                    reg.Categoria.Descripcion = (string)datos.Lector["Descripcion"];

                    registros.Add(reg);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los registros: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Categoria> ListarCategorias()
        {
            categorias = new List<Categoria>();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM Categoria");
                datos.EjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Categoria categ = new Categoria();
                    categ.Id = (int)datos.Lector["Id"];
                    categ.Descripcion = (string)datos.Lector["Descripcion"];

                    categorias.Add(categ);
                }

                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las categorías: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarRegistro(Registro nuevoRegistro)
        {
            try
            {
                datos.SetearConsulta("INSERT INTO Gastos (Nombre, Monto, IdCategoria, FechaRegistro) VALUES (@nombre, @monto, @idCategoria, @fechaRegistro)");

                datos.SetearParametro("@nombre", nuevoRegistro.NombreRegistro);
                datos.SetearParametro("@monto", nuevoRegistro.Monto);
                datos.SetearParametro("@idCategoria", nuevoRegistro.Categoria.Id);
                datos.SetearParametro("@fechaRegistro", nuevoRegistro.FechaRegistro);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar registro: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
