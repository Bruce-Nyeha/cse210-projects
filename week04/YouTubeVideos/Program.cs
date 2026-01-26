using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create 3-4 Video objects
        Video video1 = new Video("C# Basics", "Code Academy", 600);
        Video video2 = new Video("How to Bake Bread", "Chef Jane", 1200);
        Video video3 = new Video("Travel Vlog: Tokyo", "Globetrotter", 900);

        // 2. Add 3-4 comments to each video
        video1.AddComment(new Comments("User1", "Very helpful, thanks!"));
        video1.AddComment(new Comments("User2", "I love C#!"));
        video1.AddComment(new Comments("User3", "Can you explain Lists more?"));

        video2.AddComment(new Comments("Baker44", "Mine didn't rise, help!"));
        video2.AddComment(new Comments("Foodie", "Looks delicious."));
        video2.AddComment(new Comments("BreadLover", "Best tutorial ever."));

        video3.AddComment(new Comments("Explorer", "Tokyo is beautiful."));
        video3.AddComment(new Comments("VacayMode", "Adding this to my bucket list!"));
        video3.AddComment(new Comments("Jin", "I live here, great video!"));

        // 3. Put videos in a list
        List<Video> videosList = new List<Video> { video1, video2, video3 };

        // 4. Iterate and display
        foreach (Video video in videosList)
        {
            video.DisplayVideoInfo();
        }
    }
}
