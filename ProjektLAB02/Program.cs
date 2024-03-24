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
                Console.Clear();
                if (option == 1)
                {
                    AddShip();
                }
                else if (shipList.Any())
                {
                    switch (option)
                    {
                        case 2:
                            RemoveShip();
                            break;
                        case 3:
                            AddContainer();
                            break;
                    }
                    if (containerList.Any())
                    {

                    }
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
                    Console.WriteLine(i);
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
                foreach(Container i in containerList)
                {
                    Console.WriteLine(i);
                }
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
            Console.WriteLine("DODAWANIE STATKU");
            Console.Write("Podaj prędkość: ");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną liczbę kontenerów: ");
            int maxContainerNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę(t) ładunku: ");
            int maxWeight = Convert.ToInt32(Console.ReadLine());
            shipList.Add(new Ship(++shipIDCounter, speed, maxContainerNum, maxWeight));
            Console.Clear();
        }

        static void RemoveShip(){
            Console.WriteLine("USUWANIE STATKU");
            PrintShipList();
            Console.Write("\nPodaj numer statku do usunięcia: ");
            int shipID = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < shipList.Count(); i++){
                if (shipList[i].ShipID==shipID) 
                {
                    shipList.RemoveAt(i);
                    break;
                }
            }
            Console.Clear();
        }

        static void AddContainer(){
            Console.WriteLine("DODAWANIE KONTENERA\n" +
                "Typy:\n" +
                "1. Kontener na płyny\n" +
                "2. Kontener na gaz\n" +
                "3. Kontener chłodniczy\n");
            Console.Write("Podaj rodzaj kontenera: ");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (type)
            {
                case 1:
                    AddLiquidContainer();
                    break;
                default:
                    Console.WriteLine("Error: wybrana opcja jest niepoprawna\n");
                    break;
            }
        }

        static void AddLiquidContainer(){
            Console.Write("Podaj wysokość kontenera: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj głębokość kontenera: ");
            int depth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj wagę(kg) kontenera: ");
            int conWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę(kg) ładunku: ");
            int maxProductWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Czy substancja przewożona jest niebezpieczna?: ");
            bool hazardousLoad = Convert.ToBoolean(Console.ReadLine());
            containerList.Add(new LiquidContainer("KON-L-" + (++containerIDCounter), height, depth, conWeight, maxProductWeight, hazardousLoad));
            Console.Clear();
        }
    }
}