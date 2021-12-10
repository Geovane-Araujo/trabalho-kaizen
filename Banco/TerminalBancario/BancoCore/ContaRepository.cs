using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCore
{
    class ContaRepository
    {
        private readonly bancodbEntities _entities;
        public ContaRepository()
        {
            _entities = new bancodbEntities();
        }
    }
}
