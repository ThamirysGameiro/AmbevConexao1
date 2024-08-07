using AmbevConexao.API.Dto;
using AmbevConexao.Data.Repository;
using AmbevConexao.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace AmbevConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository _repository;

        public AlunoController()
        {
            _repository = new AlunoRepository();
        }

        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _repository.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Aluno Get(int id) 
        {
            return _repository.Selecionar(id);
        }

        [HttpPost]
        public IEnumerable<Aluno> Post([FromBody] AlunoDto alunoDto)
        {
            var alunoEntidade = Aluno.NovoAluno(alunoDto.Nome);

            _repository.Incluir(alunoEntidade);

            return _repository.SelecionarTudo();
        }

        [HttpPut("{id}")]
        public Aluno Put(int id, [FromBody] AlunoDto alunoDto)
        {
            var alunoEntidade = _repository.Selecionar(id);

            alunoEntidade.AlterarNome(alunoDto.Nome);

            _repository.Alterar(alunoEntidade);

            return alunoEntidade;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            _repository.Excluir(id);
        }
    }
}
