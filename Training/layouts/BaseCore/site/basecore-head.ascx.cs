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
using Sitecore.Web.UI.WebControls;

namespace Training.BaseCore.Layouts.Site
{
    public partial class Head : BaseSublayout
    {
        /// <summary>
        /// The page <head /> element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Item root = ItemReferences.SiteRoot;

            if (ItemReferences.SiteRoot != null)
            {
                Field text = root.Fields["Site Head"];

                if (text != null)
                {
                    // Going through the FieldRenderer returns <br /> tags for a multi-line
                    // text field - getting raw value instead.                      

                    SiteHead.Text = text.Value;
                }
            }
        }

        public string MetaDescription
        {
            get
            {
                return FieldRenderer.Render(Sitecore.Context.Item, "Meta Description", "disable-web-editing=true");
            }
        }
    }
}