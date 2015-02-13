using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
//Use for WebClient
using Newtonsoft.Json;
//Use To parse data from json file.
using System.Web.Script.Serialization;
// Use for json string serialization
using System.Text;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var wc = new WebClient();
        var jsonString = string.Empty;
        string url = "https://raw.github.com/mledoze/countries/master/countries.json";
        jsonString = wc.DownloadString(url);
        var data = JsonConvert.DeserializeObject(jsonString);
        string json = data.ToString();
        var jss = new JavaScriptSerializer();
        dynamic data1 = jss.Deserialize<dynamic>(json);
        StringBuilder sb = new StringBuilder();
        sb.Append("<table>\n<thead>\n<tr>\n");
        foreach (object key in data1[0].Keys)
        {
            sb.AppendFormat("<th>{0}</th>\n", key);

        }
        sb.Append("</tr>\n</thead>\n<tbody>\n");
        //foreach(Dictionary<string,object> item in data)
        //{
        //    sb.Append(" <tr>\n");
        //    foreach (object val in item.Values)
        //    {
        //        sb.AppendFormat(" <td>{0}</td>\n", val);
        //    }
        //}
        foreach (Dictionary<string, object> item in data1)
        {
            sb.Append("<tr>\n");
            foreach (object val in item.Values)
            {
                sb.AppendFormat("<td>{0}</td>\n", val);
            }
        }
        sb.Append(" </tr>\n </tbody>\n</table>");
        string myTable = sb.ToString();
        Response.Write(myTable);

    }
}