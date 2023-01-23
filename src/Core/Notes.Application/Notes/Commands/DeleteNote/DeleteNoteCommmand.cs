using MediatR;

namespace Notes.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommmand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}