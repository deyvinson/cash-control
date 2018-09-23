using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace Projeto_Cash_Control
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string perfil { get; set; }
        public DateTime dataCriacao { get; set; }
        public bool ativo { get; set; }
        public DateTime dataDesativado { get; set; }


        private string Criptografar(string texto)
        {
            StringBuilder hash = new StringBuilder();

            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();

            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(texto));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("X2"));
            }

            return hash.ToString();
        }


        public bool NovoUsuario(Usuario u)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "insert into usuarios (nome, sobrenome, email, senha, perfil, dataCriacao, ativo) values (@nome, @sobrenome, @email, @senha, @perfil, @dataCriacao, true)";

                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@sobrenome", u.sobrenome);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@senha", Criptografar(u.senha));
                cmd.Parameters.AddWithValue("@perfil", u.perfil);
                cmd.Parameters.AddWithValue("@dataCriacao", DateTime.Now);

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


        public bool EditarUsuarioNomeSobrenomeEmail(Usuario u)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE usuarios SET nome = @nome, sobrenome = @sobrenome, email = @email  where id = @id";

                cmd.Parameters.AddWithValue("@id", u.id);
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@sobrenome", u.sobrenome);
                cmd.Parameters.AddWithValue("@email", u.email);

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

        public bool DesativarUsuario(Usuario u)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE usuarios SET ativo = false, dataDesativado = @dataDesativado  where id = @id";

                cmd.Parameters.AddWithValue("@id", u.id);
                cmd.Parameters.AddWithValue("@dataDesativado", DateTime.Now);


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

        public bool AtivarUsuario(Usuario u)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE usuarios SET ativo = true where id = @id";

                cmd.Parameters.AddWithValue("@id", u.id);

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


        public bool EditarUsuarioSenha(Usuario u)
        {

            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();

            try
            {
                cmd.CommandText = "UPDATE usuarios SET senha = @senha  where id = @id";

                cmd.Parameters.AddWithValue("@id", u.id);
                cmd.Parameters.AddWithValue("@senha", Criptografar(u.senha));


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

        public DataTable Selecionar()
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "select id, nome, sobrenome, email, perfil, dataCriacao, ativo, dataDesativado from usuarios where perfil = 'Usuário' order by id";
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


        public Usuario Login(string email, string senha)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            Usuario u = new Usuario();

            try
            {

                cmd.CommandText = @"select * from usuarios where email = @email and senha = @senha";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", Criptografar(senha));

                cmd.Connection = db.OpenConnection();
                NpgsqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    u.id = Convert.ToInt32(reader["id"].ToString());
                    u.nome = reader["nome"].ToString();
                    u.sobrenome = reader["sobrenome"].ToString();
                    u.email = reader["email"].ToString();
                    u.senha = reader["senha"].ToString();
                    u.perfil = reader["perfil"].ToString();
                    u.dataCriacao = Convert.ToDateTime(reader["dataCriacao"].ToString());
                }
                return u;
            }
            catch (Exception ex)

            {
                u.id = 0;
                return u;
            }
            finally
            {
                db.CloseConnection(cmd.Connection);
            }
        }

        public Usuario SelecionarPorId(int id)
        {
            DataBase db = new DataBase();
            NpgsqlCommand cmd = new NpgsqlCommand();
            Usuario u = new Usuario();

            try
            {

                cmd.CommandText = @"select * from usuarios where id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = db.OpenConnection();
                NpgsqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    u.id = Convert.ToInt32(reader["id"].ToString());
                    u.nome = reader["nome"].ToString();
                    u.sobrenome = reader["sobrenome"].ToString();
                    u.email = reader["email"].ToString();
                    u.senha = reader["senha"].ToString();
                    u.perfil = reader["perfil"].ToString();
                    u.dataCriacao = Convert.ToDateTime(reader["dataCriacao"].ToString());
                    u.ativo = bool.Parse(reader["ativo"].ToString());
                }
                return u;
            }
            catch (Exception ex)

            {
                u.id = 0;
                return u;
            }
            finally
            {
                db.CloseConnection(cmd.Connection);
            }
        }

    }
}