using System.Collections.Generic;
using System.Drawing;

namespace Custom_Villager_Creator
{
    public static class VillagerDatabase
    {
        internal static readonly Dictionary<ModelType, Dictionary<string, Size>> VillagerTypeInfo = new Dictionary<ModelType, Dictionary<string, Size>>
        {
            { ModelType.Cat, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Head", new Size(32, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Feet", new Size(16, 16) },
                    { "Tail", new Size(16, 32) },
                }
            },
            { ModelType.Elephant, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Trunk", new Size(16, 32) },
                    { "Ears", new Size(16, 16) },
                    { "Head", new Size(16, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 16) },
                    { "Feet", new Size(16, 16) },
                }
            },
            { ModelType.Sheep, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Wool", new Size(32, 32) },
                    { "Horns", new Size(32, 16) },
                    { "Body", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 16) }
                }
            },
            { ModelType.Bear, new Dictionary<string, Size> // Check if tail exists
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Head", new Size(32, 32) },
                    { "Ears", new Size(16, 16) },
                    { "Arms", new Size(16, 16) }, // Verify that Arms & Legs are in the correct order
                    { "Legs", new Size(16, 16) },
                    { "Body", new Size(16, 16) }
                }
            },
            { ModelType.Dog, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Ears", new Size(16, 16) },
                    { "Body", new Size(32, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 16) },
                    { "Feet", new Size(16, 16) }
                }
            },
            { ModelType.Squirrel, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Ears (Front)", new Size(16, 08) },
                    { "Head", new Size(32, 32) },
                    { "Ears (Back)", new Size(16, 08) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(16, 32) }
                }
            },
            { ModelType.Rabbit, new Dictionary<string, Size> // Check this (Use Tiffany for best results)
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Ears (Front)", new Size(16, 16) },
                    { "Head", new Size(32, 32) },
                    { "Ears (Back)", new Size(16, 16) },
                    { "Arms & Tail", new Size(16, 16) }, // Check this (I'm not sure if Arms & Tail are in the same texture...)
                    { "Legs", new Size(16, 16) }
                }
            },
            { ModelType.Duck, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Bill (Lower)", new Size(16, 8) },
                    { "Head", new Size(32, 32) },
                    { "Bill (Upper)", new Size(16, 8) },
                    { "Arms", new Size(16, 16) },
                    { "Body", new Size(32, 8) },
                    { "Legs", new Size(16, 16) },
                }
            },
            { ModelType.Hippo, new Dictionary<string, Size> //
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Bottom)", new Size(16, 16) },
                    { "Mouth (Inner)", new Size(16, 16) },
                    { "Tusks", new Size(16, 8) },
                    { "Snout (Top)", new Size(16, 32) }, // Check this
                    { "Head & Mouth (Top)", new Size(16, 32) },
                    { "Neck", new Size(16, 8) },
                    { "Ears (Inner)", new Size(16, 8) },
                    { "Ears (Back)", new Size(16, 8) }, // Check this
                    { "Nostrils", new Size(16, 8) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(16, 8) }
                }
            },
            { ModelType.Wolf, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth", new Size(16, 16) },
                    { "Head", new Size(32, 32) },
                    { "Snout", new Size(16, 16) },
                    { "Ears", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 16) }
                }
            },
            { ModelType.Mouse, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Nose (Bottom)", new Size(16, 8) },
                    { "Nose (Top)", new Size(16, 8) },
                    { "Ears (Front)", new Size(16, 16) },
                    { "Head", new Size(32, 32) },
                    { "Ears (Back)", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(16, 8) }
                }
            },
            { ModelType.Pig, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Head", new Size(32, 32) },
                    { "Snout", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(32, 8) }
                }
            },
            { ModelType.Chicken, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Beak", new Size(16, 8) },
                    { "Comb", new Size(16, 8) },
                    { "Head", new Size(32, 32) },
                    { "Chin", new Size(32, 16) },
                    { "Wings", new Size(16, 8) },
                    { "Tail", new Size(16, 24) },
                    { "Legs & Feet", new Size(16, 8) }
                }
            },
            { ModelType.Bull, new Dictionary<string, Size> //
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Horns (Front)", new Size(16, 8) }, // Check that the horns are right
                    { "Horns (Back)", new Size(16, 8) },
                    { "Ears", new Size(16, 16) },
                    { "Head", new Size(16, 32) },
                    { "Nose", new Size(32, 16) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(32, 8) }
                }
            },
            { ModelType.Cow, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Horns", new Size(16, 8) },
                    { "Head", new Size(16, 48) },
                    { "Ears", new Size(16, 16) },
                    { "Nose", new Size(32, 16) },
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(32, 8) }
                }
            },
            { ModelType.Bird, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Beak", new Size(16, 8) },
                    { "Head", new Size(32, 32) },
                    { "Chin", new Size(32, 16) },
                    { "Wings", new Size(16, 8) },
                    { "Tail", new Size(16, 24) },
                    { "Legs & Feet", new Size(16, 8) },
                    { "Body", new Size(32, 8) }
                }
            },
            { ModelType.Frog, new Dictionary<string, Size> //
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Chin", new Size(32, 8) },
                    { "Head", new Size(32, 40) },
                    { "Arms", new Size(16, 16) }, // Verify Arms & Legs
                    { "Legs", new Size(16, 16) }
                }
            },
            { ModelType.Alligator, new Dictionary<string, Size> // Check Arms & Legs and Tail (I think that it's just Arms and Legs, and tail is part of body)
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Teeth", new Size(16, 8) },
                    { "Snout (Upper)", new Size(32, 16) },
                    { "Mouth", new Size(16, 8) },
                    { "Head", new Size(16, 48) },
                    { "Snout (Lower)", new Size(32, 16) },
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(16, 8) },
                    { "Body", new Size(32, 8) }
                }
            },
            { ModelType.Goat, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Beard", new Size(8, 8) },
                    { "Tail", new Size(8, 8) },
                    { "Head", new Size(32, 40) },
                    { "Hair", new Size(32, 8) },
                    { "Ears", new Size(16, 8) },
                    { "Horns", new Size(16, 8) },
                    { "Arms & Legs", new Size(16, 8) }
                }
            },
            { ModelType.Tiger, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth", new Size(16, 8) },
                    { "Snout", new Size(32, 16) },
                    { "Chin", new Size(32, 8) },
                    { "Head", new Size(32, 40) },
                    { "Ears", new Size(16, 8) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Tail", new Size(16, 16) }
                }
            },
            { ModelType.Anteater, new Dictionary<string, Size> //
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Nose", new Size(16, 16) }, // Verify nose & muzzle positions
                    { "Muzzle", new Size(16, 8) },
                    { "Ears", new Size(16, 8) },
                    { "Neck", new Size(48, 8) },
                    { "Head", new Size(32, 24) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 24) },
                    { "Legs", new Size(16, 16) }
                }
            },
            { ModelType.Koala, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Head (Top)", new Size(32, 8) },
                    { "Head (Back)", new Size(32, 40) },
                    { "Ears", new Size(32, 16) },
                    { "Arms & Legs", new Size(16, 16) }
                }
            },
            { ModelType.Horse, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Lower)", new Size(16, 16) },
                    { "Mouth (Upper)", new Size(16, 24) },
                    { "Head (Top)", new Size(32, 8) },
                    { "Muzzle", new Size(32, 8) },
                    { "Head (Back)", new Size(32, 32) },
                    { "Ears", new Size(16, 8) },
                    { "Neck", new Size(16, 16) },
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(16, 8) }
                }
            },
            { ModelType.Octopus, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth", new Size(16, 16) },
                    { "Head", new Size(16, 16) },
                    { "Lower Face", new Size(32, 16) },
                    { "Arms", new Size(16, 16) },
                    { "Legs", new Size(16, 16) }
                }
            },
            { ModelType.Lion, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Glasses", new Size(16, 8) },
                    { "Ears", new Size(16, 8) },
                    { "Head (Mane)", new Size(32, 40) },
                    { "Chin", new Size(32, 8) },
                    { "Head (Top)", new Size(32, 8) },
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(32, 8) }
                }
            },
            { ModelType.Cub, new Dictionary<string, Size> // 
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Left Ear", new Size(16, 16) },
                    { "Right Ear", new Size(16, 16) },
                    { "Body", new Size(16, 32) },
                    { "Arms", new Size(16, 16) },
                    { "Tail", new Size(16, 16) },
                    { "Feet", new Size(16, 16) }
                }
            },
            { ModelType.Rhino, new Dictionary<string, Size> //
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Horn (Head)", new Size(16, 8) }, // Check this (It's 100% not right)
                    { "Mouth (Inner)", new Size(16, 8) },
                    { "Horn (Small)", new Size(16, 8) },
                    { "Horn (Main)", new Size(16, 16) },
                    { "Head (Back)", new Size(32, 16) },
                    { "Head (Top)", new Size(32, 8) },
                    { "Ears (Inner)", new Size(16, 8) },
                    { "Ears (Back)", new Size(16, 8) },
                    { "Mouth (Bottom)", new Size(16, 8) }, // Check this too
                    { "Arms & Legs", new Size(16, 8) },
                    { "Tail", new Size(16, 8) }
                }
            },
            { ModelType.Gorilla, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth (Smile, Closed)", new Size(32, 16) },
                    { "Mouth (Smile, Opening)", new Size(32, 16) },
                    { "Mouth (Smile, Open)", new Size(32, 16) },
                    { "Mouth (Frown, Closed)", new Size(32, 16) },
                    { "Mouth (Frown, Opening)", new Size(32, 16) },
                    { "Mouth (Frown, Open)", new Size(32, 16) },
                    { "Mouth (Inside)", new Size(16, 8) },
                    { "Mouth (Lower)", new Size(16, 8) },
                    { "Head", new Size(32, 32) },
                    { "Ears", new Size(16, 8) },
                    { "Arms & Legs", new Size(16, 16) },
                    { "Body (Front)", new Size(16, 16) },
                    { "Body (Back)", new Size(16, 8) }
                }
            },
            { ModelType.Ostrich, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
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
            { ModelType.Kangaroo, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
                    { "Mouth", new Size(32, 8) },
                    { "Head", new Size(16, 32) },
                    { "Ears (Main)", new Size(16, 8) },
                    { "Snout", new Size(32, 16) },
                    { "Arms", new Size(16, 8) },
                    { "Ears (Joey)", new Size(16, 8) },
                    { "Tail", new Size(16, 8) },
                    { "Feet", new Size(32, 8) },
                    { "Pouch", new Size(16, 8) }
                }
            },
            { ModelType.Eagle, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
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
            { ModelType.Penguin, new Dictionary<string, Size>
                {
                    { "Eyes (Open)", new Size(32, 16) },
                    { "Eyes (Closing)", new Size(32, 16) },
                    { "Eyes (Closed)", new Size(32, 16) },
                    { "Eyes (Angry)", new Size(32, 16) },
                    { "Eyes (Sad)", new Size(32, 16) },
                    { "Eyes (Happy)", new Size(32, 16) },
                    { "Eyes (Surprised)", new Size(32, 16) },
                    { "Eyes (Crying)", new Size(32, 16) },
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
            return VillagerTypeInfo.ContainsKey(model) ? VillagerTypeInfo[model] : null;
        }

        public static int GetImageDataSize(ModelType model)
        {
            var size = 0;
            if (!VillagerTypeInfo.ContainsKey(model)) return size;
            foreach (var s in VillagerTypeInfo[model])
            {
                size += (s.Value.Width * s.Value.Height) / 2;
            }

            return size;
        }
    }
}
