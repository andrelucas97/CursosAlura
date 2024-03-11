namespace bytebank_Atendimento.Conta;

public class ContaCorrente : IComparable<ContaCorrente>
{
    public Cliente Titular { get; set; }
    public string Nome_Agencia { get; set; }    

    private int _numero_agencia;
    public int Numero_agencia
    {
        get
        {
            return _numero_agencia;
        }
        set
        {
            if (value <= 0)
            {

            }
            else
            {
                _numero_agencia = value;
            }
        }

    }

    private string _conta;
    public string Conta
    {
        get
        {
            return _conta;
        }
        set
        {
            if (value == null)
            {
                return;
            }
            else
            {
                _conta = value;
            }
        }
    }

    private double saldo;
    public double Saldo
    {
        get
        {
            return saldo;
        }
        set
        {
            if (value < 0)
            {
                return;
            }
            else
            {
                saldo = value;
            }
        }
    }

    public int TotalContasCriadas { get; set; }

    public bool Sacar(double valor)
    {
        if (saldo < valor)
        {
            return false;
        }
        if (valor < 0)
        {
            return false;
        }
        else
        {
            saldo = saldo - valor;
            return true;
        }
    }

    public void Depositar(double valor)
    {
        if (valor < 0)
        {
            return;
        }
        saldo = saldo + valor;
    }

    public bool Transferir(double valor, ContaCorrente destino)
    {
        if (saldo < valor)
        {
            return false;
        }
        if (valor < 0)
        {
            return false;
        }
        else
        {
            saldo = saldo - valor;
            destino.saldo = destino.saldo + valor;
            return true;
        }
    }

    public int CompareTo(ContaCorrente? other)
    {
        if (other == null)
        {
            return 1;
        }
        else
        {
            return this.Numero_agencia.CompareTo(other.Numero_agencia);
        }
    }

    public ContaCorrente(int numero_conta, string conta)
    {
        Numero_agencia = numero_conta;
        Conta = conta;
        Titular = new Cliente();
        TotalContasCriadas += 1;
    }

    public ContaCorrente(int numero_conta)
    {
        Numero_agencia = numero_conta;
        Conta = Guid.NewGuid().ToString().Substring(0, 8);
        Titular = new Cliente();
        TotalContasCriadas += 1;
    }


    public override string ToString()
    {

        return $" === DADOS DA CONTA === \n" +
               $"Número da Conta : {this.Conta} \n" +
               $"Saldo da Conta: {this.Saldo} \n" +
               $"Titular da Conta: {this.Titular.Nome} \n" +
               $"CPF do Titular  : {this.Titular.Cpf} \n" +
               $"Profissão do Titular: {this.Titular.Profissao} \n\n";
    }
}
