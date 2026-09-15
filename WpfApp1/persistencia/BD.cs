using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.model;

namespace WpfApp1.persistencia
{
    class BD
    {
        public static int IndexGlobal { get; set; } = 0;

        public static List<UVVkedin> mybd = new();

        //public static void SalvarBD(IdeiaInovadora ii) => mybd.Add(ii);
        public static void SalvarBD(UVVkedin ii)
        {
            ii.Id = ++IndexGlobal;
            mybd.Add(ii);
        }

        public static UVVkedin? RetornarBDPeloID(int id)
        {

            UVVkedin? objRetornado;
            objRetornado = mybd.Find(x => { return x.Id == id; });

            return objRetornado;
        }

        public static List<UVVkedin> RetornarBD() => mybd;
    }
}
