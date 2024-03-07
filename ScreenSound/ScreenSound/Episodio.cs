using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound
{
    public class Episodio
    {
        private List<string> convidados = new();
        public int Duracao { get; }
        public int Ordem { get; }
        public string Titulo { get; }
        public string Resumo => $"{Ordem}. {Titulo} ({Duracao} min) - {string.Join(", ", convidados)}";

        public Episodio (int duracao, int ordem, string titulo)
        {
            Duracao = duracao;
            Ordem = ordem;
            Titulo = titulo;
        }

        public void AdicionarConvidados(string convidado)
        {
            convidados.Add(convidado);
        }
    }
}
