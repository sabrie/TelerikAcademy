using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace StudentsConsole
{
    class Program
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../students.xslt");
            xslt.Transform("../../students.xml", "../../students.html");
        }
    }
}
