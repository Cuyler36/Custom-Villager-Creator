using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Villager_Creator
{
    public class GBATexture
    {
        private ushort[] _palette;
        private byte[] _rawData;

        public Bitmap Texture { get; protected set; }
        public Size Size { get; protected set; }

        public ushort[] RawPalette
        {
            get => _palette;
            set
            {
                _palette = value;
                // Regenerate bitmap.
            }
        }

        public Color[] Palette { get; protected set; }

        public GBATexture(in byte[] data, in ushort[] palette, in Size textureSize)
        {
            if (palette.Length != 16)
                throw new ArgumentException($"{nameof(palette)} didn't have 16 palette entries!");

            var pixelData = _rawData = GCNToolKit.Utilities.Utilities.SeparateNibbles(data);

            // Sanity check the total size vs. the data array length.
            if (textureSize.Width * textureSize.Height != pixelData.Length)
                throw new ArgumentException(
                    $"{nameof(textureSize)} has an invalid size. Data has info for {pixelData.Length} pixels, " +
                    $"but size says there should be {textureSize.Height * textureSize.Width} pixels!");

            Size = textureSize;

            // Convert our RGB5A1 colors into RGBA8.
            Palette = palette.Select(GCNToolKit.Formats.Colors.RGB5.ToARGB8).Select(c => Color.FromArgb((int) c)).ToArray();

            // Generate the bitmap.
            GenerateTexture();
        }

        ~GBATexture()
        {
            Texture?.Dispose();
        }

        private void GenerateTexture()
        {
            Texture?.Dispose();

            Texture = new Bitmap(Size.Width, Size.Height);
            var idx = 0;
            for (var y = 0; y < Texture.Height; y++)
            {
                for (var x = 0; x < Texture.Width; x++, idx++)
                {
                    Texture.SetPixel(x, y, Palette[_rawData[idx]]);
                }
            }
        }
    }
}
