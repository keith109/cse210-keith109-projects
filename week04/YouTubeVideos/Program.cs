using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Introduction to C#", "John Smith", 600);
        video1.AddComment(new Comment("Alice", "Great explanation, thanks!"));
        video1.AddComment(new Comment("Bob", "This was very helpful for my homework."));
        video1.AddComment(new Comment("Charlie", "Can you make a video about Loops?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Abstraction in OOP", "Software Daily", 450);
        video2.AddComment(new Comment("Dave", "I finally understand classes."));
        video2.AddComment(new Comment("Eve", "Best tutorial on the channel."));
        video2.AddComment(new Comment("Frank", "Short and clear."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Programming Tips", "Code Master", 900);
        video3.AddComment(new Comment("Grace", "Tip number 5 changed my life."));
        video3.AddComment(new Comment("Heidi", "Love your content! Keep it up."));
        video3.AddComment(new Comment("Ivan", "Awesome tips for beginners."));
        videos.Add(video3);

        // Displaying the information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }
            Console.WriteLine("---------------------------------------");
        }
    }
}