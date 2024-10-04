using CodeNest.BLL.Repositories;
using CodeNest.DTO.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeNest.DTO.Models.XmlModel;
using System.Xml.Linq;

namespace CodeNest.BLL.Service
{
     public class FormatterServices : IFormatterServices
    {

        #region JsonMethods
        /// <summary>
        /// This use to validate the json data
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public async Task<ValidationDto> JsonValidate(string jsonInput)
        {
            // Check for null or whitespace input
            if (string.IsNullOrWhiteSpace(jsonInput))
            {
                return new ValidationDto
                {
                    IsValid = false,
                    Message = "Input is either null, empty, or contains only whitespace."
                };
            }

            // Trim the input to remove any leading or trailing spaces
            jsonInput = jsonInput.Trim();

            // Validate if input starts and ends with the appropriate JSON characters
            if ((jsonInput.StartsWith('{') && jsonInput.EndsWith('}')) ||
                (jsonInput.StartsWith('[') && jsonInput.EndsWith(']')))
            {
                try
                {
                    // Try parsing the JSON input
                    JToken parsedJson = JToken.Parse(jsonInput);
                    string formattedJson = parsedJson.ToString(Formatting.Indented);

                    // Return valid JSON response
                    return new ValidationDto
                    {
                        IsValid = true,
                        Message = "Valid JSON.",
                       JsonDto = new JsonDto
                        {
                            JsonInput = jsonInput,
                            JsonOutput = formattedJson
                        }
                    };
                }
                catch (JsonReaderException ex)
                {
                    // Handle invalid JSON input
                    return new ValidationDto
                    {
                        IsValid = false,
                        Message = $"Invalid JSON: {ex.Message}",
                        JsonDto = new JsonDto
                        {
                            JsonInput = jsonInput
                        }
                    };
                }
            }
            else
            {
                // Return when the structure does not match JSON object or array
                return new ValidationDto
                {
                    IsValid = false,
                    Message = "Input is not in valid JSON format (missing appropriate starting or ending brackets).",
                    JsonDto = new JsonDto
                    {
                        JsonInput = jsonInput
                    }
                };
            }
        }
        #endregion

        #region XmlMethods
        public async Task<XmlValidation> XmlValidate(string xmlInput)
        {
            if (string.IsNullOrWhiteSpace(xmlInput))
            {
                return new XmlValidation
                {
                    IsValid = false,
                    Message = "Input is either null, empty, or contains only whitespace."
                };
            }
            
            bool isWellFormed = IsXmlWellFormed(xmlInput);
            int nodeCount = CountXmlNodes(xmlInput);

           
            string beautifiedXml = BeautifyXml(xmlInput); // You can write logic for beautifying.

            return new XmlValidation
            {
                IsValid = isWellFormed,
                Message = isWellFormed ? "Valid XML input." : "XML is not well-formed.",
                XmlDto = new XmlModel
                {
                    XmlInput = xmlInput,
                    BeautifiedXml = beautifiedXml,
                    NodeCount = nodeCount,
                  
                }
            };
        }

        #region privateXmlMethods
      
        /// <summary>
        /// Example of a method that could check if the XML is well-formed
        /// </summary>
        /// <param name="xmlInput"></param>
        /// <returns></returns>
        private bool IsXmlWellFormed(string xmlInput)
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(xmlInput);
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        /// <summary>
        ///  This method that could count the XML nodes
        /// </summary>
        /// <param name="xmlInput"></param>
        /// <returns></returns>
        private int CountXmlNodes(string xmlInput)
        {
            System.Xml.XmlDocument xmlDoc = new();
            xmlDoc.LoadXml(xmlInput);
            return xmlDoc.SelectNodes("//*").Count;
        }

        /// <summary>
        /// This method to beautify XML
        /// </summary>
        /// <param name="xmlInput"></param>
        /// <returns></returns>
        private string BeautifyXml(string xmlInput)
        {
            System.Xml.XmlDocument xmlDoc = new();
            xmlDoc.LoadXml(xmlInput);

            using (StringWriter stringWriter = new())
            {
                using (System.Xml.XmlTextWriter xmlTextWriter = new(stringWriter))
                {
                    xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
                    xmlDoc.WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }
            }
        } 
        #endregion
        #endregion
    }
}
