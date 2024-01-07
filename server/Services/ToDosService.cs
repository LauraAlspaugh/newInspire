


namespace newInspire.Services;
public class ToDosService
{
    private readonly ToDosRepository _toDosRepository;

    public ToDosService(ToDosRepository toDosRepository)
    {
        _toDosRepository = toDosRepository;
    }

    internal ToDo CreateToDo(ToDo toDoData)
    {
        ToDo toDo = _toDosRepository.CreateToDo(toDoData);
        return toDo;
    }

    internal string DestroyToDo(int toDoId, string userId)
    {
        ToDo toDo = GetToDoById(toDoId);
        if (toDo.CreatorId != userId)
        {
            throw new Exception("Not your todo to destroy!");
        }
        _toDosRepository.DestroyToDo(toDoId);
        return "It really is gone!";
    }

    internal ToDo GetToDoById(int toDoId)
    {
        ToDo toDo = _toDosRepository.GetToDoById(toDoId);
        return toDo;
    }

    internal List<ToDo> GetToDos()
    {
        List<ToDo> toDos = _toDosRepository.GetToDos();
        return toDos;
    }

    internal ToDo UpdateToDo(int toDoId, string id, ToDo toDoData)
    {
        ToDo toDo = GetToDoById(toDoId);
        if (toDo.CreatorId != id)
        {
            throw new Exception("Not your todo to update!");
        }
        toDo.Completed = toDoData.Completed ?? toDo.Completed;
        _toDosRepository.UpdateToDo(toDo);
        return toDo;
    }
}