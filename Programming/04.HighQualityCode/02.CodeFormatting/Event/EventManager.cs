using System;
using System.Linq;

class EventManager
{
    private static EventHolder events = new EventHolder();

    static void Main()
    {
        // Reads input from the text file in bin/Debug folder
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("1.input.txt"));
#endif

        while (ExecuteNextCommand())
        {
        }
        Console.WriteLine(Messages.output);       
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command[0] == 'A')
        {
            AddEvent(command);
            return true;
        }

        if (command[0] == 'D')
        {
            DeleteEvents(command);
            return true;
        }

        if (command[0] == 'L')
        {
            ListEvents(command); return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    }

    private static void AddEvent(string command)
    {
        DateTime dateTime;
        string title;
        string location;

        GetParameters(command, "AddEvent", out dateTime, out title, out location);

        events.AddEvent(dateTime, title, location);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        
        events.DeleteEvents(title);
    }

    private static void ListEvents(string command)
    {
        DateTime dateTime = GetDateTime(command, "ListEvents");

        int pipeIndex = command.IndexOf('|');
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);

        events.ListEvents(dateTime, count);
    }

    private static void GetParameters(string commandForExecution, string commandType,
        out DateTime dateTime, out string eventTitle, out string eventLocation)
    {
        dateTime = GetDateTime(commandForExecution, commandType);

        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = "";
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDateTime(string command, string commandType)
    {
        DateTime dateTime = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

        return dateTime;
    }
}

