using System;

public class Container
{
	private string serialNum;
	public string SerialNum { get { return serialNum; } }
    private int height;
    private int depth;

    private int conWeight;
    private int productMass;
	public int ProductMass { get { return productMass; } set { productMass = value; } }
	public int TotalMass { get { return conWeight + productMass; } }

    private int maxProductWeight;
	public int MaxProductWeight { get { return maxProductWeight; } }
    public Container(string serialNum, int height, int depth, int conWeight, int maxProductWeight)
	{
		this.serialNum = serialNum;
		this.height = height;
		this.depth = depth;
		this.conWeight = conWeight;
		this.maxProductWeight = maxProductWeight;

        productMass = 0;
	}

	public virtual void LoadProduct(int productMass)
	{
        this.productMass += productMass;
		if (this.productMass > maxProductWeight)
		{
            throw new OverfillException("Kontener " + serialNum + " jest przeładowany");
		}
	}
	public void UnloadProduct()
	{
        productMass = 0;
	}

	public override string ToString()
	{
		return "Kontener " + serialNum +
			" (height=" + height + ", depth=" + depth +
			", conWeight=" + conWeight +
			", productMass/maxProductWeight=" + productMass + "/" + maxProductWeight;
    }
}
