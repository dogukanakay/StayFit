using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Users.UpdateUserPhoto
{
    public class UpdateUserPhotoCommandRequest : IRequest<UpdateUserPhotoCommandResponse>
    {
        public IFormFileCollection Files { get;}
        public Guid UserId { get;}
        public string BaseStorageUrl { get;}

        public UpdateUserPhotoCommandRequest(IFormFileCollection files, Guid userId, string baseStorageUrl)
        {
            Files = files;
            UserId = userId;
            BaseStorageUrl = baseStorageUrl;
        }
    }
}
