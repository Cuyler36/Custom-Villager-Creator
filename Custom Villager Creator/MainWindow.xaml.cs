using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Interop;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text.RegularExpressions;
using GCNToolKit.Formats;
using GCNToolKit.Formats.Images;
using GCNToolKit.Formats.Colors;
using Image = System.Windows.Controls.Image;
using Microsoft.Win32;
using Color = System.Windows.Media.Color;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Custom_Villager_Creator
{
    /// <inheritdoc cref="Window" />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MainWindow : Window
    {
        private byte[] _data;
        private bool _yaz0Compressed;
        private string _fileLocation;
        private readonly OpenFileDialog _fileSelect = new OpenFileDialog();
        private readonly SaveFileDialog _fileSave = new SaveFileDialog();
        private int _selectedColor;
        private TextureEntry[] _textureEntries;
        private TextureEntry _selectedEntry;
        private bool _settingColor;
        private bool _leftMouseButtonDown;
        private bool _rightMouseButtonDown;
        private string _rgbBoxLastText = "";
        private string _rgbaBoxLastText = "";
        private int _lastX = -1;
        private int _lastY = -1;
        private readonly Canvas[] _paletteObjects;
        private readonly BitmapSource[] _houseImages;
        private DLCVillager _villager;
        private bool _changesMade;

        #region ItemNames

        private static readonly string[] ShirtNames =
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

        private static readonly string[] MinidiskNames =
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

        private static readonly string[] WallpaperNames =
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

        private static readonly string[] ToolNames =
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

        private static readonly string[] StarSigns =
        {
            "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo",
            "Libra", "Scorpio", "Sagittarius", "Aquarius", "Pisces"
        };

        private static readonly string[] ClothingTypes =
        {
            "Cool", "Cute", "Funky", "Fresh", "Fancy",
            "Subtle", "Refined", "Gaudy", "Striking", "Strange"
        };

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // Set up combobox items
            foreach (var shirt in ShirtNames)
            {
                ShirtComboBox.Items.Add(shirt);
            }

            foreach (var minidisk in MinidiskNames)
            {
                MinidiskComboBox.Items.Add(minidisk);
            }

            foreach (var wallpaper in WallpaperNames)
            {
                WallpaperComboBox.Items.Add(wallpaper);
            }

            foreach (var carpet in CarpetNames)
            {
                CarpetComboBox.Items.Add(carpet);
            }

            foreach (var tool in ToolNames)
            {
                UmbrellaComboBox.Items.Add(tool);
            }

            foreach (var sign in StarSigns)
            {
                ZodiacSignComboBox.Items.Add(sign);
            }

            foreach (var type in ClothingTypes)
            {
                FavoriteClothComboBox.Items.Add(type);
                HatedClothComboBox.Items.Add(type);
            }

            _paletteObjects = new[]
            {
                Palette0, Palette1, Palette2, Palette3,
                Palette4, Palette5, Palette6, Palette7,
                Palette8, Palette9, Palette10, Palette11,
                Palette12, Palette13, Palette14, Palette15
            };

            _houseImages = new[]
            {
                BitmapSourceFromBitmap(Properties.Resources.barnhouse1),
                BitmapSourceFromBitmap(Properties.Resources.barnhouse2),
                BitmapSourceFromBitmap(Properties.Resources.barnhouse3),
                BitmapSourceFromBitmap(Properties.Resources.barnhouse4),
                BitmapSourceFromBitmap(Properties.Resources.barnhouse5),
                BitmapSourceFromBitmap(Properties.Resources.cabin1),
                BitmapSourceFromBitmap(Properties.Resources.cabin2),
                BitmapSourceFromBitmap(Properties.Resources.cabin3),
                BitmapSourceFromBitmap(Properties.Resources.cabin4),
                BitmapSourceFromBitmap(Properties.Resources.cabin5),
                BitmapSourceFromBitmap(Properties.Resources.cabana1),
                BitmapSourceFromBitmap(Properties.Resources.cabana2),
                BitmapSourceFromBitmap(Properties.Resources.cabana3),
                BitmapSourceFromBitmap(Properties.Resources.cabana4),
                BitmapSourceFromBitmap(Properties.Resources.cabana5),
                BitmapSourceFromBitmap(Properties.Resources.cottage1),
                BitmapSourceFromBitmap(Properties.Resources.cottage2),
                BitmapSourceFromBitmap(Properties.Resources.cottage3),
                BitmapSourceFromBitmap(Properties.Resources.cottage4),
                BitmapSourceFromBitmap(Properties.Resources.cottage5),
                BitmapSourceFromBitmap(Properties.Resources.brick1),
                BitmapSourceFromBitmap(Properties.Resources.brick2),
                BitmapSourceFromBitmap(Properties.Resources.brick3),
                BitmapSourceFromBitmap(Properties.Resources.brick4),
                BitmapSourceFromBitmap(Properties.Resources.brick5)
            };

            SetHouseImage(0, 0);

            // Connect Events
            NameTextBox.TextChanged += delegate
            {
                unsafe
                {
                    if (_villager == null) return;
                    fixed (byte* name = _villager.Header.Name)
                    {
                        Utility.DnMStringToBytePtr(name, NameTextBox.Text, 6);
                    }
                    _changesMade = true;
                }
            };

            CatchphraseTextBox.TextChanged += delegate
            {
                unsafe
                {
                    if (_villager == null) return;
                    fixed (byte* catchphrase = _villager.Header.Catchphrase)
                    {
                        Utility.DnMStringToBytePtr(catchphrase, CatchphraseTextBox.Text, 4);
                    }
                    _changesMade = true;
                }
            };

            ModelComboBox.SelectionChanged += delegate
            {
                if (_villager == null) return;
                _villager.Header.Model = (ModelType)ModelComboBox.SelectedIndex;
                SetTextureEditorInfo();
                _changesMade = true;
            };

            HouseTypeComboBox.SelectionChanged += delegate
            {
                if (_villager == null || HouseTypeComboBox.SelectedIndex < 0 ||
                    HouseTypeComboBox.SelectedIndex > 4) return;
                _villager.Header.HouseStyle = (HouseType) HouseTypeComboBox.SelectedIndex;
                SetHouseImage((int) _villager.Header.HouseStyle, (int) _villager.Header.HousePalette);
                _changesMade = true;
            };

            HousePaletteComboBox.SelectionChanged += delegate
            {
                if (_villager == null || HousePaletteComboBox.SelectedIndex < 0 ||
                    HousePaletteComboBox.SelectedIndex > 4) return;
                _villager.Header.HousePalette = (HousePalette)HousePaletteComboBox.SelectedIndex;
                SetHouseImage((int)_villager.Header.HouseStyle, (int)_villager.Header.HousePalette);
                _changesMade = true;
            };

            IslanderCheckBox.Checked   += (s, e) => IslanderCheckChanged();
            IslanderCheckBox.Unchecked += (s, e) => IslanderCheckChanged();

            ShirtComboBox.SelectionChanged += delegate
            {
                if (_villager == null || ShirtComboBox.SelectedIndex < 0 || ShirtComboBox.SelectedIndex > 0xFF) return;
                _villager.Header.ShirtId = (byte) ShirtComboBox.SelectedIndex;
                _changesMade = true;
            };

            MinidiskComboBox.SelectionChanged += delegate
            {
                if (_villager == null || MinidiskComboBox.SelectedIndex < 0 || MinidiskComboBox.SelectedIndex > 0x8B) return;
                _villager.Header.SongId = (byte)MinidiskComboBox.SelectedIndex;
                _changesMade = true;
            };

            WallpaperComboBox.SelectionChanged += delegate
            {
                if (_villager == null || WallpaperComboBox.SelectedIndex < 0 || WallpaperComboBox.SelectedIndex > 0x44) return;
                _villager.Header.WallpaperId = (byte)WallpaperComboBox.SelectedIndex;
                _changesMade = true;
            };

            CarpetComboBox.SelectionChanged += delegate
            {
                if (_villager == null || CarpetComboBox.SelectedIndex < 0 || CarpetComboBox.SelectedIndex > 0x44) return;
                _villager.Header.CarpetId = (byte)CarpetComboBox.SelectedIndex;
                _changesMade = true;
            };

            UmbrellaComboBox.SelectionChanged += delegate
            {
                if (_villager == null || UmbrellaComboBox.SelectedIndex < 0 || UmbrellaComboBox.SelectedIndex > 0x5B) return;
                _villager.Header.UmbrellaId = (byte)UmbrellaComboBox.SelectedIndex;
                _changesMade = true;
            };

            ZodiacSignComboBox.SelectionChanged += delegate
            {
                if (_villager == null || ZodiacSignComboBox.SelectedIndex < 0 || ZodiacSignComboBox.SelectedIndex > 11) return;
                _villager.Header.Constellation = (byte)ZodiacSignComboBox.SelectedIndex;
                _changesMade = true;
            };

            FavoriteClothComboBox.SelectionChanged += delegate
            {
                if (_villager == null || FavoriteClothComboBox.SelectedIndex < 0 || FavoriteClothComboBox.SelectedIndex > 9) return;
                _villager.Header.FavoriteClothingCategory = (ClothingCategory)FavoriteClothComboBox.SelectedIndex;
                _changesMade = true;
            };

            HatedClothComboBox.SelectionChanged += delegate
            {
                if (_villager == null || HatedClothComboBox.SelectedIndex < 0 || HatedClothComboBox.SelectedIndex > 9) return;
                _villager.Header.HatedClothingCategory = (ClothingCategory)HatedClothComboBox.SelectedIndex;
                _changesMade = true;
            };
        }

        private static MessageBoxResult AskSaveCurrentFile()
            => MessageBox.Show(
                "The file currently open has had changes made to it.\nWould you like to save it before continuing?",
                "Save File?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

        private static Color FromArgb(int argb) => Color.FromArgb((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
        private static Color FromArgb(uint argb) => FromArgb((int)argb);

        private void SetHouseImage(int houseType, int housePalette)
        {
            HousePreviewImage.Source = _houseImages[houseType * 5 + housePalette];
        }

        private void IslanderCheckChanged()
        {
            if (_villager == null || IslanderCheckBox.IsChecked == null) return;
            _villager.Header.IsIslander = IslanderCheckBox.IsChecked.Value ? (byte)1 : (byte)0;
            _changesMade = true;
        }

        private void PopulateTreeView(IReadOnlyList<TextureEntry> entries, ItemsControl parent = null)
        {
            // Only clear it on the first run
            if (entries == null) return;
            if (parent == null)
            {
                EntryTreeView.Items.Clear();
            }

            for (var i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                var entryItem = new TreeViewItem
                {
                    Tag = entry
                };

                entry.TreeViewItem = entryItem;

                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Height = 48
                };

                var nameLabel = new Label
                {
                    Content = entry.TextureName ?? i.ToString(),
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                panel.Children.Add(nameLabel);
                entryItem.Header = panel;
                var preview = new Image {Source = BitmapSourceFromBitmap(entry.Texture)};
                RenderOptions.SetBitmapScalingMode(preview, BitmapScalingMode.NearestNeighbor);
                preview.Width = 32;
                preview.Height = 32;
                panel.Children.Add(preview);
                entryItem.Selected += (s, e) => Entry_Item_Selected(entry);

                if (parent == null)
                {
                    EntryTreeView.Items.Add(entryItem);
                }
                else
                {
                    parent.Items.Add(entryItem);
                }
            }
        }

        private void Entry_Item_Selected(TextureEntry entry)
        {
            SelectedImage.Source = BitmapSourceFromBitmap(entry.Texture);
            Set_Palette_Colors(entry.Palette);
            _selectedEntry = entry;
            SelectedLabel.Content = $"{entry.TextureName}";
            SetPaletteColor(_selectedColor);

            ImageGrid.Width = 512.0f * (entry.Width / 32.0f);
            var scale = (uint)ImageGrid.Width / (uint)entry.Width;
            ImageGrid.Height = scale * entry.Height;
            ImageGridCanvas.Width = ImageGrid.Width;

            SelectedImage.Width = ImageGrid.Width;
            SelectedImage.Height = ImageGrid.Height;
        }

        private void Set_Palette_Colors(IReadOnlyList<ushort> palette)
        {
            var hexPalette = new uint[palette.Count];
            for (var i = 0; i < palette.Count; i++)
            {
                RGB5A3.ToARGB8(palette[i], out var a, out var r, out var g, out var b);
                hexPalette[i] = (uint)((a << 24) | (r << 16) | (g << 8) | b);
                _paletteObjects[i].Background = new SolidColorBrush(FromArgb(hexPalette[i]));
            }
        }

        private void MousePosition_to_Coordinates(MouseEventArgs e, out int x, out int y)
        {
            var position = e.GetPosition(SelectedImage);
            x = Math.Max(0, Math.Min((int)position.X / 16, _selectedEntry.Width - 1));
            y = Math.Max(0, Math.Min((int)position.Y / 16, _selectedEntry.Height - 1));
        }

        private void Paint(int x, int y)
        {
            var dataIndex = x + y * _selectedEntry.Width;
            _selectedEntry.Argb8Data[dataIndex] = (int)_selectedEntry.Rgba8Palette[_selectedColor];
            _selectedEntry.RawData = C4.EncodeC4(_selectedEntry.Argb8Data, _selectedEntry.Palette, _selectedEntry.Width,
                _selectedEntry.Height);
            _changesMade = true;

            // Redraw bitmap
            _selectedEntry.Texture?.Dispose();
            _selectedEntry.Texture = Utility.CreateBitmap(_selectedEntry.Argb8Data, _selectedEntry.Width, _selectedEntry.Height);
            SelectedImage.Source = BitmapSourceFromBitmap(_selectedEntry.Texture);
        }

        private void CanvasGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedEntry == null) return;
            MousePosition_to_Coordinates(e, out var x, out var y);
            PositionLabel.Content = $"X: {x + 1} Y: {y + 1}";
            if ((_lastX == x && _lastY == y) || x >= _selectedEntry.Width) return;

            if (_leftMouseButtonDown)
            {
                Paint(x, y);
            }
            else if (_rightMouseButtonDown)
            {
                var idx = Array.IndexOf(_selectedEntry.Rgba8Palette,
                    (uint)_selectedEntry.Argb8Data[x + y * _selectedEntry.Width]);
                if (idx < 0 || idx > 15) return;
                SetPaletteColor(idx);
            }

            _lastX = x;
            _lastY = y;
        }

        private void CanvasGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedEntry == null) return;
            MousePosition_to_Coordinates(e, out var x, out var y);
            _lastX = x;
            _lastY = y;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _leftMouseButtonDown = true;
                Paint(x, y);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                _rightMouseButtonDown = true;
                var idx = Array.IndexOf(_selectedEntry.Rgba8Palette,
                    (uint)_selectedEntry.Argb8Data[x + y * _selectedEntry.Width]);
                if (idx < 0 || idx > 15) return;
                SetPaletteColor(idx);
            }
        }

        private void CanvasGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                _leftMouseButtonDown = false;
            }

            if (e.RightButton == MouseButtonState.Released)
            {
                _rightMouseButtonDown = false;
            }

            if (_textureEntries == null || _selectedEntry == null ||
                EntryTreeView.Items.Count <= _selectedEntry.EntryIndex) return;
            if (EntryTreeView.Items[_selectedEntry.EntryIndex] is TreeViewItem tvItem && tvItem.Header is StackPanel sPanel)
                ((Image) sPanel.Children[1]).Source = SelectedImage.Source;
        }

        private void CanvasMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_selectedEntry == null || !(sender is Canvas paletteCanvas)) return;
            var paletteIdx = Array.IndexOf(_paletteObjects, paletteCanvas);
            if (paletteIdx < 0) return;
            SetPaletteColor(paletteIdx);
        }

        private void SetPaletteHighlight(int index, Color highlightColor)
        {
            if (index <= -1 || index >= 16 || !(_paletteObjects[index].Parent is Border border)) return;
            border.BorderBrush = new SolidColorBrush(highlightColor);
        }

        private void SetPaletteColor(int index)
        {
            SetPaletteHighlight(_selectedColor, Colors.Black);
            SetPaletteHighlight(index, Colors.DeepSkyBlue);

            _selectedColor = index;
            _settingColor = true;
            RGB5A3.ToARGB8(_selectedEntry.Palette[index], out var alpha, out var red, out var green, out var blue);

            RedBox.Text = red.ToString();
            RedSlider.Value = red;
            GreenBox.Text = green.ToString();
            GreenSlider.Value = green;
            BlueBox.Text = blue.ToString();
            BlueSlider.Value = blue;
            TransparencyBox.Text = alpha.ToString();
            TransparencySlider.Value = alpha;

            RgbBox.Text = _selectedEntry.Palette[index].ToString("X4");
            Rgba8Box.Text = ((alpha << 24) | (red << 16) | (green << 8) | blue).ToString("X8");

            ColorPreview.Background = new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
            _settingColor = false;
        }

        private void SetPaletteColorArgb(byte a, byte r, byte g, byte b)
        {
            ColorPreview.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        private static bool IsTextAllowed(string text)
        {
            return !new Regex("[^0-9.-]+").IsMatch(text);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_settingColor)
                return;

            if (_selectedEntry == null) return;
            _settingColor = true;
            var slider = sender as Slider;
            var value = (byte)e.NewValue;
            if (Equals(slider, RedSlider))
            {
                RedBox.Text = value.ToString();
            }
            else if (Equals(slider, GreenSlider))
            {
                GreenBox.Text = value.ToString();
            }
            else if (Equals(slider, BlueSlider))
            {
                BlueBox.Text = value.ToString();
            }
            else if (Equals(slider, TransparencySlider))
            {
                TransparencyBox.Text = value.ToString();
            }
            var color = RGB5A3.ToRGB5A3(byte.Parse(TransparencyBox.Text), byte.Parse(RedBox.Text), byte.Parse(GreenBox.Text), byte.Parse(BlueBox.Text));
            RgbBox.Text = color.ToString("X4");
            Rgba8Box.Text = ((byte.Parse(TransparencyBox.Text) << 24) | (byte.Parse(RedBox.Text) << 16) | (byte.Parse(GreenBox.Text) << 8) | byte.Parse(BlueBox.Text)).ToString("X8");
            SetPaletteColorArgb(byte.Parse(TransparencyBox.Text), byte.Parse(RedBox.Text), byte.Parse(GreenBox.Text), byte.Parse(BlueBox.Text));
            _settingColor = false;
        }

        private void SliderBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_settingColor)
                return;

            if (_selectedEntry == null) return;
            var box = sender as TextBox;
            if (box != null && !IsTextAllowed(box.Text))
            {
                e.Handled = false;
            }
            else
            {
                byte value = 0;
                if (box != null && !byte.TryParse(box.Text, out value)) return;
                _settingColor = true;
                var color = RGB5A3.ToRGB5A3(byte.Parse(TransparencyBox.Text), byte.Parse(RedBox.Text), byte.Parse(GreenBox.Text), byte.Parse(BlueBox.Text));
                if (Equals(box, RedBox))
                {
                    RedSlider.Value = value;
                }
                else if (Equals(box, GreenBox))
                {
                    GreenSlider.Value = value;
                }
                else if (Equals(box, BlueBox))
                {
                    BlueSlider.Value = value;
                }
                else if (Equals(box, TransparencyBox))
                {
                    TransparencySlider.Value = value;
                }
                RgbBox.Text = color.ToString("X4");
                Rgba8Box.Text = ((byte.Parse(TransparencyBox.Text) << 24) | (byte.Parse(RedBox.Text) << 16) | (byte.Parse(GreenBox.Text) << 8) | byte.Parse(BlueBox.Text)).ToString("X8");
                SetPaletteColorArgb(byte.Parse(TransparencyBox.Text), byte.Parse(RedBox.Text), byte.Parse(GreenBox.Text), byte.Parse(BlueBox.Text));
                _settingColor = false;
            }
        }

        private void RgbBox_PreviewTextInput(object sender, TextChangedEventArgs e)
        {
            if (_settingColor) return;

            RgbBox.Text = RgbBox.Text.ToUpper();
            if (_selectedEntry != null && ushort.TryParse(RgbBox.Text, NumberStyles.AllowHexSpecifier, null, out var color))
            {
                _settingColor = true;
                RGB5A3.ToARGB8(color, out var a, out var r, out var g, out var b);
                SetPaletteColorArgb(a, r, g, b);
                _rgbBoxLastText = RgbBox.Text;
                RedBox.Text = r.ToString();
                RedSlider.Value = r;
                GreenBox.Text = g.ToString();
                GreenSlider.Value = g;
                BlueBox.Text = b.ToString();
                BlueSlider.Value = b;
                TransparencyBox.Text = a.ToString();
                TransparencySlider.Value = a;
                Rgba8Box.Text = ((a << 24) | (r << 16) | (g << 8) | b).ToString("X8");
                _settingColor = false;
            }
            else if (!string.IsNullOrEmpty(RgbBox.Text))
            {
                RgbBox.Text = _rgbBoxLastText;
            }
            else
            {
                _rgbBoxLastText = "";
            }
            RgbBox.SelectionStart = RgbBox.Text.Length;
            RgbBox.SelectionLength = 0;
        }

        private void Rgba8Box_PreviewTextInput(object sender, TextChangedEventArgs e)
        {
            if (_settingColor)
                return;

            Rgba8Box.Text = Rgba8Box.Text.ToUpper();
            if (_selectedEntry != null && int.TryParse(Rgba8Box.Text, NumberStyles.AllowHexSpecifier, null, out var color))
            {
                _settingColor = true;
                var a = (byte)(color >> 24);
                var r = (byte)(color >> 16);
                var g = (byte)(color >> 8);
                var b = (byte)(color);
                var uColor = RGB5A3.ToRGB5A3(a, r, g, b);
                // Reconvert it since we lose some precision with this conversion
                RGB5A3.ToARGB8(uColor, out var a2, out var r2, out var g2, out var b2);
                SetPaletteColorArgb(a2, r2, g2, b2);
                _rgbaBoxLastText = Rgba8Box.Text;
                RedBox.Text = r2.ToString();
                RedSlider.Value = r2;
                GreenBox.Text = g2.ToString();
                GreenSlider.Value = g2;
                BlueBox.Text = b2.ToString();
                BlueSlider.Value = b2;
                TransparencyBox.Text = a2.ToString();
                TransparencySlider.Value = a2;
                RgbBox.Text = uColor.ToString("X2");
                _settingColor = false;
            }
            else if (!string.IsNullOrEmpty(Rgba8Box.Text))
            {
                Rgba8Box.Text = _rgbaBoxLastText;
            }
            else
            {
                _rgbaBoxLastText = "";
            }
            Rgba8Box.SelectionStart = Rgba8Box.Text.Length;
            Rgba8Box.SelectionLength = 0;
        }

        private void RefreshEntries()
        {
            foreach (var entry in _textureEntries)
            {
                entry.Argb8Data = C4.DecodeC4(entry.RawData, entry.Palette, entry.Width, entry.Height);
                entry.Texture?.Dispose();
                entry.Texture = Utility.CreateBitmap(entry.Argb8Data, entry.Width, entry.Height);
                if (!(entry.TreeViewItem?.Tag is TextureEntry))
                    continue;
                var panel = entry.TreeViewItem.Header as StackPanel;
                if (panel?.Children[1] is Image img)
                    img.Source = BitmapSourceFromBitmap(entry.Texture);
            }
        }

        private void SetColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEntry == null ||
                !ushort.TryParse(RgbBox.Text, NumberStyles.AllowHexSpecifier, null, out var color)) return;
            _selectedEntry.Palette[_selectedColor] = color;
            _selectedEntry.Rgba8Palette[_selectedColor] = RGB5A3.ToARGB8(color);
            _changesMade = true;

            // Update all images
            RefreshEntries();

            // Reload Current Bitmap & Palette
            Set_Palette_Colors(_selectedEntry.Palette);
            SelectedImage.Source = BitmapSourceFromBitmap(_selectedEntry.Texture);
        }

        private unsafe void SetVillagerInfo(DLCVillager villager)
        {
            fixed (byte* name = villager.Header.Name)
            {
                NameTextBox.Text = Utility.BytePtrToDnMString(name, 6);
            }

            fixed (byte* catchphrase = villager.Header.Catchphrase)
            {
                CatchphraseTextBox.Text = Utility.BytePtrToDnMString(catchphrase, 4);
            }

            ModelComboBox.SelectedIndex = (int) villager.Header.Model;
            PersonalityComboBox.SelectedIndex = (int) villager.Header.Personality;
            HouseTypeComboBox.SelectedIndex = (int) villager.Header.HouseStyle;
            HousePaletteComboBox.SelectedIndex = (int) villager.Header.HousePalette;
            IslanderCheckBox.IsChecked = villager.Header.IsIslander != 0;
            ShirtComboBox.SelectedIndex = villager.Header.ShirtId;
            MinidiskComboBox.SelectedIndex = villager.Header.SongId;
            WallpaperComboBox.SelectedIndex = villager.Header.WallpaperId;
            CarpetComboBox.SelectedIndex = villager.Header.CarpetId;
            UmbrellaComboBox.SelectedIndex = villager.Header.UmbrellaId;
            ZodiacSignComboBox.SelectedIndex = villager.Header.Constellation;
            FavoriteClothComboBox.SelectedIndex = (int) villager.Header.FavoriteClothingCategory;
            HatedClothComboBox.SelectedIndex = (int) villager.Header.HatedClothingCategory;
        }

        private void SetTextureEditorInfo()
        {
            var selectedDatabase = VillagerDatabase.GetImageData(_villager.Header.Model);
            if (selectedDatabase == null) return;
            _textureEntries = new TextureEntry[selectedDatabase.Count];

            var lastOffset = 0;
            var rgba8Palette = Utility.ToArgb8Palette(_villager.Palette);
            for (var i = 0; i < _textureEntries.Length; i++)
            {
                var imageSize = selectedDatabase.Values.ElementAt(i);
                var dataSize = VillagerDatabase.DataSizeFromSize(imageSize);
                _textureEntries[i] = new TextureEntry(lastOffset, imageSize.Width, imageSize.Height,
                    _villager.TextureData.Skip(lastOffset).Take(dataSize).ToArray(), ref _villager.Palette, ref rgba8Palette, i)
                {
                    TextureName = selectedDatabase.Keys.ElementAt(i)
                };

                lastOffset += dataSize;
            }

            if (_textureEntries != null && _textureEntries.Length > 0 && _textureEntries[0] != null)
            {
                SelectedImage.Source = BitmapSourceFromBitmap(_textureEntries[0].Texture);
                Set_Palette_Colors(_textureEntries[0].Palette);
                _selectedEntry = _textureEntries[0];
                SelectedLabel.Content = $"{_selectedEntry.TextureName}";
                SetPaletteColor(0);

                ImageGrid.Width = (512.0f * (_selectedEntry.Width / 32.0f));
                var scale = (uint)(ImageGrid.Width / _selectedEntry.Width);
                ImageGrid.Height = scale * _selectedEntry.Height;
                ImageGridCanvas.Width = ImageGrid.Width;

                SelectedImage.Width = ImageGrid.Width;
                SelectedImage.Height = ImageGrid.Height;

                // Enable Controls
                Import.IsEnabled = true;
                ImportPalette.IsEnabled = true;
                Dump.IsEnabled = true;
                DumpAll.IsEnabled = true;
                RedSlider.IsEnabled = true;
                GreenSlider.IsEnabled = true;
                BlueSlider.IsEnabled = true;
                TransparencySlider.IsEnabled = true;
                RedBox.IsEnabled = true;
                GreenBox.IsEnabled = true;
                BlueBox.IsEnabled = true;
                TransparencyBox.IsEnabled = true;
                RgbBox.IsEnabled = true;
                Rgba8Box.IsEnabled = true;
                SetColorButton.IsEnabled = true;
            }
            else
            {
                SelectedImage.Source = null;
            }

            PopulateTreeView(_textureEntries);
        }

        private Bitmap DrawPaletteImage()
        {
            if (_villager == null || _selectedEntry == null) return null;
            const int boxWidth = 32;
            const int boxHeight = 32;
            var rgbaBuffer = new byte[4 * boxWidth * boxHeight * 16];
            for (var i = 0; i < 16; i++)
            {
                var data = BitConverter.GetBytes(_selectedEntry.Rgba8Palette[i]);
                var baseOffset = i * boxWidth * boxHeight * 4;
                for (var y = 0; y < boxHeight; y++)
                {
                    var rowOffset = baseOffset + y * boxWidth * 4;
                    for (var x = 0; x < boxWidth; x++)
                    {
                        Array.Copy(data, 0, rgbaBuffer, rowOffset + x * 4, 4);
                    }
                }
            }

            return Utility.CreateBitmap(rgbaBuffer, boxWidth, boxHeight * 16);
        }

        private static IEnumerable<int> GetPaletteFromImage(IEnumerable<int> imageData)
        {
            var palette = new List<int>();
            foreach (var pixel in imageData)
            {
                var found = false;
                foreach (var color in palette)
                {
                    if (pixel != color) continue;
                    found = true;
                    break;
                }

                if (found) continue;
                palette.Add(pixel);
                if (palette.Count >= 16)
                {
                    break;
                }
            }

            return palette.ToArray();
        }

        private static IList<int> ConvertToClosestColors(IList<int> data, int[] palette)
        {
            for (var i = 0; i < data.Count; i++)
            {
                data[i] = palette[GCNToolKit.Utilities.ColorUtilities.ClosestColorRGB(data[i], palette)];
            }

            return data;
        }

        private void ImportOverSelected_Click(object sender, RoutedEventArgs e)
        {
            if (_fileLocation == null || _selectedEntry == null) return;
            _fileSelect.FileName = "";
            _fileSelect.Filter = "PNG File|*.png";
            var result = _fileSelect.ShowDialog();
            if (!result.HasValue || !result.Value || !File.Exists(_fileSelect.FileName)) return;
            var imageData = Utility.GetBitmapDataFromPng(_fileSelect.FileName, out var width, out var height);
            if (width == _selectedEntry.Width && height == _selectedEntry.Height)
            {
                if (imageData.Length == _selectedEntry.Argb8Data.Length)
                {
                    _selectedEntry.Argb8Data = (int[]) ConvertToClosestColors(imageData, (int[])(object)_selectedEntry.Rgba8Palette);
                    _selectedEntry.RawData = C4.EncodeC4(_selectedEntry.Argb8Data, _selectedEntry.Palette,
                        _selectedEntry.Width, _selectedEntry.Height);
                    _selectedEntry.Texture?.Dispose();
                    _selectedEntry.Texture = Utility.CreateBitmap(imageData, width, height);
                    SelectedImage.Source = BitmapSourceFromBitmap(_selectedEntry.Texture);

                    if (!(EntryTreeView.Items[_selectedEntry.EntryIndex] is TreeViewItem treeViewItem)) return;
                    var panel = treeViewItem.Header as StackPanel;
                    if (panel?.Children[1] is Image img)
                        img.Source = SelectedImage.Source;

                    _changesMade = true;
                }
                else
                {
                    MessageBox.Show("There was an error importing the PNG image!\r\n" +
                                    "Please try to resave it or use another image.", "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The width and height of them image must match the selected entry!", "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImportPaletteFile(string paletteFileLocation)
        {
            if (!File.Exists(paletteFileLocation) && _selectedEntry == null) return;

            Bitmap paletteImg = null;
            try
            {
                paletteImg = (Bitmap) System.Drawing.Image.FromFile(paletteFileLocation);
            }
            catch
            {
                // Ignore error
            }

            if (paletteImg == null) return;

            var bmpData = paletteImg.LockBits(new Rectangle(0, 0, paletteImg.Width, paletteImg.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            var imageData = new int[paletteImg.Width * paletteImg.Height];
            Marshal.Copy(bmpData.Scan0, imageData, 0, imageData.Length);
            paletteImg.Dispose();

            var palette = GetPaletteFromImage(imageData);
            var paletteArray = palette as int[] ?? palette.ToArray();
            for (var i = 0; i < paletteArray.Length; i++)
            {
                _selectedEntry.Rgba8Palette[i] = (uint) paletteArray[i];
                _selectedEntry.Palette[i] = RGB5A3.ToRGB5A3(paletteArray[i]);
            }

            // Refresh texture entries
            RefreshEntries();

            // Reload Current Bitmap & Palette
            Set_Palette_Colors(_selectedEntry.Palette);
            SetPaletteColor(_selectedColor);
            SelectedImage.Source = BitmapSourceFromBitmap(_selectedEntry.Texture);
        }

        private void ImportPalette_OnClick(object sender, RoutedEventArgs e)
        {
            var oDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png"
            };

            var result = oDialog.ShowDialog();
            if (result == null || !result.Value) return;
            ImportPaletteFile(oDialog.FileName);
        }

        private void DumpSelected_Click(object sender, RoutedEventArgs e)
        {
            if (_fileLocation == null || _selectedEntry == null) return;
            string location;

            using (var folderBrowser = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = folderBrowser.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK ||
                    !Directory.Exists(folderBrowser.SelectedPath)) return;

                location = folderBrowser.SelectedPath;
            }

            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }
            
            using (var textureStream = new FileStream(location + Path.DirectorySeparatorChar + _selectedEntry.TextureName + ".png",
                FileMode.OpenOrCreate))
            {
                _selectedEntry.Texture.Save(textureStream, ImageFormat.Png);
                textureStream.Flush();
            }
        }

        private void DumpAll_Click(object sender, RoutedEventArgs e)
        {
            if (_villager == null) return;
            string location;

            using (var folderBrowser = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = folderBrowser.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK ||
                    !Directory.Exists(folderBrowser.SelectedPath)) return;

                location = folderBrowser.SelectedPath;
            }

            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            foreach (var texture in _textureEntries)
            {
                using (var textureStream = new FileStream(location + Path.DirectorySeparatorChar + texture.TextureName + ".png",
                    FileMode.OpenOrCreate))
                {
                    texture.Texture?.Save(textureStream, ImageFormat.Png);
                    textureStream.Flush();
                }
            }

            // Save Palette
            using (var paletteBitmap = DrawPaletteImage())
            {
                paletteBitmap.Save(location + Path.DirectorySeparatorChar + "Palette.png", ImageFormat.Png);
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (_changesMade)
            {
                var saveResult = AskSaveCurrentFile();
                switch (saveResult)
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        _changesMade = false;
                        Save_Click(null, null);
                        break;
                }
            }

            // Cleanup old entries
            if (_textureEntries != null)
            {
                foreach (var entry in _textureEntries)
                {
                    entry.Dispose();
                }
            }

            _villager = new DLCVillager();
            _data = new byte[0x865 + _villager.TextureData.Length];
            _yaz0Compressed = true;
            SetVillagerInfo(_villager);
            SetTextureEditorInfo();
            _changesMade = false;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (_changesMade)
            {
                var saveResult = AskSaveCurrentFile();
                switch (saveResult)
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        _changesMade = false;
                        Save_Click(null, null);
                        break;
                }
            }

            _fileSelect.FileName = "";
            _fileSelect.Filter = "All Supported Files|*.yaz0;*.bin|Yaz0 Compressed File|*.yaz0|Binary File|*.bin|All Files|*.*";
            var result = _fileSelect.ShowDialog();

            if (!result.HasValue || !result.Value) return;

            // Cleanup old entries
            if (_textureEntries != null)
            {
                foreach (var entry in _textureEntries)
                {
                    entry.Dispose();
                }
            }

            _fileLocation = _fileSelect.FileName;
            _data = File.ReadAllBytes(_fileLocation);

            // Check for Yaz0 Compression and decompress it if it is.
            _yaz0Compressed = Yaz0.IsYaz0(_data);
            if (_yaz0Compressed)
            {
                _data = Yaz0.Decompress(_data);
            }

            using (var fStream = new MemoryStream(_data))
            {
                _villager = new DLCVillager(fStream);
                SetVillagerInfo(_villager);
                SetTextureEditorInfo();
                _changesMade = false;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_villager == null) return;

            if (string.IsNullOrEmpty(_fileLocation))
            {
                _fileSave.Filter = "Yaz0 Compressed File|*.yaz0|Binary File|*.bin";
                var result = _fileSave.ShowDialog();
                if (!result.HasValue || !result.Value) return;
                _fileLocation = _fileSave.FileName;
            }

            using (var textureWriter = new BinaryWriter(new FileStream(_fileLocation, FileMode.Create)))
            {
                var header = _villager.Header;
                header.HouseRoomInfoId = header.HouseRoomInfoId.Reverse();
                header.IslandRoomInfoId = header.IslandRoomInfoId.Reverse();
                header.Unknown1 = header.Unknown1.Reverse(); // Swap endianness

                // Write header while endianness is swapped
                StructWriter.WriteStruct(_villager.Header).CopyTo(_data, 0);

                header.HouseRoomInfoId = header.HouseRoomInfoId.Reverse();
                header.IslandRoomInfoId = header.IslandRoomInfoId.Reverse();
                header.Unknown1 = header.Unknown1.Reverse(); // Swap endianness

                // Write Palette
                for (var i = 0; i < 16; i++)
                {
                    BitConverter.GetBytes(_villager.Palette[i].Reverse()).CopyTo(_data, 0x845 + i * 2);
                }

                // Write Textures
                foreach (var textureEntry in _textureEntries)
                {
                    var entry = textureEntry;
                    var c4Data = C4.EncodeC4(entry.Argb8Data, entry.Palette, entry.Width, entry.Height);
                    c4Data.CopyTo(_data, 0x865 + entry.TextureOffset);
                }

                textureWriter.Write(_yaz0Compressed ? Yaz0.Compress(_data) : _data);
                textureWriter.Flush();
                textureWriter.Close();
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (_villager == null) return;
            _fileSave.FileName = Path.GetFileName(_fileLocation) ?? "";
            _fileSave.Filter = "Yaz0 Compressed File|*.yaz0|Binary File|*.bin";
            var result = _fileSave.ShowDialog();
            if (!result.HasValue || !result.Value) return;

            _fileLocation = _fileSave.FileName;
            Save_Click(null, null);
        }

        private void DumpPaletteFile_Click(object sender, RoutedEventArgs e)
        {
            if (_villager == null || _selectedEntry == null) return;
            var dialog = new SaveFileDialog
            {
                Filter = "Binary File|*.bin",
                FileName = ""
            };
            var result = dialog.ShowDialog();
            if (!result.HasValue || !result.Value) return;
                
            if (!Directory.Exists(dialog.FileName))
            {
                Directory.CreateDirectory(dialog.FileName);
            }

            using (var paletteBitmap = DrawPaletteImage())
            {
                paletteBitmap.Save(dialog.FileName + Path.DirectorySeparatorChar + "Palette.png", ImageFormat.Png);
            }
        }

        // From: https://stackoverflow.com/questions/26260654/wpf-converting-bitmap-to-imagesource
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject([In] IntPtr hObject);

        private static BitmapSource BitmapSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }

        private void GridEnabledCheckBoxCheckChanged(object sender, RoutedEventArgs e)
        {
            if (ImageGridCanvas?.Background == null || GridEnabledCheckBox.IsChecked == null) return;
            ImageGridCanvas.Background.Opacity = GridEnabledCheckBox.IsChecked.Value ? 1 : 0;
        }
    }
}
