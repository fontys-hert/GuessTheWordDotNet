namespace GuessTheWord.Presentation;

public static class Cli
{
    public static void Print(string message)
    {
        Console.WriteLine(message);
        Thread.Sleep(1000);
    }

    public static string? Input(string message)
    {
        Console.WriteLine(message);
        var input = Console.ReadLine();
        Thread.Sleep(1000);
        return input;
    }
}
