﻿// <copyright file="Role.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Domain.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<UserRole> Users { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
