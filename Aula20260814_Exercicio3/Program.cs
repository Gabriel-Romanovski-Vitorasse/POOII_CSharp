internal class Program
{
    static void Main(string[] args)
    {
        int dias = 0;
        float TotalTemp = 0, Temp;

        Console.WriteLine("========================================");
        Console.WriteLine("Monitoramento da Temperatura do Verão");
        Console.WriteLine("========================================");

        do {
            do
            {
                Console.WriteLine($"Digite a Temperatura do dia {dias + 1}:");
                bool TempF = float.TryParse(Console.ReadLine(), out Temp);
                if (!TempF) Console.WriteLine("Entrada inválida, não é um número.");
                else if (Temp < 29) Console.WriteLine("Abaixo do Esperado.");
            } while (Temp < 29);
            TotalTemp += Temp;
            dias++;
        } while (dias < 15);

        Console.WriteLine("========================================");
        Console.WriteLine($"Temperatura media do Verão: {TotalTemp / dias}");
    }
}