using System;
using System.IO;
using IndexGenerator;

namespace Program
{
    public class Generator
    {
        static void Main(string[] vs)
        {
            //获取当前程序所在的文件路径
            String rootPath = @"D:\Programming Projects\web projects\ZSClinic\Client\Pages";
            string parentPath = Directory.GetParent(rootPath).FullName;
            string fileName = @"fileList.html";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            StreamWriter sw = new StreamWriter(fileName, true);
            // sw.WriteLine("根目录：" + rootPath);
           GetAllFileAndFolderNames.getDirectory(sw, rootPath, parentPath);
            sw.Flush();
            sw.Dispose();
        }
    }
}