using System;

public class CoolantContainer : Container
{
	private string productName;
	private double temperature;
	public CoolantContainer(string serialNum, int height, int depth, int conWeight, int maxProductWeight, string productName, double temperature) 
		: base(serialNum, height, depth, conWeight, maxProductWeight)
	{
		if (!ProductDictionary.productExists(productName))
		{
			throw new Exception("Nazwa produktu '" + productName + "' nie istnieje");
		}
		if (ProductDictionary.getTemperatureFor(productName) > temperature) 
		{
            throw new Exception("Temperatura " + temperature + " jest za niska dla produktu '"+ productName + "'");
        }
		this.productName = productName;
		this.temperature = temperature;
	}

    public override string ToString()
    {
        return base.ToString() + ", productName=" + productName 
			+ ", temperature=" + temperature + ")";
    }
}
