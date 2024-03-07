using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros;

internal class LinqFilter
{
    public static void FiltrarGenerosMusicais(List<Musica> musicas)
    {
        var generosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();

        foreach (var gen in generosMusicais)
        {
            Console.WriteLine($"- {gen}");
        }
    }

    public static void ExibirOrdemArtistas(List<Musica> musicas)
    {
        var artistasOrdem = musicas.OrderBy(x => x.Artista).Select(x => x.Artista).Distinct().ToList();
        Console.WriteLine("Lista de Artistas:");
        foreach (var artist in artistasOrdem)
        {
            Console.WriteLine($"- {artist}");
        }
    }

    public static void ExibirArtistasGenero(List<Musica> musicas, string genero)
    {
        var artistasGenero = musicas.Where(m => m.Genero!.Contains(genero)).Select(m => m.Artista).Distinct().ToList();
        Console.WriteLine($"Artistas por Genero ({genero}):");

        foreach(var artistG in artistasGenero)
        {
            Console.WriteLine($"- {artistG}");
        }
    }

    public static void FiltrarArtistaMusica(List<Musica> musicas, string artista)
    {
        var musicasArtista = musicas.Where(m => m.Artista!.Equals(artista)).ToList();

        Console.WriteLine($"Musicas do artista {artista}:");
        foreach (var musica in musicasArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarMusicasTonalidade(List<Musica> musicas, string tonalidade)
    {
        var musicasTonalidade = musicas.Where(m => m.Tonalidade!.Equals(tonalidade)).ToList();
        Console.WriteLine($"Musicas com tonalidade {tonalidade}:");
        foreach(var musica in musicasTonalidade)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }
}
