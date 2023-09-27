using System;

namespace SemesterTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem();
            Folder semesterTest = new Folder("Semester Test");
            semesterTest.Add(new File("socket_server", "py", 1024));
            semesterTest.Add(new File("socket_client", "py", 512));
            fileSystem.Add(semesterTest);

            Folder nothing = new Folder("Nothing");
            fileSystem.Add(nothing);
            
            File wireShark = new File("wiresharkCapture", "pcap", 464);
            File headerJSON = new File("header", "json", 16384);
            fileSystem.Add(wireShark);
            fileSystem.Add(headerJSON);  

            fileSystem.PrintContents();
        }
    }
}

