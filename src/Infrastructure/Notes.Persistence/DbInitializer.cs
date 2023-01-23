namespace Notes.Persistence;

public class DbInitializer
{
    public static void Initialize(NotesDbContext context)
    {
        // Убеждаемся в том, что БД создана
        // Если нет - создадим её на основе контекста
        context.Database.EnsureCreated();
    }
}