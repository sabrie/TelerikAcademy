using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.WcfServiceStringOccurrencesCounter.Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceStringOccurrencesCounter" in both code and config file together.
    public class ServiceStringOccurrencesCounter : IServiceStringOccurrencesCounter
    {
        public int CountStringOccurrences(string substring, string mainString)
        {
            int count = 0;
            int index = 0;
            while ((index = mainString.IndexOf(substring, index)) != -1)
            {
                index += substring.Length;
                count++;
            }
            return count;
        }
    }
}
