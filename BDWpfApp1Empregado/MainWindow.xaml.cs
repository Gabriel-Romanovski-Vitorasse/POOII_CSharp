using BDWpfApp1Empregado.Model;
using Microsoft.Data.SqlClient;
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

namespace BDWpfApp1Empregado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection? conexao = null;
        public MainWindow()
        {
            InitializeComponent();

            string url = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBEmpregadoGUI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            try
            {
                conexao = new(url);
                conexao.Open();
                LabelStatus.Content = "Conexão OK";
            }
            catch (Exception ex) 
            {
                LabelStatus.Content = "Conexão NOT";
                    Console.WriteLine(ex.Message);
            }
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            Empregado emp = new()
            {
                CPF = TextBoxCPF.Text,
                Nome = TextBoxNome.Text,
                Endereco = TextBoxEndereco.Text,
            };
            if (conexao != null && VerificarCampos()) { 
                emp.Salvar(conexao);
                LabelStatus.Content = "Salvar OK";
                LimparCampos();
            } else {
                LabelStatus.Content = "Salvo NOT";
            }
            
        }
        private bool VerificarCampos()
        {
            return TextBoxMatricula.Text == "" &&
                TextBoxCPF.Text != "" &&
                TextBoxNome.Text != "" &&
                TextBoxEndereco.Text != "";
        }

        private void LimparCampos()
        {
            TextBoxMatricula.Text = ""; TextBoxCPF.Text = "";
            TextBoxNome.Text = ""; TextBoxEndereco.Text = "";
        }

        private void ButtonPesquisar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}