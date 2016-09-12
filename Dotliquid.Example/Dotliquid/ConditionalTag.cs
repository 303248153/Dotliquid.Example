using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Dotliquid.Example.Dotliquid
{
    public class ConditionalTag : Tag
    {
        public string ConditionExpression { get; set; }
        public string TrueExpression { get; set; }
        public string FalseExpression { get; set; }

        public override void Initialize(string tagName, string markup, List<string> tokens)
        {
            base.Initialize(tagName, markup, tokens);
            var expressions = markup.Trim().Split(' ');
            ConditionExpression = expressions[0];
            TrueExpression = expressions[1];
            FalseExpression = expressions.Length >= 3 ? expressions[2] : "";
        }

        public override void Render(Context context, TextWriter result)
        {
            var condition = context[ConditionExpression];
            if (!(condition == null || condition.Equals(false) || condition.Equals("")))
                result.Write(context[TrueExpression]);
            else
                result.Write(context[FalseExpression]);
        }
    }
}