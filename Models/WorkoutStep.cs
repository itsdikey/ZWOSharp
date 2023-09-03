using System.Collections.Generic;
namespace ZWOSharp.Models
{
    public abstract class WorkoutStep
    {
        public List<TextEvent> TextEvents { get; set; }

        public abstract string Type { get; }
    }
}
