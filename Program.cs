namespace TextCompressor;

// Run this from anywhere that has dotnet installed
// .NET version: 8.0

internal class Program
{
    static void Main(string[] args)
    {
        // Get the input from the console
        Console.Write("Input: ");
        string input = Console.ReadLine();

        // Split the input to the command ("Z" -> compress/"R" -> uncompress) and the parameter
        string[] slice = input.Split(' ');

        if (slice.Length < 2)
        {
            Console.WriteLine("Syntax error.");
            return;
        }

        string command = slice[0];
        string parameter = slice[1];

        // Perform the correct command on the parameter
        string output = command switch
        {
            "Z" => Compressor.Compress(parameter),
            "R" => Compressor.Uncompress(parameter),
            _ => "Unknown command.",
        };

        // Write the output into the console
        Console.WriteLine(output);
    }
}
