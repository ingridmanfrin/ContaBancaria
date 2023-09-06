using ContaBancaria.Model;
using ContaBancaria.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Controller
{
    public class ContaController : IContaRepository
    {
        //aqui não foi criado um construtor, então a classe entende que é como se tivesse um construtor vazio
        private readonly List<Conta> listaContas = new();
        int numero = 0;

        //Metodos do CRUD
        public void Atualizar(Conta conta)
        {
            var buscaConta = BuscarNaCollection(conta.GetNumero());
            if (buscaConta != null)
            {
                var index = listaContas.IndexOf(buscaConta);

                listaContas[index] = conta;

                Console.WriteLine($"A conta numero {conta.GetNumero()} foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($"A conta número {conta.GetNumero()} foi criada com sucesso!");
        }

        public void Deletar(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                if (listaContas.Remove(conta) == true)
                {
                    Console.WriteLine($"A Conta {numero} foi apagada com sucesso!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void ListarTodas()
        {
            foreach (var conta in listaContas)
            {
                conta.Visualizar();
            }
        }

        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                conta.Visualizar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                if(conta.Sacar(valor) == true)
                {
                   Console.WriteLine($"O Saque na conta numero {numero} foi efetuado com sucesso!"); ;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                conta.Depositar(valor);
                
                Console.WriteLine($"O Depósito na conta numero {numero} foi efetuado com sucesso!"); ;
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNaCollection(numeroOrigem);
            var contaDestino = BuscarNaCollection(numeroDestino);

            if (contaOrigem is not null && contaDestino is not null)
            {
                if (contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);  
                    Console.WriteLine($"A transferência foi efetuada com sucesso!"); ;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Conta de origem e/ou Conta de Destino não foram encontradas!");
                Console.ResetColor();
            }
        }

        //Métodos Auxiliares

        public int GerarNumero()
        {
            return ++numero;
        }

        //Método parabuscar um Objeto Conta de uma conta específica através do numero
        public Conta? BuscarNaCollection(int numero)
        {
            foreach (var conta in listaContas)
            {
                if (conta.GetNumero() == numero)
                {
                    return conta;
                }
            }
            return null;
        }
    }
}
