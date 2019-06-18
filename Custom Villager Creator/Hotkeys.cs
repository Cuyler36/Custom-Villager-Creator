using System.Windows.Input;

namespace Custom_Villager_Creator
{
    public static class Hotkeys
    {
        public static CommandBinding Create(KeyGesture keyGesture, ExecutedRoutedEventHandler h)
        {
            var command = new RoutedCommand();
            command.InputGestures.Add(keyGesture);
            return new CommandBinding(command, h);
        }
    }
}
