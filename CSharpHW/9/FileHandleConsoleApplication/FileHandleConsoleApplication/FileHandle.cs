namespace FileHandleConsoleApplication
{
    public struct FileHandle
    {
        public int FileSize 
        {
            get
            {
                return FilePath.Length;
            }
        }
        public string FileName 
        {
            get
            {
                var position = -1;

                for (int i = 0; i < FilePath.Length - 1; i++)
                {
                    if (FilePath[i] == '\\')
                    {
                        position = i;
                    }
                }

                return position != -1 ? FilePath.Substring(position + 1) : "Unknown.txt";
            }
        }
        public string FilePath { get; set; }
        public FileAccessEnum FileAccessEnum { get; set; }

        public FileHandle(string filePath, FileAccessEnum fileAccessEnum) : this()
        {
            FilePath = filePath;
            FileAccessEnum = fileAccessEnum;
        }
    }
}
