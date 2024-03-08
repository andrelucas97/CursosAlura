using bytebank_Atendimento.bytebank.Util;
using bytebank_Atendimento.Conta;
using System.Collections;

Console.WriteLine("Boas vindas ao ByteBank, Atendimento!");

#region Exemplos Arrays em C#
void TestaArrayContasCorrente()
{

    ListaContasCorrentes listaContas = new ListaContasCorrentes();
    listaContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaContas.Adicionar(new ContaCorrente(874, "7781438-C"));       
    listaContas.Adicionar(new ContaCorrente(874, "7781438-C"));       
    listaContas.Adicionar(new ContaCorrente(874, "7781438-C"));       
    listaContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    var contaAndre = new ContaCorrente(963, "123456-X");
    listaContas.Adicionar(contaAndre);
    //listaContas.ExibeLista();
    //Console.WriteLine("===============");
    //listaContas.Remover(contaAndre);
    //listaContas.ExibeLista();

    for (int i = 0; i < listaContas.Tamanho; i++)
    {
        ContaCorrente conta = listaContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }

}

//TestaArrayContasCorrente();
#endregion 

List<ContaCorrente> _listaContas = new List<ContaCorrente>()
{
    new ContaCorrente(95, "123456-X") {Saldo=100},
    new ContaCorrente(95, "951258-X") {Saldo=200},
    new ContaCorrente(94, "987321-W") {Saldo=60}
};
//AtendimentoCliente();
void AtendimentoCliente()
{
    char opcao = '0';
    while (opcao != '6')
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("======      Atendimento       ======");
        Console.WriteLine("====== 1 - Cadastrar Conta    ======");
        Console.WriteLine("====== 2 - Listar Contas      ======");
        Console.WriteLine("====== 3 - Remover Conta      ======");
        Console.WriteLine("====== 4 - Ordenar Contas     ======");
        Console.WriteLine("====== 5 - Pesquisar Conta    ======");
        Console.WriteLine("====== 6 - Sair do sistema    ======");
        Console.WriteLine("\n\n");
        Console.Write("Digite a opção desejada: ");
        opcao = Console.ReadLine()[0];
        switch (opcao)
        {
            case '1': CadastrarConta();
                break;
            case '2':
                ListarConta();
                break;
            case '3':
                CadastrarConta();
                break;
            case '4':
                CadastrarConta();
                break;
            case '5':
                CadastrarConta();
                break;
            case '6':
                CadastrarConta();
                break;
            default: Console.WriteLine("Opção não implementada.");
                break;
        }
    }
}

void ListarConta()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===       LISTA DE CONTAS    ===");
    Console.WriteLine("================================\n");

    if (_listaContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }

    foreach(ContaCorrente item in _listaContas)
    {
        Console.WriteLine("===  Dados da Conta  ===");
        Console.WriteLine("Número da Conta: " + item.Conta);
        Console.WriteLine("Saldo da Conta: " + item.Saldo);
        Console.WriteLine("Tiular da Conta: " + item.Titular.Nome);
        Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
        Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===    CADASTRO DE CONTAS    ===");
    Console.WriteLine("================================\n");
    Console.WriteLine("===  Informe dados da Conta  ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Informe nome do Titular: ");
    conta.Titular.Nome = (Console.ReadLine());

    Console.Write("Informe CPF do Titular: ");
    conta.Titular.Cpf = (Console.ReadLine());

    Console.Write("Informe Profissão do Titular: ");
    conta.Titular.Profissao = (Console.ReadLine());

    _listaContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}
#region 
//Generica<int> teste1 = new Generica<int>();
//teste1.MostrarMensagem(10);

//Generica<string> teste2 = new Generica<string>();
//teste2.MostrarMensagem("Olá");
//public class Generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//    }
//}

//List<ContaCorrente> _listaContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaContas2.AddRange(_listaContas3);
//_listaContas2.Reverse();
//for (int i = 0; i < _listaContas2.Count; i++)
//{
//    Console.WriteLine($"Indice [{i}] = Conta [{_listaContas2[i].Conta}]");
//}
//Console.WriteLine("\n\n");
//var range = _listaContas3.GetRange(0, 2);
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice [{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//_listaContas3.Clear();

//for (int i = 0; i < _listaContas3.Count; i++)
//{
//    Console.WriteLine($"Indice [{i}] = Conta [{range[i].Conta}]");
//}
#endregion
