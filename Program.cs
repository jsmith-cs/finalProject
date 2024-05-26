using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace NameSort
{
    class Name
    {
        public Name(string fname, string lname)
        {
            this.firstName = fname;
            this.lastName = lname;
        }
        
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    class Program
    {
        static void Main (string [] args)
        {
            List<Name> Names = new List<Name>();

            using (StreamReader sr = new StreamReader ("names.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] s = sr.ReadLine().Split(' ');
                    Names.Add(new Name(s[0], s[1]));
                }
            }

            Console.WriteLine("Sorting...");

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Name> sortedNames = Names.OrderBy(s => s.lastName).ThenBy(s => s.firstName).ToList();
            stopwatch.Stop();
            Console.WriteLine ("Code took {0} milliseconds to execute", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Press Return to exit");
            Console.ReadLine();            
        }
    }
}