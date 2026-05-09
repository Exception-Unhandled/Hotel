using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_trebalho_Grupo
{
    public class reserva
    {
        public string nome { get; set; }
        public string apelido { get; set; }
        public int Nquarto { get; set; }
        public int nTele { get; set; }
        public int Npessoa { get; set; }
        public double preco { get; set; }

        public reserva()
        {
            nome = string.Empty;
            apelido = string.Empty;
            nTele = 0;
            preco = 0;
            preco = 0;
            Nquarto = 0;
        }

        public reserva(string nome_, string apelido_, int Nquarto_, int numeroTele_, int Npessoa_, double preco_)
        {
            nome = nome_;
            apelido = apelido_;
            Nquarto = Nquarto_;
            nTele = numeroTele_;
            Npessoa = Npessoa_;
            preco = preco_;

        }
        
    }
}
