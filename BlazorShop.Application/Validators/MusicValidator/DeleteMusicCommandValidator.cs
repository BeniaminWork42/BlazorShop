﻿// <copyright file="DeleteMusicCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.MusicValidator
{
    public class DeleteMusicCommandValidator : AbstractValidator<DeleteMusicCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteMusicCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
