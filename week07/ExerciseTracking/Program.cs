using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling bike = new Cycling("03 Nov 2022", 30, 9.7);
        Swimming swim = new Swimming("03 Nov 2022", 30, 20);

        activities.Add(run);
        activities.Add(bike);
        activities.Add(swim);

        Console.WriteLine("--- Exercise Tracking Summary ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}