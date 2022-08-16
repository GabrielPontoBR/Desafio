using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio.Models
{
    public class Ifes
    {   
        [Key]
        public string cnpj { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }



    }
}