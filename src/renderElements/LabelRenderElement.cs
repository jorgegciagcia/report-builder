using System.Collections.Generic;
using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace report_builder.src
{   
    public class LabelRenderElement : RenderElement
    {
        public string Caption {get;set;}
        public LabelRenderElement()
        {
        }

        public override HtmlNode Render(HtmlNode nodeWherePaint)
        {
            var node = _document.CreateElement("div");
            _baseNode = node;
            if (Class != null)
               node.Attributes.Add("class",Class);
            if (Style != null)
               node.Attributes.Add("style",Style);
            node.InnerHtml=Caption;
            nodeWherePaint.ChildNodes.Add(node);
            return null;
        }
    }
}