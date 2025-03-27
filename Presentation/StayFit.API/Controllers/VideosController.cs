using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.DTOs.Videos;
using StayFit.Application.Features.Commands.Videos.CreateVideo;
using StayFit.Application.Features.Commands.Videos.DeleteVideo;
using StayFit.Application.Features.Queries.Videos.GetVideosByVideoType;
using StayFit.Domain.Enums;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVideosByVideoType(VideoTypes videoType)
        {
            var request = new GetVideosByVideoTypeQueryRequest(videoType);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("[action]")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            var request = new CreateVideoCommandRequest(createVideoDto);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : BadRequest(response);

        }


        [HttpDelete("[action]")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteVideo(int videoId)
        {
            var request = new DeleteVideoCommandRequest(videoId);
            var response = await _mediator.Send(request);

            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
