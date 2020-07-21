using System;
using System.IO;
using HtmlAgilityPack;

namespace report_builder.src
{

    public class ReportBuilder
    {
        HtmlDocument _document;
        private readonly RenderElement _template;
        private readonly IDataStructure _data;
        public ReportBuilder(RenderElement template, IDataStructure data)
        {
            _template = template;
            _data = data;
            _document = new HtmlDocument();
            _template.Configure(_document, _data);
        }
        public string Render()
        {
            var mainDiv = _document.CreateElement("div");
            _template.FullRender(mainDiv);
            using (TextWriter writer = new StringWriter())
            {
                mainDiv.WriteContentTo(writer);
                return writer.ToString();
            }
        }
    }

}