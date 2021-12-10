using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCore
{
    public class ContaRepository
    {
        private readonly bancodbEntities _entities;
        public ContaRepository()
        {
            _entities = new bancodbEntities();
        }

        public void Saque(Conta conta)
        {
            _entities.Conta.Add(conta);
            _entities.SaveChanges();
        }
    }
}
