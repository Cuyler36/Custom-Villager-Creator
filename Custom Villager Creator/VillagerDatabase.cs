using System.Collections.Generic;
using System.Drawing;

namespace Custom_Villager_Creator
{
    public static class VillagerDatabase
    {
        internal static readonly Dictionary<string, Dictionary<string, Size>> VillagerTypeInfo = new Dictionary<string, Dictionary<string, Size>>
        {
            { "Cat", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth 1", new Size(32, 16) },
                    { "Mouth 2", new Size(32, 16) },
                    { "Mouth 3", new Size(32, 16) },
                    { "Mouth 4", new Size(32, 16) },
                    { "Mouth 5", new Size(32, 16) },
                    { "Mouth 6", new Size(32, 16) },
                    { "Head", new Size(32, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Feet", new Size(16, 16) },
                    { "Tail", new Size(16, 32) },
                }
            },
            { "Elephant", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth 1", new Size(32, 16) },
                    { "Mouth 2", new Size(32, 16) },
                    { "Mouth 3", new Size(32, 16) },
                    { "Mouth 4", new Size(32, 16) },
                    { "Mouth 5", new Size(32, 16) },
                    { "Mouth 6", new Size(32, 16) },
                    { "Trunk", new Size(16, 32) },
                    { "Ears", new Size(16, 16) },
                    { "Head", new Size(16, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 16) },
                    { "Feet", new Size(16, 16) },
                }
            },
            { "Sheep", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth 1", new Size(32, 16) },
                    { "Mouth 2", new Size(32, 16) },
                    { "Mouth 3", new Size(32, 16) },
                    { "Mouth 4", new Size(32, 16) },
                    { "Mouth 5", new Size(32, 16) },
                    { "Mouth 6", new Size(32, 16) },
                    { "Wool", new Size(32, 32) },
                    { "Horns", new Size(32, 16) },
                    { "Body", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 16) }
                }
            },
            { "Dog", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth 1", new Size(32, 16) },
                    { "Mouth 2", new Size(32, 16) },
                    { "Mouth 3", new Size(32, 16) },
                    { "Mouth 4", new Size(32, 16) },
                    { "Mouth 5", new Size(32, 16) },
                    { "Mouth 6", new Size(32, 16) },
                    { "Ears", new Size(16, 16) },
                    { "Body", new Size(32, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 16) },
                    { "Feet", new Size(16, 16) }
                }
            },
            { "Squirrel", new Dictionary<string, Size> // 
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth 1", new Size(32, 16) },
                    { "Mouth 2", new Size(32, 16) },
                    { "Mouth 3", new Size(32, 16) },
                    { "Mouth 4", new Size(32, 16) },
                    { "Mouth 5", new Size(32, 16) },
                    { "Mouth 6", new Size(32, 16) },
                    { "Ears", new Size(16, 08) },
                    { "Head", new Size(32, 32) },
                    { "Body", new Size(16, 08) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 32) }
                }
            },
            { "Cub", new Dictionary<string, Size> // 
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth 1", new Size(32, 16) },
                    { "Mouth 2", new Size(32, 16) },
                    { "Mouth 3", new Size(32, 16) },
                    { "Mouth 4", new Size(32, 16) },
                    { "Mouth 5", new Size(32, 16) },
                    { "Mouth 6", new Size(32, 16) },
                    { "Left Ear", new Size(16, 16) },
                    { "Right Ear", new Size(16, 16) },
                    { "Body", new Size(16, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 16) },
                    { "Feet", new Size(16, 16) }
                }
            },
            { "Penguin", new Dictionary<string, Size> // 
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth Closed", new Size(16, 8) },
                    { "Mouth Open", new Size(16, 8) },
                    { "Head", new Size(32, 16) },
                    { "Body", new Size(32, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(32, 8) }, // Not a tail. Might be two 16 * 8 things.
                    { "Feet", new Size(16, 16) },
                    { "Bottom Right", new Size(16, 8) },
                    { "Bottom Left", new Size(16, 8) }
                }
            }
        };

        public static int DataSizeFromSize(Size size)
        {
            return (size.Width * size.Height) / 2;
        }

        public static Dictionary<string, Size> GetImageData(ModelType model)
        {
            var modelString = model.ToString();
            return VillagerTypeInfo.ContainsKey(modelString) ? VillagerTypeInfo[modelString] : null;
        }

        public static int GetImageDataSize(ModelType model)
        {
            var modelString = model.ToString();
            var size = 0;
            if (!VillagerTypeInfo.ContainsKey(modelString)) return size;
            foreach (var s in VillagerTypeInfo[modelString])
            {
                size += (s.Value.Width * s.Value.Height) / 2;
            }

            return size;
        }
    }
}
