

using CursoOnline.Dominio.Enums;

namespace CursoOnline.Dominio.Entitys
{
    public class Curso
    {
        public string Nome { get; }
        public string Descricao { get; }
        public double CargaHoraria { get; }
        public PublicoAlvo PublicoAlvo { get; }
        public double Valor { get; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
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
