using System;

public class LiquidContainer : Container, IHazardNotifier
{
	public LiquidContainer(string serialNum, int height, int depth, int conWeight, int maxProductWeight) : base(serialNum, height, depth, conWeight, maxProductWeight)
	{
		
	}

	public void NotifyHazard()
	{

	}
}
