using ProductCatalogResources.Interfaces;
using ProductCatalogResources.Models;


namespace ProductCatalogResources.Services;

public class FileService(string filePath)
{
    private readonly string _filePath = filePath;

    public ServiceRespons SaveToFile(string content)
    {
        try
        {
                using var sw = new StreamWriter(_filePath, false);
                sw.WriteLine(content);
                return new ServiceRespons { Succeeded = true};
        }
        catch (Exception ex) 
        {
            return new ServiceRespons { Succeeded = false, Message = ex.Message };
        }
    }

    public string GetFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {

                using var sr = new StreamReader(_filePath);
                var content = sr.ReadToEnd();
                return content;
            }       

        }
        catch 
        {
        }
        return null!;
    }
}
