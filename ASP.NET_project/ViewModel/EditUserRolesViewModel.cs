namespace ASP.NET_project.ViewModel
{
    public class EditUserRolesViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        // Список всех доступных ролей в системе (например: "Admin", "User", "Manager")
        public List<string> AllRoles { get; set; }

        // Список ролей, к которым пользователь уже привязан
        public List<string> AssignedRoles { get; set; }

        public EditUserRolesViewModel()
        {
            AllRoles = new List<string>();
            AssignedRoles = new List<string>();
        }
    }
}
