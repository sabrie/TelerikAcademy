using System;
using System.Linq;
using System.Text;


class Messages
{
    public static StringBuilder output = new StringBuilder();

    public static void PrintEventAdded()
    {
        output.Append("Event added\n");
    }

    public static void PrintDeletedEventsNumber(int deletedEventsCounter)
    {
        if (deletedEventsCounter == 0)
        {
            PrintNoEventsFound();
        }
        else
        {
            output.AppendFormat("{0} events deleted\n", deletedEventsCounter);
        }
    }

    public static void PrintNoEventsFound()
    {
        output.Append("No events found with this title or on this date\n");
    }

    public static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            output.Append(eventToPrint + "\n");
        }
    }
}
