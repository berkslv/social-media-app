namespace Core.Entity.Concrete
{
    public static class Role
    {
        public const string Student = "Student";
        public const string Business = "Business";
        public const string Admin = "Admin";
        public static List<string> RoleList = new List<string>();

        static Role()
        {
            RoleList.Add(Student);
            RoleList.Add(Business);
        }

    }
}