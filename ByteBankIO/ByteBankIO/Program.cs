using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        var enderecoArquivo = "contas.txt";
        var numeroByteLidos = -1;

        var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open);

        var buffer = new byte[1024];
        

        while (numeroByteLidos != 0)
        {
            numeroByteLidos = fluxoArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);

        }

        fluxoArquivo.Read(buffer, 0, 1024);

        Console.ReadLine();
    }


    static void EscreverBuffer(byte[] buffer)
    {
        foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
    }
}