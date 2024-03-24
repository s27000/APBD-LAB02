﻿using System;

public class Container
{
	private string serialNum;
    private int height;
    private int depth;
    private int conWeight;
    private int maxProductWeight;

    private int productMass;
	public Container(string serialNum, int height, int depth, int conWeight, int maxProductWeight)
	{
		this.serialNum = serialNum;
		this.height = height;
		this.depth = depth;
		this.conWeight = conWeight;
		this.maxProductWeight = maxProductWeight;

        productMass = 0;
	}

	public void LoadProduct(int productMass)
	{
		if (productMass > maxProductWeight)
		{
            throw new OverfillException("cos");
		}
        this.productMass = productMass;
	}
	public void UnloadProduct()
	{
        productMass = 0;
	}

    public string ToString()
	{
		return "KONTENER: " + serialNum +
			"\n";	
 	}
}
