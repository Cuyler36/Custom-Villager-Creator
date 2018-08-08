﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Villager_Creator
{
    public static class Static
    {
        #region ItemNames

        public static readonly string[] ShirtNames =
        {
            "flame shirt",
            "paw shirt",
            "wavy pink shirt",
            "future shirt",
            "bold check shirt",
            "mint gingham",
            "bad plaid shirt",
            "speedway shirt",
            "folk shirt",
            "daisy shirt",
            "wavy tan shirt",
            "optical shirt",
            "rugby shirt",
            "sherbet gingham",
            "yellow tartan",
            "gelato shirt",
            "work uniform",
            "patched shirt",
            "plum kimono",
            "somber robe",
            "red sweatsuit",
            "blue sweatsuit",
            "red puffy vest",
            "blue puffy vest",
            "summer robe",
            "bamboo robe",
            "red aloha shirt",
            "blue aloha shirt",
            "dark polka shirt",
            "lite polka shirt",
            "lovely shirt",
            "citrus shirt",
            "kiwi shirt",
            "watermelon shirt",
            "strawberry shirt",
            "grape shirt",
            "melon shirt",
            "Jingle shirt",
            "blossom shirt",
            "icy shirt",
            "crewel shirt",
            "tropical shirt",
            "ribbon shirt",
            "fall plaid shirt",
            "fiendish shirt",
            "chevron shirt",
            "ladybug shirt",
            "botanical shirt",
            "Anju's shirt",
            "Kaffe's shirt",
            "lavender robe",
            "blue grid shirt",
            "butterfly shirt",
            "blue tartan",
            "Gracie's top",
            "orange tie-dye",
            "purple tie-dye",
            "green tie-dye",
            "blue tie-dye",
            "red tie-dye",
            "one-ball shirt",
            "two-ball shirt",
            "three-ball shirt",
            "four-ball shirt",
            "five-ball shirt",
            "six-ball shirt",
            "seven-ball shirt",
            "eight-ball shirt",
            "nine-ball shirt",
            "arctic camo",
            "jungle camo",
            "desert camo",
            "rally shirt",
            "racer shirt",
            "racer 6 shirt",
            "fish bone shirt",
            "spiderweb shirt",
            "zipper shirt",
            "bubble shirt",
            "yellow bolero",
            "nebula shirt",
            "neo-classic knit",
            "noble shirt",
            "turnip top",
            "oft-seen print",
            "ski sweater",
            "circus shirt",
            "patchwork top",
            "mod top",
            "hippie shirt",
            "rickrack shirt",
            "diner uniform",
            "shirt circuit",
            "U R here shirt",
            "yodel shirt",
            "pulse shirt",
            "prism shirt",
            "star shirt",
            "straw shirt",
            "noodle shirt",
            "dice shirt",
            "kiddie shirt",
            "frog shirt",
            "moody blue shirt",
            "cloudy shirt",
            "fortune shirt",
            "skull shirt",
            "desert shirt",
            "aurora knit",
            "winter sweater",
            "go-go shirt",
            "jade check print",
            "blue check print",
            "red grid shirt",
            "flicker shirt",
            "floral knit",
            "rose shirt",
            "sunset top",
            "chain-gang shirt",
            "spring shirt",
            "bear shirt",
            "MVP shirt",
            "silk bloom shirt",
            "pop bloom shirt",
            "loud bloom shirt",
            "hot spring shirt",
            "new spring shirt",
            "deep blue tee",
            "snowcone shirt",
            "ugly shirt",
            "sharp outfit",
            "painter's smock",
            "spade shirt",
            "blossoming shirt",
            "peachy shirt",
            "static shirt",
            "rainbow shirt",
            "groovy shirt",
            "loud line shirt",
            "dazed shirt",
            "red bar shirt",
            "blue stripe knit",
            "earthy knit",
            "spunky knit",
            "deer shirt",
            "blue check shirt",
            "light line shirt",
            "blue pinstripe",
            "diamond shirt",
            "lime line shirt",
            "big bro's shirt",
            "green bar shirt",
            "yellow bar shirt",
            "monkey shirt",
            "polar fleece",
            "ancient knit",
            "fish knit",
            "vertigo shirt",
            "misty shirt",
            "stormy shirt",
            "red scale shirt",
            "blue scale shirt",
            "heart shirt",
            "yellow pinstripe",
            "club shirt",
            "li'l bro's shirt",
            "argyle knit",
            "caveman tunic",
            "caf| shirt",
            "tiki shirt",
            "A shirt",
            "checkered shirt",
            "No.1 shirt",
            "No.2 shirt",
            "No.3 shirt",
            "No.4 shirt",
            "No.5 shirt",
            "No.23 shirt",
            "No.67 shirt",
            "BB shirt",
            "beatnik shirt",
            "moldy shirt",
            "houndstooth tee",
            "big star shirt",
            "orange pinstripe",
            "twinkle shirt",
            "funky dot shirt",
            "crossing shirt",
            "splendid shirt",
            "jagged shirt",
            "denim shirt",
            "cherry shirt",
            "gumdrop shirt",
            "barber shirt",
            "concierge shirt",
            "fresh shirt",
            "far-out shirt",
            "dawn shirt",
            "striking outfit",
            "red check shirt",
            "berry gingham",
            "lemon gingham",
            "dragon suit",
            "G logo shirt",
            "tin shirt",
            "jester shirt",
            "pink tartan",
            "waffle shirt",
            "gray tartan",
            "windsock shirt",
            "trendy top",
            "green ring shirt",
            "white ring shirt",
            "snappy print",
            "chichi print",
            "wave print",
            "checkerboard tee",
            "subdued print",
            "airy shirt",
            "coral shirt",
            "leather jerkin",
            "zebra print",
            "tiger print",
            "cow print",
            "leopard print",
            "danger shirt",
            "big dot shirt",
            "puzzling shirt",
            "exotic shirt",
            "houndstooth knit",
            "uncommon shirt",
            "dapper shirt",
            "gaudy sweater",
            "cozy sweater",
            "comfy sweater",
            "classic top",
            "vogue top",
            "laced shirt",
            "natty shirt",
            "citrus gingham",
            "cool shirt",
            "dreamy shirt",
            "flowery shirt",
            "caterpillar tee",
            "shortcake shirt",
            "whirly shirt",
            "thunder shirt",
            "giraffe print",
            "swell shirt",
            "toad print",
            "grass shirt",
            "mosaic shirt",
            "fetching outfit",
            "snow shirt",
            "melon gingham",
            "mannequin shirt"
        };

        public static readonly string[] MinidiskNames =
        {
            "K.K. Chorale",
            "K.K. March",
            "K.K. Waltz",
            "K.K. Swing",
            "K.K. Jazz",
            "K.K. Fusion",
            "K.K. Etude",
            "K.K. Lullaby",
            "K.K. Aria",
            "K.K. Samba",
            "K.K. Bossa",
            "K.K. Calypso",
            "K.K. Salsa",
            "K.K. Mambo",
            "K.K. Reggae",
            "K.K. Ska",
            "K.K. Tango",
            "K.K. Faire",
            "Aloha K.K.",
            "Lucky K.K.",
            "K.K. Condor",
            "K.K. Steppe",
            "Imperial K.K.",
            "K.K. Casbah",
            "K.K. Safari",
            "K.K. Folk",
            "K.K. Rock",
            "Rockin' K.K.",
            "K.K. Ragtime",
            "K.K. Gumbo",
            "The K. Funk",
            "K.K. Blues",
            "Soulful K.K.",
            "K.K. Soul",
            "K.K. Cruisin'",
            "K.K. Love Song",
            "K.K. D & B",
            "K.K. Technopop",
            "DJ K.K.",
            "Only Me",
            "K.K. Country",
            "Surfin' K.K.",
            "K.K. Ballad",
            "Comrade K.K.",
            "K.K. Lament",
            "Go K.K. Rider!",
            "K.K. Dirge",
            "K.K. Western",
            "Mr. K.K.",
            "Cafe K.K.",
            "K.K. Parade",
            "Senor K.K.",
            "My Place",
            "Forest Life",
            "To the Edge",
            "K.K. Song",
            "I Love You",
            "Two Days Ago",
            "K.K. Marathon",
            "Pondering",
            "K.K. Rockabilly",
            "K.K. Dixie",
            "K.K. Metal",
            "King K.K.",
            "K.K. Rally",
            "Agent K.K.",
            "Marine Song 2001",
            "Neapolitan",
            "Mountain Song",
            "Steep Hill",
            "K.K. Chorale (instrumental)",
            "K.K. March (instrumental)",
            "K.K. Waltz (instrumental)",
            "K.K. Swing (instrumental)",
            "K.K. Jazz (instrumental)",
            "K.K. Fusion (instrumental)",
            "K.K. Etude (instrumental)",
            "K.K. Lullaby (instrumental)",
            "K.K. Aria (instrumental)",
            "K.K. Samba (instrumental)",
            "K.K. Bossa (instrumental)",
            "K.K. Calypso (instrumental)",
            "K.K. Salsa (instrumental)",
            "K.K. Mambo (instrumental)",
            "K.K. Reggae (instrumental)",
            "K.K. Ska (instrumental)",
            "K.K. Tango (instrumental)",
            "K.K. Faire (instrumental)",
            "Aloha K.K. (instrumental)",
            "Lucky K.K. (instrumental)",
            "K.K. Condor (instrumental)",
            "K.K. Steppe (instrumental)",
            "Imperial K.K. (instrumental)",
            "K.K. Casbah (instrumental)",
            "K.K. Safari (instrumental)",
            "K.K. Folk (instrumental)",
            "K.K. Rock (instrumental)",
            "Rockin' K.K. (instrumental)",
            "K.K. Ragtime (instrumental)",
            "K.K. Gumbo (instrumental)",
            "The K. Funk (instrumental)",
            "K.K. Blues (instrumental)",
            "Soulful K.K. (instrumental)",
            "K.K. Soul (instrumental)",
            "K.K. Cruisin' (instrumental)",
            "K.K. Love Song (instrumental)",
            "K.K. D & B (instrumental)",
            "K.K. Technopop (instrumental)",
            "DJ K.K. (instrumental)",
            "Only Me (instrumental)",
            "K.K. Country (instrumental)",
            "Surfin' K.K. (instrumental)",
            "K.K. Ballad (instrumental)",
            "Comrade K.K. (instrumental)",
            "K.K. Lament (instrumental)",
            "Go K.K. Rider! (instrumental)",
            "K.K. Dirge (instrumental)",
            "K.K. Western (instrumental)",
            "Mr. K.K. (instrumental)",
            "Cafe K.K. (instrumental)",
            "K.K. Parade (instrumental)",
            "Senor K.K. (instrumental)",
            "My Place (instrumental)",
            "Forest Life (instrumental)",
            "To the Edge (instrumental)",
            "K.K. Song (instrumental)",
            "I Love You (instrumental)",
            "Two Days Ago (instrumental)",
            "K.K. Marathon (instrumental)",
            "Pondering (instrumental)",
            "K.K. Rockabilly (instrumental)",
            "K.K. Dixie (instrumental)",
            "K.K. Metal (instrumental)",
            "King K.K. (instrumental)",
            "K.K. Rally (instrumental)",
            "Agent K.K. (instrumental)",
            "Marine Song 2001 (instrumental)",
            "Neapolitan (instrumental)",
            "Mountain Song (instrumental)",
            "Steep Hill (instrumental)"
        };

        public static readonly string[] WallpaperNames =
        {
            "chic wall",
            "classic wall",
            "parlor wall",
            "stone wall",
            "blue-trim wall",
            "plaster wall",
            "classroom wall",
            "lovely wall",
            "exotic wall",
            "mortar wall",
            "gold screen wall",
            "tea room wall",
            "citrus wall",
            "cabin wall",
            "blue tarp",
            "lunar horizon",
            "garden wall",
            "spooky wall",
            "western vista",
            "green wall",
            "blue wall",
            "regal wall",
            "ranch wall",
            "modern wall",
            "cabana wall",
            "snowman wall",
            "backyard fence",
            "music room wall",
            "plaza wall",
            "lattice wall",
            "ornate wall",
            "modern screen",
            "bamboo wall",
            "kitchen wall",
            "old brick wall",
            "stately wall",
            "imperial wall",
            "manor wall",
            "ivy wall",
            "mod wall",
            "rose wall",
            "wood paneling",
            "concrete wall",
            "office wall",
            "ancient wall",
            "exquisite wall",
            "sandlot wall",
            "jingle wall",
            "meadow vista",
            "tree-lined wall",
            "mosaic wall",
            "arched window",
            "basement wall",
            "backgammon wall",
            "kiddie wall",
            "shanty wall",
            "industrial wall",
            "desert vista",
            "library wall",
            "floral wall",
            "tropical vista",
            "playroom wall",
            "kitschy wall",
            "groovy wall",
            "mushroom mural",
            "ringside seating",
            "harvest wall",
            "bathhouse wall",
            "japanese wall"
        };

        public static readonly string[] CarpetNames =
        {
            "plush carpet",
            "classic carpet",
            "checkered tile",
            "old flooring",
            "red tile",
            "birch flooring",
            "classroom floor",
            "lovely carpet",
            "exotic rug",
            "mossy carpet",
            "18 mat tatami",
            "8 mat tatami",
            "citrus carpet",
            "cabin rug",
            "closed road",
            "lunar surface",
            "sand garden",
            "spooky carpet",
            "western desert",
            "green rug",
            "blue flooring",
            "regal carpet",
            "ranch flooring",
            "modern tile",
            "cabana flooring",
            "snowman carpet",
            "backyard lawn",
            "music room floor",
            "plaza tile",
            "kitchen tile",
            "ornate rug",
            "tatami floor",
            "bamboo flooring",
            "kitchen flooring",
            "charcoal tile",
            "stone tile",
            "imperial tile",
            "opulent rug",
            "slate flooring",
            "ceramic tile",
            "fancy carpet",
            "cowhide rug",
            "steel flooring",
            "office flooring",
            "ancient tile",
            "exquisite rug",
            "sandlot",
            "jingle carpet",
            "daisy meadow",
            "sidewalk",
            "mosaic tile",
            "parquet floor",
            "basement floor",
            "chessboard rug",
            "kiddie carpet",
            "shanty mat",
            "concrete floor",
            "saharah's desert",
            "tartan rug",
            "palace tile",
            "tropical floor",
            "playroom rug",
            "kitschy tile",
            "diner tile",
            "block flooring",
            "boxing ring mat",
            "harvest rug",
            "bathhouse tile",
            "japanese floor"
        };

        public static readonly string[] ToolNames =
        {
            "gelato umbrella",
            "daffodil parasol",
            "berry umbrella",
            "orange umbrella",
            "mod umbrella",
            "petal parasol",
            "ribbon parasol",
            "gingham parasol",
            "plaid parasol",
            "lacy parasol",
            "elegant umbrella",
            "dainty parasol",
            "classic umbrella",
            "nintendo parasol",
            "bumbershoot",
            "sunny parasol",
            "batbrella",
            "checked umbrella",
            "yellow umbrella",
            "leaf umbrella",
            "lotus parasol",
            "paper parasol",
            "polka parasol",
            "sharp umbrella",
            "twig parasol",
            "noodle parasol",
            "hypno parasol",
            "pastel parasol",
            "retro umbrella",
            "icy umbrella",
            "blue umbrella",
            "flame umbrella",
            "pattern #1 umbrella",
            "pattern #2 umbrella",
            "pattern #3 umbrella",
            "pattern #4 umbrella",
            "pattern #5 umbrella",
            "pattern #6 umbrella",
            "pattern #7 umbrella",
            "pattern #8 umbrella"
        };

        #endregion

        #region Other String Arrays

        public static readonly string[] StarSigns =
        {
            "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo",
            "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces"
        };

        public static readonly string[] ClothingTypes =
        {
            "Cool", "Cute", "Funky", "Fresh", "Fancy",
            "Subtle", "Refined", "Gaudy", "Striking", "Strange"
        };

        #endregion

        #region fgnpcdata

        public static readonly ushort[] fgnpcdata =
        {
            0x1A0, 0x1A1, 0x1A2, 0x1A3, 0x1A4, 0x1A5, 0x1A6, 0x1A7, 0x1A8, 0x1A9, 0x1AA, 0x1AB, 0x1AC, 0x1AD, 0x1AE, 0x1AF,
            0x1B0, 0x1B1, 0x1B2, 0x1B3, 0x1B4, 0x1B5, 0x1B6, 0x1B7, 0x1B8, 0x1B9, 0x1BA, 0x1BB, 0x1BC, 0x1BD, 0x1BE, 0x1BF,
            0x1C0, 0x1C1, 0x1C2, 0x1C3, 0x1C4, 0x1C5, 0x1C6, 0x1C7, 0x1C8, 0x1C9, 0x1CA, 0x1CB, 0x1CC, 0x1CD, 0x1CE, 0x1CF,
            0x1D0, 0x1D1, 0x1D2, 0x1D3, 0x1D4, 0x1D5, 0x1D6, 0x1D7, 0x1D8, 0x1D9, 0x1DA, 0x1DB, 0x1DC, 0x1DD, 0x1DE, 0x1DF,
            0x1E0, 0x1E1, 0x1E2, 0x1E3, 0x1E4, 0x1E5, 0x1E6, 0x1E7, 0x1E8, 0x1E9, 0x1EA, 0x1EB, 0x1EC, 0x1ED, 0x1EE, 0x1EF,
            0x1F0, 0x1F1, 0x1F2, 0x1F3, 0x1F4, 0x1F5, 0x1F6, 0x1F7, 0x1F8, 0x1F9, 0x1FA, 0x1FB, 0x1FC, 0x1FD, 0x1FE, 0x1FF,
            0x200, 0x201, 0x202, 0x203, 0x204, 0x205, 0x206, 0x207, 0x208, 0x209, 0x20A, 0x20B, 0x20C, 0x20D, 0x20E, 0x20F,
            0x210, 0x211, 0x212, 0x213, 0x214, 0x215, 0x216, 0x217, 0x218, 0x219, 0x21A, 0x21B, 0x21C, 0x21D, 0x21E, 0x21F,
            0x220, 0x221, 0x222, 0x223, 0x224, 0x225, 0x226, 0x227, 0x228, 0x229, 0x22A, 0x22B, 0x22C, 0x22D, 0x22E, 0x22F,
            0x230, 0x231, 0x232, 0x233, 0x234, 0x235, 0x236, 0x237, 0x238, 0x239, 0x23A, 0x23B, 0x23C, 0x23D, 0x23E, 0x23F,
            0x240, 0x241, 0x242, 0x243, 0x244, 0x245, 0x246, 0x247, 0x248, 0x249, 0x24A, 0x24B, 0x24C, 0x24D, 0x24E, 0x24F,
            0x250, 0x251, 0x252, 0x253, 0x254, 0x255, 0x256, 0x257, 0x258, 0x259, 0x25A, 0x25B, 0x25C, 0x25D, 0x25E, 0x25F,
            0x260, 0x261, 0x262, 0x263, 0x264, 0x265, 0x266, 0x267, 0x268, 0x269, 0x26A, 0x26B, 0x26C, 0x26D, 0x26E, 0x26F,
            0x270, 0x271, 0x272, 0x273, 0x274, 0x275, 0x276, 0x277, 0x278, 0x279, 0x27A, 0x27B, 0x27C, 0x27D, 0x27E, 0x27F,
            0x280, 0x281, 0x282, 0x283, 0x284, 0x285, 0x286, 0x287, 0x288, 0x289, 0x28A, 0x28B, 0x28C, 0x28D, 0x28E, 0x28F,
            0x290, 0x291, 0x292, 0x293, 0x294, 0x295, 0x296, 0x297, 0x298, 0x299, 0x29A, 0x29B, 0x29C, 0x29D, 0x29E, 0x29F,
            0x2A0, 0x2A1, 0x2A2, 0x2A3, 0x2A4, 0x2A5, 0x2A6, 0x2A7, 0x2A8, 0x2A9, 0x2AA, 0x2AB, 0x2AC, 0x2AD, 0x2AE, 0x2AF,
            0x2B0, 0x2B1, 0x2B2, 0x2B3, 0x2B4, 0x2B5, 0x2B6, 0x2B7, 0x2B8, 0x2B9, 0x2BA, 0x2BB, 0x2BC, 0x2BD, 0x2BE, 0x2BF,
            0x2C0, 0x2C1, 0x2C2, 0x2C3, 0x2C4, 0x2C5, 0x2C6, 0x2C7, 0x2C8, 0x2C9, 0x2CA, 0x2CB, 0x2CC, 0x2CD, 0x2CE, 0x2CF,
            0x2D0, 0x2D1, 0x2D2, 0x2D3, 0x2D4, 0x2D5, 0x2D6, 0x2D7, 0x2D8, 0x2D9, 0x2DA, 0x2DB, 0x2DC, 0x2DD, 0x2DE, 0x2DF,
            0x2E0, 0x2E1, 0x2E2, 0x2E3, 0x2E4, 0x2E5, 0x2E6, 0x2E7, 0x2E8, 0x2E9, 0x2EA, 0x2EB, 0x2EC, 0x2ED, 0x2EE, 0x2EF,
            0x2F0, 0x2F1, 0x2F2, 0x2F3, 0x2F4, 0x2F5, 0x2F6, 0x2F7, 0x2F8, 0x2F9, 0x2FA, 0x2FB, 0x2FC, 0x2FD, 0x2FE, 0x2FF,
            0x300, 0x301, 0x302, 0x303, 0x304, 0x305, 0x306, 0x307, 0x308, 0x309, 0x30A, 0x30B, 0x30C, 0x30D, 0x30E, 0x30F,
            0x310, 0x311, 0x312, 0x313, 0x314, 0x315, 0x316, 0x317, 0x318, 0x319, 0x31A, 0x31B, 0x31C, 0x31D, 0x31E, 0x31F,
            0x320, 0x321, 0x322, 0x323, 0x324, 0x325, 0x326, 0x327, 0x328, 0x329, 0x32A, 0x32B, 0x32C, 0x32D, 0x32E, 0x32F,
            0x330, 0x331, 0x332, 0x333, 0x334, 0x335, 0x336, 0x337, 0x338, 0x339, 0x33A, 0x33B, 0x33C, 0x33D, 0x33E, 0x33F,
            0x340, 0x341, 0x342, 0x343, 0x344, 0x345, 0x346, 0x347, 0x348, 0x349, 0x34A, 0x34B, 0x34C, 0x34D, 0x34E, 0x34F,
            0x350, 0x351, 0x352, 0x353, 0x354, 0x355, 0x356, 0x357, 0x358, 0x359, 0x35A, 0x35B, 0x35C, 0x35D, 0x35E, 0x35F,
            0x360, 0x361, 0x362, 0x363, 0x364, 0x365, 0x366, 0x367, 0x368, 0x369, 0x36A, 0x36B, 0x36C, 0x36D, 0x36E, 0x36F,
            0x370, 0x371, 0x372, 0x373, 0x374, 0x375, 0x376, 0x377, 0x378, 0x379, 0x37A, 0x37B, 0x37C, 0x37D, 0x37E, 0x37F,
            0x380, 0x381, 0x382, 0x383, 0x384, 0x385, 0x386, 0x387, 0x388, 0x389, 0x38A, 0x38B, 0x38C, 0x38D, 0x38E, 0x38F,
            0x390, 0x391, 0x392, 0x393, 0x394, 0x395, 0x396, 0x397, 0x398, 0x399, 0x39A, 0x39B, 0x39C
        };

        #endregion
    }
}
