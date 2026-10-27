using BDWpfApp1Empregado.Control;
using BDWpfApp1Empregado.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BDWpfApp1Empregado.View
{
    /// <summary>
    /// Lógica interna para DeptInterface.xaml
    /// </summary>
    public partial class DeptInterface : Window, IVerificar_LimparCampos
    {

        SqlConnection? conexao = null;
        BindingList<Dept> objClasseListDataGridDept = new();
        public DeptInterface()
        {
            InitializeComponent();

            DataGridDeptList.ItemsSource = objClasseListDataGridDept;

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

        private void ButtonTrocar_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void ButtonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Dept depar = new();

            List<Dept>? ret = null;

            if (conexao != null)
            {
                if (TextBoxID.Text == "")
                {
                    ret = depar.Recuperar(0, conexao);
                }
                else
                {
                    ret = depar.Recuperar(int.Parse(TextBoxID.Text), conexao);
                }
            }
            if (ret != null)
            {
                LabelStatus.Content = "Pesquisa Ok";

                objClasseListDataGridDept = new(ret);
                DataGridDeptList.ItemsSource = objClasseListDataGridDept;
            }
            LimparCampos();
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            Dept depar = new()
            {
                Name = TextBoxNome.Text,
                Email = TextBoxEmail.Text,
            };
            if (conexao != null && VerificarCampos())
            {
                depar.Salvar(conexao);
                LabelStatus.Content = "Salvar OK";
                LimparCampos();
            }
            else
            {
                LabelStatus.Content = "Salvo NOT";
            }
        }

        public bool VerificarCampos()
        {
            return TextBoxID.Text == "" &&
                TextBoxNome.Text != "" &&
                TextBoxEmail.Text != "";
        }

        public void LimparCampos()
        {
            TextBoxID.Text = ""; TextBoxNome.Text = "";
            TextBoxEmail.Text = "";
        }
    }
}
