using BDWpfApp1Empregado.Control;
using BDWpfApp1Empregado.Model;
using BDWpfApp1Empregado.View;
using Microsoft.Data.SqlClient;
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

namespace BDWpfApp1Empregado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IVerificar_LimparCampos
    {
        SqlConnection? conexao = null;
        BindingList<Empregado> objClasseListDataGridEmpregado = new();

        public MainWindow()
        {
            InitializeComponent();

            DataGridEmpregadoList.ItemsSource = objClasseListDataGridEmpregado;

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
                MessageBox.Show(ex.Message);
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
        public bool VerificarCampos()
        {
            return TextBoxMatricula.Text == "" &&
                TextBoxCPF.Text != "" &&
                TextBoxNome.Text != "" &&
                TextBoxEndereco.Text != "";
        }

        public void LimparCampos()
        {
            TextBoxMatricula.Text = ""; TextBoxCPF.Text = "";
            TextBoxNome.Text = ""; TextBoxEndereco.Text = "";
        }

        private void ButtonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Empregado emp = new();

            List<Empregado>? ret = null;
            
            if(conexao != null)
            {
                if(TextBoxMatricula.Text == "")
                {
                    ret = emp.Pesquisar(0, conexao);
                }
                else
                {
                    ret = emp.Pesquisar(int.Parse(TextBoxMatricula.Text), conexao);
                }
            }
            if(ret != null)
            {
                LabelStatus.Content = "Pesquisa Ok";

                objClasseListDataGridEmpregado = new(ret);
                DataGridEmpregadoList.ItemsSource = objClasseListDataGridEmpregado;
            }
            LimparCampos();
        }

        private void ButtonExcluir_Click(object sender, RoutedEventArgs e)
        {
            Empregado emp = new();

            if(conexao != null)
            {
                if(TextBoxMatricula.Text != "")
                {
                    emp.Excluir(int.Parse(TextBoxMatricula.Text), conexao);
                    LabelStatus.Content = "Exclusão OK";
                }
                else
                {
                    LabelStatus.Content = "Exclusão NOT";
                }
            }
        }

        private void ButtonLimpar_Click(object sender, RoutedEventArgs e)
        {
            if (conexao != null)
            {
                if (!string.IsNullOrWhiteSpace(TextBoxMatricula.Text))
                {
                    LabelStatus.Content = "Deixe a matrícula vazia para limpar tudo";
                }

                var resposta = MessageBox.Show(
                    "Isso apagará TODOS os empregados. Deseja continuar?",
                    "Confirmar limpeza",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (resposta != MessageBoxResult.Yes) return;

                Empregado emp = new();
                emp.Limpar(conexao);
                LabelStatus.Content = "Limpeza OK";
                emp.Resetar(conexao);
            }
        }

        private void ButtonTrocar_Click(object sender, RoutedEventArgs e)
        {
            var dept = new DeptInterface();
            dept.Show();   // abre a DEPT
            this.Close();  // fecha a atual (ou remova para manter as duas abertas)
        }
    }
}