using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.LuceneProvider;
using Sitecore.ContentSearch.SearchTypes;

namespace Training.Utilities.BaseCore.Search
{
    public class SitecoreItem : SearchResultItem
    {
        public readonly NameValueCollection fields = new NameValueCollection();

        #region Generic Page Properties

        [IndexField("_group")]
        public Guid ID { get; set; }

        [IndexField("_path")]
        public string[] Path { get; set; }

        [IndexField("_template")]
        public Guid TemplateID { get; set; }

        [IndexField("page_heading")]
        public string PageHeading { get; set; }

        [IndexField("page_content")]
        public string PageContent { get; set; }

        #endregion

        #region Holidays

        [IndexField("type")]
        public Guid HolidayType { get; set; }

        [IndexField("terrain")]
        public Guid Terrain { get; set; }

        #endregion

        public string this[string key]
        {
            get
            {
                return this.fields[key];
            }

            set
            {
                this.fields[key] = value;
            }
        }
    }
}
