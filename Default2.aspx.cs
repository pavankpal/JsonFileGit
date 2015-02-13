using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

public partial class Default2 : System.Web.UI.Page
{
    public class myclass
    {
        public string Name { get; set; }
        public string Education { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public Dictionary<string, string> Hobbies { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var wc = new WebClient();
        var jsonscript = string.Empty;
        string url = Server.MapPath("~/JavaScript.js");
        jsonscript = wc.DownloadString(url);

        var data = JsonConvert.DeserializeObject(jsonscript);
        string json = data.ToString();

        var jss = new JavaScriptSerializer();
        myclass data1 = jss.Deserialize<myclass>(json);
        Dictionary<string, string> Hobbies = data1.Hobbies;

        StringBuilder sb = new StringBuilder();
        sb.Append("<table border=1><tbody>");
        sb.Append("<tr><th>Name :</th><td>");
        sb.Append(data1.Name);
        sb.Append("</td></tr><tr><th>Education :</th><td>");
        sb.Append(data1.Education);
        sb.Append("</td></tr><tr><th>Mobile :</th><td>");
        sb.Append(data1.Mobile);
        sb.Append("</td></tr><tr><th>City :</th><td>");
        sb.Append(data1.City);
        sb.Append("</td></tr><tr><th>Hobbies :</th><td>");

        foreach (var item in Hobbies)
        {

            //if (item.Value != "")
            //{
            sb.Append(item.Value);
            if (item.Value != "")
            {
                sb.Append("</td></tr><tr><th></th><td>");
            }   //sb.Append("<tr><th></th><td>");
            //}
        }

        sb.Append("</tbody></table>");
        //string mytabledata = sb.ToString();
        Response.Write(sb.ToString());
    }
}