using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXML.Models
{
    internal sealed class ExampleDocument
    {
        // Это используется для хранения ссылки на один из элементов в дереве XML.
        internal static XElement firstParticipant;

        internal static XDocument xDocument = new XDocument(
            new XDeclaration("1.0", "UTF-8", "yes"),
            new XDocumentType("BookParticipants", null, "BookParticipants.dtd", null),
            new XProcessingInstruction("BookCataloger", "out-of-print"),
            // Обратите внимание, что в следующей строке сохраняется
            // ссылка на первый элемент BookParticipant.
            new XElement("BookParticipants", firstParticipant =
                new XElement("BookParticipant",
                    new XAttribute("type", "Author"),
                    new XElement("FirstName", "Joe"),
                    new XElement("LastName", "Rattz")),
                new XElement("BookParticipant",
                    new XAttribute("type", "Editor"),
                    new XElement("FirstName", "Ewan"),
                    new XElement("LastName", "Buckingham"))));        
    }
}
