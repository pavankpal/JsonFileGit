using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;

public partial class Default3 : System.Web.UI.Page
{
    public class dataClass
    {
        public string Name { get; set; }
        public int id { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        List<dataClass> datalist = new List<dataClass>();
        //add data in Object List
        datalist.Add(new dataClass { id = 1, Name = "India" });
        datalist.Add(new dataClass { id = 2, Name = "USA" });
        datalist.Add(new dataClass { id = 3, Name = "Pakistan" });
        // Convert this object data to json string as following
        string output = JsonConvert.SerializeObject(datalist, Formatting.Indented);
        File.WriteAllText(Server.MapPath(".") + "\\country.json", output);
        var wc = new WebClient();
        var jsonString = string.Empty;
        string url = Server.MapPath(".") + "\\country.json";
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