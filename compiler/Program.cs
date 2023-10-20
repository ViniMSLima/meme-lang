

StreamReader sr = new StreamReader("./codigin.tiu");
TiozaoCompiler tc = new();

string line;

while (!sr.EndOfStream)
{
    line = sr.ReadLine();

    tc.Compile(line);
}

tc.Debug();