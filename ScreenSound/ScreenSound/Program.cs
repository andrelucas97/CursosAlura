using ScreenSound;

Banda queen = new Banda("Queen");

Album albumQueen = new Album("A night at the opera");

Musica musica1 = new Musica(queen, "Love of my life")
{
    Duracao = 213,
    Disponivel = true,
};

Musica musica2 = new Musica(queen, "Bohemian Rhapsody")
{
    Duracao = 354,
    Disponivel = false,
};

albumQueen.AdicionarMusica(musica1);
albumQueen.AdicionarMusica(musica2);
queen.AdicionarAlbum(albumQueen);

musica1.ExibirFichaTecnica();
musica2.ExibirFichaTecnica();

albumQueen.ExibirMusicasAlbum();
queen.ExibirDisco();

//Episodio ep1 = new(45, 1, "Técnicas de facilitação");
//ep1.AdicionarConvidados("Maria");
//ep1.AdicionarConvidados("Marcelo");
//
//Episodio ep2 = new(67, 2, "Tecnicas de aprendizado");
//ep2.AdicionarConvidados("Fernando");
//ep2.AdicionarConvidados("Marcos");
//ep2.AdicionarConvidados("Flavia");
//
//Podcast podcast = new("Podcast especial", "Daniel");
//podcast.AdicionarEpisodio(ep1);
//podcast.AdicionarEpisodio(ep2);
//podcast.ExibirDetalhes();
