using Menu.Model;
using Menu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Controller
{
                                   // repository ele cria metodos de interação
    public class ContaController : IContaRepository
    {
        // readonly é somente para leitura
        private readonly List<Conta> listaContas = new();
        int numero = 0; // variavel pra automaziar a criação danumeração das contas



        // metodos CRUD
        public void Atualizar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($" A conta numero {conta.GetNumero()} foi criado com sucesso! ");
        }

        public void Deletar(int numero)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        // metodos bancarios
        public void Sacar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }
        public void Depositar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            throw new NotImplementedException();
        }

        // metodos auxiliares

        public int GerarNumero() 
        {

            return ++ numero;
        }


    }
}
