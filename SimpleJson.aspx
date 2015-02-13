<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleJson.aspx.cs" Inherits="SimpleJson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <%-- <script type="text/javascript">
        var arr =
        '{"Country":[{"CountryId":1,"CountryName":"India"},{"CountryId":2,"CountryName":"USA"},{"CountryId":3,"CountryName":"Pakistan"}]}';
        var countryData = eval("(" + arr + ")");
        for (i = 0; i < countryData.Country.length; i++) {
            document.write("<br>");
            document.write("Country Id:\t" + countryData.Country[i].CountryId + "<br>");
            document.write("country Name:\t" + countryData.Country[i].CountryName + "<br>");
            document.write("<br>");
        }
</script>--%>
    <script type="text/javascript">
        var arr=
            '{"Country":[{"CountryID":1,"CountryName":"INDIA"},{"CountryID":2,"CountryName":"JAPAN"},{"CountryID":3,"CountryName":"CHINA"},{"CountryID":4,"CountryName":"US"}]}';
        var countryData = eval("(" + arr + ")");
        for (i = 0; i < countryData.Country.length; i++)
        {
            document.write("<br/>")
            document.write("Country ID:\t " + countryData.Country[i].CountryID + "<br/>");
            document.write("Country Name:\t" + countryData.Country[i].CountryName + "<br/>");

            document.write("<br/>");

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
