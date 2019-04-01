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
            string line;
            var index = 0;
            foreach (string ext in _extensions)
            {
                var files = Directory.GetFiles(_currentDirectory, ext, SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    var streamReader = new StreamReader(file);
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!IsCommentOrEmpty(line))
                        {
                            lineCount++;
                        }
                        if ((index = line.IndexOf("/*")) != -1)
                        {
                          
                            bool isNewLine = false;
                            while ((index = line.IndexOf("*/")) == -1)
                            {
                                isNewLine = true;
                                line = streamReader.ReadLine();

                                if (line == null)
                                {
                                    break;
                                }
                            }
                            if (line != null && isNewLine && index < line.Length-2 && !IsCommentOrEmpty(line))
                            {
                                lineCount++;
                            }
                        }
                    }
                    streamReader.Close();
                }
            }
            return lineCount;
        }

        private bool IsCommentOrEmpty(string s)
        {
            return s.Equals("") || s.IndexOf("//") == 0 || s.IndexOf("/*") == 0;
        }

      
    }
}
