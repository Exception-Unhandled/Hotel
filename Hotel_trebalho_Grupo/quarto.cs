using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_trebalho_Grupo
{
    public class quarto
    {
        public int codigo;
        public string nome;
        public int capacidade;

        public quarto()
        {
            codigo = 0;
            nome = string.Empty;
            capacidade = 0;
        }
        public quarto(int cod, string n, int cap)
        {
            this.codigo = cod;
            this.nome = n;
            this.capacidade = cap;
        }
        public void imprime()
        {
            Console.WriteLine($"codigo: {codigo}");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Capacide: {capacidade}");
        }
    }
}
