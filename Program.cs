using System.Text;
using System;

namespace Myprogram
{
    class Progra
    {
        static void Main(string[] agrs)
        {
            string inputtype;
            string inputstring;
            Console.Write("What you wanna 1.decode 2.encode: ");
            string input1 = Console.ReadLine();
            if (input1 == "1")
            {
                Console.Write("Okey enter string: ");
                inputstring = Console.ReadLine();
                Console.Write("Enter decode type 1.UTF8 2.UTF32 3.ASCII 4.ALL: ");
                inputtype = Console.ReadLine();
                switch (inputtype)
                {
                    case "1":
                    Console.WriteLine(DecodeUTF8(inputstring));
                    break;
                    case "2":
                    Console.WriteLine(DecodeUTF32(inputstring));
                    break;
                    case "3":
                    DecodeASCII(inputstring);
                    break;
                    case "4":
                    All(inputstring);
                    break;
                    default:
                    Console.WriteLine("Error plese enter correct number");
                    break;
                }
            }
            else if (input1 == "2")
            {
                Console.Write("Okey now enter string: ");
                inputstring = Console.ReadLine();
                Console.Write("Okey now Enter encode type 1.UTF8 2.UTF32 3.ASCII: ");
                inputtype = Console.ReadLine();
                switch (inputtype)
                {
                    case "1":
                    Console.WriteLine(EncodeUTF8(inputstring));
                    break;
                    case "2":
                    Console.WriteLine(EncodeUTF32(inputstring));
                    break;
                    case "3":
                    EncodeASCII(inputstring);
                    break;
                    default:
                    Console.WriteLine("Error plese enter correct number");
                    break;
                }
            } 
            else
            {
                Console.WriteLine("Error plese enter correct number");
            }
            
        }
        static string EncodeUTF8(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }
        static void EncodeASCII(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            foreach(byte b in bytes)
            {
                Console.Write(b + " ");
            }
        }
        static void DecodeASCII(string Text)
        {
        string[] parts = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        byte[] asciiBytes = new byte[parts.Length];

        try
        {
            for (int i = 0; i < parts.Length; i++)
            {
                asciiBytes[i] = Convert.ToByte(parts[i]);
            }
            string decodedText = DecodeASCIIHelp(asciiBytes);
            Console.WriteLine("DecodeText ASCII: " + decodedText);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error please enter correct number");
        }
        }
        static string DecodeASCIIHelp(byte[] bytes)
        {
        return Encoding.ASCII.GetString(bytes);
        }
        static string EncodeUTF32(string text)
        {
            byte[] bytes = Encoding.UTF32.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }
        static string DecodeUTF32(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
            return Encoding.UTF32.GetString(bytes);
        }
        static string DecodeUTF8(string Text)
        {
            byte[] bytes = Convert.FromBase64String(Text);
            return Encoding.UTF8.GetString(bytes);
        }
        
        static void All(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
            Console.WriteLine($"UTF8: {Encoding.UTF8.GetString(bytes)}");
            Console.WriteLine($"UTF32: {Encoding.UTF32.GetString(bytes)}");
            Console.WriteLine($"Unlicode: {Encoding.Unicode.GetString(bytes)}");
        }
    }
}
