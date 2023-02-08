using System;
using Testingproject;
using static Testingproject.GradeAddedDelegate;

namespace testingproject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DiskBook book = new DiskBook("Romeo and Juliet");
            // add the static method
            // right after instantiating the book
            // book.GradeAdded += AddedGradeEvent;
            book.AddGrade(12.5);
            System.Console.WriteLine(book.Name);

            // read from file
            book.ReadDisk();

        }

        // static method that will handle the event log on the 
        // console "Grade has been added"
        static void AddedGradeEvent(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade has been added");
        }
    }
}
