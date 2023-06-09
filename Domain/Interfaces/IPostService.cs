﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetForFriends(int userId, int skip = 0, int take = 8);
    }
}
