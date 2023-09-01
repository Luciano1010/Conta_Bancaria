using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Model
{
    public class Poupanca : Conta
    {
        private int Aniversario;

        public Poupanca(int numero, int agencia, int tipo, string titular, decimal saldo, int Aniversario) : base(numero, agencia, tipo, titular, saldo)
        {
            this.Aniversario = Aniversario;
        }

        public int GetAniversario()
        {
            return Aniversario;
        }

        public void SetAniversario(int Aniversario)
        {
            this.Aniversario = Aniversario;
        }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine("Aniversário da conta: " + this.Aniversario);
        }
    }
}
