using System;

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
1. Implemented a Leveling System: The player's level is calculated dynamically based on total score (Score / 500).
2. Implemented a Ranking System: Custom ranks (Novice, Apprentice, Elite Adventurer, Master Guardian, Eternal Legend) 
   are assigned as the player hits specific score milestones.
3. Enhanced User Interface: Added visual separators and a dedicated header for score, level, and rank display.
*/

namespace EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}