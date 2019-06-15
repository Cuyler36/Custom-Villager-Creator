using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Custom_Villager_Creator
{
    public enum ModelType : byte
    {
        Cat = 0x00,
        Elephant = 0x01,
        Sheep = 0x02,
        Bear = 0x03,
        Dog = 0x04,
        Squirrel = 0x05,
        Rabbit = 0x06,
        Duck = 0x07,
        Hippo = 0x08,
        Wolf = 0x09,
        Mouse = 0x0A,
        Pig = 0x0B,
        Chicken = 0x0C,
        Bull = 0x0D,
        Cow = 0x0E,
        Bird = 0x0F,
        Frog = 0x10,
        Alligator = 0x11,
        Goat = 0x12,
        Tiger = 0x13,
        Anteater = 0x14,
        Koala = 0x15,
        Horse = 0x16,
        Octopus = 0x17,
        Lion = 0x18,
        Cub = 0x19,
        Rhino = 0x1A,
        Gorilla = 0x1B,
        Ostrich = 0x1C,
        Kangaroo = 0x1D,
        Eagle = 0x1E,
        Penguin = 0x1F
    }

    public enum ClothingCategory : byte
    {
        Cool = 0x00,
        Cute = 0x01,
        Funky = 0x02,
        Fresh = 0x03,
        Fancy = 0x04,
        Subtle = 0x05,
        Refined = 0x06,
        Gaudy = 0x07,
        Striking = 0x08,
        Strange = 0x09,
        Invalid = 0x0A
    }

    public enum PersonalityType : byte
    {
        Normal = 0,
        Peppy = 1,
        Lazy = 2,
        Jock = 3,
        Cranky = 4,
        Snooty = 5
    }

    public enum HouseType : byte
    {
        Cottage = 0,
        Cabin = 1,
        Cabana = 2,
        Barnhouse = 3,
        Brick = 4
    }

    public enum HousePalette : byte
    {
        Palette1 = 0,
        Palette2 = 1,
        Palette3 = 2,
        Palette4 = 3,
        Palette5 = 4,
        // There may be more valid palettes
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct DLCVillagerHeader
    {
        [FieldOffset(0x00)] public byte CardId;
        [FieldOffset(0x01)] public fixed byte Name[6];
        [FieldOffset(0x07)] public fixed byte Catchphrase[4];
        [FieldOffset(0x0B)] public ModelType Model;
        [FieldOffset(0x0C)] public byte IsIslander;
        [FieldOffset(0x0D)] public PersonalityType Personality;
        [FieldOffset(0x0E)] public byte ShirtId;
        [FieldOffset(0x0F)] public HouseType HouseStyle;
        [FieldOffset(0x10)] public HousePalette HousePalette;
        [FieldOffset(0x11)] public byte WallpaperId;
        [FieldOffset(0x12)] public byte CarpetId;
        [FieldOffset(0x13), Endianness(ByteOrder.BigEndian)] public ushort HouseRoomBaseLayerInfoId;
        [FieldOffset(0x15), Endianness(ByteOrder.BigEndian)] public ushort HouseRoomSecondLayerInfoId;
        [FieldOffset(0x17)] public byte UmbrellaId;
        [FieldOffset(0x18)] public byte SongId;
        [FieldOffset(0x19), Endianness(ByteOrder.BigEndian)] public ushort Unknown1;
        [FieldOffset(0x1B)] public ClothingCategory FavoriteClothingCategory;
        [FieldOffset(0x1C)] public ClothingCategory HatedClothingCategory;
        [FieldOffset(0x1D)] public ModelType Tribe; // Deals with the villager's favorite or least favorite animal type (I think it uses the same enum as model type)
        [FieldOffset(0x1E)] public byte Character; // Unknown
        [FieldOffset(0x1F)] public byte Constellation; // Zodiac sign
        [FieldOffset(0x20)] public byte Popular; // Popularity?
        [FieldOffset(0x21)] public byte Intelligence; // Unsure what this actually affects
        [FieldOffset(0x22)] public fixed byte Unknown2[3];
    }

    public class DLCVillager
    {
        public DLCVillagerHeader Header;
        public byte[] GBATextureData = new byte[0x800];
        public ushort[] GBAPalette = new ushort[16];
        public ushort[] Palette = new ushort[16]; // 16 RGB5A3 palette
        public byte[] TextureData; // varying length texture data

        public DLCVillager()
        {
            Header = new DLCVillagerHeader();
            unsafe
            {
                fixed (byte* name = Header.Name)
                {
                    Utility.DnMStringToBytePtr(name, "Animal", 6);
                }

                fixed (byte* catchphrase = Header.Catchphrase)
                {
                    Utility.DnMStringToBytePtr(catchphrase, "none", 4);
                }
            }

            Header.CardId = byte.MaxValue;
            Header.Model = ModelType.Cat;
            Header.HouseRoomBaseLayerInfoId = 0x1A0;
            Header.HouseRoomSecondLayerInfoId = 0x1A1;
            TextureData = new byte[VillagerDatabase.GetImageDataSize(Header.Model)];
        }

        public DLCVillager(Stream villagerFile)
        {
            using (var reader = new BinaryReader(villagerFile))
            {
                Header = StructReader.ReadStruct<DLCVillagerHeader>(villagerFile);
                //Header.HouseRoomBaseLayerInfoId = Header.HouseRoomBaseLayerInfoId.Reverse();
                //Header.HouseRoomSecondLayerInfoId = Header.HouseRoomSecondLayerInfoId.Reverse();

                if (Header.HouseRoomBaseLayerInfoId < 0x1A0)
                {
                    Header.HouseRoomBaseLayerInfoId = 0x1A0;
                }

                if (Header.HouseRoomSecondLayerInfoId < 0x1A0)
                {
                    Header.HouseRoomSecondLayerInfoId = 0x1A0;
                }

                //Header.Unknown1 = Header.Unknown1.Reverse(); // Swap endianness
                villagerFile.Seek(0x25, SeekOrigin.Begin);
                villagerFile.Read(GBATextureData, 0, 0x800);

                for (var i = 0; i < 16; i++)
                {
                    GBAPalette[i] = reader.ReadUInt16().Reverse();
                }

                // Test
                var outputLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "AFe_GBA_Textures");
                Directory.CreateDirectory(outputLocation);

                for (var i = 0; i < 16; i++)
                {
                    var texture = new GBATexture(GBATextureData.Skip(i * 0x80).Take(0x80).ToArray(), GBAPalette,
                        new Size(16, 16));

                    texture.Texture.Save(Path.Combine(outputLocation, $"Texture_{i}.png"), ImageFormat.Png);
                }

                // Dump palette.
                var gbaPalette = GBAPalette.Select(GCNToolKit.Formats.Colors.RGB5A3.ToARGB8).Select(c => Color.FromArgb((int)c)).ToArray();
                var bmp = new Bitmap(32, 32 * 16);
                for (var i = 0; i < 16; i++)
                {
                    for (var y = 0; y < 32; y++)
                    {
                        for (var x = 0; x < 32; x++)
                        {
                            bmp.SetPixel(x, y + i * 32, gbaPalette[i]);
                        }
                    }
                }

                bmp.Save(Path.Combine(outputLocation, "Palette.png"), ImageFormat.Png);
                bmp.Dispose();

                villagerFile.Seek(0x845, SeekOrigin.Begin);
                for (var i = 0; i < 16; i++)
                {
                    Palette[i] = reader.ReadUInt16().Reverse();
                }

                TextureData = new byte[villagerFile.Length - 0x865];
                villagerFile.Seek(0x865, SeekOrigin.Begin);
                villagerFile.Read(TextureData, 0, TextureData.Length);
            }
        }
    }
}