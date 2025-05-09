using System;
using System.Collections.Generic;

namespace DLL {
        
    public static class StringUtils
    {
        public static string getCenteredValue(string value, int maxLen, char spacer){
            if (value.Length >= maxLen)
                return value;

            int spacing = maxLen - value.Length;
            int padLeft = spacing / 2;
            int padRight = spacing - padLeft;

            return new string(spacer, padLeft) + value + new string(spacer, padRight);
        }

        public static string Boxed(string input)
        {
            // Split the input into lines
            string[] lines = input.Split('\n');

            // Find the maximum line length
            int maxLength = 0;
            foreach (string line in lines)
            {
                int lineLength = line.Replace("\r", "").Length; // Handle \r\n as well
                if (lineLength > maxLength)
                    maxLength = lineLength;
            }

            // Build the top border
            string top = $"┌{new string('─', maxLength + 2)}┐";

            // Build each line with padding
            var boxedLines = new List<string> { top };
            foreach (string line in lines)
            {
                string cleanLine = line.Replace("\r", "");
                string paddedLine = cleanLine.PadRight(maxLength);
                boxedLines.Add($"│ {paddedLine} │");
            }
            // Build the bottom border
            string bottom = $"└{new string('─', maxLength + 2)}┘";
            boxedLines.Add(bottom);

            // Join all lines
            return string.Join("\n", boxedLines);
        }
    }
}
