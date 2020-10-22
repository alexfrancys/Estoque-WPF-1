using Estoque_WPF_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Estoque_WPF_1.Telas
{
    /// <summary>
    /// Lógica interna para TelaCadastro.xaml
    /// </summary>
    public partial class TelaCadastro : Window
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        public void ClickCadastrar(object sender, RoutedEventArgs e)
        {
            if (textSenhaCadastro.Password == textConfirmaSenha.Password && textSenhaCadastro.Password != null)
            {
                Funcionario funcionario = new Funcionario
                {
                    Matricula = int.Parse(textMatriculaCadastro.Text.Trim()),
                    Nome = textNomeCadastro.Text.ToString(),
                    Cpf = int.Parse(textMatriculaCadastro.Text.Trim()),
                    Telefone = int.Parse(textTelefoneCadastro.Text.Trim()),
                    Senha = textSenhaCadastro.Password.Trim()               
                };
              
            using (DBEstoque dBEstoque = new DBEstoque())
                {
                    dBEstoque.Funcionarios.Add(funcionario);
                    dBEstoque.SaveChanges();
                }
                MessageBox.Show("Usuário Cadastrado", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                MainWindow telaLogin = new MainWindow();
                telaLogin.Show();
            }
            else
            {
                MessageBox.Show("As senhas não são iguais ou campo de senha vazia.", "Senha Inválida", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }


        public void ClickCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow telaLogin = new MainWindow();
            telaLogin.Show();
        }
    }
}
