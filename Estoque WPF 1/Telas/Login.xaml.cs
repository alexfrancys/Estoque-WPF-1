﻿using Estoque_WPF_1.Classes;
using Estoque_WPF_1.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


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

        public bool ValidarLogin()
        {            
            using (DBEstoque dBEstoque = new DBEstoque())
            {
                List<Funcionario> Listafuncionarios = new List<Funcionario>();

                Listafuncionarios = dBEstoque.Funcionarios.ToList();

                foreach (Funcionario x in Listafuncionarios)
                {
                    if (x.Matricula == (int.Parse(Textousuario.Text)) && x.Senha == Textosenha.Password)
                    {                        
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClickEntrar(object sender, RoutedEventArgs e)
        {
            if (ValidarLogin() == true)
            {
                this.Close();
                TelaPrincipal TelaPrincipal = new TelaPrincipal();
                TelaPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Matricula ou Senha incorretas", "Erro de Login", MessageBoxButton.OK, MessageBoxImage.Error);                
            }

        }

        public void ClickNovoCadastro(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TelaCadastro TelaCadastro = new TelaCadastro();
            TelaCadastro.Show();
        }

    }
}
