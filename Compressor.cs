namespace TextCompressor;

/// <summary>
/// A class that holds functionality to convert strings between their RLE and regular representations.
/// </summary>
static class Compressor
{
    /// <summary>
    /// Compresses the specified string.
    /// </summary>
    public static string Compress(string s)
    {
        string output = "";

        char currentChar = s[0]; // We begin at the first char in the string
        int consecutiveCount = 1; // The number of consecutive identical characters is 1 initially

        // Loop through the whole string except position 0 (we've already done that)
        for (int i = 1; i < s.Length; i++)
        {
            char c = s[i];

            // If the new char is identical to the current char
            if (currentChar == c)
                // Increase the counter
                consecutiveCount++;
            // The new char isn't the same as the current one
            else
            {
                // Append the current char with its count to the output string
                output += consecutiveCount.ToString() + currentChar;

                // Reset the current char and counter variables
                currentChar = c;
                consecutiveCount = 1;
            }
        }

        // Append the last iteration's results
        output += consecutiveCount.ToString() + currentChar;

        return output;
    }

    /// <summary>
    /// Performs the inverse operation to the text compression above.
    /// </summary>
    public static string Uncompress(string s)
    {
        string output = "";
        int pointer = 0; // Points to an index in the input string

        char currentChar;
        int consecutiveCount;

        // Loop while the pointer hasn't reached the end of the string
        while (pointer < s.Length)
        {
            // Read the consecutive count of the current char (comes before the letter itself)
            consecutiveCount = GetNumber(s, ref pointer);

            // Read the char itself
            currentChar = s[pointer];
            pointer++;

            // This loop works the same as Enumerable.Repeat but I wrote it myself so hey
            for (int i = 0; i < consecutiveCount; i++)
                output += currentChar;
        }

        return output;
    }

    /// <summary>
    /// This method exists because I didn't want to use LINQ.
    /// Reads the entirety of an integer under the pointer from the input string.
    /// The ref allows me to have full access to the pointer's value from inside the method.
    /// </summary>
    static int GetNumber(string s, ref int pointer)
    {
        string numRaw = "";
        char c = s[pointer]; // Start at the pointer

        // Keep adding to the number string while the character under the pointer is numerical
        while (char.IsNumber(c))
        {
            numRaw += c;
            c = s[++pointer];
        }

        // Parse the number string to an integer before returning it
        return int.Parse(numRaw);
    }
}