using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace report_builder.src
{   
    public class CollapseRenderElement : RenderElement
    {
        public string Caption {get;set;}
        public string CollapseMode{get;set;} //hide or show
        public string HtmlContent{get;set;}
        
        public CollapseRenderElement()
        {
        }

        public override HtmlNode Render(HtmlNode nodeWherePaint)
        {
            string id="acc_"+Guid.NewGuid().ToString();
            string id2="col_"+Guid.NewGuid().ToString();
            
            var node = _document.CreateElement("div");
            node.Attributes.Add("id",id);
            _baseNode = node;
            var node2 = _document.CreateElement("div");
            node.ChildNodes.Add(node2);
            node2.Attributes.Add("class","container card "+Class ?? "");
            node2.Attributes.Add("style",Style ?? "");

            var node3 = _document.CreateElement("div");
            node2.ChildNodes.Add(node3);
            node3.Attributes.Add("class","card-header row");
            var node31 = _document.CreateElement("div");
            node3.ChildNodes.Add(node31);
            node31.Attributes.Add("class","col-md-8");

            var node32 = _document.CreateElement("div");
            node3.ChildNodes.Add(node32);
            node32.Attributes.Add("class","col-md-4 mark-header-right");    
            var node4 = _document.CreateElement("h5");
            node31.ChildNodes.Add(node4);

            node4.Attributes.Add("class","mb-0");

            var node5 = _document.CreateElement("button");
            node4.ChildNodes.Add(node5);
            node5.Attributes.Add("class","btn btn-link");
            node5.Attributes.Add("data-toggle","collapse");
            node5.Attributes.Add("data-target",$"#{id2}");
            node5.InnerHtml=Caption;
            
            var node6 = _document.CreateElement("div");
            node2.ChildNodes.Add(node6);
            node6.Attributes.Add("id",id2);
            node6.Attributes.Add("class",$"collapse {CollapseMode}");
            node6.Attributes.Add("data-parent",$"#{id}");
            
            var node7 = _document.CreateElement("div");
            node6.ChildNodes.Add(node7);
            node7.Attributes.Add("class","card-body mark-content");
            node7.InnerHtml=HtmlContent??"";
            nodeWherePaint.ChildNodes.Add(node);
            return node7;
        }
    }
}