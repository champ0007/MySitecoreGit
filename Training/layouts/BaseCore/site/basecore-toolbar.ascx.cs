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
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace Training.BaseCore.Layouts.Site
{
    public partial class Toolbar : BaseSublayout
    {
        /// <summary>
        /// The toolbar in the top right-hand corner of the site.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Item siteRoot = ItemReferences.SiteRoot;

            if (siteRoot == null)
            {
                this.Visible = false;
                return;
            }

            CheckboxField enableToolBar = siteRoot.Fields["Enable Toolbar"];

            if (!enableToolBar.Checked)
            {
                this.Visible = false;
                return;
            }

            ToolbarContent.Item = siteRoot;
        }
    }
}