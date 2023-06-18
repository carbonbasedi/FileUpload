namespace Task_PurpleBuzz.Utilities.File
{
	public interface IFileService
	{
		string Upload(IFormFile file);
		void Delete(string photoName);

		bool IsImage(IFormFile file);

		bool IsBiggerThanSize(IFormFile file,int size = 100);
	}
}
