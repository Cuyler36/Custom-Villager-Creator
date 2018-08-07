using System.Drawing;
using System.Windows.Controls;
using GCNToolKit.Formats.Images;

namespace Custom_Villager_Creator
{
    internal class TextureEntry
    {
        public Bitmap Texture;
        public ushort[] Palette;
        public uint[] Rgba8Palette;
        public int[] Argb8Data;
        public byte[] RawData; // Data is in C4 format
        public int TextureOffset;
        public int Width;
        public int Height;
        public string TextureName;
        public TreeViewItem TreeViewItem;
        public int EntryIndex;

        public TextureEntry(int textureOffset, int width, int height, byte[] textureData, ref ushort[] paletteData, ref uint[] rgba8Palette, int index)
        {
            TextureOffset = textureOffset;
            Width = width;
            Height = height;
            Palette = paletteData;
            Rgba8Palette = rgba8Palette;
            RawData = textureData;
            Argb8Data = C4.DecodeC4(textureData, Palette, width, height);
            Texture = Utility.CreateBitmap(Argb8Data, width, height);
            EntryIndex = index;
        }

        public void Dispose()
        {
            Texture?.Dispose();
        }
    }
}
