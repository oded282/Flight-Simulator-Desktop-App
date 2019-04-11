using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace FlightSimulator.Views
{ 
    public class TextBoxCommand : TextBox
    {
    public static readonly DependencyProperty OriginalValueProperty =
        DependencyProperty.Register("OriginalValue", typeof(string), typeof(TextBoxCommand));

    public static readonly DependencyProperty ChangedBackgroundProperty =
        DependencyProperty.Register("ChangedBackground", typeof(Brush), typeof(TextBoxCommand));

    public string OriginalValue
    {
        get { return (string)GetValue(OriginalValueProperty); }
        set { SetValue(OriginalValueProperty, value); }
    }

    public Brush ChangedBackground
    {
        get { return (Brush)GetValue(ChangedBackgroundProperty); }
        set { SetValue(ChangedBackgroundProperty, value); }
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);

        if (Text == OriginalValue)
        {
            ClearValue(BackgroundProperty);
        }
        else
        {
            Background = ChangedBackground;
          }
        }
    }
}
