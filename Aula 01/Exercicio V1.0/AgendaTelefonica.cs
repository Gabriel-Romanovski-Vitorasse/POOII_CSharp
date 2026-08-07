using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_V1._0
{
    internal class AgendaTelefonica
    {
        Dictionary<string, string> colecao = new Dictionary<string, string>();

        public void Inserir(string Nome, string numero)
        {
            colecao.Add(Nome, numero);
        }

        public string BuscarNumero(string Nome)
        {
            return colecao[Nome];
        }

        public void Remover(string Nome)
        {
            colecao.Remove(Nome);
        }

        public int Tamanho()
        {
            return colecao.Count;
        }

        public void Exibir()
        {
            for (int i = 0; i < colecao.Count; i++)
            {
                
            }
        }
    }
}
