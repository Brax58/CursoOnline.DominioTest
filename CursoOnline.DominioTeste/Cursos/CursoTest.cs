using CursoOnline.Dominio.Enums;
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
}
