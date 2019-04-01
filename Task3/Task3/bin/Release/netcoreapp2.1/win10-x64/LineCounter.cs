using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task3
{
    class LineCounter
    {
        private readonly List<string> _extensions;
        private readonly string _currentDirectory;

        public LineCounter(string dir, string[] extensions)
        {
            this._currentDirectory = dir;
            this._extensions = extensions.ToList();
        }

        public long CountLines()
        {
            long lineCount = 0;
            foreach (string ext in _extensions)
            {
                var files = Directory.GetFiles(_currentDirectory, ext, SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    string[] lines = System.IO.File.ReadAllLines(file);
                    lineCount += CountLinesInArray(lines);
                }
            }
            return lineCount;
        }

        private long CountLinesInArray(string[] lines)
        {
            long count = 0;
            foreach (string s in lines)
            {
                if (!s.Equals("") && s.IndexOf("//") != 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
