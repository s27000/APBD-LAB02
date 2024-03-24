using System;

public class Ship
{
	private int shipID;
    public int ShipID { get { return shipID; } }

    private List<Container> containersList;
	public string ContainersList { 
		get {
			string output = "";
			foreach (Container con in containersList) {
				output += "\t" + con;
			}
			return output;
		} 
	} 

	private int speed;
	private int maxContainerNum;
	private int maxWeight;

	public Ship(int shipID, int speed, int maxContainerNum, int maxWeight)
	{
		this.shipID = shipID;
        containersList = new List<Container>();
        this.speed = speed;
		this.maxContainerNum = maxContainerNum;
		this.maxWeight = maxWeight;
	}

	public void AddContainer (Container con)
	{
        containersList.Add(con);

		double totalLoadMass = 0;
		foreach(Container c in containersList){
            totalLoadMass += c.TotalMass;
		}

		if(totalLoadMass>maxWeight || containersList.Count() > maxContainerNum)
		{
			throw new OverfillException("Statek " + shipID + " jest przeladowany");
		}
	}

	public override string ToString()
	{
		string output = "Statek " + shipID
            + " (speed=" + speed +
            ", maxContainerNum=" + maxContainerNum
            + ", maxWeight=" + maxWeight + ")";

        if (containersList.Any()){
			output += "\n\tŁadunek:\n" + ContainersList;
		}
		return output;
	}

}
