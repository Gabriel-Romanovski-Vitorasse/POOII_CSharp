using Microsoft.Data.SqlClient;

namespace AulaBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conexao;
            conexao = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyUniversidadeBD;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            conexao.Open();
            Console.WriteLine("Conexao OK");

            Console.WriteLine(" == Salvando os dados no BD == ");

            var insCmd = conexao.CreateCommand();
            insCmd.CommandText = "INSERT INTO Cursos (Nome, Categoria, Período) VALUES (@nome, @categoria, @periodo)";

            var param = new SqlParameter("nome", "POOII");
            insCmd.Parameters.Add(param);
            insCmd.Parameters.Add(new SqlParameter("categoria", "Maneiro"));
            insCmd.Parameters.Add(new SqlParameter("periodo", 4));

            insCmd.ExecuteNonQuery();

            conexao.Close();
            Console.WriteLine(" == Salvo no BD == ");
        }
    }
}
