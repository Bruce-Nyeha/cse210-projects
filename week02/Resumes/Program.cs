using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");


        Job jobOffer = new Job();
        jobOffer._company = "Tesla";
        jobOffer._jobTitle = "Junior Backend Engineer";
        jobOffer._startYear = 2026;
        jobOffer._endYear = 2028;

        Job secondJob = new Job();
        secondJob._company = "Meta";
        secondJob._jobTitle = "Junior Fullstack Developer";
        secondJob._startYear = 2025;
        secondJob._endYear = 2029;

        jobOffer.Display();
        secondJob.Display();


        Resume myResume = new Resume();
        myResume._name = "Bruce Nyeha";
      
        myResume._jobs.Add(jobOffer);
        myResume._jobs.Add(secondJob);

    myResume.Display();
    }
}