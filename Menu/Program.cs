using Menu.Controller;
using Menu.Model;
using System.Drawing;
using System.Security.Cryptography;

namespace Menu
{
    public class Program
    {

        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao, agencia, tipo, aniversario, numero, numeroDestino;
            string? titular;
            decimal saldo, limite, valor;


            ContaController contas = new();
            // criando um obejto - c1 é um objeto e c1 da um novo objeto dentros parametro contacorrente
            Contacorrente c1 = new Contacorrente(contas.GerarNumero(), 123, 01, "Luciano Simões", 12, 10000.00M);
            contas.Cadastrar(c1);

            Poupanca c2 = new(contas.GerarNumero(), 123, 01, "Luciano Simões", 12);
            contas.Cadastrar(c2);




            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");
                Console.WriteLine("                BANCO BRAZILIEM EXPRESS              ");
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

                // tratamento de exceção, impedindo a digitação de strings.
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }catch(FormatException) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Digite um numero inteiro de 1 a 9");
                    opcao = 0; // zerar a variavel a varivael "opção" porque quando digita uma letra ela fica reservada
                    Console.ResetColor();
                }


                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBanco Braziliem Express - Pensando sempre em Voce !");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Criar Conta\n\n");
                        Console.ResetColor();

                        Console.Write("Digite o Numero da Agencia: ");
                        agencia = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Digite o Nome do titular: ");
                        titular = Console.ReadLine();
                        // o que significa ?? é um operador de coalecencia, ele retonar como string vazia o que é diferente de nulo
                        titular ??= string.Empty;
                        do 
                        {
                            Console.Write("Digite o Tipo da conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine()); 
                            }while(tipo != 1 && tipo != 2);



                        Console.Write("Digite o Saldo da conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo) 
                        {
                            case 1:
                                Console.Write("Digite o Limite da conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new Contacorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;


                            case 2:
                                Console.WriteLine("Digite o dia do aniversairio da contas: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas.Cadastrar(new Poupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;

                        
                        }
                       


                        

                        KeyPress();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();
                        contas.ListarTodas();

                        KeyPress();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();
                        
                        Console.WriteLine(" Digite o numero da conta");
                        numero = Convert.ToInt32(Console.ReadLine());   

                        contas.ProcurarPorNumero(numero);
                       

                        KeyPress();
                        break;

                        case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollection(numero);

                        if (conta is not null)
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

                                    contas.Atualizar(new Contacorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o dia do Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    contas.Atualizar(new Poupanca(numero, agencia, tipo, titular, saldo, aniversario));
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Apagar a Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine(" Digite o numero da conta");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);


                        KeyPress();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Saque\n\n");
                        Console.ResetColor();

                        Console.WriteLine(" Digite o numero da conta");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Valor  do Saque: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        // chamando metodo sacar
                        contas.Sacar(numero, valor);
                       

                        KeyPress();
                        break;
                 
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Depósito\n\n");
                        Console.ResetColor();

                        Console.WriteLine(" Digite o numero da conta");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Valor  do Deposito: ");
                        valor = Convert.ToDecimal(Console.ReadLine());
                        // chamando o metedo depositar
                        contas.Depositar(numero, valor);

                        KeyPress();
                        break;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Transferência entre Contas\n\n");
                        Console.ResetColor();
                        
                        Console.WriteLine(" Digite o numero da conta de Origem");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o numero da conta de Destino: ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Valor a ser Transferido: ");
                        valor= Convert.ToInt32(Console.ReadLine());
                        // chamando o metedo Transferir
                        contas.Transferir(numero, numeroDestino, valor);
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
            Console.WriteLine("Projeto Desenvolvido por: Luciano Simões de Almeida");
            Console.WriteLine("Email - luciano_lopesdealmeida@hotmail.com");
            Console.WriteLine("github.com/Luciano1010");
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