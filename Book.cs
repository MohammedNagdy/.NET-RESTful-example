using System;
using System.Collections.Generic;
using System.IO;

namespace Testingproject
{

    public interface ILibrary
    {
        void AddGrade(double grade);

        void ShowStats();
        string Name { get; }

        void SetName(string value);
    }

    
    public abstract class Library
    {
        public Library(string n) => Name = n;
        public abstract string Name 
        {
            get;
            set;
        }
        public abstract void AddGrade(double grade);

    }


    // save grade to disk class
    public class DiskBook : Library
    {
        public override string Name { get ; set ; }

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public void ReadDisk()
        {
            try
            {
                using(var sr = new StreamReader($"{Name}.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("This exception occured... "+e);
            }
        }
        public override void AddGrade(double grade)
        {
            using(TextWriter writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
            
        }

    }


    public class Book
    {
        
        public Book(string name)
        {
            this.name =name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
            System.Console.WriteLine(grade);
            // call the event
            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }

        }

        // define an event  the calls the GradeAddDelegate 
        public event GradeAddedDelegate.GradeAddDelegate GradeAdded;

        public void ShowStats()
        {
            double std = 0.0, sum=0.0, res = 0.0;
            
            foreach(double num in grades)
            {
                
                res += num;
            }
            double average = res/grades.Count;

            // calc std
            foreach(double n in grades)
            {
                sum += (n-average)/grades.Count;
            }
            std = Math.Sqrt(sum);
            System.Console.WriteLine($"This is the mean: {average}");
            System.Console.WriteLine($"This is the standard deviation: {std}");

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public List<double> grades = new List<double>();
        public string name;
        
        
    }

}