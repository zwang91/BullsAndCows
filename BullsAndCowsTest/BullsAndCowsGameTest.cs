using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_digits_are_same_as_secret()
        {
            // when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var bullsAndCowsGame = new BullsAndCowsGame(mockSecretGenerator.Object);
            // given
            var guessResult = bullsAndCowsGame.Guess("1 2 3 4");
            // then
            Assert.Equal("4A0B", guessResult);
        }

        [Fact]
        public void Should_return_xA0B_when_guess_given_guess_digits_having_x_digits_are_same_as_secret()
        {
            // when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var bullsAndCowsGame = new BullsAndCowsGame(mockSecretGenerator.Object);
            // given
            var guessResult = bullsAndCowsGame.Guess("1 2 5 6");
            // then
            Assert.Equal("2A0B", guessResult);
        }
    }
}
