using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

namespace Projeto_Cash_Control
{
    public class Conta
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public float saldo { get; set; }
        public int usuario { get; set; }
        public bool ativo { get; set; }


        public bool NovaConta(string descricao, float saldo, int idUsuario)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "INSERT INTO contas (descricao, saldo, id_usuario, ativo) values (@descricao, @saldo, @id_usuario, true)";

                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@saldo", saldo);
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

        public DataTable VisualizarContas(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "SELECT * from contas  WHERE id_usuario = @id AND ativo = true ORDER BY descricao";

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


        public bool EditarConta(string descricao, float saldo, int id)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE contas SET saldo = @saldo, descricao = @descricao WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@saldo", saldo);

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

        public Conta SelecionarPorId(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            Conta c = new Conta();

            try
            {
                cmd.CommandText = "SELECT * FROM contas WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);            

                cmd.Connection = db.OpenConnection();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    c.id = Convert.ToInt32(reader["id"].ToString());
                    c.descricao = reader["descricao"].ToString();
                    c.usuario = Convert.ToInt32(reader["id_usuario"]);
                    c.saldo = float.Parse(reader["saldo"].ToString());                    
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

        public Conta VisualizarPorDescricao(string descricao, int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            Conta c = new Conta();

            try
            {
                cmd.CommandText = "SELECT * FROM contas WHERE descricao = @descricao AND id_usuario = @id";
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    c.id = Convert.ToInt32(reader["id"].ToString());
                    c.descricao = reader["descricao"].ToString();
                    c.usuario = Convert.ToInt32(reader["id_usuario"]);
                    c.saldo = float.Parse(reader["saldo"].ToString());
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

        public bool AtualizarDespesa(Conta c, float valor)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            float novoSaldo = c.saldo - valor;

            try
            {
                cmd.CommandText = "UPDATE contas SET saldo = @saldo WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@saldo", novoSaldo);

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


        public bool AtualizarReceita(Conta c, float valor)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            float novoSaldo = c.saldo + valor;

            try
            {
                cmd.CommandText = "UPDATE contas SET saldo = @saldo WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@saldo", novoSaldo);

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

        public bool ExcluirConta(int id)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE contas SET ativo = false WHERE id = @id";
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