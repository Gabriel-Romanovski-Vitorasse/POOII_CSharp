using IdeiasInovadoras.model;
using IdeiasInovadoras.persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Ink;

namespace IdeiasInovadoras.control
{
    internal class IdeiasInovadoraControle
    {

        private IdeiaInovadora modeloii = new();

        public Boolean ControlCadastrarII(String area, string ideia, float custo)
        {

            ideia = ideia + "!!!!!!";

            IdeiaInovadora ii = new()
            {
                Area = area,
                Ideia = ideia,
                Custo = custo
            };

            if (modeloii.CadastrarII(ii))
                return true;
            return false;
        }

    }
}
