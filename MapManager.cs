using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace USWebTools.Web.Managers
{
    public class MapManager
    {
        public XDocument SaveMappings(List<Controllers.HomeController.SurveyField> fields)
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),

                //create root
                new XElement("ImportMap",

                    new XElement("InputFile",
                        fields.Select(x =>
                            new XElement("Field",
                                new XAttribute("destinationField", x.DestinationField)))
                    ),

                    new XElement("SurveyWorkbench",

                        new XElement("PanelistMap",
                            fields.Where(m => m.Map.Equals("PanelistMap")).Select(x =>
                              new XElement("FieldMap",
                                    new XAttribute("destinationField",x.DestinationField)
                                )
                            )
                        ),

                        new XElement("ProfileMap",
                             fields.Where(m => m.Map.Equals("ProfileMap")).Select(x =>
                              new XElement("FieldMap",
                                new XAttribute("destinationField", x.DestinationField)
                              )
                            )
                        ),
                        new XElement("SurveyMap",
                             fields.Where(m => m.Map.Equals("SurveyMap")).Select(x =>
                              new XElement("FieldMap",
                                new XAttribute("destinationField", x.DestinationField)
                              )
                            )
                        )
                        )
                    )
            );

            return doc;
        }
    }
}
