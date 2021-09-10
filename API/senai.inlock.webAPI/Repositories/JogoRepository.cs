using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source = DESKTOP-IU700GH\\SQLEXPRESS; initial catalog = inlock_games_tarde; user Id = sa; pwd = senai@132 ";
        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public JogoDomain BuscarPorId(int id)
        {
            JogoDomain jogoBuscado = new JogoDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT idJogo AS Id, nomeJogo AS Nome, descrição AS Descricao, dataLancamento AS Lancamento, valor AS Preco, J.idEstudio AS IdE, nomeEstudio AS ESTUDIO FROM JOGO J
                   LEFT JOIN ESTUDIO E
                   ON J.idEstudio = E.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        jogoBuscado = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["Id"]),
                            nomeJogo = rdr["Nome"].ToString(),
                            descricao = rdr["Descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["Lancamento"]),
                            valor = Convert.ToDouble(rdr["Preco"]),
                            idEstudio = Convert.ToInt32(rdr["IdE"]),
                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(rdr["IdE"]),
                                nomeEstudio = rdr["Estudio"].ToString()
                            }
                        };

                        return jogoBuscado;
                    }
                }
            }  
            return null;
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO JOGO(nomeJogo, descrição, dataLancamento, valor, idEstudio)
                                     VALUES(@nomeJogo, @descrição, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descrição",novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento",novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor",novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio",novoJogo.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM JOGO WHERE idJogo = @idJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT idJogo AS Id, nomeJogo AS Nome, descrição AS Descricao, dataLancamento AS Lancamento, valor AS Preco, J.idEstudio AS IdE, nomeEstudio AS ESTUDIO FROM JOGO J
                   LEFT JOIN ESTUDIO E
                   ON J.idEstudio = E.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["Id"]),
                            nomeJogo = rdr["Nome"].ToString(),
                            descricao = rdr["Descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["Lancamento"]),
                            valor = Convert.ToDouble(rdr["Preco"]),
                            idEstudio = Convert.ToInt32(rdr["IdE"]),
                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(rdr["IdE"]),
                                nomeEstudio = rdr["Estudio"].ToString()
                            }
                        };

                        listaJogos.Add(jogo);
                    }
                }

                return listaJogos;
            }
        }
    }
}
