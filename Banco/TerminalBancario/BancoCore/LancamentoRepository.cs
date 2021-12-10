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
            var data = DateTime.Now.AddDays(-30);
            return _entities.Lancamentos.Where(f => f.Data > data).Where(f => f.ContaId == idconta).ToList();
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
    }
}
