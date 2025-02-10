namespace SMS.Domain.Common
{
    public abstract class Constants
    {
        public abstract class Roles
        {
            public const string SuperAdmin = "Super Admin";
            public const string Teacher = "Teacher";
            public const string Student = "Student";
        }
        public abstract class SuperAdmin
        {
            public const string Identifier = "939b340f-44d7-4bd0-abb5-1a6424d6de11";
            public const string Name = "Connect Admin";
            public const string Email = "amoshhamal7@gmail.com";
            public const string DecryptedPassword = "0FmR7l3AqXgXf+mDhqfnTg==";
        }
        public abstract class DbProviderKey
        {
            public const string Npgsql = "postgresql";
        }
    }
}
