/* 
 Refactor the following code to use proper variable naming and 
 simplified expressions:

 public class Size
{
  public double wIdTh, Viso4ina;
  public Size(double w, double h)
  {
    this.wIdTh = w;
    this.Viso4ina = h;
  }
}

public static Size GetRotatedSize(
  Size s, double angleOfTheFigureThatWillBeRotaed)
{
  return new Size(
    Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
      Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina,
    Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
      Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina);
}

 */

using System;
using System.Linq;
using System.Text;


public class Coordinates
{
    private double x = 0;
    private double y = 0;

    public double X { get; private set; }
    public double Y { get; private set; }

    public Coordinates(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine("X: " + this.X);
        result.AppendLine("Y: " + this.Y);

        return result.ToString();
    }
}