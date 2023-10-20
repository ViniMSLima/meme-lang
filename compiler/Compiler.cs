using System.Data.Common;

public class MemeCompiler
{
    private List<Commands> commands = new();
    private List<string> data = new();


    public void Compile(string line)
    {
        string lineAux;
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

        if (line.Contains("mahOe"))
        {
            commands.Add(Commands.Eval);
            data.Add(
                line
                    .Replace("mahOe(", "")
                    .Replace(");", "")
            );
        }
        
        if (line.Contains("eAsNamoradinhas"))
        {
            if (line.Contains("<"))
            {
                commands.Add(Commands.Lt);
                data.Add(
                    line.Substring(line.IndexOf("(") + 1, line.IndexOf("<") - line.IndexOf("(") - 1)
                );

                data.Add(
                    line.Substring(line.IndexOf("<") + 1, line.IndexOf(")") - line.IndexOf("<") - 1)
                );
            }
        }
        
    }

    public void Debug()
    {
        foreach (var item in commands)
            Console.WriteLine("Command: " + (int)(item));

            
        foreach (var item in data)
            Console.WriteLine("data: " + item);
    }

    public void SaveFile(string path)
    {
        StreamWriter StreamWriter = new StreamWriter(path);

        string aux = "";
        StreamWriter.WriteLine("{");
        StreamWriter.Write('"'.ToString() + "functions" + '"'.ToString() + ":[");
        foreach (var command in this.commands)
            aux += $"{(int)command},";
        
        aux = aux.Substring(0, aux.Length - 1);
        StreamWriter.Write(aux);
        StreamWriter.WriteLine("],");
        
        
        aux = "";
        StreamWriter.Write('"'.ToString() + "data" + '"'.ToString() + ":[");
        foreach (var str in this.data)
        {
            foreach (var chr in str)
                aux += $"{(int)chr},";
            aux += (int)'@' + ",";
        }

        aux = aux.Substring(0, aux.Length - 1);
        StreamWriter.Write(aux);
        StreamWriter.WriteLine("]");
        StreamWriter.WriteLine("}");
        
        StreamWriter.Close();

    }
}