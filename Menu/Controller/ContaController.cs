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
            // busca o que ja esta na collection a conta que ja esta na collection
            var buscaConta = BuscarNaCollection(conta.GetNumero());  

            if(buscaConta is not null) 
            {  // com o index eu pego a aonde a conta esta
                var index = listaContas.IndexOf(buscaConta);
                // parte que sera feita atualização da conta
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
            var conta = BuscarNaCollection(numero);
            
            if(conta is not null) 
            {
                if (conta.Sacar(valor) == true)
                    Console.WriteLine($"O Saque na conta numero {numero} foi efetuado com sucesso: ");
            }
            else 
            {
                Console.ForegroundColor= ConsoleColor.Red;  
                Console.WriteLine($"A conta numero{numero} não foi encontrada: ");
                Console.ResetColor();
            
            }
        }
        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);
            if (conta is not null)
            {
                     conta.Depositar(valor);
                    Console.WriteLine($"O Saque na conta numero {numero} foi efetuado com sucesso: ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero{numero} não foi encontrada: ");
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
                    Console.WriteLine("Tranferencia enviada com sucesso: ");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Conta nao encontrada ");
                Console.ResetColor();

            }
        }

        // metodos auxiliares

        public int GerarNumero() 
        {

            return ++ numero;
        }

        // met0do de busca especifica dentro da classe conta
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
