using System;

namespace Custom_Villager_Creator
{
    public enum ByteOrder
    {
        LittleEndian = 0,
        BigEndian = 1
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Endianness : Attribute
    {
        public ByteOrder ByteOrder;

        public Endianness(ByteOrder byteOrder)
        {
            ByteOrder = byteOrder;
        }
    }
}
