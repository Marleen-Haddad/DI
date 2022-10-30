namespace DI.Helpers
{
    public class FileHelper
    {
            public static void WriteToFile(string filePath, string content)
            {
                if (!File.Exists(filePath))
                {
                    string? path = Path.GetDirectoryName(filePath);
                    if (string.IsNullOrEmpty(path)) 
                    Directory.CreateDirectory(filePath);
                }
                File.WriteAllText(filePath, content);
            }

            public static  string? ReadFile(string filePath)
            {
                return File.Exists(filePath) ?  File.ReadAllText(filePath) : null;
            }

        
    }
}
