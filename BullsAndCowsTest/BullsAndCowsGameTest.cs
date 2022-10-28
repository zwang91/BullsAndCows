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

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "7 2 3 6")]
        [InlineData("1 2 3 4", "5 6 3 4")]
        public void Should_return_xA0B_when_guess_given_guess_digits_having_x_digits_are_same_as_secret(
            string secretDigits, string guessDigits)
        {
            // when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secretDigits);
            var bullsAndCowsGame = new BullsAndCowsGame(mockSecretGenerator.Object);
            // given
            var guessResult = bullsAndCowsGame.Guess(guessDigits);
            // then
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 3 5 6")]
        [InlineData("0 1 5 6", "2 1 3 5")]
        [InlineData("0 1 3 6", "2 6 3 5")]
        public void Should_return_1A1B_when_guess_given_guess_having_1_digit_bull_and_1_digit_cow(
            string secretDigits, string guessDigits)
        {
            // when
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secretDigits);
            var bullsAndCowsGame = new BullsAndCowsGame(mockSecretGenerator.Object);
            // given
            var guessResult = bullsAndCowsGame.Guess(guessDigits);
            // then
            Assert.Equal("1A1B", guessResult);
        }
    }
}
