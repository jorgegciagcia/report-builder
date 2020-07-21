using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace report_builder.src
{   
    public class DecoratedCollapseRenderElement : CollapseRenderElement
    {
        public DecoratedCollapseRenderElement()
        {
        }
        public List<PercentageBox> PercentageBoxDefinition {get;set;}
        HtmlNode FindNodeForPaint (HtmlNode node)
        {
            
            var attributes = node.Attributes.AttributesWithName("class");
            foreach (var attribute in attributes)
            {
                if (attribute.Value.Contains("mark-header-right") == true)
                   return node;
            }
            foreach ( HtmlNode newNode in node.ChildNodes)
            {
                var response = FindNodeForPaint(newNode);
                if ( response != null)
                   return response;
            }
            return null;
        }

        public override HtmlNode Render(HtmlNode nodeWherePaint)
        {
            if (PercentageBoxDefinition == null)
            {
                if (SpecificData == null || SpecificData.PercentageBoxValues == null)
                    return null;
                PercentageBoxDefinition = SpecificData.PercentageBoxValues;
            }
            var nodeForReturn = base.Render(nodeWherePaint);
            HtmlNode node = FindNodeForPaint(_baseNode);
            if (node ==null)
               return null;
            HtmlNode newNode = _document.CreateElement("div");
            node.ChildNodes.Add(newNode);
            newNode.Attributes.Add("style","vertical-align:middle");
            foreach ( var perc in PercentageBoxDefinition)
            {
                var node1 = _document.CreateElement("div");
                node1.Attributes.Add("style",$"width:{perc.Percentage}%;background-color:{perc.Color};text-align:center;float:right;color:white");
                
                node1.InnerHtml=$"{perc.Percentage}%";
                newNode.AppendChild(node1);
            }

            return nodeForReturn;
        }
    }
}