using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Cash_Control
{
    public class Categoria
    {

        public int id { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }
        public int usuario { get; set; }
        public bool ativo { get; set; }


        public bool NovaCategoria(string descricao, string tipo, int idUsuario)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "INSERT INTO categorias (descricao, tipo, id_usuario, ativo) values (@descricao, @tipo, @id_usuario, true)";

                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                cmd.Connection = db.OpenConnection();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {

                db.CloseConnection(cmd.Connection);
            }
        }

        public DataTable VisualizarCategoriasDespesas(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select * from categorias where id_usuario = @id AND tipo = 'Despesa' AND ativo = true";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();
                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                db.CloseConnection(cmd.Connection);
            }
        }

        public DataTable VisualizarCategoriasReceitas(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select * from categorias where id_usuario = @id AND tipo = 'Receita' AND ativo = true";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();
                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                db.CloseConnection(cmd.Connection);
            }
        }

        public bool EditarCategoria(string descricao, string tipo, int id)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE categorias SET tipo = @tipo, descricao = @descricao WHERE id = @id";

                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {

                db.CloseConnection(cmd.Connection);
            }
        }

        public Categoria SelecionarPorId(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            Categoria c = new Categoria();

            try
            {
                cmd.CommandText = "SELECT * FROM categorias WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();
                NpgsqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    c.id = Convert.ToInt32(reader["id"].ToString());
                    c.descricao = reader["descricao"].ToString();
                    c.tipo = reader["tipo"].ToString();
                    c.usuario = Convert.ToInt32(reader["id_usuario"]);
                }
            }
            catch (Exception ex)
            {
                c.id = 0;
                c.descricao = null;
                c.usuario = 0;
                
            }
            finally
            {
                db.CloseConnection(cmd.Connection);
            }
            return c;
        }


        public bool ExcluirCategoria(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "update categorias set ativo = false where id = @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {

                db.CloseConnection(cmd.Connection);
            }
        }
    }
}