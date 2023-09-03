using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ZWOSharp.Models;

namespace ZWOSharp.Service
{
    internal static class ZWOParserUtility
    {
        public static void Parse(ZWODocument zwoDocument, string text)
        {
            var xdocument = XDocument.Parse(text);
            var workoutFileElement = xdocument.Element("workout_file");

            if(workoutFileElement == null) 
            {
                throw new ArgumentException("Provided a wrong ZWO file");
            }

            zwoDocument.Author = TryGetValue(workoutFileElement.Element("author"));
            zwoDocument.Name = TryGetValue(workoutFileElement.Element("name"));
            zwoDocument.Description = TryGetValue(workoutFileElement.Element("description"));

            var workoutNode = workoutFileElement.Element("workout");

            if(workoutNode == null)
            {
                throw new ArgumentException("Provided a wrong ZWO file");
            }

            foreach (var element in workoutNode.Elements())
            {
                WorkoutStep workout = null;
                if (element.Name == "Warmup")
                {
                    workout = new WarmUp();
                    AssignFields(element, workout);
                }
                if (element.Name == "SteadyState")
                {
                    workout = new SteadyState();
                    AssignFields(element, workout);
                }
                if (element.Name == "FreeRide")
                {
                    workout = new FreeRide();
                    AssignFields(element, workout);
                }
                if (element.Name == "Cooldown")
                {
                    workout = new Cooldown();
                    AssignFields(element, workout);
                }
                if (element.Name == "IntervalsT")
                {
                    workout = new IntervalsT();
                    AssignFields(element, workout);
                }
                if (element.Name == "Ramp")
                {
                    workout = new IntervalsT();
                    AssignFields(element, workout);
                }

                if (element.HasElements)
                {
                    if (workout == null)
                        return;
                    var elements = element.Elements();
                    workout.TextEvents = new List<TextEvent>();
                    foreach (var textEvent in elements)
                    {
                        workout.TextEvents.Add(new TextEvent()
                        {
                            TimeOffset = double.Parse(textEvent.Attribute("timeoffset").Value),
                            Message = textEvent.Attribute("message").Value
                        });
                    }
                }

                zwoDocument.Workout.Add(workout);
            }
        }

        private static string TryGetValue(XElement element, string defaultValue = "")
        {
            if (element == null)
                return defaultValue;

            return element.Value;
        }

        static void AssignFields(XElement element, object instance)
        {
            var properties = instance.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var property in properties)
            {
                var attribute = element.Attribute(property.Name);
                if (attribute == null)
                    continue;
                var value = attribute.Value;
                property.SetValue(instance, Convert.ChangeType(value, property.PropertyType));
            }
        }
    }
}
