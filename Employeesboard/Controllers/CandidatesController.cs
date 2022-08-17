using Employeesboard.Shared.Candidates;
using Microsoft.AspNetCore.Mvc;

namespace Employeesboard.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidatesFinder _candidatesFinder;

        public CandidatesController(ICandidatesFinder candidatesFinder)
        {
            _candidatesFinder = candidatesFinder;
        }

        public async Task<IActionResult> Index()
        {
            var candidates = await _candidatesFinder.GetAll();
            return View(candidates);
        }
    }
}
