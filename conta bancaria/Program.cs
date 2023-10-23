using Menu.Controller;
using Menu.Model;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;

namespace Menu
{
    public class Program
    {

        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao, agencia, tipo, aniversario, numero, numeroDestino, cpf;
            string? titular = string.Empty;
            decimal saldo, limite, valor;
            

            ContaController contas = new();
       

            Console.Clear();

            SobreInova();
            

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");
                Console.WriteLine("                    InovaBank                        ");
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
                Console.WriteLine("            9 - Consulta pelo Titular                ");
                Console.WriteLine("            10 - Sair                                ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Entre com a Opção Desejada:                          ");
                Console.WriteLine("                                                     ");
                Console.ResetColor();

                
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }catch(FormatException) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Digite um numero inteiro de 1 a 9");
                    opcao = 0; 
                    Console.ResetColor();
                }


                if (opcao == 10)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInovaBank - Pensando sempre em Voce !");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                Console.Clear();

                switch (opcao)
                {

                    case 1:

                        try { 
                        
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Deseja continuar nesta pagina de cadastros?\n\n");
                        Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                        opcao = Convert.ToInt32(Console.ReadLine());

                  
                        
                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                                
                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        }catch (FormatException) 
                        { 
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }

                        Console.BackgroundColor= ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Cadastro de Usuario\n\n");
                        Console.ResetColor();

                        Console.Write("Digite o Numero da Agencia: ");
                        agencia = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("\nDigite o Nome do Titular: ");
                        titular = Console.ReadLine();
                       
                        titular ??= string.Empty;
                       
                        Console.Write("\nDigite o Numero do CPF: ");
                        cpf = Convert.ToInt32(Console.ReadLine());
                        
                        do 
                        {
                            Console.Write("\nDigite o Tipo da Conta - (1) Conta Corrente - (2) Poupança: ");
                            tipo = Convert.ToInt32(Console.ReadLine()); 
                             if(tipo != 1 && tipo != 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Digite Opções validas\n(1) para Conta Corrente\n(2) para Conta Poupança");
                                Console.ResetColor();
                            }

                            }while(tipo != 1 && tipo != 2);
   
                        Console.Write("\nDigite o Saldo da Conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo) 
                        {
                            case 1:
                               
                                
                                Console.Write("\nDigite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas!.Cadastrar(new Contacorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite, cpf));
                                break;

                            case 2:
                                
                                
                                Console.Write("\nDigite o dia do Aniversario da Conta:\n ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas!.Cadastrar(new Poupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario,cpf));
                                break;

                        
                        }
                            
                        KeyPress();
                        Console.Clear();
                        break;
                    case 2:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Listas de Contas?\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        }catch (FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;

                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Listar todas as Contas\n");
                        Console.ResetColor();
                        contas!.ListarTodas();
                   
                        KeyPress();
                        Console.Clear();
                        break;
                    case 3:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Consultas?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        }catch(FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;

                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();
                        
                        Console.WriteLine("\nDigite o numero da conta");
                        numero = Convert.ToInt32(Console.ReadLine());   

                        contas!.ProcurarPorNumero(numero);
                       

                        KeyPress();
                        Console.Clear();
                        break;


                        
                        case 4:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Atualizar Conta?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());



                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        }catch (FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }
                            

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Atualizar dados da Conta\n");
                                Console.ResetColor();

                                try
                                {
                                    
                                    Console.Write("\nDigite o CPF da conta ser atualizada: ");
                                    cpf = Convert.ToInt32(Console.ReadLine());

                                    contas!.Buscarporcpf(cpf);

                                 var conta = contas.BuscarNaCollectionCpf(cpf); 

                                 if (conta is not null)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n**Digite as Novas Informações da Conta**\n");

                                        Console.Write("\nDigite o novo  Número da Agência: ");
                                        agencia = Convert.ToInt32(Console.ReadLine());

                                        Console.Write("\nDigite o Nome do Titular: ");
                                        titular = Console.ReadLine();

                                        titular ??= string.Empty;

                                        Console.Write("\nDigite o Saldo da Conta:");
                                        saldo = Convert.ToDecimal(Console.ReadLine());

                                        tipo = conta.GetTipo();

                                        switch (tipo)
                                        {
                                            case 1:
                                                Console.WriteLine("\nDigite o Limite da Conta: ");
                                                limite = Convert.ToDecimal(Console.ReadLine());

                                                contas.Atualizar(new Contacorrente(conta.GetNumero(),agencia, tipo, titular, saldo, limite, cpf));
                                                break;
                                            case 2:
                                                Console.WriteLine("\nDigite o dia do Aniversário da Conta: ");
                                                aniversario = Convert.ToInt32(Console.ReadLine());

                                                contas.Atualizar(new Poupanca(conta.GetNumero(),agencia, tipo, titular, saldo, aniversario, cpf));
                                                break;
                                        }
                                    }

                                
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\nA Conta com o CPF {cpf} não foi encontrada!");
                                        Console.ResetColor();
                                    }
                                }
                                catch
                                {
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     Console.WriteLine("\nDigite somente Numeros sem Pontuações ou Letras");
                                }
                                KeyPress();
                                Console.Clear();
                                break;

                        case 5:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Deletar Conta?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Entrando na Pagina de Deletar Conta\n");
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Retornando a pagina inicial\n");
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }
                        

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Apagar a Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("\nDigite o numero da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas!.Deletar(numero);


                        KeyPress();
                        Console.Clear();
                        break;

                    case 6:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Saques?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Saque\n");
                        Console.ResetColor();

                        Console.Write("\nDigite o numero da Conta:");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nDigite o Valor  do Saque: ");
                        valor = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }


                        contas!.Sacar(numero, valor);
                       

                        KeyPress();
                        Console.Clear();
                        break;
                 
                    case 7:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Depositos?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                       
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nDepósito");
                            Console.ResetColor();

                            Console.Write("\nDigite o numero da conta:");
                            numero = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nDigite o Valor  do Deposito: ");
                            valor = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }


                        contas!.Depositar(numero, valor);

                        

                        KeyPress();
                        Console.Clear();
                        break;

                    case 8:

                        try
                        {

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Transferencias?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();
                            }
                            else if (opcao == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Transferência entre Contas\n");
                            Console.ResetColor();

                            Console.Write("\nDigite o numero da conta de Origem:");
                            numero = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nDigite o numero da conta de Destino: ");
                            numeroDestino = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nDigite o Valor a ser Transferido: ");
                            valor = Convert.ToDecimal(Console.ReadLine());
                        }catch(FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }
                
                        contas!.Transferir(numero, numeroDestino, valor);
                     
                        KeyPress();
                        Console.Clear();
                        break;

                    case 9:

                        try
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Deseja continuar nesta pagina de Consultar Pelo Titular?\n\n");
                            Console.WriteLine("SIM - Digite 1\nNÂO - Digite 2\n\n");
                            opcao = Convert.ToInt32(Console.ReadLine());


                            if (opcao == 1)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();

                            }
                            else if (opcao == 2)
                            {

                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                KeyPress();
                                Console.Clear();


                            }
                            else
                            {
                                Console.WriteLine("Digite opções validas");
                                KeyPress();
                                Console.Clear();
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite Somente Numeros");
                            KeyPress();
                            Console.Clear();
                            break;
                        }

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nConsultar dados da Conta - pelo Titular");
                            Console.ResetColor();

                            Console.Write("\nDigite o nome do Titular: ");
                            titular = Convert.ToString(Console.ReadLine());

                        

                        contas!.ListarTodasporTitular(titular!);

                        KeyPress();
                        Console.Clear();
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!");
                        Console.ResetColor();

                        KeyPress();
                        Console.Clear();
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

       

        static void SobreInova()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("************************************************************");
            Console.WriteLine("       Bem-vindo ao futuro das finanças no InovaBank        ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("  InovaBank é o banco digital do futuro, reinventando       ");
            Console.WriteLine("  a experiência financeira.                                 ");
            Console.WriteLine("  Oferecemos simplicidade, segurança e conveniência,        ");
            Console.WriteLine("  usando tecnologia avançada.                               ");
            Console.WriteLine("  Facilitamos economizar, investir e gerenciar seu dinheiro.");
            Console.WriteLine("    *Explore um mundo de inovação financeira conosco*       ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("************************************************************");
            
            try
            {
                Console.WriteLine("Pressione 'Enter' para continuar");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pressione Enter para retornar ao Menu Principal");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                Console.ResetColor();
            }
        }
    }
}

                        
