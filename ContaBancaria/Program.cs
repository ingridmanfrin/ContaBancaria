using ContaBancaria.Controller;
using ContaBancaria.Model;
using System;

namespace ContaBancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao = -1, agencia, tipo, aniversario, numero, numeroDestino;
            string? titular;
            decimal saldo, limite, valor;
            string nomeBanco = "Zantander";

            //objeto criado para acessar a classe ContaController (uma criação de um objeto novo de ContaController)
            ContaController contas = new();

            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Samantha", 100000000.00M, 1000.00M);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 333, 2, "Alana", 15000.00M, 05);
            contas.Cadastrar(cp1);

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

                //tratamento de Exceção para impedir a digitação de strings:
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite um valor interio entre 1 e 9");
                    opcao = 0;
                    Console.ResetColor();
                }

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Criar Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Número da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        //AQUI diz que se a variavel titular for nula(??) é para substituir por uma string empty(vazio), caso não for nula a variavel titular, é para passar o dado atribuido na variavel
                        titular ??= string.Empty;

                        do
                        {
                            Console.WriteLine("Digite o Tipo da Conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());

                        } while (tipo != 1 && tipo != 2);


                        Console.WriteLine("Digite o Saldo da Conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.WriteLine("Digite o Aniversário da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }

                        KeyPress();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();

                        contas.ListarTodas();

                        KeyPress();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();
                        
                        //aqui dá para fazer um tratamneto de erro com try cathy e loop

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());
                        
                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollection(numero);

                        if (contas is not null)
                        {
                            Console.WriteLine("Digite o Número da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                            Console.WriteLine("Digite o Saldo da Conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o Limite da Conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    contas.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    contas.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Apagar a Conta\n\n");

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);

                        Console.ResetColor();
                        KeyPress();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Saque\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor do Saque: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Sacar(numero, valor);

                        KeyPress();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Depósito\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor do Depósito: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Depositar(numero, valor);

                        KeyPress();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Transferência entre Contas\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta de Origem: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o número da Conta de Destino: ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor da Transferência: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Transferir(numero, numeroDestino, valor);

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
            Console.ResetColor();

            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: ");
            Console.WriteLine("Ingrid Manfrin - ingridevelyn.manfrin@gmail.com");
            Console.WriteLine("github.com/ingridmanfrin/ContaBancaria");
            Console.WriteLine("*********************************************************");

            Console.ResetColor();
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

