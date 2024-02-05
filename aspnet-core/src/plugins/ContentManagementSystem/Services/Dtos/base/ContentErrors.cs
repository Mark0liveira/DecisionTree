namespace ContentManagementSystem.Services.Dtos.@base;

public static class ContentErrors
{
    public static readonly Error GetAll =  new("ContentManagement.GetAll",
        "Something inexplicable happened when searching for content.");
 
    public static readonly Error GetById =  new("ContentManagement.GetById",
        "Something inexplicable happened when searching for content informed.");
    
    public static readonly Error PostOrUpdate =  new("ContentManagement.PostOrUpdate",
        "Something inexplicable happened when create or update the content.");
}