namespace newInspire.Repositories;
public class ToDosRepository
{
    private readonly IDbConnection _db;

    public ToDosRepository(IDbConnection db)
    {
        _db = db;
    }
}