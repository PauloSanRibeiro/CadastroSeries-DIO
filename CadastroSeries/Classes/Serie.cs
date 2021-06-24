using CadastroSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace CadastroSeries
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        public int Ano { get; set; }

        private bool Excluido { get; set; }

        //Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }


        public override string ToString()
        {
            string retorno = "";
            retorno += $"Gênero: {Genero} {Environment.NewLine}";
            retorno += $"Título: {Titulo}{Environment.NewLine}";
            retorno += $"Descrição: {Descricao}{Environment.NewLine}";
            retorno += $"Ano de Inicio: {Ano}{Environment.NewLine}";
            retorno += $"Excluído: {Excluido}";

            return retorno;
        }

        public string retornoTitulo()
        {
            return Titulo;
        }

        public int retornoId()
        {
            return Id;
        }

        public bool RetornaExluido()
        {
            return Excluido;
        }
        public void Exclui()
        {
            Excluido = true;
        }


    }
}
