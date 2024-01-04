

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

    internal List<ToDo> GetToDos()
    {
        List<ToDo> toDos = _toDosRepository.GetToDos();
        return toDos;
    }
}