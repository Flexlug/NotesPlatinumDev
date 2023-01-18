using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces;

public interface INotesDbContext
{
    /// <summary>
    /// Представляет собой коллекцию всех сущностей, которые можно запросить из БД
    /// </summary>
    DbSet<Note> Notes { get; set; }
    
    /// <summary>
    /// Дублируем сигнатуру из класса DbContext для удобства. Метод сохраняет изменения контекста БД
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}