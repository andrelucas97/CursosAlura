using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //Console.WriteLine(resposta);

        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        //musicas[0].ExibirDetalhesMusica();

        //LinqFilter.FiltrarGenerosMusicais(musicas);
        //LinqFilter.ExibirOrdemArtistas(musicas);
        //LinqFilter.ExibirArtistasGenero(musicas, "rock");
        //LinqFilter.FiltrarArtistaMusica(musicas, "U2");
        LinqFilter.FiltrarMusicasTonalidade(musicas, "C#");

        //var musicasPreferidasDaniel = new MusicasPreferidas("Daniel");
        //musicasPreferidasDaniel.AdicionarMusicasFav(musicas[1]);
        //musicasPreferidasDaniel.AdicionarMusicasFav(musicas[377]);
        //musicasPreferidasDaniel.AdicionarMusicasFav(musicas[4]);
        //musicasPreferidasDaniel.AdicionarMusicasFav(musicas[6]);
        //musicasPreferidasDaniel.AdicionarMusicasFav(musicas[1467]);

        //musicasPreferidasDaniel.ExibirMusicasFav();

        //var musicasPreferidasEmy = new MusicasPreferidas("Emy");
        //musicasPreferidasEmy.AdicionarMusicasFav(musicas[3]);
        //musicasPreferidasEmy.AdicionarMusicasFav(musicas[14]);
        //musicasPreferidasEmy.AdicionarMusicasFav(musicas[234]);
        //musicasPreferidasEmy.AdicionarMusicasFav(musicas[345]);
        //musicasPreferidasEmy.AdicionarMusicasFav(musicas[1000]);
        //
        //musicasPreferidasEmy.ExibirMusicasFav();
        //
        //musicasPreferidasEmy.GerarArquivoJson();

    } catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
    
    

}