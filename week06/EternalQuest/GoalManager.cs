using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string input = "";
        while (input != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            if (input == "1") CreateGoal();
            else if (input == "2") ListGoalDetails();
            else if (input == "3") SaveGoals();
            else if (input == "4") LoadGoals();
            else if (input == "5") RecordEvent();
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 500) + 1;
        string rank;

        if (_score >= 5000) rank = "Eternal Legend";
        else if (_score >= 2500) rank = "Master Guardian";
        else if (_score >= 1000) rank = "Elite Adventurer";
        else if (_score >= 500) rank = "Apprentice";
        else rank = "Novice";

        Console.WriteLine("\n==================================================");
        Console.WriteLine($" SCORE: {_score} | LEVEL: {level} | RANK: {rank}");
        Console.WriteLine("==================================================");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1") _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == "2") _goals.Add(new EternalGoal(name, desc, points));
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            
            if (goal.IsComplete())
            {
                Console.WriteLine("This goal is already completed!");
                return;
            }

            goal.RecordEvent();

            string[] data = goal.GetStringRepresentation().Split(':');
            string[] fields = data[1].Split(',');
            int pointsEarned = int.Parse(fields[2]);

            if (goal is ChecklistGoal checklist && checklist.IsComplete())
            {
                pointsEarned += int.Parse(fields[3]);
                Console.WriteLine("BONUS ACHIEVED!");
            }

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName)) return;

        string[] lines = File.ReadAllLines(fileName);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal") _goals.Add(new SimpleGoal(data[0], data[1], data[2], bool.Parse(data[3])));
            else if (type == "EternalGoal") _goals.Add(new EternalGoal(data[0], data[1], data[2]));
            else if (type == "ChecklistGoal") _goals.Add(new ChecklistGoal(data[0], data[1], data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
        }
    }
}