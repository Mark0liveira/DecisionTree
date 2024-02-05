using System;

namespace ContentManagementSystem.Services.Dtos;

public class ContentManagementDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}