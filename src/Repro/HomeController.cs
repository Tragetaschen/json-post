using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Repro.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpPost("Post1")]
        public string Post_ModelBinding([FromBody] Model model)
        {
            return model.Name;
        }

        [HttpPost("Post2")]
        public async Task<IActionResult> Post_UpdateModel()
        {
            var model = new Model();
            if (!await TryUpdateModelAsync(model))
                return HttpBadRequest();
            return Content(model.Name);
        }
    }
}
