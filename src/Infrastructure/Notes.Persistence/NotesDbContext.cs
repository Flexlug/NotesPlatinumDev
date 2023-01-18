using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Persistence;


public sealed class NotesDbContext : DbContext, INotesDbContext
{
    public DbSet<Note> Notes { get; set; }
    
    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }
}