using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = DESKTOP-IU700GH\\SQLEXPRESS; initial catalog = inlock_games_tarde; user Id = sa; pwd = senai@132 ";
        public void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = @"UPDATE USUARIO SET senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @idUsuario ";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@senha", usuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@idUsuario", usuarioAtualizado.idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            UsuarioDomain usuarioBuscado = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"
                 SELECT idUsuario AS Id, email AS Email, senha AS Senha, TU.titulo AS Permissao FROM USUARIO U
                            INNER JOIN TIPO_USUARIO TU
                            ON U.idTipoUsuario = TU.idTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["Id"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString(),

                            tipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = rdr["Permissao"].ToString()
                            }
                        };
                        return usuarioBuscado;
                    }  
                }
            }
            return null;
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO USUARIO (email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM USUARIO WHERE idUsuario = @idUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"
                 SELECT idUsuario AS Id, email AS Email, senha AS Senha, TU.titulo AS Permissao FROM USUARIO U
                            INNER JOIN TIPO_USUARIO TU
                            ON U.idTipoUsuario = TU.idTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["Id"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString(),
                            
                            tipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = rdr["Permissao"].ToString()
                            }
                        };
                        listaUsuarios.Add(usuario);
                    }
                    return listaUsuarios;
                }
            }
        }

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuarioBuscado = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = @"
         SELECT idUsuario AS Id, email AS Email, senha AS Senha, U.idTipoUsuario AS IdT, titulo AS Titulo FROM USUARIO U
                                    INNER JOIN TIPO_USUARIO TU
                                ON U.idTipoUsuario = TU.idTipoUsuario
                                WHERE email = @email AND senha = @senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["Id"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["IdT"]),
                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(rdr["IdT"]),
                                titulo = rdr["Titulo"].ToString()
                            }
                        };
                        return usuarioBuscado;
                    }
                }
                return null;
            }
        }
    }
}
