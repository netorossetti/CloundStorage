using CloundStorage.Domain.Entity;
using CloundStorage.Domain.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundStorageTest.Infrastructure.Storage;
internal class CloundFlareStorageService : IStorageService {
    public string Upload(IFormFile file, User user) {
        throw new NotImplementedException();
    }
}
