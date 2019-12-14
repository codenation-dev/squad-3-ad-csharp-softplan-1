namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for a Enviroment.
	/// </summary>
    public class EnvironmentViewModel
    {
		/// <summary>
		/// Unique identifier for the Environment.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the Environment.
		/// </summary>
        public string Name { get; set; }
    }
}
