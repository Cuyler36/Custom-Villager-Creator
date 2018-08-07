using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using GCNToolKit.Formats.Colors;

namespace Custom_Villager_Creator
{
    public static class Utility
    {
        public static int SizeOf<T>() where T : struct
        {
            return Marshal.SizeOf(default(T));
        }

        public static unsafe string BytePtrToDnMString(byte* data, int length)
        {
            var text = "";
            for (var i = 0; i < length; i++)
            {
                text += CharacterSet.CharSet[*data++];
            }

            return text.Trim();
        }

        public static unsafe void DnMStringToBytePtr(byte* data, string text, int maxLength)
        {
            for (var i = 0; i < maxLength; i++)
            {
                var character = i >= text.Length ? " " : text.Substring(i, 1);
                if (i >= text.Length || !CharacterSet.CharSet.ContainsValue(character))
                {
                    *data++ = 0x20;
                }
                else
                {
                    *data++ = CharacterSet.CharSet.FirstOrDefault(o => o.Value == character).Key;
                }
            }
        }

        public static ushort[] ToRgb5A3Palette(byte[] data)
        {
            var output = new ushort[16];
            for (int i = 0, idx = 0; i < 16; i++, idx += 2)
            {
                output[i] = (ushort)(data[idx] << 8 | data[idx + 1]);
            }

            return output;
        }

        public static uint[] ToArgb8Palette(ushort[] palette)
        {
            var output = new uint[16];
            for (var i = 0; i < 16; i++)
            {
                output[i] = RGB5A3.ToARGB8(palette[i]);
            }

            return output;
        }

        public static uint[] ToArgb8Palette(byte[] data)
        {
            var output = new uint[16];
            for (int i = 0, idx = 0; i < 16; i++, idx += 2)
            {
                output[i] = RGB5A3.ToARGB8((ushort)(data[idx] << 8 | data[idx + 1]));
            }

            return output;
        }

        public static Bitmap CreateBitmap(int[] bitmapBuffer, int width = 32, int height = 32)
        {
            var bitmapData = new byte[bitmapBuffer.Length * 4];

            for (int i = 0, idx = 0; i < bitmapBuffer.Length; i++, idx += 4)
            {
                BitConverter.GetBytes(bitmapBuffer[i]).CopyTo(bitmapData, idx);
            }

            return CreateBitmap(bitmapData, width, height);
        }

        public static Bitmap CreateBitmap(byte[] bitmapBuffer, int width = 32, int height = 32)
        {
            var newBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bitmapData = newBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(bitmapBuffer, 0, bitmapData.Scan0, bitmapBuffer.Length);
            newBitmap.UnlockBits(bitmapData);
            return newBitmap;
        }

        public static int[] GetBitmapDataFromPng(string pngLocation, out int width, out int height)
        {
            width = 0;
            height = 0;
            try
            {
                byte[] bitmapBuffer;
                using (var stream = new MemoryStream())
                {
                    var img = Image.FromFile(pngLocation);
                    img.Save(stream, ImageFormat.Bmp);
                    bitmapBuffer = stream.ToArray();
                    img.Dispose();
                }

                var dataSize = bitmapBuffer[0x1C] / 8;
                width = BitConverter.ToInt32(bitmapBuffer, 0x12);
                height = BitConverter.ToInt32(bitmapBuffer, 0x16);

                if (dataSize < 3 || dataSize > 4)
                {
                    Console.WriteLine("Conversion Error: Image must have either 24bpp or 32bpp color depth!");
                    return null;
                }

                if (dataSize == 3 || dataSize == 4)
                {
                    var imageData = bitmapBuffer.Skip(BitConverter.ToInt32(bitmapBuffer.Skip(0xA).Take(4).ToArray(), 0)).ToArray();
                    var pixelData = new int[imageData.Length / dataSize];

                    for (var i = 0; i < pixelData.Length; i++)
                    {
                        var index = i * dataSize;
                        pixelData[i] = (imageData[index + 3] << 24) | (imageData[index + 2] << 16)
                                            | (imageData[index + 1] << 8) | imageData[index];
                    }

                    // Flip Vertically
                    Array.Reverse(pixelData);

                    // Flip Horizontally
                    for (int i = 0; i < pixelData.Length; i += width)
                        Array.Reverse(pixelData, i, width);

                    return pixelData;
                }

                return new int[0];
            }
            catch
            {
                Console.WriteLine("Conversion Error: Failed to open the image!");
                return null;
            }
        }
    }

    public static class StructReader
    {
        public static T ReadStruct<T>(Stream streamHandle, int readOffset = 0) where T : struct
        {
            var buffer = new byte[Utility.SizeOf<T>()];
            var structure = default(T);

            try
            {
                if (streamHandle.Length >= buffer.Length)
                {
                    streamHandle.Read(buffer, readOffset, buffer.Length);
                    var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    structure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                    handle.Free();
                }
            }
            catch
            {
                // ignored
            }

            return structure;
        }
    }

    public static class StructWriter
    {
        public static byte[] WriteStruct<T>(T structure, Stream streamHandle = null, int writeOffset = 0) where T : struct
        {
            try
            {
                var buffer = new byte[Utility.SizeOf<T>()];
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                Marshal.StructureToPtr(structure, handle.AddrOfPinnedObject(), false);
                handle.Free();

                streamHandle?.Write(buffer, writeOffset, buffer.Length);
                return buffer;
            }
            catch
            {
                return null;
            }
        }
    }
}
