namespace Shared.Models
{
    public class UploadedImage
    {
        //Blobs = binary large objects

        public string NewImageFileExtension { get; set; }

        //Base64 is a string that represents binary
        public string NewImageBase64Content { get; set; }
        public string OldImagePath { get; set; }



    }
}
