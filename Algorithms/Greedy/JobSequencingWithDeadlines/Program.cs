using System;
using System.Collections;

namespace JobSequencingWithDeadlines
{
    public class Job
    {
        public string Id { get; set; }
        public int Profit { get; set; }
        public int Deadline { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Job[] jobs = new Job[]
            {
                new Job{ Id ="J1", Profit=5,  Deadline=3 },
                new Job{ Id ="J2", Profit=10, Deadline=1 },
                new Job{ Id ="J3", Profit=20, Deadline=2 },
                new Job{ Id ="J4", Profit=15, Deadline=2 },
                new Job{ Id ="J5", Profit=1,  Deadline=3 },
            };

            var sortedJobs = jobs.OrderByDescending((j) => j.Profit).ToArray();

            PrintJobs(sortedJobs);

            int maxDeadline = sortedJobs.Max(j => j.Deadline);
            string[] result = new string[maxDeadline + 1];
            int totalProfit = 0; //solution

            foreach (var job in sortedJobs)
            {
                for (int slot = job.Deadline; slot >= 1; slot--)
                {
                    if (result[slot] == null)
                    {
                        result[slot] = job.Id;
                        totalProfit += job.Profit;
                        break;
                    }
                }
            }

            Console.WriteLine($"Solution: {totalProfit}");
        }

        public static void PrintJobs(Job[] jobs)
        {
            foreach (var job in jobs)
            {
                Console.WriteLine($"{job.Id} - Profit: {job.Profit} - Deadline: {job.Deadline}");
            }
        }
    }
}