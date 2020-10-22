using Estoque_WPF_1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;


namespace Estoque_WPF_1.Telas
{
    /// <summary>
    /// Lógica interna para TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {

        public TelaPrincipal()
        {
            InitializeComponent();

            LerProdutos();

        }

        public void LerProdutos()
        {
            using (DBEstoque dBEstoque = new DBEstoque())
            {
                List<Produto> lista = new List<Produto>();


                lista = dBEstoque.Produtos.ToList();

                foreach (var x in lista)
                {
                    TabelaDB.Items.Add(x);
                }
            }
        }


        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {

            TelaCadastroProduto telacadastroproduto = new TelaCadastroProduto();
            telacadastroproduto.Show();

            this.Close();
        }

        private void ButtonDeletar_Click(object sender, RoutedEventArgs e)
        {

            //string caminhoimagem;

            MessageBoxResult resultado = MessageBox.Show("Tem certeza que deseja excluir o produto?", "Deletar Produto", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                                
                using (DBEstoque dBEstoque = new DBEstoque())
                {

                    var produtotabela = (Produto)TabelaDB.SelectedCells[0].Item; //Seleciona o item da celula correspondente e adiciona implicitamente em uma variavel produto

                    Produto y = dBEstoque.Produtos.Find(produtotabela.Codigo); //Procura o produto selecionado da tabela no banco de dados

                    dBEstoque.Produtos.Remove(y); //remove o produto do bando de dados
                    dBEstoque.SaveChanges();

                   // caminhoimagem = y.ImagemPr;

                    MessageBox.Show("O Produto foi Deletado", "Produto Deletado", MessageBoxButton.OK, MessageBoxImage.Information);
                                                          
                }
                this.Hide();
                TelaPrincipal tela = new TelaPrincipal();
                tela.Show();
                
            }

        }

        private void ButtonAlterar_Click(object sender, RoutedEventArgs e)
        {
            
            using (DBEstoque dBEstoque = new DBEstoque())
            {
                var produtoTabela = (Produto)TabelaDB.SelectedCells[0].Item;

                TelaAlterarProduto telaAlterarProd = new TelaAlterarProduto();
                telaAlterarProd.Show();

                telaAlterarProd.TextCodProd.Text = produtoTabela.Codigo.ToString();
                telaAlterarProd.TextNomeProd.Text = produtoTabela.Nome.ToString();
                telaAlterarProd.TextDesProd.Text = produtoTabela.Descricao.ToString();
                telaAlterarProd.TextPreProd.Text = produtoTabela.Preco.ToString();
                telaAlterarProd.TextQtdProd.Text = produtoTabela.Quantidade.ToString();
                                               
                                
            }
            this.Close();
        }
    }
}
