//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace BancoCore
{

    public partial class Lancamentos
    {
        public int Id { get; set; }
        public System.DateTime Data { get; set; } = DateTime.Now;
        public int ContaId { get; set; }
        public int Operacao { get; set; }
        public string Historico { get; set; } = String.Empty;
        public decimal Valor { get; set; }
    
        public virtual Conta Conta { get; set; }

        public Lancamentos(int operacao, decimal valor, int contaId)
        {
            ContaId = contaId;
            Operacao = operacao;
            Valor = valor;
        }
    }


}
