using LinqToXML.Handlers;
using LinqToXML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXML
{
    sealed class LinqToXmlConsole
    {
        private static readonly XNamespace nameSpace = "LinqSchool";

        static void Main()
        {
            CreateExampleXml();
            CreateHalloweenProblem();
            LinqGenerationXml();
            ViewExampleDocument();
            EventHandlersExample();

            Console.ReadKey();
        }

        private static void CreateExampleXml()
        {
            Console.WriteLine("   Example XML:");

            XElement xBookParticipants =
                new XElement(nameSpace + "BookParticipants",
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham")));

            Console.WriteLine(xBookParticipants.ToString());
        }

        private static void CreateHalloweenProblem()
        {
            Console.WriteLine("\n   Halloween problem:");

            XDocument xDocument = new XDocument(
                new XElement("BookParticipants",
                    new XElement("BookParticipant",
                        new XAttribute("type", "Author"),
                        new XElement("FirstName", "Joe"),
                        new XElement("LastName", "Rattz")),
                    new XElement("BookParticipant",
                        new XAttribute("type", "Editor"),
                        new XElement("FirstName", "Ewan"),
                        new XElement("LastName", "Buckingham"))));

            IEnumerable<XElement> elements = xDocument.Element("BookParticipants").Elements("BookParticipant");

            foreach (XElement element in elements)
            {
                Console.WriteLine($"Исходный элемент: {element.Name} : значение = {element.Value}");
            }

            foreach (XElement element in elements)
            {
                Console.WriteLine($"Удаление {element.Name} = {element.Value} ...");
                element.Remove();
            }

            Console.WriteLine($"\n{xDocument}");
        }

        private static void LinqGenerationXml()
        {
            Console.WriteLine("\n   Xml generation by LINQ:");

            List<Participant> participants = new List<Participant>() { new Participant("Joe", "Rattz", ParticipantTypes.Author), new Participant("Ewan", "Buckingham", ParticipantTypes.Editor) };

            XElement xParticipants =
                new XElement("Participants",
                    participants.Select(p =>
                       new XElement("Participant",
                           new XAttribute("type", p.ParticipantType),
                           new XElement("FirstName", p.FirstName),
                           new XElement("LastName", p.LastName))));

            Console.WriteLine(xParticipants);
        }

        private static void ViewExampleDocument()
        {
            Console.WriteLine("\n   Example document:");
            Console.WriteLine(ExampleDocument.xDocument);            
        }

        private static void EventHandlersExample()
        {
            Console.WriteLine("\n   Event handlers example:");

            ExampleDocument.firstParticipant.Changing += new EventHandler<XObjectChangeEventArgs>(XObjectEventHandlers.MyChangingEventHandler);
            ExampleDocument.firstParticipant.Changed += new EventHandler<XObjectChangeEventArgs>(XObjectEventHandlers.MyChangedEventHandler);
            ExampleDocument.xDocument.Changed += new EventHandler<XObjectChangeEventArgs>(XObjectEventHandlers.DocumentChangedHandler);

            ExampleDocument.firstParticipant.Element("FirstName").Value = "HakunaMatata";
            
        }
    }
}
