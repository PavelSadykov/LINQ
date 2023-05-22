using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя первого файла:");
        string firstFileName = Console.ReadLine();

        Console.WriteLine("Введите имя второго файла:");
        string secondFileName = Console.ReadLine();


        // объявление переменной с именем firstWords (затем secondWords) типа string[], то есть массив строк.
        // GetWordsFromFile( ) - это вызов метода GetWordsFromFile с аргументом firstFileName ( secondFileName) , который представляет имя первого (второго) файла.

        string[] firstWords = GetWordsFromFile(firstFileName);
        string[] secondWords = GetWordsFromFile(secondFileName);



        // var commonWords=... выполняет операцию пересечения двух массивов строк firstWords и secondWords,
        // чтобы найти общие элементы.Метод Intersect из LINQ используется для выполнения этой операции.
        // В данном случае, используется перегруженная версия метода Intersect с тремя аргументами.
        //Третий аргумент (StringComparer.OrdinalIgnoreCase) - объект,
        //определяющий способ сравнения элементов коллекций без учета регистра символов.
        //Результатом выполнения этой строки кода будет новая коллекция(в данном случае, переменная commonWords),
        //содержащая только те элементы, которые присутствуют и в firstWords, и в secondWords

        var commonWords = firstWords.Intersect(secondWords, StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("Введите имя файла для записи общих слов:");
        string outputFileName = Console.ReadLine();

        SaveWordsToFile(outputFileName, commonWords);

        Console.WriteLine("Общие слова сохранены в файл: " + outputFileName);
    }

    //  Метод GetWordsFromFile принимает имя файла (fileName) в качестве аргумента и возвращает массив строк (string[]),
    //  содержащий слова из указанного файла. 
    static string[] GetWordsFromFile(string fileName)   
    {
        //File.ReadAllText(fileName):  метод считываетсодержимое файла с помощью статического метода ReadAllText класса File.
        //Он принимает имя файла (fileName) 
        string text = File.ReadAllText(fileName);

        //string[] words = Regex.Split(text, @"\W+"): Возвращаемый текст из предыдущего шага (text) передается в метод Regex.Split.
        //Этот метод использует регулярное выражение @"\W+" для разделения текста на слова.
        string[] words = Regex.Split(text, @"\W+");
        //Возвращаем полученный массив строк words,
        //который содержит разделенные слова из файла.
        return words;
    }


    //Метод SaveWordsToFile принимает имя файла (fileName) и коллекцию строк (words)
    //и сохраняет строки в указанный файл.
    static void SaveWordsToFile(string fileName, IEnumerable<string> words)
    {

        //Этот код объединяет строки из коллекции words в одну большую строку, используя символ новой строки (Environment.NewLine)
        //в качестве разделителя между строками.
        //Результат сохраняется в переменную text.
        string text = string.Join(Environment.NewLine, words);

        //Этот метод записывает текст из переменной text в указанный файл с помощью статического метода WriteAllText класса File.
        //Он принимает имя файла (fileName), текст для записи (text) 
        File.WriteAllText(fileName, text);
    }
}
