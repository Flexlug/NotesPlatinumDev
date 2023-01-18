using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration;

// Класс, реализующий IEntityTypeConfiguration<T>, который позволяет разделять конфигурацию для типа сущностей в
// отдельный класс, а не в методе OnModelCreating.
// Никто не мешает описывать всю конфигурацию в OnModelCreating, но это сделано для сокращения объема кода, который
// будет в OnModelCreating. Также это позволяет сделать концептуальное разделение
public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        // Зададим ключ
        builder.HasKey(note => note.Id);
        
        // Скажем, что ключ уникален
        builder.HasIndex(note => note.Id).IsUnique();
        
        // Задаим ограничение надлину заголовка
        builder.Property(note => note.Title).HasMaxLength(250);
    }
}