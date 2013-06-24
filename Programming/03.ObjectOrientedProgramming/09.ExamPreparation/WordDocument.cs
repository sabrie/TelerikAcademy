using System;
using System.Collections.Generic;
using System.Linq;

class WordDocument : OfficeDocument, IEditable
{
    public int? NumOfChars { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.NumOfChars = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.NumOfChars));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

