using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Entidades;

namespace Principal.Models
{
    public class TransacoesPorCategoriaModel
    {
        public Categoria Categoria { get; set; }
        public IEnumerable<Transacao> Transacoes { get; set; }
    }
}
