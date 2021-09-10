using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using senai.inlock.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : Controller
    {
        private IJogoRepository _jogoRepository { get; set; }
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR,CLIENTE")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

            return Ok(listaJogos);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            if (novoJogo.descricao == null || novoJogo.dataLancamento == null || novoJogo.idEstudio <= 0 || novoJogo.valor < 0)
            {
                return NotFound(
                       new
                       {
                           mensagem = "Informações incompletas",
                           error = true
                       }
                    );
            }

            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Id inválido",
                            erro = true
                        }
                    );
            }

            try
            {
                _jogoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
