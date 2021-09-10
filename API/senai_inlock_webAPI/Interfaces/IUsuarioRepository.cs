using senai.inlock.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarTodos();
        UsuarioDomain BuscarPorId(int id);
        void Cadastrar(UsuarioDomain novoUsuario);
        void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado);
        void Deletar(int id);
        UsuarioDomain Login(string email, string senha);
    }
}
