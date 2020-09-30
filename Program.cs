﻿using System;
using NLog.Web;
using System.IO;

namespace ServiceTickets_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
           using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace MovieLibrary
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
             string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.csv";
         string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.csv";
            logger.Info("Program started");

            // Movie movie = new Movie
            // {
            //     movieId = 1,
            //     title = "Jeff's Killer Movie (2019)",
            //     genres = new List<string> { "Action", "Romance", "Comedy" }
            // };
            // Console.WriteLine(movie.Display());
            TicketFile ticketFile = new TicketFile(ticketFilePath);
            string choice = "";
            do
            {
                // display choices to user
                Console.WriteLine("1) Add Movie");
                Console.WriteLine("2) Display All Movies");
                Console.WriteLine("Enter to quit");
                // input selection
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);

                
                if (choice == "1")
                {
                    // Add movie
                       Movie movie = new Movie();
                    // ask user to input movie title
                    Console.WriteLine("Enter movie title");
                    // input title
                    movie.title = Console.ReadLine();
                    // verify title is unique
                    if (movieFile.isUniqueTitle(movie.title)){
                          // input genres
                        string input;
                        do
                        {
                            // ask user to enter genre
                            Console.WriteLine("Enter genre (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                movie.genres.Add(input);
                            }
                        } while (input != "done");
                        // specify if no genres are entered
                        if (movie.genres.Count == 0)
                        {
                            movie.genres.Add("(no genres listed)");
                        }
                         // add movie
                        movieFile.AddMovie(movie);
                    }
                } else if (choice == "2")
                {
                    // Display All Movies
                    foreach(Movie m in movieFile.Movies)
                    {
                        Console.WriteLine(m.Display());
                    }
                }
            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
        }
    }
}
