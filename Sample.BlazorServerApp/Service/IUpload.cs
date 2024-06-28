using BlazorInputFile;

namespace Sample.BlazorServerAPP.Service
{
    public interface IUpload
    {
        public void UploadFile(IFileListEntry file, MemoryStream str, string fileName);
        public void RemoveFile(string fileName);
    }
}
