﻿using System;
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

        public void Saque(Conta conta)
        {
            _entities.Conta.Add(conta);
            _entities.SaveChanges();
        }

        public string EfetuaTransferencia(int contaOrigemId, int contaDestinoId, decimal valor)
        {
            var contaSaida = _entities.Conta.FirstOrDefault(f => f.Id == contaOrigemId);
            var valorContaSaida = contaSaida.Saldo + contaSaida.LimiteCredito;

            if (valorContaSaida < valor)
            {
                return "Saldo insuficiente";
            }

            var lancamentoSaida = new Lancamentos(0, valor, contaOrigemId);
            lancamentoSaida.Historico = $"Conta {contaDestinoId}. Data {DateTime.Now}. Valor: {valor}";
            var lancamentoEntrada = new Lancamentos(1, valor, contaDestinoId);
            lancamentoEntrada.Historico = $"Conta {contaOrigemId}. Data {DateTime.Now}. Valor: {valor}";
            var contaEntrada = _entities.Conta.FirstOrDefault(f => f.Id == contaDestinoId);

            decimal valorFaltante = 0;

            if (contaSaida.Saldo < valor)
            {
                valorFaltante = contaSaida.Saldo - valor;
            }


            contaSaida.Saldo = contaSaida.Saldo - (valor-valorFaltante);
            contaSaida.LimiteCredito = contaSaida.LimiteCredito - valorFaltante;
            contaEntrada.Saldo += valor;

            _entities.Lancamentos.AddRange(new Lancamentos[] {lancamentoSaida, lancamentoEntrada});

            _entities.SaveChanges();
            return "Transferência realizada com sucesso";
        }
    }
}
