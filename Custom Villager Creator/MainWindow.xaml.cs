using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private uint[] _rgba8Palette;
        private int _lastX = -1;
        private int _lastY = -1;
        private readonly Canvas[] _paletteObjects;
        private readonly BitmapSource[] _houseImages;
        private DLCVillager _villager;
        private bool _changesMade;
        private readonly Stack<HistoryItem> undoStack;
        private readonly Stack<HistoryItem> redoStack;

        public MainWindow()
        {
            undoStack = new Stack<HistoryItem>();
            redoStack = new Stack<HistoryItem>();

            // Initialize hotkeys
            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.N, ModifierKeys.Control), New_Click));
            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.O, ModifierKeys.Control), Open_Click));
            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.S, ModifierKeys.Control), Save_Click));
            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift), SaveAs_Click));
            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.I, ModifierKeys.Control | ModifierKeys.Shift), ImportOverSelected_Click));

            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.Z, ModifierKeys.Control), Undo_Click));
            CommandBindings.Add(Hotkeys.Create(new KeyGesture(Key.Y, ModifierKeys.Control), Redo_Click));

            InitializeComponent();

            // Supress silly WPF warnings
            #if DEBUG
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Critical;
            #endif

            // Set up combobox items
            foreach (var shirt in Static.ShirtNames)
            {
                ShirtComboBox.Items.Add(shirt);
            }

            foreach (var minidisk in Static.MinidiskNames)
            {
                MinidiskComboBox.Items.Add(minidisk);
            }

            foreach (var wallpaper in Static.WallpaperNames)
            {
                WallpaperComboBox.Items.Add(wallpaper);
            }

            foreach (var carpet in Static.CarpetNames)
            {
                CarpetComboBox.Items.Add(carpet);
            }

            foreach (var tool in Static.ToolNames)
            {
                UmbrellaComboBox.Items.Add(tool);
            }

            foreach (var sign in Static.StarSigns)
            {
                ZodiacSignComboBox.Items.Add(sign);
            }

            foreach (var type in Static.ClothingTypes)
            {
                FavoriteClothComboBox.Items.Add(type);
                HatedClothComboBox.Items.Add(type);
            }

            foreach (var npcData in Static.fgnpcdata)
            {
                var hexIndex = npcData.ToString("X");
                HouseIndexComboBox.Items.Add(hexIndex);
                HouseSecondIndexComboBox.Items.Add(hexIndex);
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

            HouseIndexComboBox.SelectionChanged += delegate
            {
                if (_villager == null || HouseIndexComboBox.SelectedIndex < 0 || HouseIndexComboBox.SelectedIndex > 508) return;
                _villager.Header.HouseRoomBaseLayerInfoId = (ushort)(HouseIndexComboBox.SelectedIndex + 0x1A0);
                _changesMade = true;
            };

            HouseSecondIndexComboBox.SelectionChanged += delegate
            {
                if (_villager == null || HouseSecondIndexComboBox.SelectedIndex < 0 || HouseSecondIndexComboBox.SelectedIndex > 508) return;
                _villager.Header.HouseRoomSecondLayerInfoId = (ushort)(HouseSecondIndexComboBox.SelectedIndex + 0x1A0);
                _changesMade = true;
            };
        }

        private static MessageBoxResult AskSaveCurrentFile()
            => MessageBox.Show(
                "The file currently open has had changes made to it.\nWould you like to save it before continuing?",
                "Save File?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

        private static Color FromArgb(int argb) => Color.FromArgb((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
        private static Color FromArgb(uint argb) => FromArgb((int)argb);

        private void SetUndoText(string text) => UndoButton.Header = "_Undo " + text;
        private void SetRedoText(string text) => RedoButton.Header = "_Redo " + text;
        private void ResetUndoText() => UndoButton.Header = "_Undo";
        private void ResetRedoText() => RedoButton.Header = "_Redo";

        private void PushUndo(ActionType type, int index, object value)
        {
            HistoryItem newItem = null;

            ClearRedoStack(); // Clear the redo stack as a new change was made.

            switch (type)
            {
                case ActionType.Palette:
                    newItem = new HistoryItem(ActionType.Palette, index, _villager.Palette[index]);
                    break;
                case ActionType.Paint:
                case ActionType.Import:
                    newItem = new HistoryItem(type, index, _textureEntries[index].RawData);
                    break;
            }

            if (newItem != null)
                undoStack.Push(newItem);

            SetUndoRedoText();
            UndoButton.IsEnabled = undoStack.Count > 0;
            RedoButton.IsEnabled = redoStack.Count > 0;
        }

        private void SetUndoRedoText()
        {
            if (undoStack.Count > 0)
            {
                switch (undoStack.Peek().Type)
                {
                    case ActionType.Palette:
                        SetUndoText("Palette Change");
                        break;
                    case ActionType.Paint:
                        SetUndoText("Paint");
                        break;
                    case ActionType.Import:
                        SetUndoText("Import");
                        break;
                }
            }
            else
                ResetUndoText();

            if (redoStack.Count > 0)
            {
                switch (redoStack.Peek().Type)
                {
                    case ActionType.Palette:
                        SetRedoText("Palette Change");
                        break;
                    case ActionType.Paint:
                        SetRedoText("Paint");
                        break;
                    case ActionType.Import:
                        SetRedoText("Import");
                        break;
                }
            }
            else
                ResetRedoText();
        }

        private void UndoRedo(Stack<HistoryItem> sourceStack, Stack<HistoryItem> destinationStack)
        {
            if (sourceStack.Count < 1) return;

            var item = sourceStack.Pop();
            HistoryItem newItem = null;

            switch (item.Type)
            {
                case ActionType.Palette:
                    {
                        var originalColor = (ushort)item.Value; // RGB5A3
                        var idx = item.Index & 0xF;

                        var currentColor = _villager.Palette[idx];
                        newItem = new HistoryItem(ActionType.Palette, idx, currentColor);

                        ChangePaletteColor(idx, originalColor);
                        break;
                    }
                case ActionType.Paint:
                case ActionType.Import:
                    {
                        var originalData = (byte[])item.Value;
                        var idx = item.Index;

                        var currentData = _textureEntries[idx].RawData;
                        newItem = new HistoryItem(item.Type, idx, currentData);

                        _textureEntries[idx].RawData = originalData;
                        _textureEntries[idx].Argb8Data = C4.DecodeC4(originalData, _villager.Palette, _textureEntries[idx].Width, _textureEntries[idx].Height, GCNToolKit.ColorFormat.RGB5A3);
                        _textureEntries[idx].Texture?.Dispose();
                        _textureEntries[idx].Texture = Utility.CreateBitmap(_textureEntries[idx].Argb8Data, _textureEntries[idx].Width, _textureEntries[idx].Height);

                        RefreshEntries(); // TODO: Write a method to refresh a single entry to save performance.

                        if (_textureEntries[idx] == _selectedEntry)
                            SelectedImage.Source = BitmapSourceFromBitmap(_textureEntries[idx].Texture);
                        break;
                    }
            }

            if (newItem != null)
                destinationStack.Push(newItem);

            SetUndoRedoText();
            UndoButton.IsEnabled = undoStack.Count > 0;
            RedoButton.IsEnabled = redoStack.Count > 0;
        }

        private void Undo() => UndoRedo(undoStack, redoStack);
        private void Redo() => UndoRedo(redoStack, undoStack);

        private void ClearRedoStack()
        {
            redoStack.Clear();
            RedoButton.IsEnabled = false;
            ResetRedoText();
        }

        private void ClearUndoStack()
        {
            undoStack.Clear();
            UndoButton.IsEnabled = false;
            ResetUndoText();
        }

        private void ClearUndoRedoStacks()
        {
            ClearUndoStack();
            ClearRedoStack();
        }

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

        private void PaintCanvas(int textureEntryIdx, int x, int y, int paletteIdx)
        {
            if (paletteIdx < 0 || paletteIdx > 15)
                paletteIdx = 0;

            var textureEntry = _textureEntries[textureEntryIdx];
            var dataIndex = x + y * textureEntry.Width;
            textureEntry.Argb8Data[dataIndex] = (int)textureEntry.Rgba8Palette[paletteIdx];
            textureEntry.RawData = C4.EncodeC4(textureEntry.Argb8Data, textureEntry.Palette, textureEntry.Width,
                textureEntry.Height, GCNToolKit.ColorFormat.RGB5A3);
            _changesMade = true;

            // Redraw bitmap
            textureEntry.Texture?.Dispose();
            textureEntry.Texture = Utility.CreateBitmap(textureEntry.Argb8Data, textureEntry.Width, textureEntry.Height);

            // If the currently selected texture is the texture modified, refresh the editor image.
            if (textureEntry == _selectedEntry)
                SelectedImage.Source = BitmapSourceFromBitmap(textureEntry.Texture);
        }

        private void Paint(int x, int y) => PaintCanvas(Array.IndexOf(_textureEntries, _selectedEntry), x, y, _selectedColor);

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
                var idx = Array.IndexOf(_textureEntries, _selectedEntry);
                PushUndo(ActionType.Paint, idx, _selectedEntry.RawData);
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
                entry.Argb8Data = C4.DecodeC4(entry.RawData, entry.Palette, entry.Width, entry.Height, GCNToolKit.ColorFormat.RGB5A3);
                entry.Texture?.Dispose();
                entry.Texture = Utility.CreateBitmap(entry.Argb8Data, entry.Width, entry.Height);
                if (!(entry.TreeViewItem?.Tag is TextureEntry))
                    continue;
                var panel = entry.TreeViewItem.Header as StackPanel;
                if (panel?.Children[1] is Image img)
                    img.Source = BitmapSourceFromBitmap(entry.Texture);
            }
        }

        private void ChangePaletteColor(int paletteIdx, ushort rgb5a3)
        {
            if (paletteIdx < 0 || paletteIdx > 15) return;

            _villager.Palette[paletteIdx] = rgb5a3;
            _rgba8Palette[paletteIdx] = RGB5A3.ToARGB8(rgb5a3);
            RefreshEntries();
            Set_Palette_Colors(_villager.Palette);
            SelectedImage.Source = BitmapSourceFromBitmap(_selectedEntry.Texture);
        }

        private void SetColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEntry == null ||
                !ushort.TryParse(RgbBox.Text, NumberStyles.AllowHexSpecifier, null, out var color)) return;
            _changesMade = true;
            PushUndo(ActionType.Palette, _selectedColor, _villager.Palette[_selectedColor]);
            ChangePaletteColor(_selectedColor, color);
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
            HouseIndexComboBox.SelectedIndex = villager.Header.HouseRoomBaseLayerInfoId - 0x1A0;
            HouseSecondIndexComboBox.SelectedIndex = villager.Header.HouseRoomSecondLayerInfoId - 0x1A0;

            // Debug
            Console.WriteLine($"Species: {villager.Header.Model}\nTribe: {villager.Header.Tribe}\n\n");
        }

        private void SetTextureEditorInfo()
        {
            ClearUndoRedoStacks();
            var selectedDatabase = VillagerDatabase.GetImageData(_villager.Header.Model);
            if (selectedDatabase == null) return;
            _textureEntries = new TextureEntry[selectedDatabase.Count];

            var lastOffset = 0;
            _rgba8Palette = Utility.ToArgb8Palette(_villager.Palette);
            for (var i = 0; i < _textureEntries.Length; i++)
            {
                var imageSize = selectedDatabase.Values.ElementAt(i);
                var dataSize = VillagerDatabase.DataSizeFromSize(imageSize);
                _textureEntries[i] = new TextureEntry(lastOffset, imageSize.Width, imageSize.Height,
                    _villager.TextureData.Skip(lastOffset).Take(dataSize).ToArray(), ref _villager.Palette, ref _rgba8Palette, i)
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
            _fileSelect.Title = "Select a File to Import...";
            var result = _fileSelect.ShowDialog();
            if (!result.HasValue || !result.Value || !File.Exists(_fileSelect.FileName)) return;
            var imageData = Utility.GetBitmapDataFromPng(_fileSelect.FileName, out var width, out var height);
            if (width == _selectedEntry.Width && height == _selectedEntry.Height)
            {
                if (imageData.Length == _selectedEntry.Argb8Data.Length)
                {
                    PushUndo(ActionType.Import, Array.IndexOf(_textureEntries, _selectedEntry), _selectedEntry.RawData);

                    _selectedEntry.Argb8Data = (int[]) ConvertToClosestColors(imageData, (int[])(object)_selectedEntry.Rgba8Palette);
                    _selectedEntry.RawData = C4.EncodeC4(_selectedEntry.Argb8Data, _selectedEntry.Palette,
                        _selectedEntry.Width, _selectedEntry.Height, GCNToolKit.ColorFormat.RGB5A3);
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
            _fileSelect.Title = "Select a File to Open...";
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
                header.HouseRoomBaseLayerInfoId = header.HouseRoomBaseLayerInfoId.Reverse();
                header.HouseRoomSecondLayerInfoId = header.HouseRoomSecondLayerInfoId.Reverse();
                header.Unknown1 = header.Unknown1.Reverse(); // Swap endianness

                // Write header while endianness is swapped
                StructWriter.WriteStruct(header).CopyTo(_data, 0);

                header.HouseRoomBaseLayerInfoId = header.HouseRoomBaseLayerInfoId.Reverse();
                header.HouseRoomSecondLayerInfoId = header.HouseRoomSecondLayerInfoId.Reverse();
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
                    var c4Data = C4.EncodeC4(entry.Argb8Data, entry.Palette, entry.Width, entry.Height, GCNToolKit.ColorFormat.RGB5A3);
                    c4Data.CopyTo(_data, 0x865 + entry.TextureOffset);
                }

                textureWriter.Write(_yaz0Compressed ? Yaz0.Compress(_data) : _data);
                textureWriter.Flush();
                textureWriter.Close();
            }

            _changesMade = false;
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

        private void PersonalityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_villager == null || PersonalityComboBox.SelectedIndex < 0 || PersonalityComboBox.SelectedIndex > 5) return;

            _villager.Header.Personality = (PersonalityType)PersonalityComboBox.SelectedIndex;
        }

        private void Undo_Click(object sender, RoutedEventArgs e) => UndoRedo(undoStack, redoStack);

        private void Redo_Click(object sender, RoutedEventArgs e) => UndoRedo(redoStack, undoStack);
    }
}
