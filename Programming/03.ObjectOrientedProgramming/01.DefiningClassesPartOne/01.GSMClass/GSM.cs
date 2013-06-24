using System;
using System.Collections.Generic;

public class GSM
{
    // static fields
    public static GSM iPhone4S = new GSM("Apple", "IPhone4S", 300, null, new Battery("Apple", 550, 6), new Display(4, 16777216));
    // private fields
    private string model;
    private string manufacturer;
    private decimal? price;
    private string owner;
    // instance of the Battery class
    private Battery Battery;
    // instance of the Display class
    private Display Display;
    private CallHistory callHistory;

    // property
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    // property
    public string Manufacturer
    {
        get { return this.manufacturer; }
        set { this.manufacturer = value; }
    }

    // property
    public decimal? Price
    {
        get { return this.price; }
        set
        {
            if (value < 0 || value > 100000)
            {
                throw new ArgumentException("Too low or too big price!");
            }
            this.price = value;
        }
    }

    // property
    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                this.owner = string.Empty;
            }
            this.owner = value;
        }
    }

    // property CallHistory 
    public CallHistory CallHistory
    {
        get { return this.callHistory; }
        set { this.callHistory = value; }
    }

    // we do not declare a default constructor as we have mandatory fields - model and manufacturer

    // constructor that takes 2 mandatory parameters (manufacturer and model)
    // we cannot create an instance of GSM class without declaring them
    // the other parameters are optional
    public GSM(string manufacturer, string model, decimal? price = null, string owner = "", Battery battery = null, Display display = null, CallHistory callHistory = null)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.Owner = owner;
        this.Battery = battery;
        this.Display = display;
        this.CallHistory = callHistory;
    }

    // !!! The method for adding and deleting calls from the Call List is in class CallHistory
 
    // method that prints the information on the Console following the format below
    public override string ToString()
    {
        return String.Format("Manufacturer: {0} {7}Model: {1} {7}Price in euro: {2} {7}Owner: {3} {7}Battery: {4} {7}Display: {5} {7}Call History: {7}{6}", 
                            this.Manufacturer, this.Model, this.Price, this.Owner, this.Battery, this.Display, this.CallHistory, Environment.NewLine);
    }
}

