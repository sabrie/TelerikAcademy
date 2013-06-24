using System;
using System.Collections.Generic;

public class GSMTest
{
    static void Main()
    {
        //------------------------------------
        //      GSM TEST
        //------------------------------------
        Console.WriteLine("GSM TEST - 01 - 07 Exercises");
        Console.WriteLine(new string('=', 50));
        
        // create an instance of Battery class using its constructor
        Battery battery = new Battery("U880", 430, 5);

        // create an instance of Display class using its constructor
        Display display = new Display(4, 60235);

        // create an instance of GSM class
        GSM lg = new GSM("LG", "U310", 299, "Pesho", battery: battery, display: display);

        string manufacturer = "Nokia";
        string model = "2660";

        // create an instance of GSM class
        GSM nokia = new GSM(manufacturer, model, null, "Sasho", new Battery("Nokia", 575, 9), new Display(2, 65325));

        // create an instance of GSM class
        GSM samsung = new GSM("Samsung", "3300", 109, battery: new Battery("Samsung", 560, 7), display: new Display(2, 16123654));

        // an array that holds all instances of the GSM class
        GSM[] allGSMs = { lg, nokia, samsung };

        // print the information about GSMs in the array
        foreach (var gsm in allGSMs)
        {
            Console.WriteLine(gsm);
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }

        // print the information about IPhone 4S - a static field in GSM class
        Console.WriteLine(GSM.iPhone4S);

        // ----------------------------------------------------
        //    GSM CALL HISTORY TEST
        //-----------------------------------------------------
        Console.WriteLine();
        Console.WriteLine("GSM CALL HISTORY TEST - 08 - 11 Exercises and part of Exercise 12 ");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine();

        // create an instance of the GSM class
        GSM myGSM = new GSM("Samsung", "3330", 99, "Me", new Battery("Samsung", 550, 9), callHistory: new CallHistory()); 

        // add calls to the Call List of given GSM
        myGSM.CallHistory.AddCall(new Call("0888123456", DateTime.Now, 80));
        myGSM.CallHistory.AddCall(new Call("0898666666", DateTime.Now, 9));
        myGSM.CallHistory.AddCall(new Call("0888777777", DateTime.Now, 325));

        Console.WriteLine(myGSM);

        // clear all calls and prints
        myGSM.CallHistory.ClearAllCalls();
        Console.WriteLine("After calls have been cleared:");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();
        Console.WriteLine(myGSM);
        
        // total Price
        decimal totalCallPrice = myGSM.CallHistory.CalcCallsPrice(0.5m);
        Console.WriteLine(totalCallPrice);
    }
}

