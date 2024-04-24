using System.Text;

namespace SonarAnalyzer.Console;
public class ResourceHolder : IDisposable
{
    private FileStream? _fs;

    public void OpenResource(string path)
    {
        _fs = new FileStream(path, FileMode.Open);
    }

    public void WriteToFile(string path, string text)
    {
        using (_fs = new FileStream(path, FileMode.Create))
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            _fs.Write(bytes, 0, bytes.Length);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _fs?.Dispose();
    }
}
