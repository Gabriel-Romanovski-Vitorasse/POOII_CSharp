using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.model;
using WpfApp1.persistencia;

namespace WpfApp1.control
{
    class UVVkedinControle
    {
        private UVVkedin modeloii = new();

        public List<UVVkedin> ControleRecuperarTodasII()
        {
            return modeloii.RecuperarTodasII();
        }

        public UVVkedin? ControleRecuperarIIPeloEmail(string email)
        {
            return modeloii.RecuperarIIPeloEmail(email);
        }

        public Boolean ControlCadastrarII(String apelido, string email, string telefone)
        {
            UVVkedin ii = new()
            {
                Apelido = apelido,
                Email = email,
                Telefone = telefone
            };

            if (modeloii.CadastrarII(ii))
                return true;
            return false;
        }
    }
}
