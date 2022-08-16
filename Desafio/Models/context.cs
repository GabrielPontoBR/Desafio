using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desafio.Models
{
    public class context: DbContext
    {
        public DbSet <Ifes> Fundacoes { get; set; }
    }
}