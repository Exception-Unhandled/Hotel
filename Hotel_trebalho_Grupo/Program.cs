using System;
using System.ComponentModel;


int op = 1;

reserva[] res = new reserva[10];

for (int i = 0; i < res.Length; i++)
{
    res[i] = new reserva();
}

Random rnd = new Random();

string[] nomes = ["Laura", "Samara", "Ana", "Rodrigo", "Herbert", "Maria", "Carolina"];
string[] apelidos = ["Faro", "Soares", "Silva", "Albuquerque", "Hernandes", "Marim", "Costa"];


//Inicio---------------------------------------------------------------------------------------------------

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("--------------------------------------");
Console.WriteLine("--------------------------------------");
Console.WriteLine("           TP 1 - modulo 7            ");
Console.WriteLine("          Gestão de Reservas          ");
Console.WriteLine("--------------------------------------");
Console.WriteLine("--------------------------------------");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("(Pressione ENTER para entrar no programa!)");
Console.ReadLine();

while ( op != 0 )
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("         Bem-vindo ao Hotel!          ");
    Console.WriteLine("         O que deseja fazer?          ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" 1- Carregar reserva                  ");
    Console.WriteLine(" 2- Inserir nova reserva              ");
    Console.WriteLine(" 3- Pesquisar reservas                ");
    Console.WriteLine(" 4- Mostrar reservas preenchidas      ");
    Console.WriteLine(" 5- Alterar dados da reserva          ");
    Console.WriteLine(" 6- Exportar reservas                 ");
    Console.WriteLine(" 7- Gerar reserva                     ");
    Console.WriteLine(" 8- Nº de reservas livres             ");
    Console.WriteLine(" 9- Consultar preços de quarto        ");
    Console.WriteLine(" 10- Limpar reserva                   ");
    Console.WriteLine(" 0- Sair                              ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;


    Console.WriteLine("Introduza a opção");
    op = Convert.ToInt32(Console.ReadLine());

    // Carregar reserva---------------------------------------------------------------------------------------------------

    if ( op == 1)
    {
        VMenu();
    }

    // Inserir nova reserva---------------------------------------------------------------------------------------------------

    if (op == 2)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

        int disp = checkV(res);
        if (disp != -1)
        {
            Console.WriteLine("Introduza o nome da reserva:");
            res[disp].nome = Console.ReadLine();

            Console.WriteLine($"Introduza o apelido de {res[disp].nome}: ");
            res[disp].apelido = Console.ReadLine();

            Console.WriteLine("Introduza o número de telemóvel:");
            res[disp].nTele = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduza o numero do quarto:");
            res[disp].Nquarto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduza o numero de pessoas que vão utilizar o quarto:");
            res[disp].Npessoa = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("              Preço de quartos variados:          ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Quarto simples de solteiro --------- 150 Euros !");
            Console.WriteLine(" Quarto grande de solteiro ---------- 150 Euros !");
            Console.WriteLine(" Quarto simples de casal ------------ 150 Euros !");
            Console.WriteLine(" Quarto grande de casal ------------- 200 Euros !");
            Console.WriteLine(" Suíte simples de casal ------------- 250 Euros !");
            Console.WriteLine(" Suíte grande de casal -------------- 350 Euros !");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Introduza o preço do quarto:");
            res[disp].preco = Convert.ToDouble(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reserva criada com sucesso!");

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não existem reservas disponíveis!\n\r(Limpe alguma reserva para armazenar uma nova)");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

        VMenu();

    }

    // Pesquisar reserva---------------------------------------------------------------------------------------------------

    if ( op == 3)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Deseja ver as reservas disponíveis ou pesquisar por número do quarto?");
        Console.WriteLine(" 1 - Ver reservas disponíveis");
        Console.WriteLine(" 2 - Pesquisar por número de quarto");
        Console.ForegroundColor = ConsoleColor.White;
        op = Convert.ToInt16(Console.ReadLine());

        // Ver reservas disponíveis

        if (op == 1)
        {
            bool disp = false;
            Console.WriteLine("Reservas disponíveis:");

            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Nquarto != 0)
                {
                    Console.Write($" {res[i].Nquarto} ");
                    disp = true;
                }

            }
            if (disp == true)
            {
                Console.WriteLine();
                Console.WriteLine("Introduza o número do quarto que quer saber as informações:");
                int quarto = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < res.Length; i++)
                {
                    if (quarto == res[i].Nquarto)
                        Dados(res[i]);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem reservas criadas!");
            }
        }

        // Pesquisar por número de quarto

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
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A reserva com este número não existe");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Operação inválida");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        VMenu();
    }

    // Mostrar todas as reservas---------------------------------------------------------------------------------------------------

    if ( op == 4)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Reservas preenchidas:");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ainda não existem reservas preenchidas!");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        VMenu();
    }
    
    // Alterar dados da reserva---------------------------------------------------------------------------------------------------

    if(op == 5)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Deseja alterar de acordo com as reservas disponíveis ou pesquisar por número do quarto?");
        Console.WriteLine("1 - Ver reservas disponíveis");
        Console.WriteLine("2 - Pesquisar por número de quarto");
        op = Convert.ToInt16(Console.ReadLine());

        //Reservas disponíveis

        if (op == 1)
        {
            bool disp = false;

            Console.WriteLine("Reservas disponíveis:");

            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Nquarto != 0)
                {
                    Console.Write($"{res[i].Nquarto} ");
                    disp = true;
                }
            }

            if (disp == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem reservas criadas!");
            }
            else
            {
                Console.WriteLine();

                Console.WriteLine("Introduza o número do quarto que quer alterar a reserva: ");
                int quarto = Convert.ToInt32(Console.ReadLine());

                int index = pesquisa(res, quarto);

                if (index != -1)
                {
                    Console.WriteLine("Introduza um novo nome");
                    res[index].nome = Console.ReadLine();

                    Console.WriteLine("Introduza um novo apelido");
                    res[index].apelido = Console.ReadLine();

                    Console.WriteLine("Introduza um novo número de quarto");
                    res[index].Nquarto = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Introduza um novo número de telemovel");
                    res[index].nTele = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Introduza uma nova quantidade de pessoas");
                    res[index].Npessoa = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Introduza um novo preço");
                    res[index].preco = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A reserva com este numero não existe");
                }
            }
        }

        //Pesquisar por número de reserva


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

                Console.WriteLine("Introduza um novo número de quarto");
                res[index].Nquarto = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduza um novo número de telemovel");
                res[index].nTele = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduza uma nova quantidade de pessoas");
                res[index].Npessoa = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduza um novo preço");
                res[index].preco = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A reserva com este numero não existe");
            }
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Operação inválida");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        VMenu();

    }

    // Exportar reservas---------------------------------------------------------------------------------------------------

    if (op == 6)
    {

    }

    // Gerar reserva---------------------------------------------------------------------------------------------------

    if (op ==7)
    {
        int disp = checkV(res);
        if (disp != -1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Reserva gerada:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            int c = rnd.Next(nomes.Length);
            res[disp].nome = nomes[c];
            c = rnd.Next(apelidos.Length);
            res[disp].apelido = apelidos[c];
            res[disp].Nquarto = rnd.Next(200, 501);
            res[disp].nTele = rnd.Next(900000000, 1000000000);
            res[disp].Npessoa = rnd.Next(1, 5);
            res[disp].preco = 0;
            Dados(res[disp]);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não é possível gerar uma reserva!\n\r(Reservas cheias)");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        VMenu();
    }

    // Reservas disponíveis---------------------------------------------------------------------------------------------------

    if (op == 8)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        int contar = 0;
        for (int i = 0;i < res.Length;i++)
        {
            if (res[i].Nquarto == 0)
            {
                contar= contar+1 ;
            }
        }
        Console.WriteLine($"Existem {contar} reservas disponíveis ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        VMenu();
    }

    // Preços de quarto---------------------------------------------------------------------------------------------------

    if (op == 9)
    {
        Console.Clear();
       
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("              Preço de quartos variados:          ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Quarto simples de solteiro --------- 150 Euros !");
        Console.WriteLine(" Quarto grande de solteiro ---------- 150 Euros !");
        Console.WriteLine(" Quarto simples de casal ------------ 150 Euros !");
        Console.WriteLine(" Quarto grande de casal ------------- 200 Euros !");
        Console.WriteLine(" Suíte simples de casal ------------- 250 Euros !");
        Console.WriteLine(" Suíte grande de casal -------------- 350 Euros !");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

        VMenu();
    }
    // Limpar reserva-------------------------------------------------------------------------------------------------
    if(op == 10)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Reservas preenchidas:");
        bool disp = false;

        for (int i = 0; i < res.Length; i++)
        {
            disp = true; //Eu coloquei o disponível dnv pra validar se tem alguma reserva preenchida*
            if (res[i].Nquarto != 0)
            Console.WriteLine($"{res[i].Nquarto}");
        }

        if (disp == false) // <--- A validação*
        {
            Console.WriteLine("Ainda não existem reservas preenchidas!");
        }
        else 
        {
            Console.WriteLine(" Introduza o numero do quarto de reserva que deseja limpar :");
            int rsLimpar = Convert.ToInt32(Console.ReadLine());

            int index = pesquisa(res, rsLimpar);

            if (index != -1) //Aq eu só fiz a validação com a função de pesquisa p ficar mais fácil de saber se o utilizador colocou um número q n existe*
            {
                res[index].nome = string.Empty;
                res[index].apelido = string.Empty;
                res[index].nTele = 0;
                res[index].preco = 0;
                res[index].Npessoa = 0;
                res[index].Nquarto = 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A reserva com este numero não existe");
            }
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        VMenu();
        

    }

    //Sair---------------------------------------------------------------------------------------------------

    if (op == 0)
    {
        bool valido = false;

        while (valido == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("          Deseja mesmo sair?          ");
            Console.WriteLine(" 1 - Sim \n \r 2 - Não");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
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

    //Opção inválida---------------------------------------------------------------------------------------------------

    if (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5 && op != 6 && op != 7 && op != 8 && op != 9 && op != 10)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Opção inválida!");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("(Pressione ENTER para voltar a tentar)");
        Console.ReadLine();
    }

}

//---------------------------------------------------------------------------------------------------
//                                            Funções
//---------------------------------------------------------------------------------------------------

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

static void VMenu()
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("(Pressione ENTER para voltar ao menu!)");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadLine();
    return;
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

//---------------------------------------------------------------------------------------------------
//                                             Struct
//---------------------------------------------------------------------------------------------------

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



//ordenar quartos com vetor e struct aula de segunda!!!!!!!
//lembrar   Jóia