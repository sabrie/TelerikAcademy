using System;
using System.Collections.Generic;
using System.Text;

public class CallHistory : Call
{
    // a list that holds sequences of calls
    public List<Call> callHistory = new List<Call>();

    public CallHistory(string dialedPhone, DateTime dateTime, int durationInSec)
    {
        this.DialedPhone = dialedPhone;
        this.DateTime = dateTime;
        this.DurationInSec = durationInSec;
    }

    public CallHistory()
    {
    }

    // method that adds calls to call history list
    public void AddCall(Call currentCall)
    {
        this.callHistory.Add(currentCall);
    }

    // method that removes calls from call history list
    public void RemoveCall(Call someCall)
    {
        this.callHistory.Remove(someCall);
    }

    // method that removes all calls from call history list
    public void ClearAllCalls()
    {
        this.callHistory.Clear();
    }

    // method that calculates the price of calls
    public decimal CalcCallsPrice(decimal pricePerMin)
    {
        decimal totalPrice = 0;
        if (this.DurationInSec <= 60)
        {
            totalPrice = pricePerMin;
        }
        else if (this.DurationInSec > 60 && this.DurationInSec % 60 == 0)
        {
            totalPrice = pricePerMin * (this.DurationInSec / 60);
        }
        else
        {
            totalPrice = pricePerMin * ((this.DurationInSec / 60) + 1);
        }        
        return totalPrice;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        foreach (Call call in this.callHistory)
        {
            info.AppendLine(call.ToString());
        }
        return info.ToString();
    }
}
