using BancoDIO.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDIO.Entities
{
    class Conta
    {
        private string Nome { get; set; }
        private ModeloConta ModeloConta { get; set; }
        public TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }

        public Conta(string nome, ModeloConta modeloconta , TipoConta tipoconta, double saldo)
        {
            Nome = nome;
            ModeloConta = modeloconta;
            TipoConta = tipoconta;
            Saldo = saldo;
        }

        public string Deposito(double valor)
        {
            Saldo += valor;
            return "Depósito realizado com sucesso!";
        }

        public bool Saque(double valor)
        {
            if(valor > Saldo)
            {
                return false;
            }
            else
            {
                Saldo -= valor;
                return true;
            }
        }

        public override string ToString()
        {
            return "Nome: " + Nome + " | Saldo: R$ " + Saldo + " | Modelo Conta: " + ModeloConta + " | Tipo Conta: " + TipoConta;
        }
    }
}