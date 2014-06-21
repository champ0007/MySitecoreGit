using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;

[assembly: TagPrefix("Training.Utilities.Basecore.Experiments", "exp")]
namespace Training.Utilities.Basecore.Experiments
{
    [ParseChildren(true)]
    public class TCText : Text
    {
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ITemplate Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        private ITemplate _prefix;

        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ITemplate Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        private ITemplate _suffix;

        protected override void DoRender(HtmlTextWriter output)
        {
            string fieldContent = output.ToString();

            if (!String.IsNullOrEmpty(fieldContent))
            {
                Literal suffixLiteral = new Literal();
                Literal prefixLiteral = new Literal();

                Suffix.InstantiateIn(suffixLiteral);
                Prefix.InstantiateIn(prefixLiteral);

                output.Write(prefixLiteral.Text);
                base.DoRender(output);
                output.Write(suffixLiteral.Text);
            }
        }
    }
}
