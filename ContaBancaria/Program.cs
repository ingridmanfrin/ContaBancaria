﻿using ContaBancaria.Model;
using System;

namespace ContaBancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao = -1;
            string nomeBanco = "Zantander";

            Conta c1 = new Conta(1, 123, 1, "Gaspar", 1000000.00M);
            c1.Visualizar();
            c1.SetNumero(345);
            c1.Visualizar();

            c1.Sacar(1000);
            c1.Visualizar();

            c1.Depositar(5000);
            c1.Visualizar();

            ContaCorrente cc1 = new ContaCorrente(2, 123, 1, "Samantha", 100000000.00M, 1000.00M);

            cc1.Visualizar();
            cc1.Sacar(200000000.00M);
            cc1.Visualizar();
            cc1.Depositar(5000);
            cc1.Visualizar();

            ContaPoupanca cp1 = new ContaPoupanca(3, 333, 2, "Alana", 15000.00M, 05);

            cp1.Visualizar();
            cp1.Sacar(1000.00M);
            cp1.Visualizar();
            cp1.Depositar(5000);
            cp1.Visualizar();

            while (opcao != 9)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");
                Console.WriteLine($"                BANCO {nomeBanco.ToUpper()}                      ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");
                Console.WriteLine("            1 - Criar Conta                          ");
                Console.WriteLine("            2 - Listar todas as Contas               ");
                Console.WriteLine("            3 - Buscar Conta por Numero              ");
                Console.WriteLine("            4 - Atualizar Dados da Conta             ");
                Console.WriteLine("            5 - Apagar Conta                         ");
                Console.WriteLine("            6 - Sacar                                ");
                Console.WriteLine("            7 - Depositar                            ");
                Console.WriteLine("            8 - Transferir valores entre Contas      ");
                Console.WriteLine("            9 - Sair                                 ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Entre com a opção desejada:                          ");
                Console.WriteLine("                                                     ");
                Console.ResetColor();

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Criar Conta\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Apagar a Conta\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Saque\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Depósito\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Transferência entre Contas\n\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 9:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"\nBanco {nomeBanco} - Construindo Futuros Financeiros Juntos!");
                        Sobre();
                        Console.ResetColor();
                        KeyPress();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();

                        KeyPress();
                        break;
                }
            }
        }
        static void Sobre()
        {
            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: ");
            Console.WriteLine("Ingrid Manfrin - ingridevelyn.manfrin@gmail.com");
            Console.WriteLine("github.com/ingridmanfrin/ContaBancaria");
            Console.WriteLine("*********************************************************");
        }
        static void KeyPress()
        {
            do
            {
                Console.Write("\nPressione Enter para Continuar...");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }

    }
}

