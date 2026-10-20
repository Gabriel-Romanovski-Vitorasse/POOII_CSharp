using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Text;

namespace BDWpfApp1Empregado.Model
{
    internal class Empregado
    {
        public int Matricula { get; set; } = 0;
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }

        public Empregado() { }
        public Empregado(string CpF, string nome, string endereco)
        {
            CPF = CpF;
            Nome = nome;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return $"Empregado -> Matricula: {Matricula} | CPF: {CPF}" + 
                $"Nome: {Nome} | Endereco: {Endereco}";
        }
        public void Salvar(SqlConnection conexao) 
        {
            Console.WriteLine("=== Salvando Empregado ===");
            if (Matricula == 0) { 
                var Cmd = conexao.CreateCommand();
                Cmd.CommandText = "INSERT INTO Empregado (CPF, Nome, Endereco) VALUES (@cpf, @nome, @endereco)";

                Cmd.Parameters.Add(new SqlParameter("cpf", CPF));
                Cmd.Parameters.Add(new SqlParameter("nome", Nome));
                Cmd.Parameters.Add(new SqlParameter("endereco", Endereco));

                Cmd.ExecuteNonQuery();
            }
        }
        public List<Empregado>? Pesquisar(int matriculaParam, SqlConnection conexao) {
            Console.WriteLine("== Recuperando Empregado ==");
            List<Empregado>? EmpregadoSLido = null;

            var Cmd = conexao.CreateCommand();

            if(matriculaParam == 0)
            {
                Cmd.CommandText = "SELECT * FROM Empregado";
            }
            else
            {
                Cmd.CommandText = "SELECT * FROM Empregado WHERE Matricula = @matricula";
                Cmd.Parameters.Add(new SqlParameter("matricula", matriculaParam));
            }

            var resultado = Cmd.ExecuteReader();

            if(resultado != null)
            {
                EmpregadoSLido = new();

                while (resultado.Read())
                {
                    Empregado EmpregadoLido = new()
                    {
                        Matricula = resultado.GetInt32("Matricula"),
                        CPF = resultado.GetString("CPF"),
                        Nome = resultado.GetString("Nome"),
                        Endereco = resultado.GetString("Endereco")
                    };
                    EmpregadoSLido.Add(EmpregadoLido);
                }
                resultado.Close();
            }
            return EmpregadoSLido;
        }
        public void Excluir() { }
        public void Alterar() { }
    }

}
