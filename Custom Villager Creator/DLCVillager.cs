using System;
using System.IO;
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
        [FieldOffset(0x13)] public ushort HouseRoomBaseLayerInfoId;
        [FieldOffset(0x15)] public ushort HouseRoomSecondLayerInfoId;
        [FieldOffset(0x17)] public byte UmbrellaId;
        [FieldOffset(0x18)] public byte SongId;
        [FieldOffset(0x19)] public ushort Unknown1;
        [FieldOffset(0x1B)] public ClothingCategory FavoriteClothingCategory;
        [FieldOffset(0x1C)] public ClothingCategory HatedClothingCategory;
        [FieldOffset(0x1D)] public byte Tribe; // Deals with the villager's favorite or least favorite animal type (I think it uses the same enum as model type)
        [FieldOffset(0x1E)] public byte Character; // Unknown
        [FieldOffset(0x1F)] public byte Constellation; // Zodiac sign
        [FieldOffset(0x20)] public byte Popular; // Popularity?
        [FieldOffset(0x21)] public byte Intelligence; // Unsure what this actually affects
        [FieldOffset(0x22)] public fixed byte Unknown2[3];
    }

    public class DLCVillager
    {
        public DLCVillagerHeader Header;
        public byte[] UnknownTextureData = new byte[0x820]; // 0x820 bytes (might be the GBA texture?)
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
            TextureData = new byte[VillagerDatabase.GetImageDataSize(Header.Model)];
        }

        public DLCVillager(Stream villagerFile)
        {
            Header = StructReader.ReadStruct<DLCVillagerHeader>(villagerFile);
            Header.HouseRoomBaseLayerInfoId = Header.HouseRoomBaseLayerInfoId.Reverse();
            Header.HouseRoomSecondLayerInfoId = Header.HouseRoomSecondLayerInfoId.Reverse();
            Header.Unknown1 = Header.Unknown1.Reverse(); // Swap endianness
            villagerFile.Seek(0x25, SeekOrigin.Begin);
            villagerFile.Read(UnknownTextureData, 0, 0x820);
            villagerFile.Seek(0x845, SeekOrigin.Begin);
            for (var i = 0; i < 16; i++)
            {
                Palette[i] = (ushort)(villagerFile.ReadByte() << 8 | villagerFile.ReadByte());
            }

            TextureData = new byte[villagerFile.Length - 0x865];
            villagerFile.Seek(0x865, SeekOrigin.Begin);
            villagerFile.Read(TextureData, 0, TextureData.Length);
        }
    }
}