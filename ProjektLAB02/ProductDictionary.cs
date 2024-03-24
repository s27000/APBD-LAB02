using System;

public class ProductDictionary
{
	private static Dictionary<string, double> productDict;
	static ProductDictionary()
	{
        productDict = new Dictionary<string, double>
        {
            { "Bananas", 13.3 },
            { "Choclate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice Cream", -18 },
            { "Frozen Pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5},
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
    }

    public static bool productExists(string product)
    {
        return productDict.ContainsKey(product);
    }
    public static double getTemperatureFor(string product) 
    {
        return productDict[product];
    }
}
