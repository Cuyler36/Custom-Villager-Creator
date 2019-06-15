using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Custom_Villager_Creator
{
    public static class DataExtensions
    {
        public static unsafe T ToStruct<T>(this IEnumerable<byte> buffer, int offset = 0) where T : struct
        {
            if (buffer == null) throw new ArgumentNullException($"{nameof(buffer)} cannot be null!");
            if (offset < 0) throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot be less than 0!");

            byte[] bufferAsArray;

            if (buffer is byte[] localBuffer)
            {
                bufferAsArray = localBuffer;
            }
            else
            {
                bufferAsArray = buffer.ToArray();
            }

            T structure;
            fixed (byte* bufferPointer = bufferAsArray)
            {
                structure = Marshal.PtrToStructure<T>((IntPtr)bufferPointer + offset);
            }

            // Sort endianness
            object boxedStruct = structure;
            foreach (var property in typeof(T).GetFields())
            {
                if (property.GetCustomAttribute<Endianness>(true)?.ByteOrder != ByteOrder.BigEndian) continue;

                var value = System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(
                    (dynamic) property.GetValue(boxedStruct));
                property.SetValue(boxedStruct, value);
            }

            return (T) boxedStruct;
        }

        public static unsafe IEnumerable<byte> ToBytes<T>(this T structure) where T : struct
        {
            var buffer = new byte[Marshal.SizeOf<T>()];

            fixed (byte* bufferPointer = buffer)
            {
                Marshal.StructureToPtr(structure, (IntPtr)bufferPointer, false);
            }

            // Sort endianness
            foreach (var property in typeof(T).GetProperties())
            {
                var attributes = (Endianness[]) property.GetCustomAttributes(typeof(Endianness), false);
                foreach (var attribute in attributes)
                {
                    Console.WriteLine($"{property.Name}, {attribute.ByteOrder}");
                }
            }

            return buffer;
        }
    }
}
