﻿using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ScreenSound_04.Modelos;

internal class Musica
{
    private string[] tonalidades = {"C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B" };
    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("key")]
    public int Key { get; set; }

    public string Tonalidade {
        get
        {
            return tonalidades[Key];
        }
    }
    public void ExibirDetalhesMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Musica: {Nome}");
        Console.WriteLine($"Duração: {Duracao/1000}");
        Console.WriteLine($"Gênero: {Genero}");        
        Console.WriteLine($"Tonalidade: {Tonalidade}");
        

    }
}
