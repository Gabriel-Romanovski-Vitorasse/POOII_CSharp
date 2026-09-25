using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.control;
using WpfApp1.model;
using WpfApp1.persistencia;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UVVkedinControle controleii = new();
        private BindingList<UVVkedin> objBind = new();
        public MainWindow()
        {
            InitializeComponent();
            DataGridUVVkedin.ItemsSource= objBind;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxApelido.Text) && !string.IsNullOrWhiteSpace(TextBoxEmail.Text)) {
                if (controleii.ControlCadastrarII(TextBoxApelido.Text, TextBoxEmail.Text, TextBoxTelefone.Text))
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!");
                }
            }
        }

        private void Button_Listar_Click(object sender, RoutedEventArgs e)
        {
            List<UVVkedin> DadosRecuperados = null;
            DataGridUVVkedin.ItemsSource = null;

            var id = TextBoxEmail.Text;

            if (string.IsNullOrEmpty(id))
            {
                DadosRecuperados = controleii.ControleRecuperarTodasII();
            }
            else
            {
                var ret = controleii.ControleRecuperarIIPeloEmail(id);

                if (ret != null)
                {
                    DadosRecuperados = new() { ret };
                }
            }

            DadosRecuperados = controleii.ControleRecuperarTodasII();

            objBind = new(DadosRecuperados);

            DataGridUVVkedin.ItemsSource = objBind;

        }
    }
}