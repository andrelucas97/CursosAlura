// Screen Sound

string mensagemBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaBandas = new List<string>();

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Link Park", new List<int> { 10, 8, 6});
bandasRegistradas.Add("The Beatles", new List<int> { 10, 9, 8});

void ExibirMensagemBoasVindas()
{
    Console.WriteLine(@"
    
▒█▀▀▀█ ▒█▀▀█ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀▀ ▒█▄░▒█ 　 ▒█▀▀▀█ ▒█▀▀▀█ ▒█░▒█ ▒█▄░▒█ ▒█▀▀▄ 
░▀▀▀▄▄ ▒█░░░ ▒█▄▄▀ ▒█▀▀▀ ▒█▀▀▀ ▒█▒█▒█ 　 ░▀▀▀▄▄ ▒█░░▒█ ▒█░▒█ ▒█▒█▒█ ▒█░▒█ 
▒█▄▄▄█ ▒█▄▄█ ▒█░▒█ ▒█▄▄▄ ▒█▄▄▄ ▒█░░▀█ 　 ▒█▄▄▄█ ▒█▄▄▄█ ░▀▄▄▀ ▒█░░▀█ ▒█▄▄▀
");
    Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirMensagemBoasVindas();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;

    switch (opcaoEscolhida)
    {
        case "1":
            RegistrarBanda();
            break;
        case "2":
            MostrarBandasRegistradas();
            break;
        case "3":
            AvaliarBanda(bandasRegistradas);
            break;
        case "4":
            MediaBandas(bandasRegistradas);
            break;
        case "-1":
            Console.WriteLine("Obrigado, Até!");
            break;
        default:
            Console.WriteLine("Opção Inválida.");
            break;
    }

}

void MediaBandas(Dictionary<string, List<int>> bandasRegistradas)
{
    Console.Clear();
    ExibirTituloOpcao("Nota média de cada banda");
    int count = 0;
    foreach (string banda in bandasRegistradas.Keys)
    {
        count++;
        Console.WriteLine($"Banda {count}: {banda}");
    }

    Console.Write("\nDigite o nome da banda que deseja visualizar a média das notas: ");
    string nomeBanda = Console.ReadLine()!;

    if (!bandasRegistradas.ContainsKey(nomeBanda))
    {
       nomeBanda = bandaNaoRegistrada(nomeBanda);
    }
    else
    {
        double mediaNotaBanda = bandasRegistradas[nomeBanda].Average();
        Console.WriteLine($"\nA média das notas da banda {nomeBanda} é: " + mediaNotaBanda);

    }



    Console.WriteLine("\nDigite uma tecla para voltar ao menu Principal");
    Console.ReadKey();
    Console.Clear();
    
    ExibirOpcoesMenu();
}

string bandaNaoRegistrada(string nomeBanda)
{
    while (!bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Banda {nomeBanda} não encontrada! Digite novamente ou digite -1 para voltar ao Menu Principal: ");
        nomeBanda = Console.ReadLine()!;
        if (nomeBanda == "-1")
        {
            Console.Clear();
            ExibirOpcoesMenu();
        }
    }

    return nomeBanda;
}

void AvaliarBanda(Dictionary<string, List<int>> bandasRegistradas)
{
    Console.Clear();
    ExibirTituloOpcao("Avaliar banda");
    int count = 0;
    foreach (string banda in bandasRegistradas.Keys)
    {
        count++;
        Console.WriteLine($"Banda {count}: {banda}");
    }

    Console.Write("\nDigite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    if (!bandasRegistradas.ContainsKey(nomeBanda))
    {
        bandaNaoRegistrada(nomeBanda);
    }
    else
    {
        Console.Write($"Qual a nota que a banda {nomeBanda} merece: ");
        int nota = Convert.ToInt32((Console.ReadLine()!));
        bandasRegistradas[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}");

    }

    Thread.Sleep(5000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloOpcao("Lista de Bandas já registradas");

    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    if (bandasRegistradas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda cadastrada!");

    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu Principal");
    Console.ReadKey();
    Console.Clear();

    ExibirOpcoesMenu();


}

void RegistrarBanda()
{
    Console.Clear();

    ExibirTituloOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda a ser registrada: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"Banda {nomeBanda} registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void ExibirTituloOpcao(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

ExibirOpcoesMenu();
