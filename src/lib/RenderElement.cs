using System;
using System.Collections.Generic;
using System.Reflection;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace report_builder.src
{    public class RenderElement
    {
        public static Dictionary<string,Type> DerivedClasses = new Dictionary<string, Type>
        {
             {"label", typeof(LabelRenderElement)},
             {"renderElement",typeof(RenderElement)},
             {"collapse",typeof(CollapseRenderElement)},
             {"complexTable", typeof(TableRenderElement)},
             {"simpleTable",typeof(SimpleTableRenderElement)},
             {"decoratedCollapse",typeof(DecoratedCollapseRenderElement)},
        };
        protected HtmlDocument _document;
        protected IDataStructure _dataStructure;
        public Dictionary<string,object> Properties;
        public string Style {get;set;}
        public string Class {get;set;}
        public List<RenderElement> Cards;
        public string TypeOf {get;set;}
        public CommonDataStructure SpecificData {get;set;}
        // property for decorator
        protected HtmlNode _baseNode {get;set;}
        public RenderElement()
        {
        }
        public RenderElement(HtmlDocument document, IDataStructure dataStructure, Dictionary<string,object> properties)
        {
            Configure (document,dataStructure,properties,null,null);
        }
        
        public void Configure (HtmlDocument document,IDataStructure dataStructure,Dictionary<string,object> properties,List<RenderElement> cards,CommonDataStructure data)
        {
            _document = document;
            _dataStructure = dataStructure;
            Properties = properties;
            if (cards != null)
               Cards = cards;
            if (data != null)
               SpecificData = data;
            foreach ( var key in Properties.Keys)
            {
                PropertyInfo pr = this.GetType().GetProperty(key); 
                if (pr != null)
                {
                    pr.SetValue(this,GetValue(key,Properties[key]));
                }
            }
        }
        public void Configure (HtmlDocument document,IDataStructure dataStructure)
        {
            _document = document;
            _dataStructure = dataStructure;
            ProcessCards();
        }
        
        protected object GetValue(string key,object objValue)
        {
            try 
            {
                string val = (string)objValue;
                if (val.StartsWith("{") && val.EndsWith("}"))
                {
                    val = val.Substring(1,val.Length-2);
                    return GetValue(val.Split("."),_dataStructure,0);    
                }
            }
            catch{}
            if ( Properties[key].GetType().ToString().Contains("JArray"))
            {
                JArray arr = (JArray)Properties[key];
                objValue = arr.ToObject<List<TextFullFormatDefinition>>();
            }

            return objValue;
        }
        protected object GetValue(string [] parser,object dataStructure,int count)
        {
            PropertyInfo propertyInfo = dataStructure.GetType().GetProperty(parser[count]);
            if (propertyInfo == null )
            {
               throw new Exception ($"Element {string.Join(".",parser)} not found");
            }
            var obj = propertyInfo.GetValue(dataStructure);
            if (parser.Length - count == 1)
               return obj;
            return GetValue(parser,obj,count+1);
        }
        protected void ProcessCards(){
            //Factory parttern 

            if (Cards == null)
               return;

            List<RenderElement> newCards = new List<RenderElement>();
            foreach (var card in Cards)
            {
               var element = (RenderElement)Activator.CreateInstance(DerivedClasses[card.TypeOf]);
               element.Configure(_document,_dataStructure,card.Properties,card.Cards,card.SpecificData);
               newCards.Add (element);
            }
            Cards = newCards;
            foreach ( var card in Cards)
               card.ProcessCards();
        }
        public virtual HtmlNode Render(HtmlNode node)
        {
            return node;
        }
        public void FullRender(HtmlNode node)
        {
            var nodeWhereToPaint = Render(node);
            if (nodeWhereToPaint!= null && Cards != null)
               foreach (var element in Cards)
                  element.FullRender(nodeWhereToPaint);
        }
    }
}