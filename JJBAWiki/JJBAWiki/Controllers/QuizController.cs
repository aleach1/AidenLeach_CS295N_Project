using JJBAWiki.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JJBAWiki.Controllers
{
    public class QuizController : Controller
    {
        private readonly string _quizFilePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "triviadata.json");
        [HttpGet]
        public IActionResult Index()
        {
            // Read the JSON file and deserialize it to the list of QuestionModel
            var jsonString = System.IO.File.ReadAllText(_quizFilePath);
            var questionsFromJson = JsonSerializer.Deserialize<List<QuestionModel>>(jsonString);

            var viewModel = new QuizViewModel
            {
                Questions = questionsFromJson ?? new List<QuestionModel>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(QuizViewModel submittedViewModel)
        {
            // Re-load the original questions to ensure we have the correct answers
            var jsonString = System.IO.File.ReadAllText(_quizFilePath);
            var correctQuestions = JsonSerializer.Deserialize<List<QuestionModel>>(jsonString);

            // Update the UserAnswerIndex for the original questions with the submitted answers
            for (int i = 0; i < correctQuestions.Count; i++)
            {
                correctQuestions[i].UserAnswer = submittedViewModel.Questions[i].UserAnswer;
            }

            // Create a new ViewModel with the correct questions
            var viewModel = new QuizViewModel
            {
                Questions = correctQuestions
            };

            int score = viewModel.CalculateScore();
            ViewData["Score"] = score;
            ViewData["Checked"] = true;

            return View(viewModel);
        }
    }
}
