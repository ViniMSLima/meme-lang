

StreamReader sr = new StreamReader("./codigin.meme");
MemeCompiler tc = new();

string line;

while (!sr.EndOfStream)
{
    line = sr.ReadLine();

    tc.Compile(line);
}

tc.Debug();
tc.SaveFile("../codigin.txt");