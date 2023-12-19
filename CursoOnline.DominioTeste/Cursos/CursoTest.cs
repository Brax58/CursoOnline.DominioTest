using CursoOnline.DominioTest.Builders;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        private readonly ITestOutputHelper _outputHelper;

        public CursoTest(ITestOutputHelper output)
        {
            _outputHelper = output;
            _outputHelper.WriteLine("Construtor sendo executado"); 
        }

        [Fact]
        public void DeveCriarCurso()
        {
            //Act
            var curso = CursoBuilder.Novo().Build();

            //Assert
            Assert.IsType<PublicoAlvo>(curso.PublicoAlvo);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeeveCursoTerUmNomeNuloOuVazio(string nomeInvalido)
        {
            //Act 
            var result = Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().AtualizarNome(nomeInvalido).Build()).Message;

            //Assert
            Assert.Equal("Nome inválido", result);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(0.1)]
        public void NaoDeveCursoTerCargaHorariaMenorQueUm(double cargaHorariaInvalida)
        {
            //Act 
            var result = Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().AtualizarCargaHoraria(cargaHorariaInvalida).Build()).Message;

            //Assert
            Assert.Equal("Carga horária inválida", result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(0.1)]
        public void NaoDeveCursoTerValorMenorQueUm(double valorInvalido)
        {
            //Act   
            var result = Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().AtualizarValor(valorInvalido).Build()).Message;

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
        public string Descricao { get; }
        public double CargaHoraria { get; }
        public PublicoAlvo PublicoAlvo { get; }
        public double Valor { get; }

        public Curso(string nome,string descricao,double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }
    }
}
