using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RMAgent
{
    class Assets
    {
        #region "Properties"
        public string AssetDirectory { get; set; }
        #endregion
        #region "Constructor and IDisposable Support"
        public Assets(string anAssetName)
        {
            AssetDirectory = anAssetName + "/Assets/Data";
        }//end Storage
        #region "IDisposable Support"
        #endregion
        #endregion
        #region "Methods"
        public void PutObject(String ObjectName, Stream aStream)
        {
            string directory = Path.Combine(AssetDirectory, Path.GetDirectoryName(ObjectName));
            try
            {
                if (!Directory.Exists(Path.Combine(directory)))
                    Directory.CreateDirectory(directory);

                using (var fileStream = File.Create(Path.Combine(AssetDirectory, ObjectName)))
                {
                    //reset stream position to 0 prior to copying to filestream;
                    aStream.Position = 0;
                    aStream.CopyTo(fileStream);
                }//end using

            }
            catch (Exception)
            {

            }
        }

        //Download Object
        public Stream GetObject(String ObjectName)
        {
            string objfile = Path.Combine(AssetDirectory, ObjectName);
            try
            {
                return File.OpenRead(objfile);
            }
            catch (Exception)
            {
                return null;
            }

        }//end GetObject

        //Delete Object
        public Boolean DeleteObject(String ObjectName)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
