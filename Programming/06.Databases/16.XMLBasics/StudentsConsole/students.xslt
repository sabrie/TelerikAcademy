<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns="urn:studentss"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
  
      <xsl:template match="/">
        <html>
          <body>
            <h1>Students</h1>
            <table bgcolor="#E0E0E0" cellspacing="1">
              <tr bgcolor="#EEEEEE">
                <td><b>Name</b></td>
                <td><b>Sex</b></td>
              </tr>
              <xsl:for-each select="/students/student">
                <tr bgcolor="white">
                  <td>
                    <xsl:value-of select="name"/>
                  </td>
                  <td>
                    <xsl:value-of select="sex"/>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </body>
        </html>
      </xsl:template>
</xsl:stylesheet>
