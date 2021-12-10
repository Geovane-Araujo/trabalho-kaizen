using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCore
{
    class LancamentoRepository
    {
        private readonly bancodbEntities _entities;
        public LancamentoRepository()
        {
            _entities = new bancodbEntities();
        }
    }
}
