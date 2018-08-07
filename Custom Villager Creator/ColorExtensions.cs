// ReSharper disable once CheckNamespace
namespace System.Windows.Media
{
    public static class ColorExtensions
    {
        public static Color FromArgb(this Color c, int argb) => Color.FromArgb((byte) (argb >> 24), (byte) (argb >> 16), (byte) (argb >> 8), (byte) argb);
        public static Color FromArgb(this Color c, uint argb) => FromArgb(c, (int) argb);
    }
}
