using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string state = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Add items to the DropDownList
                DropDownList1.Items.Add(new ListItem("--Select--"));
                DropDownList1.Items.Add(new ListItem("Andhrapradesh"));
                DropDownList1.Items.Add(new ListItem("Telangana"));
                DropDownList1.Items.Add(new ListItem("Kerala"));

                if (DropDownList1.SelectedIndex <= 3)
                {
                    state += DropDownList1.Items;
                }


                // Add more items as needed
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TextBox1.Text);
            string name = TextBox2.Text;
            string gender = " ";
           
            if (RadioButton1.Checked == true)
            {
                gender="male";
            }
            if(RadioButton2.Checked==true)
            {
                gender="female";
            }

           
            //inserting a record using connection oriented architecture
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dotnet"].ToString());
            con.Open();
            string q = "insert into emp values('"+id+"','"+name+"','"+gender+ "','"+hobbies+"','"+state+"')";
            SqlCommand cmd=new SqlCommand(q,con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        string hobbies = " ";

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string hobby1 = " ";
           // string hobbies = " ";
            if (CheckBox1.Checked == true)
            {
                hobby1 = "Carroms";
                hobbies = hobby1 + " ";
            }

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            string hobby2 = " ";
            if (CheckBox2.Checked == true)
            {
                hobby2 = "Sleeping";
                hobbies += hobby2 + " ";
            }

        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            string hobby3 = " ";
            if (CheckBox3.Checked == true)
            {
                hobby3 = "Eating";
                hobbies += hobby3 + " ";
            }
        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            string hobby4 = " ";
            if (CheckBox4.Checked == true)
            {
                hobby4 = "Reading";
                hobbies += hobby4 + " ";
            }

        }
        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            state = DropDownList1.SelectedItem.Text;
        }
    }
}