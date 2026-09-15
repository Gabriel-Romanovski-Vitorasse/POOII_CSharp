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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TextBoxApelido.Text) && !string.IsNullOrWhiteSpace(TextBoxEmail.Text)) {
                if (controleii.ControlCadastrarII(TextBoxApelido.Text, TextBoxEmail.Text, TextBoxTelefone.Text))
                {
                    MessageBox.Show("PQP");
                }
            }
        }
    }
}