using IdeiasInovadoras.control;
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

namespace IdeiasInovadoras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IdeiasInovadoraControle controleii = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxArea.Text) && !string.IsNullOrWhiteSpace(TextBoxIdeia.Text))

            {
                if (controleii.ControlCadastrarII(TextBoxArea.Text, TextBoxIdeia.Text, float.Parse(TextBoxCusto.Text)))
                {
                    MessageBox.Show("Cadastro realizado com sucesso!!");
                }
            }
            else
            {
                MessageBox.Show("ERRO: Campos Obrigatórios não preenchidos.");
            }
        }
    }
}