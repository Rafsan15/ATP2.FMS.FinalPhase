﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Core.Entities;
using FMS.FrameWork;
using FMS_Entities;

namespace FMS.Core.Service.Interfaces
{
    public interface IPostAProjectService:IService<PostAProject>
    {
        Result<PostAProject> GetLastId();
        Result<bool> DeletebyUser(int id);

    }
}
