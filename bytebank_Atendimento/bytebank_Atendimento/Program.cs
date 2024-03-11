using bytebank_Atendimento.bytebank.Atendimento;
using bytebank_Atendimento.bytebank.Util;
using bytebank_Atendimento.Conta;

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
#region Exemplos de uso do List
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

new ByteBankAtendimento().AtendimentoCliente();
