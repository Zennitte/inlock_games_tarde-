using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source = DESKTOP-IU700GH\\SQLEXPRESS; initial catalog = inlock_games_tarde; user Id = sa; pwd = senai@132 ";
        public void AtualizarIdCorpo(EstudioDomain estudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = @"UPDATE ESTUDIO SET nomeEstudio = @nomeEstudio
                                     WHERE idEstudio = @idEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudioAtualizado.nomeEstudio);
                    cmd.Parameters.AddWithValue("@idEstudio", estudioAtualizado.idEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            EstudioDomain estudioBuscado = new EstudioDomain();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT idEstudio AS Id, nomeEstudio AS Nome FROM ESTUDIO 
                                       WHERE idEstudio = @idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        estudioBuscado = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr["Id"]),
                            nomeEstudio = rdr["Nome"].ToString()
                        };

                        return estudioBuscado;

                    }
                }
                return null;
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ESTUDIO (nomeEstudio) VALUES (@nomeEstudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = @"DELETE FROM ESTUDIO 
                                       WHERE idEstudio = @idEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idEstudio AS Id, nomeEstudio AS Nome FROM ESTUDIO";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr["Id"]),
                            nomeEstudio = rdr["Nome"].ToString()
                        };

                        listaEstudios.Add(estudio);
                    }
                }

                return listaEstudios;
            }
        }
    }
}
