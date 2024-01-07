




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

    internal void DestroyToDo(int toDoId)
    {
        string sql = @"
DELETE FROM todos WHERE id = @toDoId LIMIT 1;
SELECT td.*,
    acc.*
    FROM todos td
    JOIN accounts acc ON td.creatorId = acc.id
    Where td.id = @toDoId;
";
        _db.Execute(sql, new { toDoId });
    }

    internal ToDo GetToDoById(int toDoId)
    {
        string sql = @"
    SELECT td.*,
    acc.*
    FROM todos td
    JOIN accounts acc ON td.creatorId = acc.id
    Where td.id = @toDoId;
    ";
        ToDo toDo = _db.Query<ToDo, Account, ToDo>(sql, (todo, account) =>
        {
            todo.Creator = account;
            return todo;
        }, new { toDoId }).FirstOrDefault();
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

    internal ToDo UpdateToDo(ToDo toDo)
    {
        string sql = @"
        UPDATE todos
        SET 
        completed = @Completed
        WHERE id = @Id;

        SELECT 
        td.*,
        acc.*
        FROM todos td
        JOIN accounts acc ON td.creatorId = acc.id
        WHERE td.id = @Id;
        ";

        ToDo newToDo = _db.Query<ToDo, Account, ToDo>(sql, (todo, account) =>
        {
            todo.Creator = account;
            return todo;
        }, toDo).FirstOrDefault();
        return newToDo;
    }
}