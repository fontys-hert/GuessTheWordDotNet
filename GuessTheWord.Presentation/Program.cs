using GuessTheWord.Core;
using GuessTheWord.Presentation;

Cli.Print("Welkom bij Galgje!" + Environment.NewLine);
Cli.Print("Laat je scherm niet aan je tegenspeler zien! Ik zal even wachten...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("...");
string? word = null;
while (string.IsNullOrWhiteSpace(word))
{
    word = Cli.Input("Oke, Voer het woord in om raden: ");
    Cli.Print("Oke, dankje. Een momentje alsjeblieft...");
    Cli.Print("...");
    Cli.Print("...");
    Cli.Print("...");

    if (string.IsNullOrWhiteSpace(word)) Cli.Print("Ah sorry, dit woord lijkt leeg te zijn. Probeer het nog een keer!");
}

Console.Clear();
Cli.Print("Dit lijkt me een prima woord! Geef je laptop aan je medespeler. Ik wacht wel even...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("...");
Cli.Print("Ha medespeler! Welkom bij galgje!");
var game = new Game(word);

Cli.Print($"Het woord dat je medespeler heeft gemaakt ziet er zo uit: {game.Word}");
Cli.Print("Laten we met een eerste gokje beginnen!");

while (!game.IsGameOver)
{
    var guess = Cli.Input("Voer een letter in:");
    Cli.Print("");

    if (guess?.Length != 1)
    {
        Cli.Print("Ajj, ik kan niet zoveel met je invoer. Het mag echt maar 1 letter zijn. Probeer het nog een keer");
        continue;
    }

    var guessResult = game.Guess(guess.ToCharArray().First());

    switch (guessResult)
    {
        case GuessResult.Correct:
            Cli.Print($"Goed geraden, klasse!");
            break;
        case GuessResult.Incorrect:
            Cli.Print($"Helaas, deze letter zit niet in het woord :(. Je hebt nog {game.AmountOfTriesLeft} poging(en) over");
            break;
        case GuessResult.AlreadyGuessed:
        case GuessResult.AlreadyGuessedIncorrectly:
            Cli.Print("Deze letter heb je al een keer gebruikt. Geen paniek, er gebeurd niets met je pogingen die over zijn! Probeer het opnieuw");
            break;
    }

    if (!game.IsGameOver)
    {
        Cli.Print($"Dit is de tussenstand: {game.Word}");
    }
}

if(game.IsWon)
{
    Cli.Print($"Hoera! Je hebt gewonnen, proficiat!!! Het woord was natuurlijk {game.Word}");
} else
{
    Cli.Print("Helaas, je hebt verloren... Volgende keer beter!");
}

