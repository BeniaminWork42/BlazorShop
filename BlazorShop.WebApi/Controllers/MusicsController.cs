﻿// <copyright file="MusicsController.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Controllers
{
    /// <summary>
    /// Controller for Musics.
    /// </summary>
    public class MusicsController : ApiControllerBase
    {
        /// <summary>
        /// Create the music.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPost("music")]
        public async Task<IActionResult> CreateMusic([FromBody] CreateMusicCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Update the music.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpPut("music")]
        public async Task<IActionResult> UpdateMusic([FromBody] UpdateMusicCommand command)
        {
            var result = await this.Mediator.Send(command);
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Delete the music.
        /// </summary>
        /// <param name="id">The id of the music.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}")]
        [HttpDelete("music/{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var result = await this.Mediator.Send(new DeleteMusicCommand { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the music.
        /// </summary>
        /// <param name="id">The id of the music.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("music/{id}")]
        public async Task<IActionResult> GetMusic(int id)
        {
            var result = await this.Mediator.Send(new GetMusicByIdQuery { Id = id });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }

        /// <summary>
        /// Get the musics.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Authorize(Roles = $"{StringRoleResources.Admin}, {StringRoleResources.User}, {StringRoleResources.Default}")]
        [HttpGet("musics")]
        public async Task<IActionResult> GetMusics()
        {
            var result = await this.Mediator.Send(new GetMusicsQuery { });
            return result.Successful == true
                ? this.Ok(result)
                : this.BadRequest(result);
        }
    }
}
