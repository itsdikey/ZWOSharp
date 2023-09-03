## Quick and dirty library to parse Zwift workout files

C# library to parse ZWIFT Workout files (*.zwo)

### Usage

    var document = ZWODocument.Parse("workout_file_text");
    foreach(var workout in document.Workout)
    {
	    Console.WriteLine(workout.Type);
    }
