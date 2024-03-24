using System;

public class GazContainer : Container, IHazardNotifier
{
	private int pressure;
	public GazContainer(string serialNum, int height, int depth, int conWeight, int maxProductWeight, int pressure) : base(serialNum, height, depth, conWeight, maxProductWeight)
	{
		this.pressure = pressure;
	}

    public override void LoadProduct(int productMass)
    {
        base.LoadProduct(productMass);
        if (pressure>100 && (ProductMass > (MaxProductWeight * 0.5)))
        {
            NotifyHazard();
        }
    }

    public void NotifyHazard() 
	{
        Console.WriteLine("WYKRYTO NIEBEZPIECZEŃSTWO: Kontener " + SerialNum + " posiada wysoce skondensowany gaz w nadmiarze!");
    }
    public override string ToString()
    {
        return base.ToString() + ", pressure=" + pressure + ")";
    }
}
