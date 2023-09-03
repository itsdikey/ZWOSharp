using System.Collections.Generic;
using System.IO;
using ZWOSharp.Models;
using ZWOSharp.Service;
using static System.Net.Mime.MediaTypeNames;

namespace ZWOSharp
{
    public sealed class ZWODocument
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<WorkoutStep> Workout { get; set; }
        private ZWODocument() { Workout = new List<WorkoutStep>(); }


        public static ZWODocument Parse(string text)
        {
            var result = new ZWODocument();
            ZWOParserUtility.Parse(result, text);
            return result;
        }

        public static ZWODocument Load(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var result = new ZWODocument();
                ZWOParserUtility.Parse(result, reader.ReadToEnd());
                return result;
            }
        }


        public static ZWODocument Empty => new ZWODocument();
    }
}
