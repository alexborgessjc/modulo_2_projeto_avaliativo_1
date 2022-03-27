using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Entidades
{
    public abstract class EntidadeBase
    {
        public string Id { get; private set; }
        protected EntidadeBase() { }
        protected EntidadeBase(string id) => Id = id;
    }
}
