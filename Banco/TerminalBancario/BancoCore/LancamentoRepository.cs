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
    }
}
