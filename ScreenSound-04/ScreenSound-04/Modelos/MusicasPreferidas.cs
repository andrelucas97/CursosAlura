using System.Text.Json;

namespace ScreenSound_04.Modelos;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> ListaMusicasFav { get;  }

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaMusicasFav = new List<Musica>();
    }

    public void AdicionarMusicasFav(Musica musica)
    {
        ListaMusicasFav.Add(musica);
    }

    public void ExibirMusicasFav()
    {
        Console.WriteLine($"Essas são as musicas favoritas {Nome}");
        foreach(var musica in ListaMusicasFav)
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = ListaMusicasFav
        });

        string nomeArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeArquivo, json);
        Console.WriteLine($"Arquivo Json criado com sucesso! {Path.GetFullPath(nomeArquivo)}");

    }

}
