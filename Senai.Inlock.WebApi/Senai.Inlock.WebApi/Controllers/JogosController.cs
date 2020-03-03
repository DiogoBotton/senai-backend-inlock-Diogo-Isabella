using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class JogosController : ControllerBase
    {
        public IJogoRepository _jogoRepository { get; set; }
        public IEstudioRepository _estudioRepository { get; set; }
        public InLockContext _context { get; set; }

        public JogosController()
        {
            _context = new InLockContext();
            _jogoRepository = new JogoRepository(_context);
            _estudioRepository = new EstudioRepository(_context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var retorno = _jogoRepository.GetAll();
            var estudios = _estudioRepository.GetAll();

            //Um forEach para iterar sobre cada jogo, e acrescentar um objeto EstudioVM (ViewModel)
            //retorno.ForEach((x) =>
            //{
            //    EstudioVM = estudios.FirstOrDefault(e => e.Id == x.EstudioId);
            //});

            var jogosEstudios = retorno.Select(x => new
            {
                x.Id,
                x.Nome,
                x.Descricao,
                x.DataLancamento,
                x.Valor,
                Estudio = estudios.Where(y => y.Id == x.EstudioId).Select(e => new
                {
                    e.Id,
                    e.Descricao
                }).FirstOrDefault(),
            }).ToList();
            //Created("https://localhost:5000/api/Jogos", retorno);
            return Ok(jogosEstudios);
        }
    }
}
