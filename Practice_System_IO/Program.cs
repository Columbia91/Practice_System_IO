using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice_System_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            Console.WriteLine("Программа для создания файла.");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                    Console.WriteLine($"{i}.{drives[i].Name}");
            }
            Console.WriteLine("Выберите диск, в котором хотите создать файл, написав его порядковый номер: ");
            var number = int.Parse(Console.ReadLine());

            path = drives[number].Name;
            Console.WriteLine($"Выбран диск {path}");

            foreach (var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory.Name}");
            }

            Console.WriteLine("Укажите папку, в которую хотите сохранить данные: ");
            var directoryName = Console.ReadLine();
            path += directoryName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string[] data = { "Akhmetkali", "Adilet", "27" };
            path += @"\" + "data.txt";

            using (var streamWriter = new StreamWriter(path))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    streamWriter.WriteLine(data[i]);
                }
            }
            string newData;
            using (StreamReader sr = new StreamReader(path))
            {
                newData = sr.ReadToEnd();
            }

            int symbolsCount = 256;
            int count = 0;
            for (int i = 0; i < symbolsCount; i++)
            {
                for (int j = 0; j < newData.Length; j++)
                {
                    if(((char)i).ToString() == newData[j].ToString())
                    {
                        count++;
                    }
                }
                Console.WriteLine($"{((char)i).ToString()}: {count}" );
                count = 0;
            }
            
        }
    }
}


/* 1. Написать программу, читающую побайтно заданный файл и подсчитывающую число появлений каждого из 
 * 256 возможных знаков.
 * 
 * 2. С помощью класса StreamWriter записать в текстовый файл свое имя, фамилию и возраст. 
 * Каждая запись должна начинаться с новой строки.*/
