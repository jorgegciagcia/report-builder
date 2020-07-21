using System.Collections.Generic;

namespace report_builder.src{
    public class CommonDataStructure
    {
        // common data for TableRenderElement (complexTable)
        public class ComplexTableDataDefinition
        {
          public List<TextFullFormatDefinition> Headers {get;set;}
          public List<List<TextFullFormatDefinition>> Rows {get;set;}
        }
        // common data for SimpleDataDefinition
        public class SimpleTableDataDefinition
        {
            public List<string> Headers {get;set;}
            public List<List<string>> Rows {get;set;}
        }

        public ComplexTableDataDefinition ComplexTable {get;set;}
        public SimpleTableDataDefinition SimpleTable {get;set;}
        public List<PercentageBox> PercentageBoxValues {get;set;}

          // define more data fields for render elements
    }
}