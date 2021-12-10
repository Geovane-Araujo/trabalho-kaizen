using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCore
{
    public class LancamentoRepository
    {
        private readonly bancodbEntities _entities;
        public LancamentoRepository()
        {
            _entities = new bancodbEntities();
        }


        public List<Lancamentos> Extrato(int idconta)
        {
            return _entities.Lancamentos.Where(f => f.Data > DateTime.Now.AddDays(-30)).Where(f => f.ContaId == idconta).ToList();
        }

        public Conta GetByID(int id)
        {
            var correntista = _entities.Conta.FirstOrDefault(f => f.Id == id);
            if (correntista != null)
            {
                return correntista;
            }
            else { return new Conta(); }
        }

        public void Saque(Conta conta)
        {
            _entities.Conta.Add(conta);
            _entities.SaveChanges();
        }
    }
}
