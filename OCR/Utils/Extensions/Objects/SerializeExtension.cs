using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OCR.Utils.Extensions.Objects
{
    public static class SerializeExtension
    {

        /// <summary>
        /// Chuyển đổi một Object có anomation [Serializeable] thành một chuổi byte
        /// </summary>
        /// <param name="o">Object muốn phân tách thành chuổi byte</param>
        /// <returns></returns>
        public static byte[] Serialize(this object o)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Chuyển một chuổi byte thành một object tương ứng với object mà nó đã 
        /// Serialize thành.
        /// </summary>
        /// <typeparam name="T">Kiểu của Object trả về sau khi DeSerialize</typeparam>
        /// <param name="arrBytes">Chuổi byte</param>
        /// <returns></returns>
        public static T DeSerialize<T>(this byte[] arrBytes)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                try
                {
                    if (arrBytes == null)
                    {
                        throw new ArgumentNullException(nameof(arrBytes));
                    }

                    BinaryFormatter binForm = new BinaryFormatter();
                    memStream.Write(arrBytes, 0, arrBytes.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    object obj = binForm.Deserialize(memStream);
                    return (T)obj;
                }
                catch (ArgumentNullException e)
                {
                    Debug.WriteLine(e.Message);
                    throw new ArgumentNullException(nameof(arrBytes));
                }
            }
        }

    }
}
