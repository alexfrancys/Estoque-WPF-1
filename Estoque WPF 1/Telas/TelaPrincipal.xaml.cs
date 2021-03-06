﻿using Estoque_WPF_1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

            LerProdutosAsync();

        }

        public async void LerProdutosAsync()
        {
            try
            {
                using (DBEstoque dBEstoque = new DBEstoque())
                {
                    List<Produto> lista = new List<Produto>();


                    lista = await dBEstoque.Produtos.ToListAsync();

                    foreach (var x in lista)
                    {
                        TabelaDB.Items.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {

            TelaCadastroProduto telacadastroproduto = new TelaCadastroProduto();
            telacadastroproduto.Show();

            this.Close();
        }

        private async void ButtonDeletar_ClickAsync(object sender, RoutedEventArgs e)
        {

            MessageBoxResult resultado = MessageBox.Show("Tem certeza que deseja excluir o produto?", "Deletar Produto", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                try
                {

                    using (DBEstoque dBEstoque = new DBEstoque())
                    {

                        var produtotabela = (Produto)TabelaDB.SelectedCells[0].Item; //Seleciona o item da celula correspondente e adiciona implicitamente em uma variavel produto

                        Produto y = await dBEstoque.Produtos.FindAsync(produtotabela.Codigo); //Procura o produto selecionado da tabela no banco de dados

                        dBEstoque.Produtos.Remove(y); //remove o produto do bando de dados
                        await dBEstoque.SaveChangesAsync();


                        MessageBox.Show("O Produto foi Deletado", "Produto Deletado", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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
