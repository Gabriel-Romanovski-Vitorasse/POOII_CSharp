using IdeiasInovadoras.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeiasInovadoras.persistencia
{
    internal class BD
    {
        public static List<IdeiaInovadora> mybd = new();

        public static void SalvarBD(IdeiaInovadora ii) => mybd.Add(ii);

        public static List<IdeiaInovadora> RetornarBD() => mybd;
    }
}
