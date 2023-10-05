﻿using SfdEnerji.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Repository.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<AppUser> Users { get; }
        IRepository<ContactForm> ContactForms { get; }
        IRepository<Meta> Metas { get; }
        IRepository<Page> Pages { get; }
        IRepository<Picture> Pictures { get; }
        IRepository<Project> Projects { get; }
        IRepository<Service> Services { get; }
        void Save();
    }
}
