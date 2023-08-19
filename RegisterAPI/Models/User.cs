namespace RegisterAPI.Models
{
	public class User
	{
        public int UserID { get; set; }
        public string? UserName { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Pwd { get; set; }
		public int? Contact { get; set; }
		public string? Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
