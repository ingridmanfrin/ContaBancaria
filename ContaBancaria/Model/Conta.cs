using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContaBancaria.Model
{
    //Instanciar a Classe é criar um, ou vários objetos dela
    //A classe é a forma o objeto é o bolo
    // criando novo tipo  de dado chamado Conta
    public abstract class Conta
    {
        //Atributos da minha classe:
        //preciso manter o encapsulamento dos meus dados é para não poder alterar dados como numero, agencia então uso os metodos Get e Set
        //outro benefico de encapsular é na hora de fazer a herança (consigo fazer a reutilização de código) 
        //os metodos de acesso no caso da herança servem para ...
        private int numero;
        private int agencia;
        private int tipo;
        private string titular = string.Empty;
        private decimal saldo;

        //Metodo Construtor: cria um novo objeto e preenche os atributos da classe, com os parâmetros passados no construtor:
        public Conta(int id, int agencia, int tipo, string titular, decimal saldo)
        {
            this.numero = id;
            this.agencia = agencia;
            this.tipo = tipo;
            this.titular = titular;
            this.saldo = saldo;
        }

        //*** Polimorfismo de Sobrecarga(que é feita dentro da própria Classe)!
        //Construtor vazio (tem assinatura diferente do de cima) 
        //construtor vazio pode ser usado para fazer teste, validação de dados:
        //ou tbm criar um metodo com menos algum parâmetro que o de cima por exemplo:
        public Conta() { }

        //Método de Acesso:
        //métodos SET servem para modificar os atributos.
        //métodos GET servem para ler os dados dos atributos.
        /*Métodos Get e Set*/
        public int GetNumero()
        {
            return numero;
        }

        public void SetNumero(int numero)
        {
            this.numero = numero;
        }

        public int GetAgencia()
        {
            return agencia;
        }

        public void SetAgencia(int agencia)
        {
            this.agencia = agencia;
        }

        public int GetTipo()
        {
            return tipo;
        }

        public void SetTipo(int tipo)
        {
            this.tipo = tipo;
        }

        public string GetTitular()
        {
            return titular;
        }

        public void SetTitular(string titular)
        {
            this.titular = titular;
        }

        public decimal GetSaldo()
        {
            return saldo;
        }

        public void SetSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }

        public virtual bool Sacar(decimal valor)
        {
            if(this.saldo < valor)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            else
            {
                this.SetSaldo(this.saldo - valor);
                return true;
            }
        }

        public void Depositar(decimal valor)
        {
            this.SetSaldo(this.saldo + valor);
        }

        public virtual void Visualizar()
        {
            string tipo= "";  //mesma coisa seria por: string tipo= string.empty;

            switch (this.tipo)
            {
                case 1:
                    tipo = "Conta Corrente";
                    break;
                case 2:
                    tipo = "Conta Poupança";
                    break;
                
            }

            Console.WriteLine("**************************************************");
            Console.WriteLine("Dados da Conta");
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Número da Conta: {this.numero}");
            Console.WriteLine($"Número da Agência: {this.agencia}");
            Console.WriteLine($"Tipo da Conta: {tipo}");
            Console.WriteLine($"Titular da Conta: {this.titular}");
            Console.WriteLine($"Saldo da Conta: {(this.saldo).ToString("C")}");
        }
    }
}
