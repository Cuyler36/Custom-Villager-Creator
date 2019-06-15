using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Villager_Creator
{
    public class BinaryReaderX : BinaryReader
    {
        public ByteOrder ByteOrder = ByteOrder.LittleEndian;

        public long Position
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }

        public BinaryReaderX(Stream input) : base(input) { }

        public BinaryReaderX(Stream input, ByteOrder byteOrder) : this(input)
        {
            ByteOrder = byteOrder;
        }

        public long Seek(long offset, SeekOrigin origin = SeekOrigin.Begin) => BaseStream.Seek(offset, origin);

        public override short ReadInt16() =>
            ByteOrder == ByteOrder.BigEndian ? base.ReadInt16().Reverse() : base.ReadInt16();

        public override ushort ReadUInt16() =>
            ByteOrder == ByteOrder.BigEndian ? base.ReadUInt16().Reverse() : base.ReadUInt16();

        public override int ReadInt32() =>
            ByteOrder == ByteOrder.BigEndian ? base.ReadInt32().Reverse() : base.ReadInt32();

        public override uint ReadUInt32() =>
            ByteOrder == ByteOrder.BigEndian ? base.ReadUInt32().Reverse() : base.ReadUInt32();

        public override long ReadInt64() =>
            ByteOrder == ByteOrder.BigEndian ? base.ReadInt64().Reverse() : base.ReadInt64();

        public override ulong ReadUInt64() =>
            ByteOrder == ByteOrder.BigEndian ? base.ReadUInt64().Reverse() : base.ReadUInt64();

        public T ReadStruct<T>() where T : struct => ReadBytes(Marshal.SizeOf<T>()).ToStruct<T>();
    }
}
