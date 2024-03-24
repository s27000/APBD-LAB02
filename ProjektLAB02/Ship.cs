using System;

public class Ship
{
	private int shipID;
	private List<Container> containers;

	private int speed;
	private int maxContainerNum;
	private float maxWeight;

	public Ship(int shipID, int speed, int maxContainerNum, float maxWeight)
	{
		this.shipID = shipID;
        containers = new List<Container>();
        this.speed = speed;
		this.maxContainerNum = maxContainerNum;
		this.maxWeight = maxWeight;
	}

	public void AddContainer (Container c)
	{
		
	}

	public int GetID()
	{
		return shipID;
	}
	public string ToString() {
		return "Statek " + shipID
			+ " (speed=" + speed +
			", maxContainerNum=" + maxContainerNum
            + ", maxWeight=" + maxWeight + ")";
	}

}
