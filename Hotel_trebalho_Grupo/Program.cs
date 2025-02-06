using System.ComponentModel;


int op = 1;

reserva[] res = new reserva[10];

for (int i = 0; i < res.Length; i++)
{
    res[i] = new reserva();
}

Random rnd = new Random();

string[] nomes = ["Laura", "Samara", "Ana", "Rodrigo", "Herbert"];
string[] apelidos = ["Faro", "Soares", "Silva"];

int nindex = rnd.Next(nomes.Length);
res[0].nome = nomes[nindex--];

//Inicio


Console.WriteLine("--------------------------------------");
Console.WriteLine("--------------------------------------");
Console.WriteLine("           TP 1 - modulo 7            ");
Console.WriteLine("          Gestão de Reservas          ");
Console.WriteLine("--------------------------------------");
Console.WriteLine("--------------------------------------");
Console.WriteLine("(Pressione ENTER para entrar no programa!)");
Console.ReadLine();

while ( op != 0 )
{
    Console.Clear();

    Console.WriteLine("--------------------------------------");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("         Bem-vindo ao Hotel!          ");
    Console.WriteLine("         O que deseja fazer?          ");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine(" 1- Carregar reserva                  ");
    Console.WriteLine(" 2- Inserir nova reserva              ");
    Console.WriteLine(" 3- Pesquisar reservas                ");
    Console.WriteLine(" 4- Mostrar reservas preenchidas      ");
    Console.WriteLine(" 5- Alterar dados da reserva          ");
    Console.WriteLine(" 6- Exportar reservas                 ");
    Console.WriteLine(" 7- Gerar reserva                     ");
    Console.WriteLine(" 8- Nº de reservas livres             ");
    Console.WriteLine(" 9- Mostrar preços de quarto          ");
    Console.WriteLine(" 0- Sair                              ");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("--------------------------------------");


    Console.WriteLine("Introduza a opção");
    op = Convert.ToInt32(Console.ReadLine());

    // Carregar reserva

    if( op == 1)
    {

    }

    // Inserir nova reserva

    if (op == 2)
    {
        int disp = checkV(res);
        if( disp != -1  )
        {
            Console.WriteLine("Introduza o nome da reserva:");
            res[disp].nome = Console.ReadLine();

            Console.WriteLine($"Introduza o apelido de {res[disp].nome}: ");
            res[disp].apelido = Console.ReadLine();

            Console.WriteLine("Introduza o número de telemóvel:");
            res[disp].nTele = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduza o numero do quarto:");
            res[disp].Nquarto=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduza o numero de pessoas que vão utilizar o quarto:");
            res[disp].Npessoa= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduza o preço do quarto:");
            res[disp].preco = Convert.ToDouble(Console.ReadLine());
           
        }
        else
            Console.WriteLine("Não existem reservas disponíveis! (Limpe alguma reserva para armazenar uma nova)");

        Console.WriteLine("Reserva criada com sucesso! \n \r(Pressione ENTER para voltar ao menu)");
        Console.ReadLine();

    }

    // Pesquisar reserva

    if ( op == 3)
    {
        Console.WriteLine("Deseja ver as reservas disponíveis ou pesquisar por número do quarto?");
        Console.WriteLine("1 - Ver reservas disponíveis");
        Console.WriteLine("2 - Pesquisar por número de quarto");
        op = Convert.ToInt16(Console.ReadLine());

        if (op == 1)
        {
            Console.WriteLine("Reservas disponíveis:");

            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Nquarto != 0)
                    Console.Write($" {res[i].Nquarto} ");

            }
            Console.WriteLine();
            Console.WriteLine("Introduza o número do quarto que quer saber as informações:");
            int quarto = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < res.Length; i++)
            {
                if (quarto == res[i].Nquarto)
                    Dados(res[i]);
            }
        }
        else if (op == 2)
        {
            Console.WriteLine("Introduza o número do quarto que quer saber as informações:");
            int n = Convert.ToInt32(Console.ReadLine());
            int index = pesquisa(res, n);
            if (index != -1)
            {
                Dados(res[index]);
            }
            else
                Console.WriteLine("A reserva com este número não existe");
        }
        else
            Console.WriteLine("Operação inválida");

        Console.WriteLine("(Pressione ENTER para voltar ao menu)");
        Console.ReadLine();
    }

    // Mostrar todas as reservas

    if( op == 4)
    {
        bool disp = false;

        for (int i = 0; i < res.Length; i++)
        {
            if (res[i].Nquarto != 0)
            {
                disp = true;
                Dados(res[i]);
                Console.WriteLine();
            }
        }

        if (disp == false)
        {
            Console.WriteLine("Ainda não existem reservas preenchidas!");
        }

        Console.WriteLine("(Pressione ENTER para voltar ao menu)");
        Console.ReadLine();
    }

    // Alterar dados da reserva

    if(op == 5)
    {

        Console.WriteLine("Deseja alterar de acordo com as reservas disponíveis ou pesquisar por número do quarto?");
        Console.WriteLine("1 - Ver reservas disponíveis");
        Console.WriteLine("2 - Pesquisar por número de quarto");
        op = Convert.ToInt16(Console.ReadLine());

        if (op == 1)
        {
            bool disp = false;

            Console.WriteLine("Reservas disponíveis:");

            for (int i = 0; i < res.Length; i++)
            {
                disp = true;
                if (res[i].Nquarto != 0)
                    Console.Write($"{res[i].Nquarto} ");
            }

            if (disp == false)
                Console.WriteLine("Não existem reservas criadas!");
            else
            {
                disp = false;
                Console.WriteLine();

                Console.WriteLine("Introduza o número do quarto que quer alterar a reserva: ");
                int quarto = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < res.Length; i++)
                {
                    int index = pesquisa(res, quarto);

                    if (index != -1)
                    {
                        disp = true;
                        Console.WriteLine("Introduza um novo nome");
                        res[index].nome = Console.ReadLine();

                        Console.WriteLine("Introduza um novo apelido");
                        res[index].apelido = Console.ReadLine();

                        Console.WriteLine("Introduza um novo número de telemovel");
                        res[index].nTele = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Introduza uma nova quantidade de pessoas");
                        res[index].Npessoa = Convert.ToInt32(Console.ReadLine());
                    }
                }

                if (disp == false)
                    Console.WriteLine("A reserva com este numero não existe");

                Console.WriteLine("(Pressione ENTER para voltar ao menu)");
                Console.ReadLine();
            }
        }

        else if (op == 2)
        {
            Console.WriteLine("Introduza o número do quarto que quer alterar:");
            int n = Convert.ToInt32(Console.ReadLine());
            int index = pesquisa(res, n);
            if (index != -1)
            {
                Console.WriteLine("Introduza um novo nome");
                res[index].nome = Console.ReadLine();

                Console.WriteLine("Introduza um novo apelido");
                res[index].apelido = Console.ReadLine();

                Console.WriteLine("Introduza um novo número de telemovel");
                res[index].nTele = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduza uma nova quantidade de pessoas");
                res[index].Npessoa = Convert.ToInt32(Console.ReadLine());
            }
            else
                Console.WriteLine("A reserva com este numero não existe");
        }

        else
            Console.WriteLine("Operação inválida");

    }

    // Exportar reservas

    if (op == 6)
    {

    }

    // Gerar reserva

    if(op ==7)
    {


        Console.ReadLine();
    }

    // Reservas disponíveis

    if (op == 8)
    {
        int contar = 0;
        for (int i = 0;i < res.Length;i++)
        {
            if (res[i].Nquarto == 0)
            {
                contar= contar+1 ;
            }
        }
        Console.WriteLine($"Existem {contar} reservas disponíveis ");
        Console.WriteLine("(Pressione ENTER para voltar ao menu)");
        Console.ReadLine();
    }

    //Sair

    if (op == 0)
    {
        bool valido = false;

        while (valido == false)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("          Deseja mesmo sair?          ");
            Console.WriteLine(" 1 - Sim \n \r 2 - Não");
            Console.WriteLine("--------------------------------------");
            op = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
                return;
            else if (op == 2)
                valido = true;
            else
            {
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("(Pressione ENTER para voltar a tentar)");
                Console.ReadLine();
            }
        }
    }

    if (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5 && op != 6 && op != 7 && op != 8)
    {
        Console.WriteLine("Opção inválida!");
        Console.WriteLine("(Pressione ENTER para voltar a tentar)");
        Console.ReadLine();
    }

}

//--------------------------------------------------
static int pesquisa(reserva[] a, int n)
{
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto == n)
        {
            return i;
        }
        
    }
    return -1;
}

static void Dados(reserva a)
{
    Console.WriteLine("--------------------------------------");
    Console.WriteLine($"Nome: {a.nome} {a.apelido}");
    Console.WriteLine($"Número do quarto: {a.Nquarto}");
    Console.WriteLine($"Número de telefone {a.nTele}");
    Console.WriteLine($"Número de pessoas: {a.Npessoa}");
    Console.WriteLine($"Preço da reserva: {a.preco}");
    Console.WriteLine("--------------------------------------");

    return;

}

static int checkV(reserva[] a)
{
    for (int i = 0;i < a.Length; i++)
    {
        if (a[i].Nquarto == 0)
        {
            return i;
        } 
    }
    return -1;
}
public struct reserva
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

    public reserva(string nome_, string apelido_, int Nquarto_,int numeroTele_, int Npessoa_, double preco_)
    {
        nome = nome_;
        apelido = apelido_;
        Nquarto = Nquarto_;
        nTele = numeroTele_;
        Npessoa = Npessoa_;
        preco = preco_;

    }
}