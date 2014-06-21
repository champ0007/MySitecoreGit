using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Training.Utilities.BaseCore.Fields.Mappings
{
    /// <summary>
    /// Sitecore reference fields are things 'DropLink' that reference and item by GUID.
    /// </summary>
    public class SitecoreReferenceField : SitecoreField, ISitecoreField
    {
        public SitecoreReferenceField(Item item, string fieldName)
        {
            this.FieldName = fieldName;
            this.Item = item;
        }

        /// <summary>
        /// The actual reference field.
        /// </summary>
        public ReferenceField Field
        {
            get
            {
                ReferenceField referenceField = null;

                if (IsValidField)
                {
                    referenceField = Item.Fields[FieldName];
                }

                return referenceField;
            }
        }

        /// <summary>
        /// The field's target item.
        /// </summary>
        private Item _item;
        public Item ReferenceItem
        {
            get
            {
                _item = null;

                if (Field != null)
                {
                    _item = Field.TargetItem;
                }

                return _item;
            }
        }
    }
}
