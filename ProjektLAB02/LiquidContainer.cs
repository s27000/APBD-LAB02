using System;

public class LiquidContainer : Container, IHazardNotifier
{
	private bool hazardousLoad;
	public LiquidContainer(string serialNum, int height, int depth, int conWeight, int maxProductWeight, bool hazardousLoad) : base(serialNum, height, depth, conWeight, maxProductWeight)
	{
		this.hazardousLoad = hazardousLoad;
	}

	public void NotifyHazard()
	{
		Console.WriteLine("WYKRYTO NIEBEZPIECZEŃSTWO: Kontener " + SerialNum);
	}

    public override string ToString()
    {
        return base.ToString() + ", hazardous=" + hazardousLoad + ")";
    }
}
