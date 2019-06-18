using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXML.Handlers
{
    internal static class XObjectEventHandlers
    {
        /// <summary>
        /// Этот метод будет зарегистрирован для обработки события начала изменения элемента
        /// </summary>
        /// <param name="sender">изменившийся объект, который вызвал возникновение события</param>
        /// <param name="cea">XObjectChange, указывающее на тип произошедшего изменения: XObjectChange.Add, XObjectChange.Name, XObjectChange.Remove или XObjectChange.Value.</param>
        public static void MyChangingEventHandler(object sender, XObjectChangeEventArgs cea)
        {
            Console.WriteLine($"{"Element", -10} [Тип изменяемого объекта]=\"{sender.GetType().Name}\" [Тип изменения]=\"{cea.ObjectChange}\"");
        }

        /// <summary>
        /// Этот метод будет зарегистрирован для обработки события окончания изменения элемента
        /// </summary>
        /// <param name="sender">изменившийся объект, который вызвал возникновение события</param>
        /// <param name="cea">XObjectChange, указывающее на тип произошедшего изменения: XObjectChange.Add, XObjectChange.Name, XObjectChange.Remove или XObjectChange.Value.</param>
        public static void MyChangedEventHandler(object sender, XObjectChangeEventArgs cea)
        {
            Console.WriteLine($"{"Element", -10} [Тип измененного объекта]=\"{sender.GetType().Name}\" [Тип изменения]=\"{cea.ObjectChange}\"");
        }

        /// <summary>
        /// Этот метод будет зарегистрирован для обработки события изменения XML-документа
        /// </summary>
        /// <param name="sender">изменившийся объект, который вызвал возникновение события</param>
        /// <param name="cea">XObjectChange, указывающее на тип произошедшего изменения: XObjectChange.Add, XObjectChange.Name, XObjectChange.Remove или XObjectChange.Value.</param>
        public static void DocumentChangedHandler(object sender, XObjectChangeEventArgs cea)
        {
            Console.WriteLine($"{"Doc", -10} [Тип измененного объекта]=\"{sender.GetType().Name}\" [Тип изменения]=\"{cea.ObjectChange}\"");
        }
    }
}
