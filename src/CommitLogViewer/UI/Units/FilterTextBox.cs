using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommitLogViewer.UI.Units
{
    public class FilterTextBox : TextBox
    {
        static FilterTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilterTextBox), new FrameworkPropertyMetadata(typeof(FilterTextBox)));
        }

        public static readonly DependencyProperty KeyDownCommandProperty = DependencyProperty.Register(
            "KeyDownCommand", typeof(ICommand), typeof(FilterTextBox));
    
        public ICommand KeyDownCommand
        {
            get { return (ICommand)this.GetValue(KeyDownCommandProperty); }
            set { this.SetValue(KeyDownCommandProperty, value); }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Enter) 
            {
                KeyDownCommand.Execute(e);
            }
        }
    }
}
