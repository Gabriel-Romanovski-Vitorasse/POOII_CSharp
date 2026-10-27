using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BDWpfApp1Empregado.Model
{
    class Dept
    {
        public int ID { get; set; } = 0;
        public string? Name { get; set; }
        public string? Email { get; set; }


        public void Salvar(SqlConnection conexao)
        {
            Console.WriteLine("=== Salvando Dept ===");
            if (ID == 0)
            {
                var Cmd = conexao.CreateCommand();
                Cmd.CommandText = "INSERT INTO DEPT (Name, Email) VALUES (@name, @email)";

                Cmd.Parameters.Add(new SqlParameter("name", Name));
                Cmd.Parameters.Add(new SqlParameter("email", Email));

                Cmd.ExecuteNonQuery();
            }
        }

        public List<Dept>? Recuperar(int idParam, SqlConnection conexao)
        {
            Console.WriteLine("== Recuperando Dept ==");
            List<Dept>? DeptSLido = null;

            var Cmd = conexao.CreateCommand();

            if (idParam == 0)
            {
                Cmd.CommandText = "SELECT * FROM DEPT";
            }
            else
            {
                Cmd.CommandText = "SELECT * FROM DEPT WHERE ID = @id";
                Cmd.Parameters.Add(new SqlParameter("id", idParam));
            }

            var resultado = Cmd.ExecuteReader();

            if (resultado != null)
            {
                DeptSLido = new();

                while (resultado.Read())
                {
                    Dept DeptLido = new()
                    {
                        ID = resultado.GetInt32("ID"),
                        Name = resultado.GetString("Name"),
                        Email = resultado.GetString("Email")
                    };
                    DeptSLido.Add(DeptLido);
                }
                resultado.Close();
            }
            return DeptSLido;
        }

    }
}
