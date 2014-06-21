using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Utilities.Basecore.Base;
using Sitecore.Search;
using Sitecore.Data;
using Training.Utilities.Basecore.References;
using Sitecore.ContentSearch.LuceneProvider;
using Training.Utilities.BaseCore.Search;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.Links;
using Training.Utilities.BaseCore.References;

namespace Training.BaseCore.Layouts.Search
{
    public partial class SearchForm : BaseSublayout
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                foreach (Item i in ItemReferences.HolidayTypes.Children)
                {
                    ddlHolidayType.Items.Add(new ListItem(FieldRenderer.Render(i, "Text"), i.ID.Guid.ToString()));
                }

                foreach (Item i in ItemReferences.Terrains.Children)
                {
                    ddlTerrain.Items.Add(new ListItem(FieldRenderer.Render(i, "Text"), i.ID.Guid.ToString()));
                }

                if (Session[Keys.HolidaySearchSession] != null)
                {
                    SearchObject searchObject = Session[Keys.HolidaySearchSession] as SearchObject;

                    string v = searchObject.HolidayType.ToString();

                    ddlHolidayType.SelectedIndex = ddlHolidayType.Items.IndexOf(ddlHolidayType.Items.FindByValue(searchObject.HolidayType.ToString()));
                    ddlTerrain.SelectedValue = searchObject.Terrain.ToString();
                    txtSearchText.Text = searchObject.Text;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            // Clear existing holiday search session
            Session.Remove(Keys.HolidaySearchSession);
                
            SearchObject searchObject = new SearchObject();

            Session.Add(Keys.HolidaySearchSession, searchObject);

            searchObject.Text = txtSearchText.Text;
            searchObject.HolidayType = !String.IsNullOrEmpty(ddlHolidayType.SelectedValue) ? new Guid(ddlHolidayType.SelectedValue) : Guid.Empty;
            searchObject.Terrain = !String.IsNullOrEmpty(ddlTerrain.SelectedValue) ? new Guid(ddlTerrain.SelectedValue) : Guid.Empty;

            Response.Redirect(String.Format("{0}?{1}={2}", LinkManager.GetItemUrl(Sitecore.Context.Item), Keys.SearchPage, 1), false);
        }
    }
}