using System;
using System.Collections.Generic;
using BancoDIO.Entities;
using BancoDIO.Entities.Enums;

namespace BancoDIO
{
    class Program
    {
        static List<Conta> ListaConta = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoMenu = OpcaoMenu();

            while (opcaoMenu != "7")
            {
                switch (opcaoMenu)
                {
                    case "1":
                        CadastrarConta();
                        break;
                    case "2":
                        ListarContas();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                opcaoMenu = OpcaoMenu();
            }
        }

        private static void ListarContas()
        {
            if (ListaConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
            }
            else
            {
                for (int i = 0; i < ListaConta.Count; i++)
                {
                    Console.WriteLine($"Conta Número: {i} | " + ListaConta[i]);
                }
            }

            Console.WriteLine("");
        }

        private static string OpcaoMenu()
        {
            Console.WriteLine("App de Gestão do BancoDIO");
            Console.WriteLine("--------- Menu ----------");
            Console.WriteLine("1) Nova Conta");
            Console.WriteLine("2) Listar Contas");
            Console.WriteLine("3) Depósito");
            Console.WriteLine("4) Saque");
            Console.WriteLine("5) Transferência");
            Console.WriteLine("6) Limpar Tela");
            Console.WriteLine("7) Sair");

            Console.Write("Digite o número da opção desejada: ");
            string opcaoMenu = Console.ReadLine();
            Console.WriteLine("");
            return opcaoMenu;
        }

        private static void Transferir()
        {
            Console.WriteLine("Realizando Transferência Entre Contas");
            Console.Write("Informe número da Conta Origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Informe o valor a ser transferido: R$ ");
            double valorTransferir = double.Parse(Console.ReadLine());
            Console.Write("Informe número da Conta Destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            if (ListaConta[contaOrigem].Saque(valorTransferir))
            {
                ListaConta[contaDestino].Deposito(valorTransferir);
                Console.WriteLine("Transferência realizada!");
            }
            else
            {
                Console.WriteLine("Saldo indisponível!");
            }

            Console.WriteLine("");
        }

        private static void Sacar()
        {
            Console.WriteLine("Realizando Saque");
            Console.Write("Informe número da Conta: ");
            int contaSaque = int.Parse(Console.ReadLine());
            Console.Write("Informe o valor a ser sacado: R$ ");
            double valorSaque = double.Parse(Console.ReadLine());

            if (ListaConta[contaSaque].Saque(valorSaque))
            {
                Console.WriteLine("Saque realizado!");
            }
            else
            {
                Console.WriteLine("Saldo indisponível");
            }
            Console.WriteLine("");
        }

        private static void CadastrarConta()
        {
            Console.WriteLine("Cadastrando Nova Conta");
            Console.Write("Nome do Titular: ");
            string nomeConta = Console.ReadLine();
            Console.Write("Informe 1 para Pessoa Fisica ou 2 para Pessoa Juridica: ");
            ModeloConta modeloConta = Enum.Parse<ModeloConta>(Console.ReadLine());
            Console.Write("Informa 1 para Conta Corrente ou 2 para ContaPoupanca: ");
            TipoConta tipoConta = Enum.Parse<TipoConta>(Console.ReadLine());
            Console.Write("Saldo inicial: R$ ");
            double saldoConta = double.Parse(Console.ReadLine());

            ListaConta.Add(new Conta(nomeConta, modeloConta, tipoConta, saldoConta));
            Console.WriteLine("");
        }

        private static void Depositar()
        {
            Console.WriteLine("Realizar Depósito");
            Console.Write("Informe número da Conta: ");
            int contaDeposito = int.Parse(Console.ReadLine());
            Console.Write("Informe o valor a ser depositado: R$ ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListaConta[contaDeposito].Deposito(valorDeposito);
            Console.WriteLine("Depósito realizado!");
            Console.WriteLine("");
        }

    }
}