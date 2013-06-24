using System;

public struct Struct3DPoint
{
    static readonly Struct3DPoint pointZero = new Struct3DPoint(0d, 0d, 0d);
    
    public double X {get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    // property that returns the point zero
    public static Struct3DPoint PointZero
    {
        get { return pointZero; }
    }

    // constructor
    public Struct3DPoint(double x, double y, double z)
        : this() // calls the parameterless constructor
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    // method printing a 3D point following the format below
    public override string ToString()
    {
        return String.Format("{0} {1} {2}", this.X, this.Y, this.Z);
    }
}
