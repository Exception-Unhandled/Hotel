using System;
using System.ComponentModel;


int op = 1;

reserva[] res = new reserva[100];


for (int i = 0; i < res.Length; i++)
{
    res[i] = new reserva();
}

Random rnd = new Random();

string[] nomes = ["Laura", "Samara", "Ana", "Rodrigo", "Herbert", "Maria", "Carolina", "João", "Marcos", "Otávio", "César", "Micaela"];
string[] apelidos = ["Faro", "Soares", "Silva", "Albuquerque", "Hernandes", "Marim", "Costa", "Alves", "Souza", "Pereira", "Oliveira"];
int[] precos = [115, 150, 165, 200, 250, 350];


//Inicio---------------------------------------------------------------------------------------------------

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine("                   TP 1 - Módulo 7                   ");
Console.WriteLine("                 Gestão de Reservas                  ");
Console.WriteLine("    Herbert Júnior - n7 / Micaela Albuquerque n12    ");
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine("-----------------------------------------------------");
Console.ForegroundColor = ConsoleColor.Gray;
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
    Console.WriteLine(" 1- Importar reserva                  ");
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
    
    // Importar reserva---------------------------------------------------------------------------------------------------

    if ( op == 1)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("               Importar               ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Deseja importar as reservas preenchidas de um ficheiro txt?");
        Console.WriteLine(" 1 - Sim \n \r 2 - Não");
        int opescolha = Convert.ToInt32(Console.ReadLine());

        if (opescolha == 1)
        {
            Console.WriteLine("Introduza o nome do arquivo\n\r(ATENÇÃO: Não inclua o formato do arquivo)");
            StreamReader reader = new StreamReader(Console.ReadLine() + ".txt");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("           Reservas importadas        ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            int c = Convert.ToInt16(reader.ReadLine());

            for (int i = 0; i < c; i++)
            {
                Import(ref res[i], reader); //Porque ref? - ref é o comando que indica que você quer alocar os valores da função num 'ponteiro' (ou seja, coordenada) da memória específic. Ou seja, quer alocar seus dados no seu vetor original, e não numa cópia
                Dados(res[i]);
            }

            reader.Close();
        }
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
            Console.WriteLine(" Quarto simples de solteiro --------- 115 Euros !");
            Console.WriteLine(" Quarto grande de solteiro ---------- 150 Euros !");
            Console.WriteLine(" Quarto simples de casal ------------ 165 Euros !");
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

                    Console.Write($"|| {res[i].Nquarto} ");
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
    }

    // Alterar dados da reserva---------------------------------------------------------------------------------------------------

    if (op == 5)
    {

        int opescolha;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Deseja alterar de acordo com as reservas disponíveis ou pesquisar por número do quarto?");
        Console.WriteLine("1 - Ver reservas disponíveis");
        Console.WriteLine("2 - Pesquisar por número de quarto");
        opescolha = Convert.ToInt16(Console.ReadLine());

        //Reservas disponíveis

        if (opescolha == 1)
        {


            
            bool disp = false;

            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].Nquarto != 0)
                {
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
                Console.Clear ();
               Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("            Reservas disponíveis:");
                Console.WriteLine();
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i].Nquarto != 0)
                    {

                        Console.Write($"|| {res[i].Nquarto}");

                    }
                }
                Console.WriteLine();  
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Introduza o número do quarto que quer alterar a reserva:");
                int quarto = Convert.ToInt32(Console.ReadLine());

                int index = pesquisa(res, quarto);

                if (index != -1)
                {
                    Console.Clear();
                    Dados(res[index]);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("-------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("O que deseja alterar?");
                    Console.WriteLine("1 - Nome/Apelido");
                    Console.WriteLine("2 - Número de quarto");
                    Console.WriteLine("3 - Número de telemóvel");
                    Console.WriteLine("4 - Quantidade de pessoas");
                    Console.WriteLine("5 - Preço");
                    Console.WriteLine("6 - Mudar tudo");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("-------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    opescolha = Convert.ToInt32(Console.ReadLine());

                    if (opescolha == 1)
                    {

                        Console.WriteLine("Introduza o novo nome da reserva");
                        res[index].nome = Console.ReadLine();
                        Console.WriteLine($"Introduza o novo apelido de {res[index].nome}");
                        res[index].apelido = Console.ReadLine();

                    }
                    if (opescolha == 2)
                    {
                        bool dispo = true;
                        while (dispo == false)
                        {

                            Console.WriteLine("Introduza o número de quarto da reserva");
                            int novoquart = Convert.ToInt32(Console.ReadLine());


                            for (int i = 0; i < res.Length; i++)
                            {
                                if (novoquart == res[i].Nquarto)
                                {
                                    dispo = false;
                                }
                            }
                            if (dispo == true)
                                res[index].Nquarto = novoquart;
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("----------------------------");
                                Console.WriteLine("      Quarto ocupado        ");
                                Console.WriteLine("----------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                        }
                    }
                    if (opescolha == 3)
                    {
                        bool dispo = true;
                        while (dispo == false)
                        {
                            Console.WriteLine("Introduza o número de telemóvel da reserva");
                            int novotelemovel = Convert.ToInt32(Console.ReadLine());


                            for (int i = 0; i < res.Length; i++)
                            {
                                if (novotelemovel == res[i].nTele)
                                {
                                    dispo = false;
                                }
                            }
                            if (dispo == true)
                                res[index].nTele = novotelemovel;
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("    Número de telemóvel ja utilizado     ");
                                Console.WriteLine("-----------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                        }
                    }
                    if (opescolha == 4)
                    {
                        Console.WriteLine("Introduza o número de pessoas: ");
                        res[index].Npessoa = Convert.ToInt32(Console.ReadLine());
                    }
                    if (opescolha == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("              Preço de quartos variados:          ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Quarto simples de solteiro --------- 115 Euros !");
                        Console.WriteLine(" Quarto grande de solteiro ---------- 150 Euros !");
                        Console.WriteLine(" Quarto simples de casal ------------ 165 Euros !");
                        Console.WriteLine(" Quarto grande de casal ------------- 200 Euros !");
                        Console.WriteLine(" Suíte simples de casal ------------- 250 Euros !");
                        Console.WriteLine(" Suíte grande de casal -------------- 350 Euros !");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Introduza o novo preço do quarto ");
                        res[index].preco = Convert.ToInt32(Console.ReadLine());

                    }
                    if (opescolha == 6)
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

                    Console.WriteLine("Reserva alterada com sucesso!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A reserva com este numero não existe");
                }
            }
        }

        //Pesquisar por número de reserva


        else if (opescolha == 2)
        {

            Console.WriteLine("Introduza o número do quarto que quer alterar:");
            int n = Convert.ToInt32(Console.ReadLine());
            int index = pesquisa(res, n);
            if (index != -1)
            {

                Dados(res[index]);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("O que deseja alterar?");
                Console.WriteLine("1 - Nome/Apelido");
                Console.WriteLine("2 - Número de quarto");
                Console.WriteLine("3 - Número de telemóvel");
                Console.WriteLine("4 - Quantidade de pessoas");
                Console.WriteLine("5 - Preço");
                Console.WriteLine("6 - Mudar tudo");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                opescolha = Convert.ToInt32(Console.ReadLine());

                if (op == 1)
                {

                    Console.WriteLine("Introduza o novo nome da reserva");
                    res[index].nome = Console.ReadLine();
                    Console.WriteLine("Introduza o novo apelido da reserva");
                    res[index].apelido = Console.ReadLine();

                }
                if (op == 2)
                {

                    bool dispo = true;
                    while (dispo == false)
                    {
                        Console.WriteLine("Introduza o número de quarto da reserva");
                        int novoquart = Convert.ToInt32(Console.ReadLine());


                        for (int i = 0; i < res.Length; i++)
                        {
                            if (novoquart == res[i].Nquarto)
                            {

                                dispo = false;

                            }
                        }
                        if (dispo == true)
                            res[index].Nquarto = novoquart;
                        else
                        {

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("      Quarto ocupado        ");
                            Console.WriteLine("----------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                        }


                    }
                }
                if (op == 3)
                {
                    bool dispo = true;
                    while (dispo == false)
                    {
                        Console.WriteLine("Introduza o número de telemóvel da reserva");
                        int novotelemovel = Convert.ToInt32(Console.ReadLine());


                        for (int i = 0; i < res.Length; i++)
                        {
                            if (novotelemovel == res[i].nTele)
                            {
                                dispo = false;
                            }
                        }
                        if (dispo == true)
                            res[index].nTele = novotelemovel;
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("    Número de telemóvel já utilizado     ");
                            Console.WriteLine("-----------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                    }
                }
                if (op == 4)
                {
                    Console.WriteLine("Introduza o número de pessoas: ");
                    res[index].Npessoa = Convert.ToInt32(Console.ReadLine());
                }
                if (op == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("              Preço de quartos variados:          ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" Quarto simples de solteiro --------- 115 Euros !");
                    Console.WriteLine(" Quarto grande de solteiro ---------- 150 Euros !");
                    Console.WriteLine(" Quarto simples de casal ------------ 165 Euros !");
                    Console.WriteLine(" Quarto grande de casal ------------- 200 Euros !");
                    Console.WriteLine(" Suíte simples de casal ------------- 250 Euros !");
                    Console.WriteLine(" Suíte grande de casal -------------- 350 Euros !");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Introduza o novo preço do quarto ");
                    res[index].preco = Convert.ToInt32(Console.ReadLine());

                }
                if (op == 6)
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

                Console.WriteLine("Reserva alterada com sucesso!");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A reserva com este numero não existe");
            }
            op = 0;
        }
        else
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Operação inválida");

        }
    }
   
    // Exportar reservas---------------------------------------------------------------------------------------------------

    if (op == 6)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("               Exportar               ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Deseja exportar as reservas preenchidas para um ficheiro txt?");
        Console.WriteLine(" 1 - Sim \n \r 2 - Não");
        int opescolha = Convert.ToInt32(Console.ReadLine());

        if (opescolha == 1)
        {
            int c = 0;
            string export = "reservas.txt";
            string import = "reservasI.txt";
            StreamWriter writer = new StreamWriter(export);
            StreamWriter writer2 = new StreamWriter(import);

            Export(res, writer, c);
            ExportI(res, writer2, c);
        }
        else
            Console.WriteLine("Operação cancelada");
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

            bool sucesso = false;
            
            while (sucesso == false)
            {
                int nquarto = rnd.Next(200, 501);
                int confirmacao = pesquisa(res, nquarto);
                if (confirmacao == -1)
                {
                    res[disp].Nquarto = nquarto;
                    sucesso = true;
                }
            }

            sucesso = false;

            while (sucesso == false)
            {
                int ntel = rnd.Next(900000000, 1000000000);
                int confirmacao = pesquisaTel(res, ntel);

                if (confirmacao == -1)
                {
                    res[disp].nTele = ntel;
                    sucesso = true;
                }
            }

            res[disp].Npessoa = rnd.Next(1, 5);
            c = rnd.Next(precos.Length);
            res[disp].preco = precos[c];
            Dados(res[disp]);

        }
        else
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não é possível gerar uma reserva!\n\r(Reservas cheias)");

        }

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
        Console.WriteLine(" Quarto simples de solteiro --------- 115 Euros !");
        Console.WriteLine(" Quarto grande de solteiro ---------- 150 Euros !");
        Console.WriteLine(" Quarto simples de casal ------------ 165 Euros !");
        Console.WriteLine(" Quarto grande de casal ------------- 200 Euros !");
        Console.WriteLine(" Suíte simples de casal ------------- 250 Euros !");
        Console.WriteLine(" Suíte grande de casal -------------- 350 Euros !");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

    }

    // Limpar reserva-------------------------------------------------------------------------------------------------

    if(op == 10)
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("          Reservas preenchidas:       ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

        bool disp = false;

        for (int i = 0; i < res.Length; i++)
        {

            disp = true;
            if (res[i].Nquarto != 0)
            Console.Write($"|| {res[i].Nquarto}");
        }

        if (disp == false)
        {

            Console.WriteLine("Ainda não existem reservas preenchidas!");

        }
        else 
        {

            Console.WriteLine("Introduza o número do quarto de reserva que deseja limpar:");
            int rsLimpar = Convert.ToInt32(Console.ReadLine());

            int index = pesquisa(res, rsLimpar);

            if (index != -1) 
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
    }

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    VMenu();
    Console.Clear();

}

//---------------------------------------------------------------------------------------------------
//                                            Funções
//---------------------------------------------------------------------------------------------------

static int pesquisaTel(reserva[] a, int n)
{
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].nTele == n)
        {
            return i;
        }

    }
    return -1;
}

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

static void Export(reserva[] a, StreamWriter writer, int c)
{
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto != 0)
            c = c + 1;
    }

    writer.WriteLine($"Número de reservas: {c}");

    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto != 0)
        {
            writer.WriteLine("--------------------------------------");
            writer.WriteLine($"Nome: {a[i].nome} {a[i].apelido}");
            writer.WriteLine($"Número do quarto: {a[i].Nquarto}");
            writer.WriteLine($"Número de telefone {a[i].nTele}");
            writer.WriteLine($"Número de pessoas: {a[i].Npessoa}");
            writer.WriteLine($"Preço da reserva: {a[i].preco}");
            writer.WriteLine("--------------------------------------");
            writer.WriteLine();
        }
    }

    Console.WriteLine($"{c} reservas exportadas!");

    writer.Close();
    return;
}

static void ExportI(reserva[] a, StreamWriter writer, int c)
{
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto != 0)
            c = c + 1;
    }

    writer.WriteLine(c);

    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto != 0)
        {
            writer.WriteLine(a[i].nome);
            writer.WriteLine(a[i].apelido);
            writer.WriteLine(a[i].Nquarto);
            writer.WriteLine(a[i].nTele);
            writer.WriteLine(a[i].Npessoa);
            writer.WriteLine(a[i].preco);
        }
    }

    Console.WriteLine($"{c} reservas exportadas em um formato importável!");

    writer.Close();
    return;
}

static void Import (ref reserva res, StreamReader reader)
{
    res.nome = reader.ReadLine();
    res.apelido = reader.ReadLine();
    res.Nquarto = Convert.ToInt32(reader.ReadLine());
    res.nTele = Convert.ToInt32(reader.ReadLine());
    res.Npessoa = Convert.ToInt32(reader.ReadLine());
    res.preco = Convert.ToDouble(reader.ReadLine());

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

