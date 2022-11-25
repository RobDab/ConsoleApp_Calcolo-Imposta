using ConsoleApp_Calcolo_Imposta.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Calcolo_Imposta
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;



            Console.WriteLine("         |       *** Benventuro in IncCool8 ***     |");
            Console.WriteLine("         |--   Calcolatore d'imposta sul reddito  --|\n\n");
            Console.WriteLine("_click -ENTER- to start.");
            Console.ReadLine();

            string answerNeg = "n";
            string answer = "y";
            do
            {
                try
                {
                    Contribuente CurrentContribuente = GetInfo();
                    Console.WriteLine($"|    Contribuente: {CurrentContribuente.Name} {CurrentContribuente.Lastname} / ({CurrentContribuente.Gender})");
                    Console.WriteLine($"|    Nato il: {CurrentContribuente.BirthDate.ToShortDateString()}");
                    Console.WriteLine($"|    Residente a: {CurrentContribuente.City}");
                    Console.WriteLine($"|    Cod Fisc: {CurrentContribuente.FiscalCode}\n");
                    Console.WriteLine($">    Reddito dichiarato :  €{CurrentContribuente.GrossSalary}");
                    Console.WriteLine($">    Imposta sul reddito:  €{CurrentContribuente.GetImposta()}\n");

                    double NetSalary = GetNetSalary(CurrentContribuente.GrossSalary, CurrentContribuente.GetImposta());

                    Console.WriteLine($"*** Reddito netto previsto: €{NetSalary}\n");

                    Console.WriteLine("-* Vuoi effettuare un nuoco calcolo? *-\n qualsiasi tasto per proseguire_\n'n' per terminare_");
                    answer = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }


                if(answer == answerNeg)
                {
                    Console.WriteLine("---------------------\n");
                    Console.WriteLine(" THANKS FOR USING THIS APPLICATION! rate me on the appstore\n\n ___ Ending in 3s...\n");
                    Console.WriteLine("---------------------\n");
                    Thread.Sleep(3500);
                    Environment.Exit(0);
                }
            } while (answer != answerNeg);
        }

        public static Contribuente GetInfo()
        {
            string cf;

            Console.WriteLine("- Insert Name: _");
            string Name = Console.ReadLine();

            Console.WriteLine("- Insert Lastname: _");
            string Lastname = Console.ReadLine();

            do
            {
                Console.WriteLine("-Insert Fiscal Code: _");
                cf = Console.ReadLine();
                if(cf.Length != 16)
                {
                    Console.WriteLine("- hai inserito un CF della lunghezza sbagliata. Riprova_\n");
                }
            } while (cf.Length != 16);

            Console.WriteLine("-Insert City: _");
            string City = Console.ReadLine();
            

            Console.WriteLine("-Insert salary: € _");
            double salary = double.Parse(Console.ReadLine());
            Console.WriteLine("... solo?");
            Console.ReadLine();



            Contribuente currentContribuente = new Contribuente(cf.ToUpper())
            {
                Name = Name.ToUpper(),
                Lastname = Lastname.ToUpper(),
                FiscalCode = cf.ToUpper(),
                City = City,
                GrossSalary = salary
            };

            return currentContribuente;
        }

        public static double GetNetSalary(double gross, double imposta)
        {
            double netSalary = gross - imposta;

            return netSalary;
        }
    }
}
