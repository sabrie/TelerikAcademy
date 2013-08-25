using System.Xml.Xsl;


public class XSLTransform
{
    static void Main()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("../../students.xslt");
        xslt.Transform("../../students.xml", "../../students.html");
    }
}
