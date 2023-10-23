using Menu.Model;
using Menu.Repository;



namespace Menu.Controller
{
                                   
    public class ContaController : IContaRepository
    {
        
        private readonly List<Conta> listaContas = new();
        int numero = 0;


        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($" A conta numero {conta.GetNumero()} foi criado com sucesso! ");
        }


        public void Atualizar(Conta conta)
        {
                        
            var buscaConta = BuscarNaCollectionCpf(conta.Getcpf());  

            if(buscaConta is not null) 
            {  
                var index = listaContas.IndexOf(buscaConta);
                
                listaContas[index] = conta;

                Console.WriteLine($"A Conta com numero de CPF {conta.Getcpf()} foi atualizado com Sucesso");

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero de CPF {conta.Getcpf()} não foi encontrado");
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

        public void ListarTodasporTitular(string titular)
        {
            var contasPortitular = from conta in listaContas
                                   where conta.GetTitular().Contains(titular)
                                   select conta;
            contasPortitular.ToList().ForEach(c => c.Visualizar());

            if (contasPortitular is not null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTitular não encontrado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTitular encontrado");
                Console.ResetColor();
            }
        }

        public void Buscarporcpf(int cpf)
        {
            var conta = BuscarNaCollectionCpf(cpf);

            if (conta is not null)
                conta.Visualizar();
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CPF {cpf} não foi encontrado:");
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
                    Console.WriteLine($"O Deposito na conta {numero} foi efetuado com sucesso: ");
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

        

        public int GerarNumero() 
        {

            return ++ numero;
        }

       
            public Conta? BuscarNaCollection(int numero) 
            {
                foreach (var conta in listaContas) 
                {
                    if (conta.GetNumero() == numero) 
                        return conta;
            
                }
                return null;
            }

        public Conta? BuscarNaCollections(int cpf)
        {
            foreach (var conta in listaContas)
            {
                if (conta.Getcpf() == cpf)
                    return conta;

            }
            return null;
        }

        public Conta? BuscarNaCollectionCpf(int cpf)
        {
            foreach (var conta in listaContas)
            {
                if (conta.Getcpf() == cpf)
                    return conta;

            }
            return null;
        }

    }
}
