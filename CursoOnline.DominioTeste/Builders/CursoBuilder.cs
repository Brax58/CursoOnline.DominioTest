using CursoOnline.DominioTest.Cursos;

namespace CursoOnline.DominioTest.Builders
{
    internal class CursoBuilder
    {
        private string _nome = "Informática básica";
        private string _descricao = "";
        private double _cargaHoraria = 80;        
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Universitario;        
        private double _valor = 950.0;       

        public static CursoBuilder Novo() 
        {
            return new CursoBuilder();
        }

        public Curso Build() 
        {
            return new Curso(_nome,_descricao,_cargaHoraria,_publicoAlvo,_valor);
        }

        public CursoBuilder AtualizarNome(string nome) 
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder AtualizarDescricao(string descricao) 
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder AtualizarCargaHoraria(double cargaHoraria) 
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder AtualizarPublicoAlvo(PublicoAlvo publicoAlvo) 
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder AtualizarValor(double valor) 
        {
            _valor = valor;
            return this;
        }

    }
}
