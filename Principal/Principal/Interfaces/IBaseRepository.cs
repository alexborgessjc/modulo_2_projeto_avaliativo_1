using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Entidades;

namespace Principal.Interfaces
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        public void AdicionarElemento(T elemento);

        public void ApagarElemento(string id);

        public T RetornarElemento(string id);
    }
}
