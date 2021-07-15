using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaloDotNetSDK;
using ZaloCSharpSDK;
using System.IO;

namespace Zalo_TestAPI
{
    public partial class Followers : System.Web.UI.Page
    {
        static string access_token = "60jaMd9CrXeQ3czJTaNJ6Xa5R5zsMR0VSqXVN49ld1feNb5VT1IEUM8eFLjq8e4IJ3rmAaKtb2fnDMatOd6e44mr6ovz1gCD5I5cEIacrI8dC34B217SIne400yL1iWUEni7MWa8oMvb0X9sUn_BFX8uDmSO5SalF30LF5OBtpvUIX0-Bb_K7KPS2Z9-PjK9G21fCteDg6vL375tGX-iR4iS45Td8ErGSHS95XqKjnO9814j90ZBRJuTTqWBExXH6X1v4ofRY0WaNbbD3tphMnbYMMPz9gXVSZLTSejmTbVU7G";
        ZaloClient client = new ZaloClient(access_token);
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show_followers();
            }
        }
        private void show_followers()
        {
            GridView1.DataSource = followers();
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
        }
        public DataTable followers()
        {
            JObject result;
            result = client.getListFollower(0, 50);
            dt = JsonConvert.DeserializeObject<DataTable>(result["data"]["followers"].ToString());
            

            DataTable dt1 = new DataTable();
            DataColumn dc;
            DataRow dr;

            dc = new DataColumn();
            dc.DataType = typeof(String);
            dc.ColumnName = "User ID";
            dt1.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = typeof(Int32);
            dc.ColumnName = "STT";
            dt1.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = typeof(String);
            dc.ColumnName = "Ảnh đại diện";
            dt1.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = typeof(String);
            dc.ColumnName = "Tên hiển thị";
            dt1.Columns.Add(dc);

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                string id = dt.Rows[i - 1][0].ToString();
                result = client.getProfileOfFollower(id);
                dr = dt1.NewRow();
                dr["User ID"] = id;
                dr["STT"] = i;
                dr["Ảnh đại diện"] = result["data"]["avatars"]["120"].ToString();
                dr["Tên hiển thị"] = result["data"]["display_name"].ToString();
                dt1.Rows.Add(dr);
            }
            return dt1;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow SelectedRow = GridView1.SelectedRow;
            string id = SelectedRow.Cells[0].Text;
            JObject result = client.getProfileOfFollower(id);
            TextBox1.Text = result.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //GridViewRow SelectedRow = GridView1.SelectedRow;
            //string id = SelectedRow.Cells[0].Text;
            //JObject result = client.sendTextMessageToUserId("8059516961179187373", TextBox2.Text);
            JObject result = client.sendImageMessageToUserIdByUrl("8059516961179187373", "this is a message", "");

        }
        protected void Get_json(object sender, EventArgs e)
        {
            JObject jo;
            string a = File.ReadLines(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/text.json")).Last();
            jo = JObject.Parse(a);
            TextBox1.Text = "User: " + jo["sender"]["id"].ToString()+ " gửi " +jo["event_name"].ToString() + "\n";
        }

    }
}