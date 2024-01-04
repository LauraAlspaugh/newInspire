namespace newInspire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDosController : ControllerBase
{
    private readonly ToDosService _toDosService;
    private readonly Auth0Provider _auth0Provider;

    public ToDosController(ToDosService toDosService, Auth0Provider auth0Provider)
    {
        _toDosService = toDosService;
        _auth0Provider = auth0Provider;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ToDo>> CreateToDo([FromBody] ToDo toDoData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            toDoData.CreatorId = userInfo.Id;
            ToDo toDo = _toDosService.CreateToDo(toDoData);
            return Ok(toDo);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<ToDo>> GetToDos()
    {
        try
        {
            List<ToDo> toDos = _toDosService.GetToDos();
            return Ok(toDos);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}