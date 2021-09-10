using senai.inlock.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> ListarTodos();
        EstudioDomain BuscarPorId(int id);
        void Cadastrar(EstudioDomain novoEstudio);
        void AtualizarIdCorpo(EstudioDomain estudioAtualizado);
        void Deletar(int id);

    }
}
