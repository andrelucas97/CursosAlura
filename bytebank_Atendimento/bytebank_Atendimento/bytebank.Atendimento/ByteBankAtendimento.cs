using bytebank_Atendimento.bytebank.Exceptions;
using bytebank_Atendimento.Conta;

namespace bytebank_Atendimento.bytebank.Atendimento;

internal class ByteBankAtendimento
{
#nullable disable
    private List<ContaCorrente> _listaContas = new List<ContaCorrente>()
{
    new ContaCorrente(95, "123456-X") {Saldo=100, Titular = new Cliente{Cpf="11111", Nome = "Henrique" } },
    new ContaCorrente(95, "951258-X") {Saldo=200, Titular = new Cliente{Cpf="22222", Nome = "Pedro" } },
    new ContaCorrente(94, "987321-W") {Saldo=60, Titular = new Cliente{Cpf="33333", Nome = "Marisa" } }
};
    public void AtendimentoCliente()
    {
        try
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
                Console.WriteLine("====================================\n");

                Console.Write("\nDigite a opção desejada: ");
                try
                {
                    opcao = Console.ReadLine()[0];

                }
                catch (Exception excecao)
                {
                    throw new ByteBankException(excecao.Message);
                }
                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarConta();
                        break;
                    case '3':
                        RemoverConta();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        PesquisarConta();
                        break;
                    case '6':
                        EncerrarApp();
                        break;
                    default:
                        Console.WriteLine("Opção não implementada.");
                        break;
                }
            }
        }
        catch (ByteBankException excecao)
        {
            Console.WriteLine($"{excecao.Message}");
        }

    }

    private void EncerrarApp()
    {
        Console.WriteLine("... Encerrando aplicação ...");
        Console.ReadKey();
    }

    private void PesquisarConta()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("===     PESQUISAR CONTAS     ===");
        Console.WriteLine("================================\n");
        Console.Write("Deseja pesquisar por: \n1 - NUMERO DA CONTA \n2 - CPF TITULAR \n3 - Nº AGÊNCIA \nOpção: ");
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                Console.Write("Informe o número da conta: ");
                string _numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorNumero(_numeroConta);
                Console.WriteLine(consultaConta.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
                break;
            case 2:
                Console.Write("Informe o CPF do Titular: ");
                string _cpf = Console.ReadLine();
                ContaCorrente consultaCPF = ConsultaPorCPF(_cpf);
                Console.WriteLine(consultaCPF.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();

                break;
            case 3:
                Console.Write("Informe o Nº da Agência: ");
                int _numeroAgencia = int.Parse(Console.ReadLine());
                var contasporAgencia = ConsultaPorAgencia(_numeroAgencia);
                ExibirListaContas(contasporAgencia);
                Console.ReadKey();

                break;
        }
    }

    private void ExibirListaContas(List<ContaCorrente> contasporAgencia)
    {
        if (contasporAgencia == null)
        {
            Console.WriteLine("... A consulta não retornou dados");
        }
        else
        {
            foreach (var item in contasporAgencia)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
    {
        var consulta = (
            from conta in _listaContas
            where conta.Numero_agencia == numeroAgencia
            select conta).ToList();
        return consulta;
    }

    private ContaCorrente ConsultaPorCPF(string? cpf)
    {
        ContaCorrente conta = null;
        //for (int i = 0; i < _listaContas.Count; i++)
        //{
        //    if (_listaContas[i].Titular.Cpf.Equals(cpf))
        //    {
        //        conta = _listaContas[i];
        //    }
        //}
        //return conta;

        return _listaContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    }

    private ContaCorrente ConsultaPorNumero(string? numeroConta)
    {
        //ContaCorrente conta = null;
        //for (int i = 0; i < _listaContas.Count; i++)
        //{
        //    if (_listaContas[i].Conta.Equals(numeroConta)){
        //        conta = _listaContas[i];

        //    }
        //}
        //return conta;

        return _listaContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();

    }

    private void OrdenarContas()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("===      ORDENAR CONTAS      ===");
        Console.WriteLine("================================\n");

        _listaContas.Sort();
        Console.WriteLine("... Lista de contas ordenada!");
        Console.ReadKey();
    }

    private void RemoverConta()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("===      REMOVER CONTAS      ===");
        Console.WriteLine("================================\n");
        Console.Write("Informe o número da Conta: ");
        string numeroConta = Console.ReadLine();
        ContaCorrente conta = null;

        foreach (var item in _listaContas)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
            }
        }
        if (conta != null)
        {
            Console.Write("Deseja realmente remover esta conta? Digite 'SIM' para confirmar ou 'NAO' para cancelar: ");
            string confirm = Console.ReadLine();

            if (confirm == "SIM")
            {
                _listaContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
                Console.ReadKey();
            }
            else if (confirm == "NAO")
            {
                Console.WriteLine("Conta não removida!");
                Console.ReadKey();

            }

        }
        else
        {
            Console.WriteLine("... Conta para remoção não encontrada ...");
            Console.ReadKey();

        }
    }

    private void ListarConta()
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

        foreach (ContaCorrente item in _listaContas)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("===    CADASTRO DE CONTAS    ===");
        Console.WriteLine("================================\n");
        Console.WriteLine("===  Informe dados da Conta  ===");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia);
        Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");
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
}
