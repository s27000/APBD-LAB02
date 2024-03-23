using System;

public class Container
{
	private string serialNum;
    private int height;
    private int depth;
    private int conWeight;

    private int productMass;
    private int maxProductWeight;
	public Container(string serialNum, int height, int depth, int conWeight)
	{
		this.serialNum = serialNum;
		this.height = height;
		this.depth = depth;
		this.conWeight = conWeight;

        productMass = 0;
        maxProductWeight = 0;
	}

	public void loadProduct(int productMass)
	{
		this.productMass = productMass;
	}
	public void unloadProduct()
	{
        productMass = 0;
	}

    public string toString()
	{
		return "KONTENER: " + serialNum +
			"\n";	
 	}
}
