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
using Training.Utilities.BaseCore.References;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data.Managers;

namespace Training.BaseCore.Layouts.Search
{
    public partial class SearchResults : BaseSublayout
    {

        private const int itemsPerPage = 5;
        private static int page = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("sitecore_web_index");
            var context = index.CreateSearchContext();

            if (context != null)
            {
                var query = context.GetQueryable<SitecoreItem>();

                Guid template = TemplateReferences.Holiday.ID.Guid;
                Guid path = ItemReferences.SiteHome.ID.Guid;

                if (Request.QueryString[Keys.SearchPage] != null)
                {
                    int.TryParse(Request.QueryString[Keys.SearchPage], out page);

                    if (Session[Keys.HolidaySearchSession] != null)
                    {
                        SearchObject searchObject = Session[Keys.HolidaySearchSession] as SearchObject;

                        // Conditional .Where() clauses

                        if (searchObject != null)
                        {
                            Guid holidayType = searchObject.HolidayType;
                            Guid terrain = searchObject.Terrain;
                            string text = searchObject.Text;

                            if (terrain != Guid.Empty)
                            {
                                query = query.Where(x => x.Terrain == terrain);
                            }
                            if (holidayType != Guid.Empty)
                            {
                                query = query.Where(x => x.HolidayType == holidayType);
                            }
                            if (!String.IsNullOrEmpty(text))
                            {
                                query = query.Where(x => (x.PageHeading.Contains(text) || x.PageContent.Contains(text)));
                            }
                        }
                    }
                }

                // .Where() that always exists 
                // TODO: Make .Page work instead of skip/take

                //&& x.Path == path

                string id = ItemReferences.SiteRoot.ID.ToShortID().ToString();

                ID contextLanguageId = LanguageManager.GetLanguageItemId(Sitecore.Context.Language, Sitecore.Context.Database);
                Item contextLanguage = Sitecore.Context.Database.GetItem(contextLanguageId);

                string lang = !String.IsNullOrEmpty(contextLanguage["Regional Iso Code"]) ? contextLanguage["Regional Iso Code"] : contextLanguage["Iso"];

                query = query.Where(x => x.TemplateID == template && x.Path.Contains(id))
                    .Where(x => x.Language == lang);

                int count = query.Count();

                query = query.Page(page - 1, itemsPerPage);

                var result = query.GetResults();

                /* TODO: Do a count */

                List<Item> items = new List<Item>();

                if (result != null)
                {
                    if (result.Hits.Any())
                    {
                        foreach (var r in result.Hits)
                        {
                            Item i = Sitecore.Context.Database.GetItem(new ID(r.Document.ID));
                            items.Add(i);
                        }
                    }
                }

                rpHolidays.DataSource = items;
                rpHolidays.DataBind();

                pgPagination.Page = page;
                pgPagination.PageSize = itemsPerPage;
                pgPagination.Total = count;
            }
        }
    }
}