using System;

namespace SemesterTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileSystem f = new FileSystem();
            Folder semesterTest = new Folder("Semester Test");
            semesterTest.Add(new File("socket_server", "py", 1024));
            semesterTest.Add(new File("socket_client", "py", 512));
            f.Add(semesterTest);

            Folder nothing = new Folder("Nothing");
            f.Add(nothing);

            File wireShark = new File("wiresharkCapture", "pcap", 464);
            File headerJSON = new File("header", "json", 16384);
            f.Add(wireShark);
            f.Add(headerJSON);  

            f.PrintContents();
        }
    }
}

