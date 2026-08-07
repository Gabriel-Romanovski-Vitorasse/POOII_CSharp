namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            carro c01 = new carro();
            c01.Modelo = "Fusca";
            c01.Ano = 1990;
            c01.Velo = 1;

            carro c02 = new();
            carro c03 = new() { Velo = 2, Ano = 2000, Modelo = "Fusca" };

            c01.acelerar();
            c01.Frear();
        }
    }
}
