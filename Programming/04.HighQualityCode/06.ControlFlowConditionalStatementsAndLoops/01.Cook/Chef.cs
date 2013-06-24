/*
 * Refactor the following class using best practices for organizing straight-line code:

public void Cook() 
public class Chef
{
    private Bowl GetBowl()
    {   
        //... 
    }
    private Carrot GetCarrot()
    {
        //...
    }
    private void Cut(Vegetable potato)
    {
        //...
    }
   public void Cook()
    {
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();
        Bowl bowl;
        Peel(potato);
                
        Peel(carrot);
        bowl = GetBowl();
        Cut(potato);
        Cut(carrot);
        bowl.Add(carrot);
                
        bowl.Add(potato);
    }
    private Potato GetPotato()
    {
        //...
    }
}

 */

using System;
using System.Linq;

public class Chef
{
    public void Cook()
    {
        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);

        Bowl bowl = GetBowl();
        bowl.Add(potato);
        bowl.Add(carrot);
    }

    private Potato GetPotato()
    {
        //...
    }

    private Carrot GetCarrot()
    {
        //...
    }

    private void Peel(Vegetable vegetable)
    {
        //...
    }

    private void Cut(Vegetable vegetable)
    {
        //...
    }

    private Bowl GetBowl()
    {
        //... 
    }
}
