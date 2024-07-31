using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RateYourFriends.Controllers;

[Authorize]
public class QuestionController : Controller
{
    private readonly ILogger<QuestionController> _logger;

    public QuestionController(ILogger<QuestionController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        _logger.LogDebug("Mensaje");
        return View();
    }

    [HttpPost]
    public IActionResult Index(QuestionInputModel model)
    {
        _logger.LogDebug("{} - {}", model.Question, model.ParticipantIds);
        return RedirectToAction("Question", 1);
    }

    // Get
    [Route("/question/{id}")]
    public IActionResult Question(int id)
    {
        return View();
    }


    public class QuestionInputModel
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public required string Question { get; set; }

        [Required]
        public List<long>? ParticipantIds { get; set; }
    }
}