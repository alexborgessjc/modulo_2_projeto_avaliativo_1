using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Enums;

namespace Principal.Entidades
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; private set; }
        public TipoCategoriaEnum TipoCategoria { get; private set; }

        public Categoria(string id, string nome, TipoCategoriaEnum tipoCategoria) : base(id)
        {
            Nome = nome;
            TipoCategoria = tipoCategoria;
        }
    }
}
