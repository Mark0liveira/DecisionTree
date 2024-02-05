using System;
using System.Threading.Tasks;
using ContentManagementSystem.Services;
using ContentManagementSystem.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace ContentManagementSystem.Controllers;

[Route("/api/content-manager")]
public class ContentManagementController : AbpController
{
    private readonly ContentManagementService _service;

    public ContentManagementController(ContentManagementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var content = await _service.GetAllAsync();
        return content.IsSuccess ? Ok(content.Value) : BadRequest(content.Error);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCMSContent(Guid id)
    {
        var content = await _service.GetCMSContentAsync(id);
        return content.IsSuccess ? Ok(content.Value) : BadRequest(content.Error);
    }

    [HttpPost]
    public async Task<ActionResult> InsertOrUpdateCMSContent([FromBody] ContentManagementDto model)
    {
        var content = await _service.InsertOrUpdateCMSContentAsync(model);
        return content.IsSuccess ? Ok(content.Value) : BadRequest(content.Error);
    }
}