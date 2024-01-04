namespace newInspire.Services;
public class ToDosService
{
    private readonly ToDosRepository _toDosRepository;

    public ToDosService(ToDosRepository toDosRepository)
    {
        _toDosRepository = toDosRepository;
    }
}