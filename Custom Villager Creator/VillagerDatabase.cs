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
            { "Squirrel", new Dictionary<string, Size>
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
                    { "Ears (Front)", new Size(16, 08) },
                    { "Head", new Size(32, 32) },
                    { "Ears (Back)", new Size(16, 08) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(16, 32) }
                }
            },
            { "Duck", new Dictionary<string, Size>
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
                    { "Bill (Lower)", new Size(16, 8) },
                    { "Head", new Size(32, 32) },
                    { "Bill (Upper)", new Size(16, 8) },
                    { "Arms", new Size(16, 16) },
                    { "Body", new Size(32, 8) },
                    { "Legs", new Size(16, 16) },
                }
            },
            { "Wolf", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth", new Size(16, 16) },
                    { "Head", new Size(32, 32) },
                    { "Snout", new Size(16, 16) },
                    { "Ears", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 16) }
                }
            },
            { "Tiger", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth", new Size(16, 8) },
                    { "Snout", new Size(32, 16) },
                    { "Chin", new Size(32, 8) },
                    { "Head", new Size(32, 40) },
                    { "Ears", new Size(16, 8) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(16, 16) }
                }
            },
            { "Octopus", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Mouth", new Size(16, 16) },
                    { "Head", new Size(16, 16) },
                    { "Lower Face", new Size(32, 16) },
                    { "Arms", new Size(16, 16) },
                    { "Legs", new Size(16, 16) }
                }
            },
            { "Lion", new Dictionary<string, Size>
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
                    { "Glasses", new Size(16, 8) },
                    { "Ears", new Size(16, 8) },
                    { "Head (Mane)", new Size(32, 40) },
                    { "Chin", new Size(32, 8) },
                    { "Head (Top)", new Size(32, 8) },
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(32, 8) }
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
            { "Ostrich", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Beak", new Size(16, 8) },
                    { "Hair", new Size(16, 16) },
                    { "Lower Face", new Size(32, 16) },
                    { "Head", new Size(32, 32) },
                    { "Arms", new Size(16, 8) },
                    { "Tail", new Size(16, 24) },
                    { "Feet", new Size(16, 8) },
                    { "Body", new Size(16, 8) }
                }
            },
            { "Eagle", new Dictionary<string, Size>
            {
                { "Eyes 1", new Size(32, 16) },
                { "Eyes 2", new Size(32, 16) },
                { "Eyes 3", new Size(32, 16) },
                { "Eyes 4", new Size(32, 16) },
                { "Eyes 5", new Size(32, 16) },
                { "Eyes 6", new Size(32, 16) },
                { "Eyes 7", new Size(32, 16) },
                { "Eyes 8", new Size(32, 16) },
                { "Inner Beak", new Size(16, 8) },
                { "Head", new Size(16, 32) },
                { "Neck", new Size(48, 16) },
                { "Outer Beak", new Size(16, 16) },
                { "Arms", new Size(16, 8) },
                { "Tail", new Size(16, 24) },
                { "Feet", new Size(16, 8) },
                { "Legs", new Size(16, 8) },
                { "Body", new Size(16, 8) }
            }
        },
            { "Penguin", new Dictionary<string, Size>
                {
                    { "Eyes 1", new Size(32, 16) },
                    { "Eyes 2", new Size(32, 16) },
                    { "Eyes 3", new Size(32, 16) },
                    { "Eyes 4", new Size(32, 16) },
                    { "Eyes 5", new Size(32, 16) },
                    { "Eyes 6", new Size(32, 16) },
                    { "Eyes 7", new Size(32, 16) },
                    { "Eyes 8", new Size(32, 16) },
                    { "Beak", new Size(32, 8) },
                    { "Head (Back)", new Size(32, 16) },
                    { "Body", new Size(32, 16) }, // Check this size (Might be two separate things)
                    { "Eyebrows", new Size(32, 16) },
                    { "Arms", new Size(16, 16) },
                    { "Head (Top)", new Size(32, 8) },
                    { "Feet", new Size(16, 16) },
                    { "Stomach", new Size(32, 8) }
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
