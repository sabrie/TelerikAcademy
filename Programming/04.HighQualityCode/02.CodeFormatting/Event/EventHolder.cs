using System;
using System.Linq;
using Wintellect.PowerCollections;

public class EventHolder
{
    private MultiDictionary<string, Event> byTitle =
        new MultiDictionary<string, Event>(true);
    private OrderedBag<Event> byDate =
        new OrderedBag<Event>();

    public void AddEvent(DateTime date, string title, string location)
    {
        Event newEvent = new Event(date, title, location);

        this.byTitle.Add(title.ToLower(), newEvent);
        this.byDate.Add(newEvent);

        Messages.PrintEventAdded();
    }

    public void DeleteEvents(string titleToDelete)
    {
        string title = titleToDelete.ToLower();
        int removed = 0;

        foreach (var eventToRemove in this.byTitle[title])
        {
            this.byDate.Remove(eventToRemove);
            removed++;
        }

        this.byTitle.Remove(title);

        Messages.PrintDeletedEventsNumber(removed);
    }

    public void ListEvents(DateTime dateTime, int eventsNumberToShow)
    {
        OrderedBag<Event>.View eventsToShow =
            byDate.RangeFrom(new Event(dateTime, "", ""), true);
        int showed = 0;

        foreach (var eventToShow in eventsToShow)
        {
            if (showed == eventsNumberToShow)
            {
                break;
            }

            Messages.PrintEvent(eventToShow);
            showed++;
        }

        if (showed == 0)
        {
            Messages.PrintNoEventsFound();
        }
    }
}