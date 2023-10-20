public class TiozaoCompiler
{
    public StreamWriter StreamWriter 
    { 
        get
        {
            if (sw != null)
                return sw;
            
            sw = new StreamWriter("resp.txt");
            return sw;
        }

        private set {    }
    }
    private StreamWriter sw;

    private List<Commands> commands = new();
    private List<string> data = new();


    public void Compile(string line)
    {
        if (line.Contains("pave"))
        {
            commands.Add(Commands.WriteLine);
            data.Add(
                line
                    .Replace("pave(", "")
                    .Replace(");", "")
                    .Replace('"'.ToString(), "")
            );
        }

        if (line.Contains("pacume"))
        {
            commands.Add(Commands.Input);
        }
    }

    public void Debug()
    {
        foreach (var item in commands)
            Console.WriteLine((int)(item));

            
        foreach (var item in data)
            Console.WriteLine(item);
    }

    public void SaveFile(string path)
    {
        
    }
}