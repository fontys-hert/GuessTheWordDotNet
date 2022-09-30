namespace GuessTheWord.Core;

public class Game
{
    private readonly string _wordToGuess;
    private readonly List<char> _lettersGuessed;
    private readonly List<char> _lettersIncorrect;

    public string Word { get; private set; }
    public int AmountOfTriesLeft { get; private set; }
    public bool IsGameOver => AmountOfTriesLeft == 0 || IsWon;
    public bool IsWon => !Word.Contains('*');
    public bool IsLost => IsGameOver && !IsWon;

    public Game(string wordToGuess, int amountOfTries = 5)
    {
        if (string.IsNullOrWhiteSpace(wordToGuess)) throw new InvalidOperationException("Insert a proper word!");
        _wordToGuess = wordToGuess.ToLower();
        _lettersGuessed = new List<char>();
        _lettersIncorrect = new List<char>();
        Word = CreateMaskedWord();
        AmountOfTriesLeft = amountOfTries;
    }

    private string CreateMaskedWord()
    {
        string word = "";

        foreach (var letter in _wordToGuess)
        {
            if (_lettersGuessed.Contains(letter))
            {
                word += letter;
            }
            else
            {
                word += "*";
            }
        }

        return word;
    }

    public GuessResult Guess(char guessedLetter)
    {
        if (IsGameOver) throw new InvalidOperationException("You cannot guess again when the game is over!");

        if (_wordToGuess.Contains(guessedLetter))
        {
            if (!_lettersGuessed.Contains(guessedLetter)) _lettersGuessed.Add(guessedLetter);
            else return GuessResult.AlreadyGuessed;
            Word = CreateMaskedWord();
            return GuessResult.Correct;
        }

        if (!_lettersIncorrect.Contains(guessedLetter))
        {
            _lettersIncorrect.Add(guessedLetter);
            AmountOfTriesLeft -= 1;
            return GuessResult.Incorrect;
        } else
        {
            return GuessResult.AlreadyGuessedIncorrectly;
        }
    }
}
