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
    /// Lógica interna para TelaAlterarProduto.xaml
    /// </summary>
    public partial class TelaAlterarProduto : Window
    {
        public TelaAlterarProduto()
        {
            InitializeComponent();
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult resultado = MessageBox.Show("Tem certeza que deseja alterar o produto?", "Alterar Produto", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                using (DBEstoque dBEstoque = new DBEstoque())
                {
                    Produto produto = new Produto();

                    produto.Nome = TextNomeProd.Text;
                    produto.Descricao = TextDesProd.Text.ToString();
                    produto.Preco = double.Parse(TextPreProd.Text.Trim());
                    produto.Quantidade = int.Parse(TextQtdProd.Text.Trim());

                    var produtoselecionado = dBEstoque.Produtos.Where<Produto>(x => x.Codigo.ToString() == TextCodProd.Text).FirstOrDefault();

                    produtoselecionado.Codigo = int.Parse(TextCodProd.Text.ToString());
                    produtoselecionado.Nome = TextNomeProd.Text;
                    produtoselecionado.Descricao = TextDesProd.Text.ToString();
                    produtoselecionado.Preco = double.Parse(TextPreProd.Text.Trim());
                    produtoselecionado.Quantidade = int.Parse(TextQtdProd.Text.Trim());


                    dBEstoque.SaveChanges();
                }

                MessageBox.Show("Produto Alterado com sucesso", "Produto Alterado", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            TelaPrincipal TelaPrincipal = new TelaPrincipal();
            TelaPrincipal.Show();
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
