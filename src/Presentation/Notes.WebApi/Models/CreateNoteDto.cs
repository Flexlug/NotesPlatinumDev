using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebApi.Models;

public class CreateNoteDto : IMapWith<CreateNoteDto>
{
    public string Title { get; set; }
    public string Details { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateNoteDto, CreateNoteCommand>();
    }
}