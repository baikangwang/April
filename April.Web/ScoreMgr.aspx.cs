using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using April.BLL;
using April.Entity;
using April.Entity.Base;
using April.Web.Base;

namespace April.Web
{
    public partial class ScoreMgr : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gvCourse.DataBind();

                if (string.IsNullOrEmpty(Id))
                    ListStudent.Visible = false;
                else
                {
                    ListStudent.Visible = true;
                    gvStudent.DataBind();
                }
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvCourse.DataBind();
        }

        protected void RefreshStd_Click(object sender, EventArgs e)
        {
            gvStudent.DataBind();
        }

        protected void Course_DataBinding(object sender, EventArgs e)
        {
            gvCourse.DataSource = BLL.CourseMgr.List();
        }

        protected void Student_DataBinding(object sender, EventArgs e)
        {
            gvStudent.DataSource = BLL.SelectionMgr.ListByCourse(Id);
        }

        protected void Gender_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null||selection.Student==null) return;
            lbl.Style.Add("background",
                                 selection.Student.Gender == Gender.Male
                                     ? "url('../images/icons/male.png\') no-repeat center transparent"
                                     : "url('../images/icons/female.png') no-repeat center transparent");
            lbl.Text = " ";
        }

        protected void Id_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Student == null) return;
            lbl.Text = selection.Student.Id;
        }

        protected void Name_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Student == null) return;
            lbl.Text = selection.Student.Name;
        }

        protected void Grade_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Student == null) return;
            lbl.Text = selection.Student.Grade;
        }

        protected void Score_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null) return;
            lbl.Text = selection.Score == null ? "无" : Convert.ToString(selection.Score.Value);
        }

        protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = Convert.ToString(e.Keys[e.RowIndex]);
            int? score = e.NewValues["Score"] == null ? (int?) null : Convert.ToInt32(e.NewValues["Score"]);
            bool updated = SelectionMgr.Update(new Dictionary<string, object>() {{"oId", id}, {"Score", score}});
            lblMessage.Text = updated ? "修改分数成功！" : "修改分数失败！";
            gvStudent.EditIndex = -1;
            gvStudent.DataBind();
        }

        protected void gvStudent_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
        }

        protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudent.EditIndex = e.NewEditIndex;
            gvStudent.DataBind();
        }

        protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudent.EditIndex = -1;
            gvStudent.DataBind();
        }
    }
}