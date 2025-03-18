[TestFixture]
public class Creator
{
    [Test]
    [Explicit]
    public void Run()
    {
        var builder = new StringBuilder();
        for (int i = 0; i < 1000; i++)
        {
            builder.Append(
                $$"""

                  [TestFixture]
                  public class Test{{i}}
                  {
                      [Test]
                      public void Run()
                      {
                      }
                  }

                  """);
        }

        var directory = GetDirectory();
        var file = Path.Combine(directory, "Tests.cs");
        File.Delete(file);
        File.WriteAllText(file, builder.ToString());
    }

    static string GetDirectory([CallerFilePath] string filePath = "") =>
        Path.GetDirectoryName(filePath)!;
}