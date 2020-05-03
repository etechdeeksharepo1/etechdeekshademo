using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Associate_wellcomeletter : System.Web.UI.Page
{
    SqlConnection con;
    DataSet ds;
    SqlDataAdapter da;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = Session["loginid"].ToString();
        string s = ConfigurationSettings.AppSettings["con"];
        con = new SqlConnection(s);
        string sql = "select ASSID,NAME from TBL_ASSOCIATEMASTER where ASSID=" + Session["loginid"] + "";
        da = new SqlDataAdapter(sql, con);
        ds = new DataSet();
        da.Fill(ds, "TBL_ASSOCIATEMASTER");
        con.Close();
        if (ds.Tables["TBL_ASSOCIATEMASTER"].Rows.Count > 0)
        {
            Label1.Text = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0]["NAME"].ToString();
           
        }
        
         Label2.Text = ds.Tables["TBL_ASSOCIATEMASTER"].Rows[0]["ASSID"].ToString();
    }
}
