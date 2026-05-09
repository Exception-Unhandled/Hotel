using System;
using System.ComponentModel;
using Hotel_trebalho_Grupo;


int op = 1;

reserva[] reservas = new reserva[100];



for (int i = 0; i < reservas.Length; i++)
{
    reservas[i] = new reserva();
}

Random rnd = new Random();

List<quarto> lista = new List<quarto>();
string caminho = "quartos.txt";

string[] nomes = ["Laura", "Samara", "Ana", "Rodrigo", "Herbert", "Maria", "Carolina", "João", "Marcos", "Otávio", "César", "Micaela", "Cláudia"];
string[] apelidos = ["Faro", "Soares", "Silva", "Albuquerque", "Hernandes", "Marim", "Costa", "Alves", "Souza", "Pereira", "Oliveira", "Vilarouca", "Queiroz"];
int[] precos = [115, 150, 165, 200, 250, 350];


//Start---------------------------------------------------------------------------------------------------

Menu:

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine("                   TP 1 - Module 7                   ");
Console.WriteLine("                 Reservation Manager                 ");
Console.WriteLine("   Herbert Junior - #7 / Micaela Albuquerque #12     ");
Console.WriteLine("-----------------------------------------------------");
Console.WriteLine("-----------------------------------------------------");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("(Press ENTER to start the program!)");
Console.ReadLine();

