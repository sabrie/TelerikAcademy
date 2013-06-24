using System;
using System.Collections.Generic;

class AudioDocument : MultimediaDocument
{
    public int? SampleRateHz { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRateHz = int.Parse(value);
        }
        
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRateHz));
        base.SaveAllProperties(output);
    }
}
