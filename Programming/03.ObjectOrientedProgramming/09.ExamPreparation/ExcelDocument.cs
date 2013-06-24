using System;
using System.Collections.Generic;

class ExcelDocument : OfficeDocument
{
    public int? NumOfCols { get; set; }
    public int? NumOfRows { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.NumOfRows = int.Parse(value);
        }
        if (key == "cols")
        {
            this.NumOfCols = int.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.NumOfRows));
        output.Add(new KeyValuePair<string, object>("cols", this.NumOfCols));
        base.SaveAllProperties(output);
    }
}
