using CloundStorage.Domain.Entity;
using CloundStorage.Domain.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundStorageTest.Infrastructure.Storage;
public class GoogleCloundStorageService : IStorageService {
    public string Upload(IFormFile file, User user) {
        var credentials = new UserCredential(null, user.Email, new TokenResponse {
            AccessToken = user.AccessToken,
            RefreshToken = user.RefreshToken
        });

        var service = new DriveService(new BaseClientService.Initializer());

        var driveFile = new Google.Apis.Drive.v3.Data.File {
            Name = file.Name,
            MimeType = file.ContentType,
        };

        var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
        command.Fields = "id";

        var response = command.Upload();
        if (response.Status is not UploadStatus.Completed or UploadStatus.NotStarted) {
            throw new Exception("");
        }

        return command.ResponseBody.Id;
    }
}
