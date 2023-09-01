using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Model
{
    public class ContaPoupanca : Conta
    {
        private int aniversario; //int pq eu só preciso saber o dia que vai ser, pq todo mês naquele dia é o aniversario

        public ContaPoupanca(int id, int agencia, int tipo, string titular, decimal saldo, int aniversario) : base(id, agencia, tipo, titular, saldo)
        {
            this.aniversario = aniversario;
        }

        public int getAniversario()
        {
            return this.aniversario;
        }

        public void SetAniversario(int aniversario)
        {
            this.aniversario = aniversario;
        }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine($"Aniversario da Conta: dia {this.aniversario}");
        }
    }
}
