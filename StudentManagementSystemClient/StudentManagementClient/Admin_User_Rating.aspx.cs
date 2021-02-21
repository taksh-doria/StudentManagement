﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentRatingSystemClient
{
    public partial class Admin_User_Rating : System.Web.UI.Page
    {
        StudentSystemServiceReferece.StudentSystemClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManage.sessionId == -1)
            {
                Response.Redirect("Login.aspx");
            }
            client = new StudentSystemServiceReferece.StudentSystemClient();
            Admin_User_Rating_Label.Text = "";
            IEnumerable<StudentSystemServiceReferece.RatinDto> data = client.ShowRating();
            if (data.Count() == 0)
            {
                Admin_User_Rating_Label.ForeColor = System.Drawing.Color.Green;
                Admin_User_Rating_Label.Text = "No Data Available";
            }
          
          
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void Student_Rating___Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_User_Rating.aspx");
        }

        protected void User___Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_User_Check.aspx");
        }

        protected void Student___Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            SessionManage.sessionId = -1;
            Response.Redirect("Login.aspx");
        }
    }
}