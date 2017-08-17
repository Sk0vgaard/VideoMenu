using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;

namespace VideoMenu
{
    class Program
    {
        static List<Video> videos = new List<Video>();
        static int id = 1;

        static void Main(string[] args)
        {
            var video1 = new Video
            {
                Id = id++,
                Title = "Tarzan",
                Genre = "Eventyr",
                Year = 2016
            };
            videos.Add(video1);

            videos.Add(new Video()
            {
                Id = id++,
                Title = "Baby",
                Genre = "Drama",
                Year = 2018
            });

            //Console.WriteLine($"Name: {video1.Title}\nGenre: {video1.Genre}\n");

            string[] menuItems =
            {
                // play, chapter, 
                "List of videos",
                "Search", //Search the movies
                "Add a video",
                "Edit a video",
                "Delete a video", //Cru(d)
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ListOfVideos();
                        break;
                    case 2:
                        FindVideoById();
                        break;
                    case 3:
                        AddVideo(); //Adds a video.
                        break;
                    case 4:
                        EditVideo();
                        break;
                    case 5:
                        DeleteVideo(); //Deleting a video.
                        break;
                    default:
                        break;
                }
                Console.WriteLine("-------------------------------------------");
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Exiting...");
            Console.ReadLine();
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            Console.WriteLine($"Video name: ");
            video.Title = Console.ReadLine();
            Console.WriteLine($"Genre name: ");
            video.Genre = Console.ReadLine();
            Console.WriteLine($"Year of video: ");
            video.Year = Int32.Parse(Console.ReadLine());
        }

        private static Video FindVideoById()
        {
            Console.WriteLine("Insert video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number...");
            }

            foreach (var video in videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();

            if (videoFound != null)
            {
                videos.Remove(videoFound);
            }
        }

        private static void AddVideo()
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var genre = Console.ReadLine();

            Console.WriteLine("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            videos.Add(new Video()
            {
                Id = id++,
                Title = title,
                Genre = genre,
                Year = year
            });
        }

        private static void ListOfVideos()
        {
            Console.WriteLine("\nList of videos:\n");
            foreach (var video in videos)
            {
                Console.WriteLine(
                    $"Id: {video.Id}\nTitle of video: {video.Title}\nGenre: {video.Genre}\nYear: {video.Year}\n");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Chose a option...\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6)
            {
                Console.WriteLine("Please select a number between 1-6...");
            }
            Console.WriteLine($"You have selected option: {selection}");
            return selection;
        }
    }
}