﻿using Estoque_WPF_1.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Estoque_WPF_1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                      
        }

        public void ClickEntrar(object sender, RoutedEventArgs e)
        {
            if (Textosenha.Password == "admin" && Textousuario.Text == "admin")
            {
                Textousuario.Clear();
                Textosenha.Clear();
                TelaPrincipal TelaPrincipal = new TelaPrincipal();
                TelaPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Login Inválido!!!", "Erro ao Logar", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
        }

        public void ClickNovoCadastro(object sender, RoutedEventArgs e)
        {
            TelaCadastro TelaCadastro = new TelaCadastro();
            TelaCadastro.Show();   
        }
    }
}