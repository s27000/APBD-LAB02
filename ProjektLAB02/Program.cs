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
                            case 9:
                                AddContainerListToShip();
                                break;
                            case 10:
                                ExchangeContainerOnShip();
                                break;
                        }
                    }
                    if (!shipsEmpty())
                    {
                        switch (option)
                        {
                            case 8:
                                RemoveContainerFromShip();
                                break;
                            case 11:
                                ExchangeContainersBetweenShips();
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
                if (!shipsEmpty())
                {
                     Console.WriteLine("8. Usuń kontener z statku");
                }
                if (containerList.Any())
                {
                    Console.WriteLine("9. Załaduj liste kontenerów na statek" +
                       "\n10. Zastąp kontener na statku innym kontenerem");
                }
                if (!shipsEmpty())
                {
                    Console.WriteLine("11. Przenieś kontener między dwoma statkami");
                }
            }
            Console.WriteLine("0. Wyjscie z programu");
        }

        static bool shipsEmpty()
        {
            foreach (Ship i in shipList)
            {
                if (!i.isEmpty)
                {
                    return false;
                }
            }
            return true;
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
                case 3:
                    AddCoolantContainer();
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

        static void AddContainerListToShip()
        {
            Console.WriteLine("ZAŁADOWANIE LISTY KONTENERÓW NA STATEK");
            PrintShipList();
            Console.Write("Podaj numer statku: ");
            int shipID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            findShip(shipID).AddContainerList(containerList);
            containerList.Clear();
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

        static void RemoveContainerFromShip(){
            Console.WriteLine("USUŃ KONTENER ZE STATEK");
            PrintShipList();
            Console.Write("Podaj numer statku: ");
            int shipID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNum = Console.ReadLine();
            Console.Clear();
            containerList.Add(findShip(shipID).RemoveContainer(serialNum));
        }

        static void ExchangeContainerOnShip()
        {
            Console.WriteLine("WYMIEŃ KONTENER ZE STATKU Z INNNYM KONTENEREM");
            PrintShipList();
            Console.Write("Podaj numer statku: ");
            int shipID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj numer seryjny kontenera na statku: ");
            string serialNumShip = Console.ReadLine();
            PrintContainerList();
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNumExchange = Console.ReadLine();
            Console.Clear();
            containerList.Add(findShip(shipID).RemoveContainer(serialNumShip));
            findShip(shipID).AddContainer(findContainerFromList(serialNumExchange));
            containerList.Remove(findContainerFromList(serialNumExchange));
        }

        static void ExchangeContainersBetweenShips() {
            Console.WriteLine("WYMIEŃ KONTENERY MIEDZY STATKAMI");
            PrintShipList();
            Console.Write("Podaj numer statku wysyłającego: ");
            int shipID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj numer seryjny kontenera: ");
            string serialNum = Console.ReadLine();

            Console.Write("Podaj numer statku docelowego: ");
            int shipID2 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            findShip(shipID2).AddContainer(findShip(shipID).RemoveContainer(serialNum));
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
            Console.WriteLine("DODAWANIE KONTENERA NA GAZ");
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
            Console.Clear();
            containerList.Add(new GazContainer("KON-G-" + (++containerIDCounter), height, depth, conWeight, maxProductWeight, pressure));
        }

        static void AddCoolantContainer()
        {
            Console.WriteLine("DODAWANIE KONTENERA CHŁODNICZEGO");
            Console.Write("Podaj wysokość kontenera: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj głębokość kontenera: ");
            int depth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj wagę(kg) kontenera: ");
            int conWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę(kg) ładunku: ");
            int maxProductWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj typ produktu: ");
            string productName = Console.ReadLine();
            Console.Write("Podaj temperature wewnątrz kontenera: ");
            double temperature = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            containerList.Add(new CoolantContainer("KON-C-" + (++containerIDCounter), height, depth, conWeight, maxProductWeight, productName, temperature));
        }
    }
}