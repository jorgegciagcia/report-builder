using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using HtmlAgilityPack;

namespace report_builder.src
{
    public class SimpleTableRenderElement : RenderElement
    {

        public string Caption { get; set; }
        public string HeadStyle { get; set; }
        public string HeadClass { get; set; }
        public string BodyStyle { get; set; }
        public string BodyClass { get; set; }
        public CommonDataStructure.SimpleTableDataDefinition TableDefinition { get; set; }

        public SimpleTableRenderElement()
        {
        }

        public override HtmlNode Render(HtmlNode nodeWherePaint)
        {
            if (TableDefinition == null)
            {
                if (SpecificData == null || SpecificData.SimpleTable == null)
                    return null;
                TableDefinition = SpecificData.SimpleTable;
            }
            var node = _document.CreateElement("div container");
            _baseNode = node;
            var table = _document.CreateElement("table");
            table.Attributes.Add("class", Class ?? "");
            table.Attributes.Add("style", Style ?? "");
            node.ChildNodes.Add(table);

            if (TableDefinition.Headers != null)
            {
                var thead = _document.CreateElement("thead");
                thead.Attributes.Add("class", HeadClass ?? "");
                thead.Attributes.Add("style", BodyStyle ?? "");
                table.ChildNodes.Add(thead);
                var tr = _document.CreateElement("tr");
                thead.ChildNodes.Add(tr);
                foreach (var head in TableDefinition.Headers)
                {
                    var element = _document.CreateElement("td");
                    element.InnerHtml = head;
                    tr.ChildNodes.Add(element);
                }
            }
            if (TableDefinition.Rows != null)
            {
                var tbody = _document.CreateElement("tbody");
                tbody.Attributes.Add("class", BodyClass ?? "");
                tbody.Attributes.Add("style", BodyStyle ?? "");
                table.ChildNodes.Add(tbody);
                foreach (var row in TableDefinition.Rows)
                {
                    var tr = _document.CreateElement("tr");
                    tbody.ChildNodes.Add(tr);
                    foreach (var data in row)
                    {
                        var element = _document.CreateElement("td");
                        element.InnerHtml = data;
                        tr.ChildNodes.Add(element);
                    }
                }
            }

            nodeWherePaint.ChildNodes.Add(node);
            return null;
        }
    }
}