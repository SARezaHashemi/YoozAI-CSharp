// See https://aka.ms/new-console-template for more information
using YoozAI;

//this is a sample pattern
/*string pattern = @"
    )
    + سبحان الله همش گوشته
    - سبحان الله همینطوره، این نسخه تقدیم میشه به تمام نال ها و آقای اجاقی
    (
    )
    + سلام من نال هستم
    - سلام وقتت بخیر نال عزیز
    (
    ";*/


string filePattern = "";
string patternPath = "pattern.txt";
using(StreamReader reader = new (patternPath))
{
    filePattern = reader.ReadToEnd();
}
string ask = "سبحان الله همش گوشته";
using (YoozHandler handler = new(filePattern))
{
    //as you know windows terminal doesn't support persian texts 
    //so i prefer to save text in a file
    //Console.WriteLine(handler.GetResponse(ask));
    string path = @"text.txt";
    if (File.Exists(path))
    {
        File.Delete(path);
    }
    using StreamWriter sw = new(path);
    sw.WriteLine(handler.GetResponse(ask));
}