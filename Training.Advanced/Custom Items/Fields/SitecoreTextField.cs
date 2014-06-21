using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace Training.Utilities.BaseCore.Fields.Mappings
{
    /// <summary>
    /// A standard Sitecore text field - e.g. Single-Line Text
    /// </summary>
    public class SitecoreTextField : SitecoreField, ISitecoreField 
    {
        public SitecoreTextField(Item item, string fieldName)
        {
            this.FieldName = fieldName;
            this.Item = item;
        }
    }
}
