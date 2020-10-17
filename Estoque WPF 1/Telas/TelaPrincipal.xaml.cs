using Estoque_WPF_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


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
            DBEstoque dBEstoque = new DBEstoque();
            List<Produto> lista = new List<Produto>();            

            
            lista = dBEstoque.Produtos.ToList();

            foreach (var x in lista)
            {              
                TabelaDB.Items.Add(x);       

            }
        }


        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            TelaCadastroProduto telacadastroproduto = new TelaCadastroProduto();

            telacadastroproduto.Show();

        }
    }
}
