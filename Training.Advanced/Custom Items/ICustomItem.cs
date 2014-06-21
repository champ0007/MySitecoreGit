using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace Training.Utilities.BaseCore.Mappings
{
    /// <summary>
    /// Interface for custom items.
    /// </summary>
    public interface IPageItem
    {
        string Url { get; }
    }
}