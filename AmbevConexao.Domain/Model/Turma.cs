namespace AmbevConexao.Domain.Model
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }

        public List<TurmaAluno> TurmaAluno { get; set; }

        public static Turma NovaTurma(string nome, int idProfessor)
        {
            var turma = new Turma();
            turma.Nome = nome;
            turma.IdProfessor = idProfessor;

            return turma;
        }

    }
}
