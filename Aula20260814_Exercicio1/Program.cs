internal class Program
{
    static void Main(string[] args)
    {
        int idade;
        float total = 0, qtdeA = 0, qtdeB = 0, qtdeC = 0, qtdeD = 0, qtdeE = 0;

        Console.WriteLine("========================================");
        Console.WriteLine("Gestão de Pessoas");
        Console.WriteLine("========================================");

        do {
            Console.WriteLine("Digite a idade:");
            idade = int.Parse(Console.ReadLine());
            if (idade < 1) { }
            switch (idade)
            {
                case < 16:
                    qtdeA++;
                    total++;
                    break;
                case < 31:
                    qtdeB++;
                    total++;
                    break;
                case < 46:
                    qtdeC++;
                    total++;
                    break;
                case < 61:
                    qtdeD++;
                    total++;
                    break;
                case >= 61:
                    qtdeE++;
                    total++;
                    break;
            }
        } while (idade > 0);
        Console.WriteLine($"Total de Participantes: {total}");
        Console.WriteLine($"Quantidade de Pessoas na Faixa A (0-15): {qtdeA}");
        Console.WriteLine($"Quantidade de Pessoas na Faixa B (16-30): {qtdeB}");
        Console.WriteLine($"Quantidade de Pessoas na Faixa C (31-45): {qtdeC}");
        Console.WriteLine($"Quantidade de Pessoas na Faixa D (46-60): {qtdeD}");
        Console.WriteLine($"Quantidade de Pessoas na Faixa E (61+): {qtdeE}");

    }
}