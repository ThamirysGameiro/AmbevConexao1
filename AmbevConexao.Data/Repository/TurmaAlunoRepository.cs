using AmbevConexao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AmbevConexao.Data.Repository
{
    public class TurmaAlunoRepository : BaseRepository<TurmaAluno>
    {
        public List<TurmaAluno> SelecionarTudoCompleto()
        {
            var t = contexto.TurmaAluno
                .Include(x => x.Aluno)
                .Include(x => x.Turma);
                //.ThenInclude(x => x.Professor)
                //.ToList();

            return t.ToList();
        }
    }
}
