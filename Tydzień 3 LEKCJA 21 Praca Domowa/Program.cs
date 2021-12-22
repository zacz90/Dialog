using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tydzień_3_LEKCJA_21_Praca_Domowa
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dialog();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine("\nDziękuję za korzystanie z programu.");
            }
        }
        private static void Dialog()
        {
            //Napisz aplikację, która na podstawie wprowadzonych przez użytkownika danych
            //tj. imię, rok urodzenia, miesiąc urodzenia, dzień urodzenia i miejsce urodzenia zwraca 1 zdanie opisujące tego użytkownika.
            //Np „Cześć IMIE urodziłeś się w MIEJSCOWOŚĆ i masz WIEK lat”.

            //deklaracja zmiennych
            string userName, birthPlace;
            int birthYear, birthMonth, birthDay;
            decimal age;
            const int ELDEST_PERSON_BIRTHDAY = 1903;
            DateTime birthDate;
            DateTime today = DateTime.Today;

            //inicjalizacja zmiennych na podstawie danych wprowadzonych przez użytkownika
            Console.WriteLine("Witaj. Proszę podaj swoje imię");
            userName = Console.ReadLine();
            while (userName.Length == 0)
            {
                Console.WriteLine("Należy podać imię.");
                userName = Console.ReadLine();
            }

            Console.WriteLine("Podaj rok swojego urodzenia w formacie RRRR.");
            birthYear = GetInput();
            while (birthYear > today.Year || birthYear < ELDEST_PERSON_BIRTHDAY )
            {
                Console.WriteLine("Proszę wprowadzić prawidłowy rok urodzenia.");
                birthYear = GetInput();
            }
            

            Console.WriteLine("Podaj miesiąc swojego urodzenia w formacie MM.");
            birthMonth = GetInput();
            while (birthMonth < 1 || birthMonth > 12) 
            {
                Console.WriteLine("Proszę wprowadzić prawidłowy miesiąc urodzenia.");
                birthMonth = GetInput();
            }

            Console.WriteLine("Podaj dzień swojego urodzenia w formacie DD.");
            birthDay = GetInput();
            while (birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth))
            {
                Console.WriteLine("Proszę wprowadzić prawidłowy dzień urodzenia.");
                birthDay = GetInput();
            }

            Console.WriteLine("Podaj miasto swojego urodzenia.");
            birthPlace = Console.ReadLine();
            while (birthPlace.Length == 0)
            {
                Console.WriteLine("Należy podać miasto.");
                birthPlace = Console.ReadLine();
            }

            birthDate = new DateTime(birthYear, birthMonth, birthDay);
            
            //obliczenie wieku
            //-pierwszy sposób
            //age = (int)(today - birthDate).Days/365.25M;
            //-drugi sposób
            age = today.Year - birthDate.Year;
            if (birthDate.DayOfYear > today.DayOfYear)
                age--;
            
            
            Console.WriteLine($"Cześć {userName}. Urodziłeś się w mieście {birthPlace} i masz {(int)age} lat.");
        }
        private static int GetInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Nieprawidłowe dane, wprowadź ponownie.");
            }
            return result;
        }
    }
}
