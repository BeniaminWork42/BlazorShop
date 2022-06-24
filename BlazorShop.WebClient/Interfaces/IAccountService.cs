﻿// <copyright file="IAccountService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> ChangePassword(ChangePasswordCommand command);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="todoItem">.</param>
        /// <returns></returns>
        Task<RequestResponse> ResetPassword(ResetPasswordCommand command);
    }
}
