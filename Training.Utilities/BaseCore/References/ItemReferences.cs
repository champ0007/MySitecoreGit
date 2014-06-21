using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;

namespace Training.Utilities.Basecore.References
{
    /// <summary>
    /// A central list of item GUIDs. Because this is a multi-site installation, no items apart from global settings items
    /// are referenced.
    /// </summary>
    public class ItemReferences
    {
        #region Queries

        private static readonly string queryAncestorOrSelfByTemplate = "ancestor-or-self::*[@@templateid='{0}']";

        #endregion

        #region Settings Items

        public static Item SettingsHeadings { get { return Sitecore.Context.Database.GetItem(new ID("{444CDDCD-497B-4505-BD76-D0E71C452629}")); } }
        public static Item Samples { get { return Sitecore.Context.Database.GetItem(new ID("{F185C049-BA44-491A-8DE0-B9CC382A758B}")); } }
        public static Item SampleWidget { get { return Sitecore.Context.Database.GetItem(new ID("{79DF8FFB-508C-4768-8E75-F8BA92886ECE}")); } }

        #endregion

        #region Query Items

        /// <summary>
        /// 
        /// </summary>
        public static Item SiteRoot
        {
            get
            {
                Item root = null;

                Item[] siteRoots = Sitecore.Context.Item.Axes.SelectItems(String.Format(queryAncestorOrSelfByTemplate, TemplateReferences.SiteFolder.ToString()));

                if (siteRoots.Length > 0)
                {
                    root = siteRoots.FirstOrDefault();
                }

                return root;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item SiteHome
        {
            get
            {
                Item home = null;

                Item[] homes = Sitecore.Context.Item.Axes.SelectItems(String.Format(queryAncestorOrSelfByTemplate, TemplateReferences.Home.ToString()));

                if (homes.Length > 0)
                {
                    home = homes.FirstOrDefault();
                }

                return home;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item Global
        {
            get
            {
                return SiteRoot.Children.Where(x => x.TemplateID == TemplateReferences.Global).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item Terrains
        {
            get
            {
                return Global.Children.Where(x => x.TemplateID == TemplateReferences.TerrainsFolder).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item HolidayTypes
        {
            get
            {
                return Global.Children.Where(x => x.TemplateID == TemplateReferences.HolidayTypesFolder).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item BookingsRoot
        {
            get
            {
                return SiteRoot.Children.Where(x => x.TemplateID == TemplateReferences.BookingsFolder).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item BookingsPage
        {
            get
            {
                return SiteHome.Children.Where(x => x.TemplateID == TemplateReferences.BookingsPage).FirstOrDefault();
            }
        }

        /// <summary>
        /// We expect the 'Holidays' item to be a direct child of 'Home'. Using GetDescendants() is expensive on a large tree.
        /// </summary>
        public static Item HolidaysRoot
        {
            get
            {
                Item holidaysRoot = null;

                if (SiteHome != null)
                {
                    holidaysRoot = SiteHome.Children.Where(x => x.TemplateID == TemplateReferences.Holidays).FirstOrDefault();
                }

                return holidaysRoot;
            }
        }

        #endregion

    }
}
