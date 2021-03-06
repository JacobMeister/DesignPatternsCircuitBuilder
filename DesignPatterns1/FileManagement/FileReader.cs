﻿using System;
using System.Collections.Generic;
using System.IO;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.FileManagement
{
    class FileReader
    {
        private IOutputHandler output;
        public FileReader(IOutputHandler output)
        {
            this.output = output;
        }


        public List<String> GetLines(String pathString)
        {

            try
            {

                if (!pathString.Equals("") && File.Exists(pathString))
                {
                    output.Write("Path is: " + pathString);
                    if (pathString.ToLower().EndsWith(".txt"))
                    {
                        output.Write("Found the file!");
                        return GetFile(pathString);
                    }
                    else
                    {
                        output.Write("Filepath is not a .txt file");
                    }
                }
                else
                {
                    output.Write("File does not exist");
                }
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
            }

            return null;
        }

        private List<String> GetFile(String path)
        {
            if (path.ToLower().EndsWith(".txt"))
            {
                List<String> list = new List<String>();

                try
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        list.Add(line);
                    }

                }
                catch (IOException e)
                {
                    Console.Write(e.StackTrace);
                }

                return list;
            }
            else
            {
                output.Write("WARNING: File must have .txt extension!");
                return null;
            }
        }
    }
}
