using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.WcfServiceStringOccurrencesCounter.Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceStringOccurrencesCounter" in both code and config file together.
    [ServiceContract]
    public interface IServiceStringOccurrencesCounter
    {
        [OperationContract]
        int CountStringOccurrences(string text, string pattern);
    }
}
