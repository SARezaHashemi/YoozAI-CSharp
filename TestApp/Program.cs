// See https://aka.ms/new-console-template for more information
using YoozAI;

string pattern = @"
    )
    + سبحان الله همش گوشته
    - سبحان الله همینطوره، این نسخه تقدیم میشه به تمام نال ها و آقای اجاقی
    (
    )
    + سلام من نال هستم
    - سلام وقتت بخیر نال عزیز
    (
    ";

string ask = "سلام من نال هستم";
using (YoozHandler handler = new(pattern))
{
    //as you know windows terminal doesn't support persian texts 
    //so i prefer to save text in a file
    //Console.WriteLine(handler.GetResponse(ask));
    string path = @"text.txt";
    if (File.Exists(path))
    {
        File.Delete(path);
        File.Create("test.txt");
    }
    using (StreamWriter sw = new StreamWriter(path))
    {
        sw.WriteLine(handler.GetResponse(ask));
    }
}