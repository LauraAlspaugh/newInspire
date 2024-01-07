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
    [Authorize]
    [HttpDelete("{toDoId}")]
    public async Task<ActionResult<string>> DestroyToDo(int toDoId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _toDosService.DestroyToDo(toDoId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{toDoId}")]
    public ActionResult<ToDo> GetToDoById(int toDoId)
    {
        try
        {
            ToDo toDo = _toDosService.GetToDoById(toDoId);
            return Ok(toDo);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }

    }
    [Authorize]
    [HttpPut("{toDoId}")]
    public async Task<ActionResult<ToDo>> UpdateToDo(int toDoId, [FromBody] ToDo toDoData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            ToDo toDo = _toDosService.UpdateToDo(toDoId, userInfo.Id, toDoData);
            return Ok(toDo);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}