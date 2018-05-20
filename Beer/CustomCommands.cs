using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beer
{
    class CustomCommands
    {
        public static readonly RoutedUICommand AddRecipe = new RoutedUICommand(
            "Dodaj",
            "Dodaj",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand AddHop = new RoutedUICommand(
            "Dodaj Chmiel",
            "Dodaj",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Control)
            });

        public static readonly RoutedUICommand AddMalt = new RoutedUICommand(
            "Dodaj Słód",
            "Dodaj",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Control)
            });
    }
}
