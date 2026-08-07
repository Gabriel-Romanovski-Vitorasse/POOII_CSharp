namespace Exercicio_V1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgendaTelefonica ag01 = new AgendaTelefonica();
            ag01.Inserir("Paulo", "27999887766");
            ag01.Inserir("Ana", "27988776655");
            ag01.Inserir("Carlos", "27977665544");
            ag01.Inserir("Fernanda", "27966554433");
            ag01.Inserir("Ricardo", "27955443322");
            Console.WriteLine(ag01.BuscarNumero("Paulo"));
            Console.WriteLine(ag01.Tamanho);
        }
    }
}