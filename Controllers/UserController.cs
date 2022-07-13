using Dissertation.Context;
using Dissertation.Models;
using Dissertation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dissertation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IScoreService _scoreService;
        private readonly IAnswerService _answerService;
        public UserController(ITestService testService, IQuestionService questionService, IScoreService scoreService, IAnswerService answerService)
        {
            _testService = testService;
            _questionService = questionService;
            _scoreService = scoreService;
            _answerService = answerService;
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("Students")]
        [Authorize(Roles = "Student")]
        public IActionResult StudentsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("Tests")]
        [Authorize(Roles = "Student,Administrator")]
        public IActionResult TestsEndpoint()
        {
            var currentUser = GetCurrentUser();
            var tests = _testService.GetAllTests(); 


            return Ok(tests);
        }

        [HttpPost("Answer")]
        [Authorize(Roles = "Student,Administrator")]
        public IActionResult AnswerEndpoint([FromBody] Answers answers)
        {
            var result = _answerService.CalculateAnswer(answers, answers.UserId);
            return Ok($"Congratulations, you got {result} correct!");
        }

        [HttpGet("Questions")]
        [Authorize(Roles = "Student,Administrator")]
        public IActionResult QuestionsEndpoint()
        {
            var currentUser = GetCurrentUser();
            var questions = _questionService.GetAllQuestions();

            return Ok(questions);
        }

        [HttpGet("Testresults")]
        [Authorize(Roles = "Administrator")]
        public IActionResult TestresultsEndpoint()
        {
            var currentUser = GetCurrentUser();
            var scores = _scoreService.GetAllScores();

            return Ok(scores);
        }

        [HttpGet("Modules")]
        [Authorize(Roles = "Student,Administrator")]
        public IActionResult ModulesEndpoint()
        {
            return Ok("Module 1: lorem ipsum. Access /questions and then /answers to complete the test(s) for this module.");
        }

        [HttpGet("AdminsAndStudents")]
        [Authorize(Roles = "Administrator,Student")]
        public IActionResult AdminsAndStudentsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("This is a public page");

        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value

            };
            }
            return null;

        }
    }
}
