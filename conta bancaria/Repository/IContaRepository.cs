using Menu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repository
{
    public interface IContaRepository
    {

       
        public void Cadastrar(Conta conta);
        public void Atualizar(Conta conta);
        public void ProcurarPorNumero(int numero);

        public void Buscarporcpf(int cpf);
        public void ListarTodas();
        public void ListarTodasporTitular(string titular);
        public void Deletar(int numero);

       
        public void Sacar(int numero, decimal valor);
        public void Depositar(int numero, decimal valor);
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor);
            
    }
}
