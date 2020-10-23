using Estoque_WPF_1.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Estoque_WPF_1.Telas
{
    /// <summary>
    /// Lógica interna para TelaCadastroProduto.xaml
    /// </summary>
    public partial class TelaCadastroProduto : Window
    {
        string caminhoimagem;

        public TelaCadastroProduto()
        {
            InitializeComponent();
        }

        public string SalvarImagem()
        {
            try
            {
                string tipoimagem = Path.GetExtension(caminhoimagem);
                string nomeAleatorio = Path.GetRandomFileName();
                string caminhoDestinoImg = @"c:\Estoque by Alex\Imagens\" + nomeAleatorio + tipoimagem;

                Directory.CreateDirectory(@"c:\Estoque by Alex\Imagens"); //criar o repositório das imagens
                File.Copy(caminhoimagem, caminhoDestinoImg); //copiar a imagem selecionada com o nome sendo o codigo do produto para o repositório

                return caminhoDestinoImg;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private void ButtonCarregarImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog teladeSelecao = new OpenFileDialog
                {
                    Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*",
                    CheckFileExists = true
                };


                if (teladeSelecao.ShowDialog() == true)
                {
                    Uri fileUri = new Uri(teladeSelecao.FileName); //Pega o local do arquivo                     
                    ImagemCarregada.Source = new BitmapImage(fileUri);
                }
                caminhoimagem = teladeSelecao.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            TelaPrincipal TelaPrincipal = new TelaPrincipal();
            TelaPrincipal.Show();
        }

        private async void ButtonCadastrar_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBEstoque dBEstoque = new DBEstoque())
                {
                    Produto produto = new Produto
                    {
                        Nome = TextNomeProd.Text,
                        Descricao = TextDesProd.Text.ToString(),
                        Preco = double.Parse(TextPreProd.Text.Trim()),
                        ImagemPr = SalvarImagem(),
                        Quantidade = int.Parse(TextQtdProd.Text.Trim())
                    };

                    dBEstoque.Produtos.Add(produto);
                    await dBEstoque.SaveChangesAsync();
                }

                MessageBox.Show("Produto Cadastrado", "Produto Cadastrado", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\nOs campos Preço e Quantidade aceitam somente números. Produto não Cadastrado.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            TelaPrincipal TelaPrincipal = new TelaPrincipal();
            TelaPrincipal.Show();
            this.Close();
        }
    }
}
