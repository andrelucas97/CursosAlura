using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound
{
    public class Podcast
    {
        private List<Episodio> episodios = new();
        public string Host { get; }
        public string Nome { get; }
        public int TotalEpisodios => episodios.Count; 
        public Podcast(string host, string nome)
        {
            Host = host;
            Nome = nome;
        }

        public void AdicionarEpisodio(Episodio episodio)
        {
            episodios.Add(episodio);
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"Podcast {Nome} apresentado por {Host}\n");
            foreach(Episodio episodio in episodios.OrderBy(e => e.Ordem))
            {
                Console.WriteLine(episodio.Resumo);
            }
            Console.WriteLine($"\n\nTotal de episódios: {TotalEpisodios}.");
        }
    }
}
