using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_library.User.Controller;
 
[Route("/hello")]
public class Controller : ControllerBase
{
    [Authorize]
    public ActionResult GetUser()
    {
        return  Ok("siema");
    }
}