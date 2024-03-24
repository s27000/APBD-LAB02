using System.Runtime.InteropServices;

namespace ProjektLAB02
{
    public class Program
    {
        private static List<Ship> shipList;
        private static int shipIDCounter;
        private static List<Container> containerList;
        private static int containerIDCounter;
        static void Main(string[] args)
        {
            shipList = new List<Ship>();
            shipIDCounter = 0;
            containerList = new List<Container>();
            containerIDCounter = 0;
            int option;

            do
            {
                MenuText();
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddShip();
                        break;
                    case 2:
                        RemoveShip();
                        break;
                }
            } while (option != 0);
        }

        static void MenuText()
        {
            Console.WriteLine("Lista kontenerowcow: ");
            PrintShipList();
            Console.WriteLine("\nLista kontenerów: ");
            PrintContainerList();
            Console.WriteLine("\nMożliwe akcje: ");
            PrintOptions();
            Console.Write("Wybierz opcje: ");
        }

        static void PrintShipList()
        {
            if (!shipList.Any())
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (Ship i in shipList)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }

        static void PrintContainerList()
        {
            if (!containerList.Any()) 
            {
                Console.WriteLine("Brak");
            }
            else
            {

            }
        }

        static void PrintOptions() 
        {
            Console.WriteLine("1. Dodaj kontenerowiec");
            if (shipList.Any())
            {
                Console.WriteLine(
                    "2. Usun kontenerowiec" +
                    "\n3. Dodaj kontener"
                );
                if (containerList.Any())
                {
                    Console.WriteLine("4. Usun Kontener");
                }
            }
            Console.WriteLine("0. Wyjscie z programu");
        }
        static void AddShip()
        {
            Console.Clear();
            Console.WriteLine("DODAWANIE STATKU");
            Console.Write("Podaj prędkość: ");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną liczbę kontenerów: ");
            int maxContainerNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę ładunku: ");
            int maxWeight = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            shipList.Add(new Ship(++shipIDCounter, speed, maxContainerNum, maxWeight));
        }

        static void RemoveShip(){
            Console.Clear();
            Console.WriteLine("USUWANIE STATKU");
            PrintShipList();
            Console.Write("\nPodaj numer statku do usunięcia: ");
            int shipID = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < shipList.Count(); i++){
                if (shipList[i].GetID()==shipID) 
                {
                    shipList.RemoveAt(i);
                    break;
                }
            }
            Console.Clear();
        }
    }
}