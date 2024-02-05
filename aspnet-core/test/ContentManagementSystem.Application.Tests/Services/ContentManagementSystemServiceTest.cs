using System;
using System.Threading.Tasks;
using ContentManagementSystem.Application.Tests.Mocks;
using ContentManagementSystem.Entities;
using ContentManagementSystem.Services;
using ContentManagementSystem.Services.Dtos.@base;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Shouldly;
using Xunit;

namespace ContentManagementSystem.Application.Tests.Services
{
    public class ContentManagementSystemServiceTest
    {
        [Fact]
        public async Task ShouldRetrieveCMSById_WhenExistsOnDatabase()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.GetAsync(ContentManagementSystemMock.CmsId)
                .Returns(ContentManagementSystemMock.ContentManagement);
            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.GetCMSContentAsync(ContentManagementSystemMock.CmsId);
            
            res.IsSuccess.ShouldBeTrue();
            await mock.FakeRepo.Received(1).GetAsync(ContentManagementSystemMock.CmsId);
        }
        
        [Fact]
        public async Task ShouldThrowException_WhenRetrieveCMSById()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.GetAsync(ContentManagementSystemMock.CmsId).ThrowsAsync(new Exception());

            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.GetCMSContentAsync(ContentManagementSystemMock.CmsId);
            
            res.Error.Message.ShouldBe(ContentErrors.GetById.Message);
            await mock.FakeRepo.Received(1).GetAsync(ContentManagementSystemMock.CmsId);
        }
        
        [Fact]
        public async Task ShouldRetrieveAll_WhenExistsOnDatabase()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.GetListAsync().Returns(ContentManagementSystemMock.ContentManagements);
            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.GetAllAsync();
            
            res.IsSuccess.ShouldBeTrue();
            await mock.FakeRepo.Received(1).GetListAsync();
        }
        
        [Fact]
        public async Task ShouldThrowException_WhenGetListAsync()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.GetListAsync().ThrowsAsync(new Exception());
            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.GetAllAsync();
            
            res.Error.Message.ShouldBe(ContentErrors.GetAll.Message);
            await mock.FakeRepo.Received(1).GetListAsync();
        }
        
        [Fact]
        public async Task ShouldCreate_WhenValidModel()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.InsertAsync(ContentManagementSystemMock.ContentManagement)
                .Returns(ContentManagementSystemMock.ContentManagement);

            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.InsertOrUpdateCMSContentAsync(ContentManagementSystemMock.NewContentManagementDto);
            
            res.IsSuccess.ShouldBeTrue();
        }
        
        [Fact]
        public async Task ShouldThrowException_WhenCreate()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.InsertAsync(Arg.Any<ContentManagement>()).ThrowsAsync(new Exception());

            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.InsertOrUpdateCMSContentAsync(ContentManagementSystemMock.ContentManagementDto);
            
            res.Error.Message.ShouldBe(ContentErrors.PostOrUpdate.Message);
        }
        
        [Fact]
        public async Task ShouldUpdate_WhenValidModel()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.InsertAsync(ContentManagementSystemMock.ContentManagement)
                .Returns(ContentManagementSystemMock.ContentManagement);
            mock.FakeRepo.GetAsync(ContentManagementSystemMock.CmsId)
                .Returns(ContentManagementSystemMock.ContentManagement);

            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.InsertOrUpdateCMSContentAsync(ContentManagementSystemMock.ContentManagementDto);
            
            res.IsSuccess.ShouldBeTrue();
        }
        
        [Fact]
        public async Task ShouldThrowException_WhenUpdate()
        {
            var mock = new ContentManagementSystemMock();
            mock.FakeRepo.InsertAsync(ContentManagementSystemMock.ContentManagement)
                .Returns(ContentManagementSystemMock.ContentManagement);
            mock.FakeRepo.GetAsync(Arg.Any<Guid>()).ThrowsAsync(new Exception());

            var service = new ContentManagementService(mock.FakeLogger, mock.FakeRepo, mock.FakeMapper);

            var res = await service.InsertOrUpdateCMSContentAsync(ContentManagementSystemMock.ContentManagementDto);
            
            res.Error.Message.ShouldBe(ContentErrors.PostOrUpdate.Message);
        }
    }
}