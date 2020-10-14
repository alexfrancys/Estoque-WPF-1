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
            TelaCadastro telaCadastro = new TelaCadastro();
            telaCadastro.Close();
        }


        public void ClickCancelar(object sender, RoutedEventArgs e)
        {
            TelaCadastro telaCadastro = new TelaCadastro();
            telaCadastro.Close();
        }
    }
}
