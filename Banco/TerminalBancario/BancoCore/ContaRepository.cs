using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoCore
{
    public class ContaRepository
    {
        private readonly bancodbEntities _entities;

        public ContaRepository()
        {
            _entities = new bancodbEntities();
        }

        public string Saque(int contaId, decimal valorSacado)
        {
            try
            {
                var lancamentos = new Lancamentos();

                var conta = _entities.Conta.FirstOrDefault(f => f.Id == contaId);

                if (valorSacado < conta.Saldo)
                {
                    conta.Saldo -= valorSacado;
                }
                else if (valorSacado > conta.Saldo && valorSacado < conta.LimiteCredito)
                {
                    decimal aux = 0;
                    aux = (valorSacado - conta.Saldo);
                    conta.Saldo = 0;
                    conta.LimiteCredito -= aux;
                }
                else
                {
                    return "Saldo Insulficiente";
                }


                lancamentos.Data = DateTime.Now;
                lancamentos.Valor = valorSacado;
                lancamentos.Operacao = 1;
                lancamentos.Historico = " Saque no Auto atendimento dia " + DateTime.Now.ToString("dd/MM/yyyy");

                conta.Lancamentos.Add(lancamentos);

                _entities.SaveChanges();

                return lancamentos.Historico;
             
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void InsereConta()
        {
            var conta = new Conta();
            _entities.Conta.Add(conta);
            _entities.SaveChanges();
        }

        public void AtualizaCorrentista(int id, string novoCpf, string novoNome)
        {
            var correntistaBD = _entities.Correntista.FirstOrDefault(f => f.Id == id);
            correntistaBD.Nome = novoNome;
            correntistaBD.CPF = novoCpf;
            _entities.Correntista.Add(correntistaBD);
            _entities.SaveChanges();
        }

        public bool Delete(int id)
        {
            var correntista = _entities.Correntista.FirstOrDefault(f => f.Id == id);

            if (correntista != null)
            {


                foreach (var conta in from conta in correntista.Conta select conta)
                {
                    _entities.Lancamentos.RemoveRange(conta.Lancamentos);
                    _entities.Conta.Remove(conta);
                }

                _entities.Correntista.Remove(correntista);
                return (_entities.SaveChanges()) > 0;
            }
            else { return false; }
        }

        public Correntista GetByID(int id)
        {
            var correntista = _entities.Correntista.FirstOrDefault(f => f.Id == id);
            if (correntista != null)
            {
                return correntista;
            }
            else { return new Correntista(); }
        }

        public ICollection<Correntista> GetAll()
        {
            return _entities.Correntista.ToList();
        }
    }
}