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

            var buscaConta = BuscarNaCollection(conta.GetNumero());  

            if(buscaConta is not null) 
            {
                var index = listaContas.IndexOf(buscaConta);

                listaContas[index] = conta;

                Console.WriteLine($"A Conta numero {conta.GetNumero()}");

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrado");
                Console.ResetColor();
            }

        }

        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($" A conta numero {conta.GetNumero()} foi criado com sucesso! ");
        }

        public void Deletar(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                if (listaContas.Remove(conta) == true)
                    Console.WriteLine($"A Conta {numero} foi apagada com Sucesso");
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrado");
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
                conta.Visualizar();
            else 
            {
            
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrado:");
                Console.ResetColor();
            }
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

        // metedo de busca especifica
        public Conta? BuscarNaCollection(int numero) 
        {
            foreach (var conta in listaContas) 
            {
                if (conta.GetNumero() == numero) 
                    return conta;
            
            }
            return null;// minha assinatura nao esta com o ?, onde o objeto pode vim nulo, entao é so colocar o ? na frente da assinatura
        }   
    
        
    }
}
