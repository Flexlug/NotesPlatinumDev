using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class NoteDetailsVm : IMapWith<Note>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Datails { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteDetailsVm>();
    }
}