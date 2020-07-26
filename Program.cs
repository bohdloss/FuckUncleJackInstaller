using System;
using System.IO;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2) Console.WriteLine("Invalid arguments");

            StringBuffer buf = new StringBuffer(args);

            while(true)
            {
                String operation = buf.get();
                Console.WriteLine("Operation: "+operation);
                if(operation.Equals("folder"))
                {
                    string p = path(buf);

                    Console.WriteLine("Creating folder");

                    Directory.CreateDirectory(p);

                } else if(operation.Equals("file"))
                {

                    Console.WriteLine("Creating file");

                    string p = path(buf);

                    File.Create(p).Close();

                    string next = buf.get();

                    if(next.Equals("/endfile\\"))
                    {
                        Console.WriteLine("Detected end of file command");
                    } else if(next.Equals("/copyfile\\"))
                    {

                        Console.WriteLine("Detected additional copyfile argument");

                        string p2 = path(buf);

                        Console.WriteLine("Reading bytes from "+p2);

                        byte[] bytes = File.ReadAllBytes(p2);

                        Console.WriteLine("Writing bytes to new file " + p);

                        File.WriteAllBytes(p, bytes);

                    }

                } else if(operation.Equals("/endprogram\\"))
                {
                    break;
                } else if(operation.Equals("delete"))
                {
                    string p = path(buf);

                    Console.WriteLine("Recursively deleting every file");

                    Directory.Delete(p, true);

                }
            }
        }

        public static string path(StringBuffer buf)
        {
            String path = "";

            String current = "";

            while (!(current = buf.get()).Equals("/endpath\\"))
            {
                path = path + current + " ";
            }
            path = path.Trim();
            Console.WriteLine("Path found: " + path);
            return path;
        }
    }
}
