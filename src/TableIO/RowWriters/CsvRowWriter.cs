﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TableIO.RowWriters
{
    public class CsvRowWriter : IRowWriter
    {
        public TextWriter TextWriter { get; }

        private static readonly Regex _escapeCharRegex = new Regex(",|\"|\\r|\\n", RegexOptions.Compiled);

        public CsvRowWriter(TextWriter textWriter)
        {
            TextWriter = textWriter;
        }

        public void Write(IList<object> row)
        {
            if (row.Count == 0)
            {
                TextWriter.WriteLine();
                return;
            }

            var sb = new StringBuilder();
            foreach (var field in row)
            {
                if (field == null)
                {
                    sb.Append(",");
                }
                else
                {
                    var val = (field as string) ?? $"{field}";
                    if (val != "")
                    {
                        if (_escapeCharRegex.IsMatch(val))
                            sb.Append($"\"{val.Replace("\"", "\"\"")}\",");
                        else
                            sb.Append($"{val},");
                    }
                    else
                    {
                        sb.Append(",");
                    }
                }
            }

            sb.Remove(sb.Length - 1, 1);

            TextWriter.WriteLine(sb.ToString());
        }
    }
}
