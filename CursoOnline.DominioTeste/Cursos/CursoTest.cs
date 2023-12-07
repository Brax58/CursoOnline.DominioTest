using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = 80,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = 950
            };

            //Act
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor);

            //Assert
            Assert.IsType<PublicoAlvo>(curso.PublicoAlvo);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeeveCursoTerUmNomeNuloOuVazio(string nomeInvalido)
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = nomeInvalido,
                CargaHoraria = 80,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = 950
            };

            //Act 
            var result = Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor)).Message;

            //Assert
            Assert.Equal("Nome inválido", result);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(0.1)]
        public void NaoDeveCursoTerCargaHorariaMenorQueUm(double cargaHorariaInvalida)
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = "Informatica",
                CargaHoraria = cargaHorariaInvalida,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = 950
            };

            //Act 
            var result = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor)).Message;

            //Assert
            Assert.Equal("Carga horária inválida", result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(0.1)]
        public void NaoDeveCursoTerValorMenorQueUm(double valorInvalido)
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = "Informatica",
                CargaHoraria = 90,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = valorInvalido
            };

            //Act 
            var result = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor)).Message;

            //Assert
            Assert.Equal("Valor inválido",result);
        }

    }

    public enum PublicoAlvo
    {
        Estudantes,
        Universitario,
        Empregado,
        Empreendedor
    }

    internal class Curso
    {
        public string Nome { get; }
        public double CargaHoraria { get; }
        public PublicoAlvo PublicoAlvo { get; }
        public double Valor { get; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }
    }
}
