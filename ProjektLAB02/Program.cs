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
                        switch (option)
                        {
                            case 4:
                                RemoveContainer();
                                break;
                            case 5:
                                LoadContainer();
                                break;
                            case 6:
                                UnloadContainer();
                                break;
                            case 7:
                                AddContainerToShip();
                                break;
                        }
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
                foreach (Container i in containerList)
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
                Console.WriteLine("2. Usun kontenerowiec" +
                    "\n3. Dodaj kontener"
                );
                if (containerList.Any())
                {
                    Console.WriteLine("4. Usun kontener" +
                        "\n5. Załaduj ładunek do kontenera" +
                        "\n6. Rozładuj kontener" +
                        "\n7. Załaduj kontener na statek");
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
            Console.Write("Podaj maksymalną wagę(kg) ładunku: ");
            int maxWeight = Convert.ToInt32(Console.ReadLine());
            shipList.Add(new Ship(++shipIDCounter, speed, maxContainerNum, maxWeight));
            Console.Clear();
        }

        static void RemoveShip() {
            Console.WriteLine("USUWANIE STATKU");
            PrintShipList();
            Console.Write("\nPodaj numer statku do usunięcia: ");
            int shipID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            shipList.Remove(findShip(shipID));
        }

        static Ship findShip(int shipID)
        {
            foreach (Ship i in shipList)
            {
                if (i.ShipID == shipID)
                {
                    return i;
                }
            }
            return null;
        }

        static void AddContainer() {
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
                case 2:
                    AddGazContainer();
                    break;
            }
        }

        static void LoadContainer(){
            Console.WriteLine("ZAŁADUJ KONTENER");
            PrintContainerList();
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNum = Console.ReadLine();
            Console.Write("Podaj mase ladunku: ");
            int productMass = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            findContainerFromList(serialNum).LoadProduct(productMass);
        }

        static void UnloadContainer(){
            Console.WriteLine("ROZŁADUJ KONTENER");
            PrintContainerList();
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNum = Console.ReadLine();
            Console.Clear();
            findContainerFromList(serialNum).UnloadProduct();
        }
        static void AddContainerToShip(){
            Console.WriteLine("ZAŁADOWANIE KONTENER NA STATEK");
            PrintContainerList();
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNum = Console.ReadLine();
            PrintShipList();
            Console.Write("Podaj numer statku: ");
            int shipID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Container con = findContainerFromList(serialNum);
            findShip(shipID).AddContainer(con);
            containerList.Remove(con);
        }

        static Container findContainerFromList(String serialNum)
        {
            foreach(Container c in containerList)
            {
                if (c.SerialNum == serialNum)
                {
                    return c;
                }
            }
            return null;
        }
        static void RemoveContainer(){
            Console.WriteLine("USUWANIE KONTENERA");
            PrintContainerList();
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNum = Console.ReadLine();
            Console.Clear();
            containerList.Remove(findContainerFromList(serialNum));
        }

        static void AddLiquidContainer(){
            Console.WriteLine("DODAWANIE KONTENERA NA PŁYNY");
            Console.Write("Podaj wysokość kontenera: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj głębokość kontenera: ");
            int depth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj wagę(kg) kontenera: ");
            int conWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę(kg) ładunku: ");
            int maxProductWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Czy substancja przewożona jest niebezpieczna?\n(true) or (false): ");
            bool hazardousLoad = Convert.ToBoolean(Console.ReadLine());
            containerList.Add(new LiquidContainer("KON-L-" + (++containerIDCounter), height, depth, conWeight, maxProductWeight, hazardousLoad));
            Console.Clear();
        }

        static void AddGazContainer() {
            Console.WriteLine("DODAWANIE KONTENERA NA PŁYNY");
            Console.Write("Podaj wysokość kontenera: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj głębokość kontenera: ");
            int depth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj wagę(kg) kontenera: ");
            int conWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę(kg) ładunku: ");
            int maxProductWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj cisnienie(atm) ładunku: ");
            int pressure = Convert.ToInt32(Console.ReadLine());
            containerList.Add(new GazContainer("KON-G-" + (++containerIDCounter), height, depth, conWeight, maxProductWeight, pressure));
            Console.Clear();
        }
    }
}