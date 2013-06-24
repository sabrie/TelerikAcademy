using System;

public class Display
{
    // private fields
    private int? size;
    private int? numOfColors;

    // constructor
    public Display(int? size = null, int? numOfColors = null)
    {
        this.Size = size;
        this.NumOfColors = numOfColors;
    }

    // property
    public int? Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    // property
    public int? NumOfColors
    {
        get { return this.numOfColors; }
        set { this.numOfColors = value; }
    }

    // method that prints the information on the Console following the format below
    public override string ToString()
    {
        return String.Format("Size in inches {0}, Number of colors {1}",
                            this.Size, this.NumOfColors);
    }
}

