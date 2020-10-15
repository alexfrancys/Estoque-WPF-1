using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_WPF_1.Classes
{
    public class Funcionario
    {
        [Key]
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public int Telefone { get; set; }
        public string Senha { get; set; }

    }
}
