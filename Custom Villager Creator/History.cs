namespace Custom_Villager_Creator
{
    public enum ActionType
    {
        Generic = 0,
        Paint = 1,
        Palette = 2,
        Import = 3,
        Setting = 4
    }

    public sealed class HistoryItem
    {
        public readonly ActionType Type;
        public readonly int Index; // Used to determine which color in the palette when ActionType == Palette or canvas when ActionType == Paint
        public readonly object Value; // The previous value.

        public HistoryItem(ActionType type, int index, object value)
        {
            Type = type;
            Index = index;
            Value = value;
        }
    }
}
