using GuessTheWord.Core;

namespace GuessTheWord.Tests;

public class GuessTheWordTests
{
    [Fact]
    public void Starts_a_new_game_with_the_word_completely_masked()
    {
        var game = new Game("timo");

        var toGuess = game.Word;

        Assert.Equal("****", toGuess);
    }

    [Fact]
    public void A_default_game_has_5_tries_by_default()
    {
        var game = new Game("timo");
        Assert.Equal(5, game.AmountOfTriesLeft);
    }
}
