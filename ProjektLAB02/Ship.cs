using System;

public class Ship
{
	private int shipID;
	private List<Container> containers;

	public Ship(int shipID)
	{
		this.shipID = shipID;
		containers = new List<Container>();
	}


}
