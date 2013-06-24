using System;

public class Battery
{
    // enumeration - Battery Type
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }

    // private fields
    private string model;
    private int? hoursIdle;
    private int? hoursTalk;
    private BatteryType batteryType;

    // property
    public string Model
    {
        get { return this.model;}
        set
        {
             // model could not be an empty string
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid model!");
            }
            this.model = value;
        }
    }

    // property
    public int? HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (this.hoursIdle > 50)
            {
                throw new OverflowException("Too big value for hours idle");
            }
            if (this.hoursIdle < 0)
            {
                throw new Exception("Value for hours idle should be positive!");
            }
            this.hoursIdle = value; 
        }
    }

    // property
    public int? HoursTalk
    {
        get { return this.hoursTalk; }
        set 
        {
            if (this.hoursTalk < 0)
            {
                throw new Exception("Value for hours talk should be positive!");
            }
            this.hoursTalk = value; 
        }
    }
    
    // constructor
    public Battery(string model, int? hoursIdle = null, int? hoursTalk = null)
    {
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
    }

    // method that overrides ToString()
    public override string ToString()
    {
        return String.Format("Model {0}, Hours Idle {1}, Hours Talk {2}", this.Model, this.HoursIdle, this.HoursTalk);
    }
}