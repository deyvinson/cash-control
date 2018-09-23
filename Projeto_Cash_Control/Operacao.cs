using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Cash_Control
{
    public class Operacao
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime dataHora { get; set; }
        public string categoria { get; set; }
        public string conta { get; set; }
        public string tipo { get; set; }
        public float valor { get; set; }
        public int usuario { get; set; }
        public bool ativo { get; set; }

        public bool NovaOperacao(Operacao o)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "INSERT INTO operacoes (descricao, dataHora, categoria, conta, tipo, valor, id_usuario, ativo) values (@descricao, @dataHora, @categoria, @conta, @tipo, @valor, @usuario, true)";

                cmd.Parameters.AddWithValue("@descricao", o.descricao);
                cmd.Parameters.AddWithValue("@dataHora", o.dataHora);
                cmd.Parameters.AddWithValue("@categoria", o.categoria);
                cmd.Parameters.AddWithValue("@conta", o.conta);
                cmd.Parameters.AddWithValue("@tipo", o.tipo);
                cmd.Parameters.AddWithValue("@valor", o.valor);
                cmd.Parameters.AddWithValue("@usuario", o.usuario);

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

        public bool EditarOperacao(Operacao o)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE operacoes set descricao = @descricao, dataHora = @dataHora, categoria = @categoria, conta = @conta, valor = @valor WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", o.id);
                cmd.Parameters.AddWithValue("@descricao", o.descricao);
                cmd.Parameters.AddWithValue("@dataHora", o.dataHora);
                cmd.Parameters.AddWithValue("@categoria", o.categoria);
                cmd.Parameters.AddWithValue("@conta", o.conta);
                cmd.Parameters.AddWithValue("@valor", o.valor);

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

        public bool ExcluirOperacao(int id)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE operacoes set ativo = false WHERE id = @id";
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

        public Operacao SelecionarporId(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            Operacao o = new Operacao();

            try
            {
                cmd.CommandText = "Select * from operacoes WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    o.id = Convert.ToInt32(reader["id"]);
                    o.descricao = reader["descricao"].ToString();
                    o.dataHora = Convert.ToDateTime(reader["dataHora"].ToString());                   
                    o.categoria = reader["categoria"].ToString();
                    o.conta = reader["conta"].ToString();
                    o.valor = float.Parse(reader["valor"].ToString());
                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                db.CloseConnection(cmd.Connection);
            }

            return o;
        }

        public DataTable VisualizarReceitas(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select id, dataHora, descricao, categoria, conta, valor from operacoes where id_usuario = @id_usuario AND tipo = 'receita' AND ativo = true ORDER BY dataHora";

                cmd.Parameters.AddWithValue("@id_usuario", id);

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
        public DataTable VisualizarReceitas(int id, DateTime inicial, DateTime final)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select id, dataHora, descricao, categoria, conta, valor from operacoes where id_usuario = @id_usuario AND tipo = 'receita' AND ativo = true and dataHora >= @inicial and dataHora <= @final  ORDER BY dataHora";

                cmd.Parameters.AddWithValue("@id_usuario", id);
                cmd.Parameters.AddWithValue("@inicial", inicial);
                cmd.Parameters.AddWithValue("@final", final);

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

        public DataTable VisualizarDespesas(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select id, dataHora, descricao, categoria, conta, valor from operacoes where id_usuario = @id_usuario AND tipo = 'despesa' AND ativo = true ORDER BY dataHora";

                cmd.Parameters.AddWithValue("@id_usuario", id);

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
        public DataTable VisualizarDespesas(int id, DateTime inicial, DateTime final)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select id, dataHora, descricao, categoria, conta, valor from operacoes where id_usuario = @id_usuario AND tipo = 'despesa' AND ativo = true and dataHora >= @inicial and dataHora <= @final  ORDER BY dataHora";

                cmd.Parameters.AddWithValue("@id_usuario", id);
                cmd.Parameters.AddWithValue("@inicial", inicial);
                cmd.Parameters.AddWithValue("@final", final);

                cmd.Connection = db.OpenConnection();
                dt.Load(cmd.ExecuteReader());

                
            }
            catch
            {
                
            }
            finally
            {
                db.CloseConnection(cmd.Connection);
            }

            return dt;
        }

        public DataTable VisualizarTudo(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select dataHora, descricao, categoria, conta, tipo, valor from operacoes where id_usuario = @id_usuario AND ativo = true ORDER BY dataHora";

                cmd.Parameters.AddWithValue("@id_usuario", id);

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
        public DataTable VisualizarTudo(int id, DateTime inicial, DateTime final)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select tipo, dataHora, descricao, categoria, conta, valor from operacoes where id_usuario = @id_usuario AND ativo = true and dataHora >= @inicial and dataHora <= @final  ORDER BY dataHora";

                cmd.Parameters.AddWithValue("@id_usuario", id);
                cmd.Parameters.AddWithValue("@inicial", inicial);
                cmd.Parameters.AddWithValue("@final", final);

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


    }
}