﻿// <copyright file="ActivateUserCommand.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to activate an user.
    /// </summary>
    public class ActivateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int Id { get; set; }
    }
}
