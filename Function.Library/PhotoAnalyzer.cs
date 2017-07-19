using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.Library
{
    public class PhotoAnalyzer
    {

        private readonly string _faceKey;
        
        // private readonly string _partitionKeyName;
        // private IDocumentDbRepository<PhotographData> _repository;

        public PhotoAnalyzer(string faceKey)
        {
            _faceKey = faceKey;
        }

        //public PhotoAnalyzer(string faceKey, string computerVisionKey, string emotionKey, string docDBEndpoint, string docDBKey, string docDbName, string partitionKeyName, string docDbCollectionName)
        //{
        //    _faceKey = faceKey;

        //    _partitionKeyName = partitionKeyName;

        //    var initializer = new DocumentDbInitializer();

        //    TODO check out connection policy
        //    var client = initializer.GetClient(docDBEndpoint, docDBKey);
        //    _repository = new DocumentDbRepository<PhotographData>(client, docDbName, _partitionKeyName, () => docDbCollectionName);
        //}

        public async Task ProcessImage(Stream imageBlob, string name)
        {
            Debug.WriteLine($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {imageBlob.Length} Bytes");
           
            Face[] faces = await DetectFaces(GetImageAsMemoryStream(imageBlob));

            var photo = new PhotographData() { Id = name.Replace(@"/", ""),  NumberOfPeople = faces.Length, Faces = faces };

            Debug.WriteLine(photo.ToString()); 

            // await _repository.AddOrUpdateAsync(photo);

        }

        private async Task<Face[]> DetectFaces(Stream imageStream)
        {
            FaceServiceClient faceServiceClient = new FaceServiceClient(_faceKey);

            try
            {
                var faces = await faceServiceClient.DetectAsync(imageStream, false, true, new FaceAttributeType[] { FaceAttributeType.Emotion, FaceAttributeType.Gender, FaceAttributeType.HeadPose, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.FacialHair, FaceAttributeType.Glasses });
                return faces;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }

        }

        static MemoryStream GetImageAsMemoryStream(Stream myImage)
        {
            BinaryReader binaryReader = new BinaryReader(myImage);
            var bytes = binaryReader.ReadBytes((int)myImage.Length);
            return new MemoryStream(bytes);
        }

        

    }
}
