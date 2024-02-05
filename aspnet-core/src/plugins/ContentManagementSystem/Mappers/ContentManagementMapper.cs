using System.Collections.Generic;
using System.Linq;
using ContentManagementSystem.Entities;
using ContentManagementSystem.Services.Dtos;

namespace ContentManagementSystem.Mappers;

internal static class ContentManagementMapper
{
    internal static List<ContentManagementDto> MapToDto(this List<ContentManagement> entities)
    {
        return entities.Select(MapToDto).ToList();
    }
    
    internal static List<ContentManagement> MapToEntity(this List<ContentManagementDto> models)
    {
        return models.Select(MapToEntity).ToList();
    }
    
    internal static ContentManagementDto MapToDto(this ContentManagement entity)
    {
        return new ContentManagementDto
        {
            Id = entity.Id,
            Content = entity.Content,
            Title = entity.Title
        };
    }
    
    internal static ContentManagement MapToEntity(this ContentManagementDto model)
    {
        return new ContentManagement
        {
            Content = model.Content,
            Title = model.Title
        };
    }
}