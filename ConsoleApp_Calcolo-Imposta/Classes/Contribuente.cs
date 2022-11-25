using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Calcolo_Imposta.Classes
{
    internal class Contribuente
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

        public DateTime BirthDate { get; set; }

        public string FiscalCode { get; set; }

        public string Gender { get; set; }
        public string City { get; set; }

        public double GrossSalary { get; set; }

        //Overload del costruttore per reperire BirthDate e Gender
        //dal FiscalCode preso in input. 
        public Contribuente(string CF)   
        {
            //la string MonthCode permette di confrontare il carattere relativo al mese
            //del codice fiscale e identificarlo grazie al suo indice in MonthCode > vedi riga 44
            String MonthCode = "ABCDEHLMPRST";
           
            
            string year = $"{CF[6]}{CF[7]}";
            int Year = int.Parse(year);
            if (Year > 20)
            {
                Year += 1900;
            }
            else
            {
                Year += 2000;
            }



            char month = CF[8];
            int Month = MonthCode.IndexOf(month) +1;

            string day = $"{CF[9]}{CF[10]}";
            int dayNum = int.Parse(day);
            int Day;

            //Nel codice fiscale il genere è codificato nel giorno di nascita.
            //Se (F) al giorno di nascita va sommato 40.
            if (dayNum<31) {
                Day = dayNum;
                Gender = "male";
            }
            else
            {
                
                Day = dayNum - 40;
                Gender = "female";
            }

            
            BirthDate = new DateTime(Year, Month, Day);
        }

        public double GetImposta()
        {
            double Imposta;
            if(GrossSalary <= 15000)
            {
                Imposta = GrossSalary * 23 / 100;
            }else if(GrossSalary <= 28000)
            {
                Imposta = 3450 + ((GrossSalary - 15000) * 27 / 100);
            }else if(GrossSalary <= 55000)
            {
                Imposta = 6960 + ((GrossSalary - 28000) * 38 / 100);
            }else if (GrossSalary <= 75000)
            {
                Imposta = 17220 + ((GrossSalary - 28000) * 41 / 100);
            }else
            {
                Imposta = 25420 + ((GrossSalary - 28000) * 43 / 100);
            }

            return Imposta;
        }
    }
}
