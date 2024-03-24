using System;

public class LiquidContainer : Container, IHazardNotifier
{
	private bool hazardousLoad;
	public LiquidContainer(string serialNum, int height, int depth, int conWeight, int maxProductWeight, bool hazardousLoad) : base(serialNum, height, depth, conWeight, maxProductWeight)
	{
		this.hazardousLoad = hazardousLoad;
	}
	
	public override void LoadProduct(int productMass)
	{
		ProductMass += productMass;
		if (hazardousLoad && (ProductMass > (MaxProductWeight*0.5)) )
		{
			NotifyHazard();
		}
		if(ProductMass > (MaxProductWeight * 0.9))
		{
			throw new OverfillException("Kontener " + SerialNum + " jest przeładowany");
		}
	}
	public void NotifyHazard()
	{
		Console.WriteLine("WYKRYTO NIEBEZPIECZEŃSTWO: Kontener " + SerialNum + " jest wysoce załadowany niebezpieczną substancją!");
	}

    public override string ToString()
    {
        return base.ToString() + ", hazardous=" + hazardousLoad + ")";
    }
}
