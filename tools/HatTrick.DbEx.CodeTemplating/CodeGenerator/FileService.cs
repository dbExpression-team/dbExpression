using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HatTrick.DbEx.CodeTemplating.CodeGenerator
{
    public class FileService
    {
        private string TemplatePath { get; set; }
        private string OutputSubdirectory { get; set; }

        public FileService(string templatePath, string outputSubdirectory)
        {
            TemplatePath = templatePath;
            OutputSubdirectory = outputSubdirectory;
        }

        public string ReadFile(string path)
                => File.ReadAllText(path);

        public void WriteFile(string path, string content)
            => File.WriteAllText(path, content);

        public string GetTemplate()
        {
            var path = $@"{GetApplicationPath()}\{TemplatePath}";
            return File.ReadAllText(path);
        }

        public string GetOutputPath(string fileName)
        {
            var directory = new DirectoryInfo($@"{GetApplicationPath()}\..\..\{OutputSubdirectory}\{fileName}");
            return directory.FullName;
        }

        public static string GetApplicationPath()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            return appPathMatcher.Match(exePath).Value;
        }
    }
}
