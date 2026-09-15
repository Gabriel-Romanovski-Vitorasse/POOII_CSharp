using System;
using System.Collections.Generic;
using System.Text;
using IdeiasInovadoras.persistencia;

namespace IdeiasInovadoras.model
{
    internal class IdeiaInovadora
    {
        public string? Area { get; set; }
        public string? Ideia { get; set; }
        public float Custo { get; set; }

        public Boolean CadastrarII(IdeiaInovadora ii)
        {
            BD.SalvarBD(ii);

            return true;
        }
    }
}
