using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
        }
        public void Excluir() { }
        public void Alterar() { }
    }

}
