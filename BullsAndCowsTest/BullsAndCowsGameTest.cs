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
        public void Should_return_4A0B_when_guess_given_guess_all_corrects()
        {
            //Given
            string secretNumber = "1234";
            string guessNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("4A0B", result);
        }

        [Fact]
        public void Should_return_0A0B_when_guess_given_guess_all_incorrect()
        {
            //Given
            string secretNumber = "1234";
            string guessNumber = "5678";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("0A0B", result);
        }

        //Invalid length input
        //Invalid digit input
        //Duplicate digit input
    }
}
