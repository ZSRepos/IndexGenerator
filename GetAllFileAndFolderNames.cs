using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexGenerator
{
    internal class GetAllFileAndFolderNames
    {
        /// <summary>
        /// 获得指定路径下所有文件名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件写入流</param>
        /// <param name="indent">输出时的缩进量</param>
        public static void getFileName(StreamWriter sw, string path, string parentPathOfRoot)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                //for (int i = 0; i < indent; i++)
                //{
                //    sw.Write("  ");
                //}
                if(f.Name.ToLower().EndsWith(".html") && !f.Name.ToLower().Contains("index"))
                {
                    sw.Write("<div><a href=\"");
                    // sw.WriteLine(path.Split(Path.DirectorySeparatorChar)[^1] + "/" + f.Name);
                    sw.Write((f.DirectoryName + "\\" + f.Name).Replace(parentPathOfRoot + "\\", ""));
                    //Console.WriteLine(f.Name);
                    sw.WriteLine("\">" + Path.GetFileNameWithoutExtension(f.FullName) +"</a></div>");
                }
            }
        }

        /// <summary>
        /// 获得指定路径下所有子目录名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件夹路径</param>
        /// <param name="indent">输出时的缩进量</param>
        public static void getDirectory(StreamWriter sw, string path, string parentPathOfRoot)
        {
            getFileName(sw, path, parentPathOfRoot);
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                //for (int i = 0; i < indent; i++)
                //{
                //    sw.Write("  ");
                //}
                // sw.WriteLine("文件夹：" + d.Name);
                if(!d.Name.ToLower().Contains("00模板"))
                {
                    getDirectory(sw, d.FullName, parentPathOfRoot);
                }
                // sw.WriteLine();
            }
        }
    }
}
