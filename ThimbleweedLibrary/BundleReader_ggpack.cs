﻿using System;
using System.Collections.Generic;
using System.IO;

namespace ThimbleweedLibrary
{
    public class Bundle
    {
        private string FileName;
        private string FileExtension;
        private Int64 Offset;
        private int Size;
        private bool Compressed;
    }

    public class BundleReader_ggpack
    {
        private List<Bundle> BundleFiles;
        private string BundleFilename;
        private BinaryReader fileReader;

        //Constructor
        public BundleReader_ggpack(string ResourceFile)
        {
            BundleFilename = ResourceFile;

            fileReader = new BinaryReader(File.Open(BundleFilename, FileMode.Open)); //free this in destructor

            if (DetectBundle() == false)
            {
                throw new ArgumentException("Invalid ggpack file!");
            }
        }

        //Destructor
        ~BundleReader_ggpack()
        {
            fileReader.Dispose();
        }

        //Decrypt the first 4 bytes and see if its a valid bundle
        private bool DetectBundle()
        {
            uint DataOffset = fileReader.ReadUInt32();
            uint DataSize = fileReader.ReadUInt32();
            fileReader.BaseStream.Position = DataOffset;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryReader decReader = new BinaryReader(ms)) //Frees when done + underlying stream
                {
                    CopyStream(fileReader.BaseStream, decReader.BaseStream, Convert.ToInt32(DataSize));
                    ms.Position = 0;

                    //Decode data records
                    if (DecodeUnbreakableXor(ms) == false)
                    {
                        return false;
                    }

                    //using (FileStream file = new FileStream("c:/users/ben/desktop/file.bin", FileMode.Create, System.IO.FileAccess.Write))
                    //    ms.CopyTo(file);
                    //    ms.Position = 0;

                    //Check header is valid. First dword is 01,02,03,04
                    if (decReader.ReadInt32() == 67305985)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Takes a stream and decodes it, overwriting the contents. Doesnt actually check if valid data produced.
        /// </summary>
        /// <param name="DecodeStream"></param>
        /// <returns>F</returns>
        private bool DecodeUnbreakableXor(MemoryStream DecodeStream)
        {
            var magic_bytes = new byte[] { 0x4F, 0xD0, 0xA0, 0xAC, 0x4A, 0x5B, 0xB9, 0xE5, 0x93, 0x79, 0x45, 0xA5, 0xC1, 0xCB, 0x31, 0x93 };  //0x5B - possibly 0x56?
            var buffer = DecodeStream.ToArray();

            //alt way to get data from generic stream to array buffer
            //byte[] buffer = new byte[DecodeStream.Length];
            //DecodeStream.Read(buffer, 0, (int)DecodeStream.Length);

            var buf_len = buffer.Length;
            var eax = buf_len;
            var var4 = buf_len & 255;
            var ebx = 0;
            while (ebx < buf_len)
            {
                eax = ebx & 255;
                eax = eax * -83; // 109;
                var ecx = ebx & 15;
                eax = (eax ^ magic_bytes[ecx]) & 255;
                ecx = var4;
                eax = (eax ^ ecx) & 255;
                buffer[ebx] = Convert.ToByte(buffer[ebx] ^ eax);
                ecx = ecx ^ buffer[ebx];
                ebx = ebx + 1;
                var4 = ecx;
            }

            //Loop through in blocks of 16 and xor the 6th and 7th bytes
            int i = 5;
            while (i < buf_len)
            {
                buffer[i] = Convert.ToByte(buffer[i] ^ 0x0D);
                buffer[i + 1] = Convert.ToByte(buffer[i + 1] ^ 0x0D);
                i += 16;
            }

            //Check everything has decoded
            if (buffer != null && buffer.Length > 0)
            {
                DecodeStream.SetLength(0); //empty the stream
                DecodeStream.Write(buffer, 0, buffer.Length); //write the decoded bytes back
                DecodeStream.Position = 0;

                return true;
            }
            return false;
        }

        public void ParseFiles()
        {
            uint DataOffset = fileReader.ReadUInt32();
            uint DataSize = fileReader.ReadUInt32();
            fileReader.BaseStream.Position = DataOffset;

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryReader decReader = new BinaryReader(ms)) //Frees when done + underlying stream
                {
                    CopyStream(fileReader.BaseStream, decReader.BaseStream, Convert.ToInt32(DataSize));
                    ms.Position = 0;

                    //Decode data records
                    if (DecodeUnbreakableXor(ms) == false)
                    {
                        return;
                    }

                    //using (FileStream file = new FileStream("c:/users/ben/desktop/file.bin", FileMode.Create, System.IO.FileAccess.Write))
                    //    ms.CopyTo(file);
                    //    ms.Position = 0;

                    //Check header is valid. First dword is 01,02,03,04
                    if (decReader.ReadInt32() == 67305985)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public static void CopyStream(Stream input, Stream output, int bytes)
        {
            byte[] buffer = new byte[32768];
            int read;
            while (bytes > 0 &&
                   (read = input.Read(buffer, 0, Math.Min(buffer.Length, bytes))) > 0)
            {
                output.Write(buffer, 0, read);
                bytes -= read;
            }
        }
    }
}