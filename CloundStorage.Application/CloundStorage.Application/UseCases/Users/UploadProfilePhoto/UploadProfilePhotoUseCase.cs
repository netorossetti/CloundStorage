using CloundStorage.Domain.Entity;
using CloundStorage.Domain.Storage;
using FileTypeChecker;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CloundStorage.Application.UseCases.Users.UploadProfilePhoto;
public class UploadProfilePhotoUseCase {

    private readonly IStorageService _storageService;

    public UploadProfilePhotoUseCase(IStorageService storageService){
        _storageService = storageService;
    }

    public void Execute(IFormFile file) {
        var fileStream = file.OpenReadStream();
        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();
        if(isImage == false) {
            throw new Exception("O arquivo não é uma imagem.");
        }

        var user = GetUser();
        _storageService.Upload(file, user);
    }

    private User GetUser() {
        return new User() {
            Id = 1,
            Name = "Florio",
            Email = "netinho.rossetti@gmail.com"
        };
    }
}
