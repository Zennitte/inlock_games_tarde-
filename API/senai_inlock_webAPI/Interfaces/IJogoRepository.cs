using senai.inlock.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> ListarTodos();
        JogoDomain BuscarPorId(int id);
        void Cadastrar(JogoDomain novoJogo);
        void AtualizarIdCorpo(JogoDomain jogoAtualizado);
        void Deletar(int id);
    }
}
