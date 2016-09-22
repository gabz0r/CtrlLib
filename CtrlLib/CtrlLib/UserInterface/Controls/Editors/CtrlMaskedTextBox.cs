using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CtrlLib.UserInterface.Controls.Editors
{
    public class CtrlMaskedTextBox : TextBox
    {
        static CtrlMaskedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlMaskedTextBox), new FrameworkPropertyMetadata(typeof(CtrlMaskedTextBox)));
        }

        private readonly DispatcherTimer _maskTimer;

        public CtrlMaskedTextBox()
        {
            PreviewTextInput += OnPreviewTextInput;
            PreviewKeyDown += OnPreviewKeyDown;
            CommandManager.AddPreviewExecutedHandler(this, PreviewExecutedHandler);
            
            _maskTimer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 1)};
            _maskTimer.Tick += (s, a) => MaskAllDisplayText();

            Background = Brushes.White;
        }

        private void MaskAllDisplayText()
        {
            _maskTimer.Stop();
            int caretIndex = CaretIndex;
            Text = new string('●', Text.Length);
            CaretIndex = caretIndex;
        }

        private void PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Command == ApplicationCommands.Copy ||
                executedRoutedEventArgs.Command == ApplicationCommands.Cut ||
                executedRoutedEventArgs.Command == ApplicationCommands.Paste)
            {
                executedRoutedEventArgs.Handled = true;
            }
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Key pressedKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            switch (pressedKey)
            {
                case Key.Space:
                    AddToSecureString(" ");
                    keyEventArgs.Handled = true;
                    break;
                case Key.Back:
                case Key.Delete:
                    if (SelectionLength > 0)
                    {
                        RemoveFromSecureString(SelectionStart, SelectionLength);
                    }
                    else if (pressedKey == Key.Delete && CaretIndex < Text.Length)
                    {
                        RemoveFromSecureString(CaretIndex, 1);
                    }
                    else if (pressedKey == Key.Back && CaretIndex > 0)
                    {
                        int caretIndex = CaretIndex;
                        if (CaretIndex > 0 && CaretIndex < Text.Length)
                            caretIndex = caretIndex - 1;
                        RemoveFromSecureString(CaretIndex - 1, 1);
                        CaretIndex = caretIndex;
                    }

                    keyEventArgs.Handled = true;
                    break;
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            AddToSecureString(textCompositionEventArgs.Text);
            textCompositionEventArgs.Handled = true;
        }

        private void AddToSecureString(string text)
        {
            if (SelectionLength > 0)
            {
                RemoveFromSecureString(SelectionStart, SelectionLength);
            }

            foreach (char c in text)
            {
                int caretIndex = CaretIndex;
                CtrlMaskedText.InsertAt(caretIndex, c);
                MaskAllDisplayText();
                if (caretIndex == Text.Length)
                {
                    _maskTimer.Stop();
                    _maskTimer.Start();
                    Text = Text.Insert(caretIndex++, c.ToString());
                }
                else {
                    Text = Text.Insert(caretIndex++, "*");
                }
                CaretIndex = caretIndex;
            }
        }

        private void RemoveFromSecureString(int startIndex, int trimLength)
        {
            int caretIndex = CaretIndex;
            for (int i = 0; i < trimLength; ++i)
            {
                CtrlMaskedText.RemoveAt(startIndex);
            }

            Text = Text.Remove(startIndex, trimLength);
            CaretIndex = caretIndex;
        }

        #region DepProp_CtrlLabelText

        /***********************************************************************************************/

        public static readonly DependencyProperty CtrlLabelProperty = DependencyProperty.Register("CtrlLabel", typeof (string), typeof (CtrlMaskedTextBox),
            new FrameworkPropertyMetadata(default(string)));

        public string CtrlLabel
        {
            get { return (string) GetValue(CtrlLabelProperty); }
            set { SetValue(CtrlLabelProperty, value); }
        }

        /***********************************************************************************************/

        #region DepProp_MaskedText

/***********************************************************************************************/

        public static readonly DependencyProperty CtrlMaskedTextProperty = DependencyProperty.Register("CtrlMaskedText", typeof (SecureString), typeof (CtrlMaskedTextBox),
            new FrameworkPropertyMetadata(new SecureString()));

        public SecureString CtrlMaskedText
        {
            get { return (SecureString) GetValue(CtrlMaskedTextProperty); }
            set { SetValue(CtrlMaskedTextProperty, value); }
        }

/***********************************************************************************************/

        #endregion

        #endregion
    }
}