while (op != 0)
{

    Console.OutputEncoding = System.Text.Encoding.UTF8;

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("         Welcome to the Hotel!        ");
    Console.WriteLine("         What would you like to do?  ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" 1- Import reservation                ");
    Console.WriteLine(" 2- Insert new reservation            ");
    Console.WriteLine(" 3- Search reservations               ");
    Console.WriteLine(" 4- Show filled reservations          ");
    Console.WriteLine(" 5- Edit reservation data             ");
    Console.WriteLine(" 6- Export reservations               ");
    Console.WriteLine(" 7- Generate reservation              ");
    Console.WriteLine(" 8- Number of available slots         ");
    Console.WriteLine(" 9- Check room prices                 ");
    Console.WriteLine(" 10- Clear reservation                ");
    Console.WriteLine(" 0- Exit                              ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;


    Console.WriteLine("Enter your option");
    op = Convert.ToInt32(Console.ReadLine());

    // Import reservation---------------------------------------------------------------------------------------------------

    if (op == 1)
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("               Import                 ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Do you want to import filled reservations from a txt file?");
        Console.WriteLine(" 1 - Yes \n \r 2 - No");
        int opescolha = Convert.ToInt32(Console.ReadLine());

        if (opescolha == 1)
        {
        inicioImportar1:
            try
            {
                Console.WriteLine("Enter the file name\r\n(WARNING: Do not include the file extension)");

                caminho = Console.ReadLine() + ".txt";
                Console.WriteLine("Searching in: " + Path.GetFullPath(caminho));

                StreamReader reader = new StreamReader(caminho);

                Array.Clear(reservas);

                for (int i = 0; i < reservas.Length; i++)
                {
                    reservas[i] = new reserva();
                }

                int c = Convert.ToInt16(reader.ReadLine());

                for (int i = 0; i < c; i++)
                {
                    Import(ref reservas[i], reader);
                    Dados(reservas[i]);
                }

                reader.Close();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("         Reservations imported        ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
                goto Menu;
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
                Console.ReadLine();
                goto inicioImportar1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
                Console.ReadLine();
                goto Menu;
            }
        }
    }

    // Insert new reservation---------------------------------------------------------------------------------------------------

    if (op == 2)
    {
    novares1:
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            int disp = checkV(reservas);
            if (disp != -1)
            {

                Console.WriteLine("Enter the reservation name:");
                reservas[disp].nome = Console.ReadLine();

                Console.WriteLine($"Enter the last name for {reservas[disp].nome}: ");
                reservas[disp].apelido = Console.ReadLine();

                Console.WriteLine("Enter the phone number:");
                reservas[disp].nTele = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the room number:");
                reservas[disp].Nquarto = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the number of people who will use the room:");
                reservas[disp].Npessoa = Convert.ToInt32(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("              Room price list:                    ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Single room (small) ---------------- 115 € !");
                Console.WriteLine(" Single room (large) ---------------- 150 € !");
                Console.WriteLine(" Double room (small) ---------------- 165 € !");
                Console.WriteLine(" Double room (large) ---------------- 200 € !");
                Console.WriteLine(" Suite (small) ---------------------- 250 € !");
                Console.WriteLine(" Suite (large) ---------------------- 350 € !");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Enter the room price:");
                reservas[disp].preco = Convert.ToDouble(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Reservation created successfully!");

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No available reservation slots!\n\r(Clear a reservation to store a new one)");

            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto novares1;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto novares1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }
    }

    // Search reservation---------------------------------------------------------------------------------------------------

    if (op == 3)
    {
    pesquisa1:
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you want to see available reservations or search by room number?");
            Console.WriteLine(" 1 - See available reservations");
            Console.WriteLine(" 2 - Search by room number");
            Console.ForegroundColor = ConsoleColor.White;
            op = Convert.ToInt16(Console.ReadLine());

            // See available reservations

            if (op == 1)
            {

                bool disp = false;
                Console.WriteLine("Available reservations:");

                for (int i = 0; i < reservas.Length; i++)
                {
                    if (reservas[i].Nquarto != 0)
                    {

                        Console.Write($"|| {reservas[i].Nquarto} ");
                        disp = true;

                    }

                }
                if (disp == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the room number to see its details:");
                    int quarto = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < reservas.Length; i++)
                    {
                        if (quarto == reservas[i].Nquarto)
                            Dados(reservas[i]);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No reservations have been created!");
                }
            }

            // Search by room number

            else if (op == 2)
            {
                Console.WriteLine("Enter the room number to see its details:");
                int n = Convert.ToInt32(Console.ReadLine());
                int index = pesquisa(reservas, n);
                if (index != -1)
                {
                    Dados(reservas[index]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No reservation found with this number");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto pesquisa1;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto pesquisa1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }
    }

    // Show all reservations---------------------------------------------------------------------------------------------------

    if (op == 4)
    {
    mostraRes:
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Filled reservations:");
            bool disp = false;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].Nquarto != 0)
                {

                    disp = true;
                    Dados(reservas[i]);
                    Console.WriteLine();

                }
            }

            if (disp == false)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No reservations have been filled yet!");

            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto mostraRes;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto mostraRes;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }
    }

    // Edit reservation data---------------------------------------------------------------------------------------------------

    if (op == 5)
    {
    InicioAlterar:
        int opescolha;
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you want to edit from available reservations or search by room number?");
            Console.WriteLine("1 - See available reservations");
            Console.WriteLine("2 - Search by room number");
            opescolha = Convert.ToInt16(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto InicioAlterar;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }
        //Available reservations

        if (opescolha == 1)
        {
            bool disp = false;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].Nquarto != 0)
                {
                    disp = true;
                }
            }

            if (disp == false)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No reservations have been created!");

            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("            Available reservations:");
                Console.WriteLine();
                for (int i = 0; i < reservas.Length; i++)
                {
                    if (reservas[i].Nquarto != 0)
                    {

                        Console.Write($"|| {reservas[i].Nquarto}");

                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                int quarto;

                try
                {
                    Console.WriteLine("Enter the room number of the reservation you want to edit:");
                    quarto = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
                    Console.ReadLine();
                    goto InicioAlterar;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
                    Console.ReadLine();
                    goto InicioAlterar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
                    Console.ReadLine();
                    goto Menu;
                }

                int index = pesquisa(reservas, quarto);

                if (index != -1)
                {
                    Console.Clear();
                    Dados(reservas[index]);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("-------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("What would you like to edit?");
                    Console.WriteLine("1 - Name/Last name");
                    Console.WriteLine("2 - Room number");
                    Console.WriteLine("3 - Phone number");
                    Console.WriteLine("4 - Number of guests");
                    Console.WriteLine("5 - Price");
                    Console.WriteLine("6 - Change everything");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("-------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    opescolha = Convert.ToInt32(Console.ReadLine());

                    if (opescolha == 1)
                    {

                        Console.WriteLine("Enter the new reservation name");
                        reservas[index].nome = Console.ReadLine();
                        Console.WriteLine($"Enter the new last name for {reservas[index].nome}");
                        reservas[index].apelido = Console.ReadLine();

                    }
                    if (opescolha == 2)
                    {
                        bool dispo = true;
                        while (dispo == false)
                        {

                            Console.WriteLine("Enter the new room number");
                            int novoquart = Convert.ToInt32(Console.ReadLine());


                            for (int i = 0; i < reservas.Length; i++)
                            {
                                if (novoquart == reservas[i].Nquarto)
                                {
                                    dispo = false;
                                }
                            }
                            if (dispo == true)
                                reservas[index].Nquarto = novoquart;
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("----------------------------");
                                Console.WriteLine("       Room occupied        ");
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
                            Console.WriteLine("Enter the new phone number");
                            int novotelemovel = Convert.ToInt32(Console.ReadLine());


                            for (int i = 0; i < reservas.Length; i++)
                            {
                                if (novotelemovel == reservas[i].nTele)
                                {
                                    dispo = false;
                                }
                            }
                            if (dispo == true)
                                reservas[index].nTele = novotelemovel;
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("      Phone number already in use        ");
                                Console.WriteLine("-----------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }


                        }
                    }
                    if (opescolha == 4)
                    {
                        Console.WriteLine("Enter the number of guests: ");
                        reservas[index].Npessoa = Convert.ToInt32(Console.ReadLine());
                    }
                    if (opescolha == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("              Room price list:                    ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Single room (small) ---------------- 115 Euros !");
                        Console.WriteLine(" Single room (large) ---------------- 150 Euros !");
                        Console.WriteLine(" Double room (small) ---------------- 165 Euros !");
                        Console.WriteLine(" Double room (large) ---------------- 200 Euros !");
                        Console.WriteLine(" Suite (small) ---------------------- 250 Euros !");
                        Console.WriteLine(" Suite (large) ---------------------- 350 Euros !");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Enter the new room price ");
                        reservas[index].preco = Convert.ToInt32(Console.ReadLine());

                    }
                    if (opescolha == 6)
                    {
                        Console.WriteLine("Enter a new name");
                        reservas[index].nome = Console.ReadLine();

                        Console.WriteLine("Enter a new last name");
                        reservas[index].apelido = Console.ReadLine();

                        Console.WriteLine("Enter a new room number");
                        reservas[index].Nquarto = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter a new phone number");
                        reservas[index].nTele = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter a new number of guests");
                        reservas[index].Npessoa = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter a new price");
                        reservas[index].preco = Convert.ToDouble(Console.ReadLine());
                    }

                    Console.WriteLine("Reservation edited successfully!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No reservation found with this number");
                }
            }
        }

        //Search by reservation number

        else if (opescolha == 2)
        {

            Console.WriteLine("Enter the room number of the reservation you want to edit:");
            int n = Convert.ToInt32(Console.ReadLine());
            int index = pesquisa(reservas, n);
            if (index != -1)
            {

                Dados(reservas[index]);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("1 - Name/Last name");
                Console.WriteLine("2 - Room number");
                Console.WriteLine("3 - Phone number");
                Console.WriteLine("4 - Number of guests");
                Console.WriteLine("5 - Price");
                Console.WriteLine("6 - Change everything");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                opescolha = Convert.ToInt32(Console.ReadLine());

                if (op == 1)
                {

                    Console.WriteLine("Enter the new reservation name");
                    reservas[index].nome = Console.ReadLine();
                    Console.WriteLine("Enter the new last name");
                    reservas[index].apelido = Console.ReadLine();

                }
                if (op == 2)
                {

                    bool dispo = true;
                    while (dispo == false)
                    {
                        Console.WriteLine("Enter the new room number");
                        int novoquart = Convert.ToInt32(Console.ReadLine());


                        for (int i = 0; i < reservas.Length; i++)
                        {
                            if (novoquart == reservas[i].Nquarto)
                            {

                                dispo = false;

                            }
                        }
                        if (dispo == true)
                            reservas[index].Nquarto = novoquart;
                        else
                        {

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("       Room occupied        ");
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
                        Console.WriteLine("Enter the new phone number");
                        int novotelemovel = Convert.ToInt32(Console.ReadLine());


                        for (int i = 0; i < reservas.Length; i++)
                        {
                            if (novotelemovel == reservas[i].nTele)
                            {
                                dispo = false;
                            }
                        }
                        if (dispo == true)
                            reservas[index].nTele = novotelemovel;
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("      Phone number already in use        ");
                            Console.WriteLine("-----------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                    }
                }
                if (op == 4)
                {
                    Console.WriteLine("Enter the number of guests: ");
                    reservas[index].Npessoa = Convert.ToInt32(Console.ReadLine());
                }
                if (op == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("              Room price list:                    ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" Single room (small) ---------------- 115 Euros !");
                    Console.WriteLine(" Single room (large) ---------------- 150 Euros !");
                    Console.WriteLine(" Double room (small) ---------------- 165 Euros !");
                    Console.WriteLine(" Double room (large) ---------------- 200 Euros !");
                    Console.WriteLine(" Suite (small) ---------------------- 250 Euros !");
                    Console.WriteLine(" Suite (large) ---------------------- 350 Euros !");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Enter the new room price ");
                    reservas[index].preco = Convert.ToInt32(Console.ReadLine());

                }
                if (op == 6)
                {
                    Console.WriteLine("Enter a new name");
                    reservas[index].nome = Console.ReadLine();

                    Console.WriteLine("Enter a new last name");
                    reservas[index].apelido = Console.ReadLine();

                    Console.WriteLine("Enter a new room number");
                    reservas[index].Nquarto = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter a new phone number");
                    reservas[index].nTele = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter a new number of guests");
                    reservas[index].Npessoa = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter a new price");
                    reservas[index].preco = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine("Reservation edited successfully!");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No reservation found with this number");
            }
            op = 0;
        }
        else
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid operation");

        }
    }
    // Export reservations---------------------------------------------------------------------------------------------------

    if (op == 6)
    {
    Exportar:
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("               Export                 ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you want to export filled reservations to a txt file?");
            Console.WriteLine(" 1 - Yes \n \r 2 - No");
            int opescolha = Convert.ToInt32(Console.ReadLine());

            if (opescolha == 1)
            {
                int c = 0;
                string export = "reservas.txt";
                string import = "reservasI.txt";
                StreamWriter writer = new StreamWriter(export);
                StreamWriter writer2 = new StreamWriter(import);

                Export(reservas, writer, c);
                ExportI(reservas, writer2, c);
            }
            else
                Console.WriteLine("Operation cancelled");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto Exportar;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto Exportar;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }
    }

    // Generate reservation---------------------------------------------------------------------------------------------------

    if (op == 7)
    {
    gerar:
        try
        {
            int disp = checkV(reservas);
            if (disp != -1)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Generated reservation:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                int c = rnd.Next(nomes.Length);
                reservas[disp].nome = nomes[c];
                c = rnd.Next(apelidos.Length);
                reservas[disp].apelido = apelidos[c];

                bool sucesso = false;

                while (sucesso == false)
                {
                    int nquarto = rnd.Next(200, 501);
                    int confirmacao = pesquisa(reservas, nquarto);
                    if (confirmacao == -1)
                    {
                        reservas[disp].Nquarto = nquarto;
                        sucesso = true;
                    }
                }

                sucesso = false;

                while (sucesso == false)
                {
                    int ntel = rnd.Next(900000000, 1000000000);
                    int confirmacao = pesquisaTel(reservas, ntel);

                    if (confirmacao == -1)
                    {
                        reservas[disp].nTele = ntel;
                        sucesso = true;
                    }
                }

                reservas[disp].Npessoa = rnd.Next(1, 5);
                c = rnd.Next(precos.Length);
                reservas[disp].preco = precos[c];
                Dados(reservas[disp]);

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to generate a reservation!\n\r(All reservation slots are full)");

            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto gerar;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto gerar;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }

    }

    // Available slots---------------------------------------------------------------------------------------------------

    if (op == 8)
    {
    ReservasDispo:

        try
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            int contar = 0;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].Nquarto == 0)
                {

                    contar = contar + 1;

                }
            }

            Console.WriteLine($"There are {contar} available reservation slots");
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto ReservasDispo;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto ReservasDispo;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }
    }

    // Room prices---------------------------------------------------------------------------------------------------

    if (op == 9)
    {

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("              Room price list:                    ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Single room (small) ---------------- 115 € !");
        Console.WriteLine(" Single room (large) ---------------- 150 € !");
        Console.WriteLine(" Double room (small) ---------------- 165 € !");
        Console.WriteLine(" Double room (large) ---------------- 200 € !");
        Console.WriteLine(" Suite (small) ---------------------- 250 € !");
        Console.WriteLine(" Suite (large) ---------------------- 350 € !");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

    }

    // Clear reservation-------------------------------------------------------------------------------------------------

    if (op == 10)
    {
    LimparRes:

        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("          Filled reservations:        ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            bool disp = false;

            for (int i = 0; i < reservas.Length; i++)
            {

                disp = true;
                if (reservas[i].Nquarto != 0)
                    Console.Write($"|| {reservas[i].Nquarto}");
            }
            Console.WriteLine();
            if (disp == false)
            {

                Console.WriteLine("No reservations have been filled yet!");

            }
            else
            {

                Console.WriteLine("Enter the room number of the reservation you want to clear:");
                int rsLimpar = Convert.ToInt32(Console.ReadLine());

                int index = pesquisa(reservas, rsLimpar);

                if (index != -1)
                {

                    reservas[index].nome = string.Empty;
                    reservas[index].apelido = string.Empty;
                    reservas[index].nTele = 0;
                    reservas[index].preco = 0;
                    reservas[index].Npessoa = 0;
                    reservas[index].Nquarto = 0;

                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No reservation found with this number");

                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERROR: File not found. Check if the file name is correct or if it is in the bin folder");
            goto LimparRes;
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR: The entered data is in the wrong format! Please enter it again");
            Console.ReadLine();
            goto LimparRes;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: An error occurred while running the program. Returning to menu");
            Console.ReadLine();
            goto Menu;
        }


    }

    //Exit---------------------------------------------------------------------------------------------------

    if (op == 0)
    {

        bool valido = false;

        while (valido == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("          Are you sure you want to exit?  ");
            Console.WriteLine(" 1 - Yes \n \r 2 - No");
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
                Console.WriteLine("Invalid option!");
                Console.WriteLine("(Press ENTER to try again)");
                Console.ReadLine();
            }
        }
    }

    //Invalid option---------------------------------------------------------------------------------------------------

    if (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5 && op != 6 && op != 7 && op != 8 && op != 9 && op != 10)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid option!");
    }

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    VMenu();
    Console.Clear();

}

//---------------------------------------------------------------------------------------------------
//                                            Functions
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
    Console.WriteLine("(Press ENTER to return to the menu!)");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadLine();
    return;
}

static void Dados(reserva a)
{
    Console.WriteLine("--------------------------------------");
    Console.WriteLine($"Name: {a.nome} {a.apelido}");
    Console.WriteLine($"Room number: {a.Nquarto}");
    Console.WriteLine($"Phone number: {a.nTele}");
    Console.WriteLine($"Number of guests: {a.Npessoa}");
    Console.WriteLine($"Reservation price: {a.preco} €");
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

    writer.WriteLine($"Number of reservations: {c}");

    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto != 0)
        {
            writer.WriteLine("--------------------------------------");
            writer.WriteLine($"Name: {a[i].nome} {a[i].apelido}");
            writer.WriteLine($"Room number: {a[i].Nquarto}");
            writer.WriteLine($"Phone number: {a[i].nTele}");
            writer.WriteLine($"Number of guests: {a[i].Npessoa}");
            writer.WriteLine($"Reservation price: {a[i].preco}");
            writer.WriteLine("--------------------------------------");
            writer.WriteLine();
        }
    }

    Console.WriteLine($"{c} reservations exported!");

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

    Console.WriteLine($"{c} reservations exported in importable format!");

    writer.Close();
    return;
}

static void Import(ref reserva reservas, StreamReader reader)
{
    reservas.nome = reader.ReadLine();
    reservas.apelido = reader.ReadLine();
    reservas.Nquarto = Convert.ToInt32(reader.ReadLine());
    reservas.nTele = Convert.ToInt32(reader.ReadLine());
    reservas.Npessoa = Convert.ToInt32(reader.ReadLine());
    reservas.preco = Convert.ToDouble(reader.ReadLine());

    return;
}

static int checkV(reserva[] a)
{
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i].Nquarto == 0)
        {
            return i;
        }
    }
    return -1;
}