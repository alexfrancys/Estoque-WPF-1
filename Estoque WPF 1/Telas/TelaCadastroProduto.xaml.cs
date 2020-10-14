using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Estoque_WPF_1.Telas
{
    /// <summary>
    /// Lógica interna para TelaCadastroProduto.xaml
    /// </summary>
    public partial class TelaCadastroProduto : Window
    {
        public TelaCadastroProduto()
        {
            InitializeComponent();
        }

        private void ButtonCarregarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog TeladeSelecao = new OpenFileDialog();
            TeladeSelecao.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            TeladeSelecao.CheckFileExists = true;

                     
            if(TeladeSelecao.ShowDialog() == true)
            {
                Uri FileUri = new Uri(TeladeSelecao.FileName); //Pega o local do arquivo                
                ImagemCarregada.Stretch = Stretch.Uniform;                
                ImagemCarregada.Source = new BitmapImage(FileUri);
               
            }
        }
    }
}
