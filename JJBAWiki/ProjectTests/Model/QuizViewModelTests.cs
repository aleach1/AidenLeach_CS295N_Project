using Xunit;
using JJBAWiki.Models;


namespace ProjectTests.Model
{
    public class QuizViewModelTests
    {
        [Fact]
        public void WrongAnswersIdentifiedTest()
        {
            // Arrange
            var viewModel = new QuizViewModel
            {
                Questions = new List<QuestionModel>
                {
                    new QuestionModel { Text = "What is 2+2?", Answers = new List<string> { "3", "4", "5" }, CorrectAnswer = 1, UserAnswer = 0 }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.False(viewModel.Questions[0].IsCorrect);
        }

        [Fact]
        public void RightAnswersIdentifiedTest()
        {
            // Arrange
            var viewModel = new QuizViewModel
            {
                Questions = new List<QuestionModel>
                {
                    new QuestionModel { Text = "What is 2+2?", Answers = new List<string> { "3", "4", "5" }, CorrectAnswer = 1, UserAnswer = 1 }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.True(viewModel.Questions[0].IsCorrect);
        }

        [Fact]
        public void AnswerOutOfBoundsTest()
        {
            // Arrange
            var viewModel = new QuizViewModel
            {
                Questions = new List<QuestionModel>
                {
                    new QuestionModel { Text = "What is 2+2?", Answers = new List<string> { "3", "4", "5" }, CorrectAnswer = 1, UserAnswer = 3 }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.False(viewModel.Questions[0].IsCorrect);
        }

        [Fact]
        public void NoAnswerProvidedTest()
        {
            // Arrange
            var viewModel = new QuizViewModel
            {
                Questions = new List<QuestionModel>
                {
                    new QuestionModel { Text = "What is 2+2?", Answers = new List<string> { "3", "4", "5" }, CorrectAnswer = 1, UserAnswer = -1 }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.False(viewModel.Questions[0].IsCorrect);
        }
    }
}
