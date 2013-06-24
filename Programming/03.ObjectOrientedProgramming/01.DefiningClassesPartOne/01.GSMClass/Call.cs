using System;

public class Call
{
    // private fields
    private string dialedPhone;
    private DateTime dateTime;    
    private int durationInSec;


    // property
    public DateTime DateTime
    {
        get { return this.dateTime; }
        set { this.dateTime = value; }
    }

    // property
    public int DurationInSec
    {
        get { return this.durationInSec; }
        set { this.durationInSec = value; }
    }

    // property
    public string DialedPhone
    {
        get { return this.dialedPhone; }
        set { this.dialedPhone = value; }
    }

    // parameterless constructor
    public Call()
    {
        this.dialedPhone = null;
        this.dateTime = DateTime.MinValue;
        this.durationInSec = 0;
    }

    // constructor that takes 3 parameters
    public Call(string dialedPhone, DateTime date, int durationInSec)
    {
        this.dialedPhone = dialedPhone;
        this.dateTime = date;
        this.durationInSec = durationInSec;
    }

    // method that overrides ToString() and prints the Call information following the format bellow
    public override string ToString()
    {
        return String.Format("Dialed Phone: {0} {3}Date and time: {1} {3}Duration in seconds: {2}", this.DialedPhone, this.DateTime, this.DurationInSec, Environment.NewLine);
    }
}

