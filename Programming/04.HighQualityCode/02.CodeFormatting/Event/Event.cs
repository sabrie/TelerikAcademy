using System;
using System.Linq;
using System.Text;

public class Event : IComparable
{
    private DateTime dateTime;
    private string title;
    private string location;

    public Event(DateTime dateTime, string title, string location = null)
    {
        this.DateTime = dateTime;
        this.Title = title;
        this.Location = location;
    }

    public DateTime DateTime { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }

    public int CompareTo(object obj)
    {
        Event otherEvent = obj as Event;

        int byDate = this.DateTime.CompareTo(otherEvent.DateTime);
        int byTitle = this.Title.CompareTo(otherEvent.Title);
        int byLocation = this.Location.CompareTo(otherEvent.Location);

        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        
        output.Append(this.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        output.Append(" | " + this.Title);

        if (this.Location != null && this.Location != "")
        {
            output.Append(" | " + this.Location);
        }

        return output.ToString();
    }
}