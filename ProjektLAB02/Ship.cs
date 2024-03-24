using System;

public class Ship
{
	private int shipID;
    public int ShipID { get { return shipID; } }

    private List<Container> containers;

	private int speed;
	private int maxContainerNum;
	private int maxWeight;

	public Ship(int shipID, int speed, int maxContainerNum, int maxWeight)
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

	public override string ToString() {
		return "Statek " + shipID
			+ " (speed=" + speed +
			", maxContainerNum=" + maxContainerNum
            + ", maxWeight=" + maxWeight + ")";
	}

}
