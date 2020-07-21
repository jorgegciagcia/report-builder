using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace report_builder.src
{   
    public class TableRenderElement : RenderElement
    {
    
        public string Caption {get;set;}
        public string HeadStyle {get;set;}
        public string HeadClass {get;set;}
        public string BodyStyle {get;set;}
        public string BodyClass{get;set;}
        public CommonDataStructure.ComplexTableDataDefinition TableDefinition {get;set;}
        
        public TableRenderElement()
        {
        }

        public override HtmlNode Render(HtmlNode nodeWherePaint)
        {
            if (TableDefinition == null)
            {
                if (SpecificData == null ||SpecificData.ComplexTable == null)
                    return null;
                TableDefinition = SpecificData.ComplexTable;
            }
            var node = _document.CreateElement("div container");
            _baseNode = node;
            
            var table = _document.CreateElement("table");
            table.Attributes.Add("class",Class??"");
            table.Attributes.Add("style",Style??"");
            node.ChildNodes.Add(table);
            
            if ( TableDefinition.Headers != null)
            {
                var thead = _document.CreateElement("thead");
                thead.Attributes.Add("class",HeadClass??"");
                thead.Attributes.Add("style",BodyStyle??"");
                table.ChildNodes.Add(thead);
                var tr = _document.CreateElement("tr");
                thead.ChildNodes.Add(tr);
                foreach ( var head in TableDefinition.Headers)
                {
                    var element = _document.CreateElement("td");
                    element.Attributes.Add("class",head.Class??"");
                    element.Attributes.Add("style",head.Style??"");
                    element.InnerHtml=head.Caption;
                    tr.ChildNodes.Add(element);
                }
            }
            if ( TableDefinition.Rows != null)
            {
                var tbody = _document.CreateElement("tbody");
                tbody.Attributes.Add("class",BodyClass??"");
                tbody.Attributes.Add("style",BodyStyle??"");
                table.ChildNodes.Add(tbody);
                foreach ( var row in TableDefinition.Rows)
                {
                    var tr = _document.CreateElement("tr");
                    tbody.ChildNodes.Add(tr);
                    foreach ( var data in row)
                    {
                        var element = _document.CreateElement("td");
                        element.Attributes.Add("class",data.Class??"");
                        element.Attributes.Add("style",data.Style??"");
                        element.InnerHtml=data.Caption;
                        tr.ChildNodes.Add(element);
                    }
                }
            }

            nodeWherePaint.ChildNodes.Add(node);
            return null;
        }
    }
}