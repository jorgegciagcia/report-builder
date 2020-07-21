using System.Collections.Generic;

namespace report_builder.src
{
    public class ContainerOneStructure
    {
        public string TestCaption { get; set; }
        public List<string> DataListValues { get; set; }
        public string LoremIpsum { get; set; }

    }

    public class DataStructure : IDataStructure
    {
        public ContainerOneStructure ContainerOne { get; set; }
        public ContainerTableStructure ContainerTable { get; set; }
        public CommonDataStructure CommonDataForTable { get; set; }
        public List<PercentageBox> PercentageExample {get;set;}
        public static DataStructure DataStructureExample
        {
            get => new DataStructure
            {
                ContainerOne = new ContainerOneStructure
                {
                    TestCaption = "FFAAAFFFEEAADDAAEEFFEE122EADD",
                    DataListValues = new List<string>{
                       "one","two","three"
                   },
                    LoremIpsum = "Great!<br/>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32."
                },
                ContainerTable = new ContainerTableStructure
                {
                    Header = new List<TextFullFormatDefinition>{
                        new TextFullFormatDefinition{
                            Caption="Column #1"
                        },
                        new TextFullFormatDefinition{
                            Caption="Column #2"
                        },
                        new TextFullFormatDefinition{
                            Caption="Column #3"
                        }
                    }
                },
                CommonDataForTable = new CommonDataStructure
                {
                    ComplexTable = new CommonDataStructure.ComplexTableDataDefinition
                    {
                        Headers = new List<TextFullFormatDefinition>
                        {
                            new TextFullFormatDefinition{
                                Caption ="Column #1",
                                Style="font-weight:bold"
                            },
                            new TextFullFormatDefinition{
                                Caption ="Column #2",
                                Style="font-weight:bold"
                            },
                            new TextFullFormatDefinition{
                                Caption ="Column #3",
                                Style="font-weight:bold"
                            },
                            new TextFullFormatDefinition{
                                Caption ="Column #4",
                                Style="font-weight:bold"
                            }
                        },
                        Rows = new List<List<TextFullFormatDefinition>>
                        {
                            new List<TextFullFormatDefinition> {
                                new TextFullFormatDefinition{
                                    Caption= "data#1.1"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#1.2"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#1.3"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#1.4"
                                }
                            },
                            new List<TextFullFormatDefinition> {
                                new TextFullFormatDefinition{
                                    Caption= "data#2.1"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#2.2"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#2.3"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#2.4"
                                }
                            },
                            new List<TextFullFormatDefinition> {
                                new TextFullFormatDefinition{
                                    Caption= "data#3.1"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#3.2"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#3.3"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#3.4"
                                }
                            },
                            new List<TextFullFormatDefinition> {
                                new TextFullFormatDefinition{
                                    Caption= "data#4.1"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#4.2"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#4.3"
                                },
                                new TextFullFormatDefinition{
                                    Caption= "data#4.4",
                                    Style="color:blue"
                                }
                            }
                        }
                    },
                    SimpleTable = new CommonDataStructure.SimpleTableDataDefinition
                    {
                        Headers = new List<string>{
                        "<b>Column #1</b>","<b>Column #2</b>","<b>Column #3</b>","<b>Column #4</b>"
                        },
                        Rows = new List<List<string>>{
                            new List<string>{
                                "data #1.1","data #1.2","data #1.3","data #1.4"
                            },
                            new List<string>{
                                "data #2.1","data #2.2","data #2.3","data #2.4"
                            },
                            new List<string>{
                                "data #3.1","data #3.2","data #3.3","data#3.4"
                            },
                            new List<string>{
                                "data #4.1","data #4.2","data #4.3","<span style=\"color:blue\">data #4.4</span>"
                            }
                        }
                    }
                },
                PercentageExample = new List<PercentageBox>
                {
                    new PercentageBox{
                        Color="blue",
                        Percentage=20
                    },
                    new PercentageBox{
                        Color="green",
                        Percentage=40
                    },
                    new PercentageBox{
                        Color="red",
                        Percentage=20
                    },
                    new PercentageBox{
                        Color="yellow",
                        Percentage=20
                    },
                }
            };
        }
    }
}