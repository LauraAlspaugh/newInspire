

namespace newInspire.Repositories;
public class ToDosRepository
{
    private readonly IDbConnection _db;

    public ToDosRepository(IDbConnection db)
    {
        _db = db;
    }

    internal ToDo CreateToDo(ToDo toDoData)
    {
        string sql = @"
    INSERT INTO 
    todos(description, completed, creatorId )
    VALUES(@Description, @Completed, @CreatorId);
    SELECT 
    td.*,
    acc.*
    FROM todos td
    JOIN accounts acc ON td.creatorId = acc.id
    WHERE td.id = LAST_INSERT_ID();
    ";
        ToDo toDo = _db.Query<ToDo, Account, ToDo>(sql, (todo, account) =>
        {
            todo.Creator = account;
            return todo;
        }, toDoData).FirstOrDefault();
        return toDo;
    }

    internal List<ToDo> GetToDos()
    {
        string sql = @"
    SELECT 
    td.*,
    acc.*
    FROM todos td
    JOIN accounts acc ON td.creatorId = acc.id
    ";
        List<ToDo> toDos = _db.Query<ToDo, Account, ToDo>(sql, (todo, account) =>
        {
            todo.Creator = account;
            return todo;
        }).ToList();
        return toDos;
    }
}