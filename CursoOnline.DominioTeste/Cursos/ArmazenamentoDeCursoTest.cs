using CursoOnline.Dominio.Entitys;
using CursoOnline.Dominio.Enums;
using CursoOnline.DominioTest.Builders;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenamentoDeCursoTest
    {
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;

        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        private readonly CursoDto _cursoDto;

        public ArmazenamentoDeCursoTest()
        {
            _cursoRepositorioMock = new Mock<ICursoRepositorio>();

            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);

            _cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descricao",
                CargaHoraria = 90,
                PublicoAlvo = "Estudantes",
                Valor = 800
            };
        }

        [Fact]
        public void DeveArmazenarCurso()
        {

            _armazenadorDeCurso.ArmazenarCurso(_cursoDto);

            _cursoRepositorioMock.Verify(x => x.Adicionar(It.Is<Curso>(c => 
                    c.Nome == _cursoDto.Nome &&
                    c.Descricao == _cursoDto.Descricao
                )), Times.AtLeastOnce);
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvo() 
        {
            _cursoDto.PublicoAlvo = "";

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.ArmazenarCurso(_cursoDto));
        }

        [Fact]
        public void NaoDeveAdicionarCursoComMesmoNomeDeOutroSalvo() 
        {
            //Arrange
            var cursoJaSalvo = CursoBuilder.Novo().AtualizarNome(_cursoDto.Nome).Build();

            _cursoRepositorioMock.Setup(c => c.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);

            //Act and Assert
            var erro = Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.ArmazenarCurso(_cursoDto));

            Assert.Equal("Nome do curso já consta no banco de dados.",erro.Message);
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
        Curso ObterPeloNome(string nome);
    }

    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void ArmazenarCurso(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo),cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
                throw new ArgumentException("Publico Alvo inválido.");

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria,(PublicoAlvo)publicoAlvo, cursoDto.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }


    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public int Valor { get; set; }
    }
}
