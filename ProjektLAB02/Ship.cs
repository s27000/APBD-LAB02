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
				output += "\t" + con + "\n";
			}
			return output;
		} 
	} 

	public bool isEmpty { 
		get {
			if (containersList.Any()) {
				return false;
			}
			return true;
		} }
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

	public void AddContainerList(List<Container> containersList){
		foreach(Container con in containersList)
		{
			this.containersList.Add(con);
		}
	}

	public Container RemoveContainer(string serialNum){
		for(int i = 0; i < containersList.Count(); i++)
		{
			if (containersList[i].SerialNum == serialNum)
			{
				Container con = containersList[i];
				containersList.RemoveAt(i);
				return con;
			}
		}
		return null;
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
