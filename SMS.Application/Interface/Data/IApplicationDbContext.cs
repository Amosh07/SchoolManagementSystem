using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Service;
using SMS.Domain.Entities;
using SMS.Domain.Entities.Identity;
using System.Data;

namespace SMS.Application.Interface.Data
{
    public interface IApplicationDbContext : IScopeService
    {
        #region Identity
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<UserRoles> UserRoles { get; set; }

        DbSet<UserClaims> UserClaims { get; set; }

        DbSet<UserLogin> UserLogins { get; set; }

        DbSet<UserToken> UserTokens { get; set; }

        DbSet<RoleClaims> RoleClaims { get; set; }
        #endregion

        #region Modules
        DbSet<Attendance> Attendances { get; set; }

        DbSet<Class> Classes { get; set; }

        DbSet<Exam> Exams { get; set; } 

        DbSet<Result> Results { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<Subject> Subjects { get; set; }

        DbSet<Teacher> Teachers { get; set; }
        #endregion

        IDbConnection Connection { get; }

    }
}
