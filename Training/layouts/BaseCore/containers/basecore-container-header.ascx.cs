using System;
using Training.Utilities.Basecore.Base;
using Training.Utilities.Basecore.References;

namespace Training.BaseCore.Layouts.Containers {

    /// <summary>
    /// Container for header.
    /// </summary>
    public partial class HeaderContainer : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Logo.Item = ItemReferences.SiteRoot;
        }
    }
}