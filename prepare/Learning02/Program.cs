using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Z Modern", "Business Analyst", 2021, 2023);
        Job job2 = new Job("Kunene Consulting", "Founder and CEO", 2022, 2023);

        // Display the jobs
        job1.Display();
        job2.Display();

        Resume myResume = new Resume("Nokwazi P Kunene");
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display the resume
        myResume.Display();
    }
}
