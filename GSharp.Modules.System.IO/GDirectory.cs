﻿using System.IO;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.System.IO
{
    public class GDirectory : GModule
    {
        #region 내부 함수
        private static void CopyDirectory(string source, string destination, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destination, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    CopyDirectory(subdir.FullName, Path.Combine(destination, subdir.Name), copySubDirs);
                }
            }
        }
        #endregion

        #region 사용자 함수
        [GCommand("{object}에서 {object}로 폴더 복사")]
        public static void Copy(string source, string destination)
        {
            if (Directory.Exists(source))
            {
                CopyDirectory(source, destination, true);
            }
        }

        [GCommand("{object}에서 {object}로 폴더 이동")]
        public static void Move(string source, string destination)
        {
            if (Directory.Exists(source))
            {
                Directory.Move(source, destination);
            }
        }

        [GCommand("{object}에서 {object}폴더 생성")]
        public static void Create(string path, string name)
        {
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(string.Format(@"{0}\{1}", path, name));
            }
        }

        [GCommand("{object}폴더 삭제")]
        public static void Delete(string source)
        {
            if (Directory.Exists(source))
            {
                Directory.Delete(source, true);
            }
        }

        [GCommand("{object}폴더의 이름을 {object}로 변경")]
        public static void Rename(string source, string name)
        {
            if (Directory.Exists(source))
            {
                Directory.Move(source, string.Format(@"{0}\{1}", new DirectoryInfo(source).Parent.FullName, name));
            }
        }
        #endregion
    }
}
