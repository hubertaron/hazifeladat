using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string eleresiUt = @"D:\husi\"; 
        string kiterjesztes = ".txt"; // a keresett fájlkiterjesztés

        DateTime creationDate = new DateTime(2023, 5, 3); // a keresett létrehozási dátum (év, hónap, nap)

        string[] files = Directory.GetFiles(eleresiUt, "*" + kiterjesztes, SearchOption.AllDirectories);

        using (StreamWriter writer = new StreamWriter("files.txt"))
        {
            foreach (string file in files)
            {
                DateTime fileCreationDate = File.GetCreationTime(file);
                if (fileCreationDate >= creationDate)
                {
                    writer.WriteLine("{0}; {1}", Path.GetFileName(file), fileCreationDate);
                }
            }
        }
    }
}