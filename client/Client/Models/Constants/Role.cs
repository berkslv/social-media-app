namespace Client.Models.Constants
{
    public static class Role
    {
        public const string Student = "Student";
        public const string Business = "Business";
        public const string Manager = "Manager";
        public const string Admin = "Admin";
        public static List<string> RoleList = new List<string>();

        static Role()
        {
            RoleList.Add(Student);
            RoleList.Add(Business);
            RoleList.Add(Manager);
            RoleList.Add(Admin);
        }

    }
}