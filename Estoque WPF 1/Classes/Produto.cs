﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_WPF_1.Classes
{
    public class Produto
    {
        [Key]        
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public int Quantidade { get; set; }
        public string ImagemPr { get; set; }
    }
}
