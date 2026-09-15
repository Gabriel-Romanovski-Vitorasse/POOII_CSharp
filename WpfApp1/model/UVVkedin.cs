using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.persistencia;

namespace WpfApp1.model
{
    class UVVkedin
    {
        public int Id { get; set; }
        public string? Apelido { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public List<UVVkedin> RecuperarTodasII()
        {
            return BD.RetornarBD();
        }

        public UVVkedin? RecuperarIIPeloID(int id)
        {
            return BD.RetornarBDPeloID(id);
        }

        public Boolean CadastrarII(UVVkedin ii)
        {
            BD.SalvarBD(ii);

            return true;
        }
    }
}
