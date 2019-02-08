using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tiles
{
    /// <summary>
    ///     Interaction logic for WallWindow.xaml
    /// </summary>
    public partial class WallWindow : Window
    {
        private readonly Element _currentElement = new Element();
        private double _sumWidth;
        private double _sumHeight;
        private int _rowNum;


        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _currentElement.X = Mouse.GetPosition((IInputElement) sender).X;
            _currentElement.Y = Mouse.GetPosition((IInputElement) sender).Y;
            _currentElement.InputElement?.CaptureMouse();

        }
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _currentElement.InputElement?.ReleaseMouseCapture();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)

                _currentElement.IsDragging = true;

            if (_currentElement.IsDragging && _currentElement.InputElement != null)

            {
                var newX = Mouse.GetPosition((IInputElement) sender).X;
                var newY = Mouse.GetPosition((IInputElement) sender).Y;

                var rt = ((UIElement) _currentElement.InputElement).RenderTransform;
                var offsetX = rt.Value.OffsetX;
                var offsetY = rt.Value.OffsetY;

                rt.SetValue(TranslateTransform.XProperty, offsetX + newX - _currentElement.X);
                rt.SetValue(TranslateTransform.YProperty, offsetY + newY - _currentElement.Y);

                _currentElement.X = newX;
                _currentElement.Y = newY;
            }
        }

        public void Tile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _currentElement.InputElement = (IInputElement) sender;
        }

        public void Tile_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var b = (Border) sender;
                cnvWall.Children.Remove(b);
            }
        }

        public void AddTile(Tile t, int cnt)
        {
            if (cnt > 0)
                for (var i = 0; i < cnt; i++)
                {
                    var translateTransform = new TranslateTransform();
                    var b = new Border();
                    var myBrush = new ImageBrush();

                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(t.ImageFile);

                    bi.Rotation = t.ImageRotation;
                    bi.EndInit();

                    myBrush.ImageSource = bi;
                    b.BorderBrush = t.FugaColor;
                    b.BorderThickness = new Thickness(t.Fuga, t.Fuga, t.Fuga, t.Fuga);

                    if (t.ImageRotation == Rotation.Rotate90)
                    {
                        b.Height = t.ScaleHeight;
                        b.Width = t.ScaleWidth;
                    }
                    else
                    {
                        b.Height = t.ScaleHeight;
                        b.Width = t.ScaleWidth;
                    }

                    b.MouseLeftButtonDown += Tile_MouseLeftButtonDown;
                    b.MouseRightButtonDown += Tile_MouseRightButtonDown;
                    b.Background = myBrush;
                    b.RenderTransform = translateTransform;

                    cnvWall.Children.Add(b);
                }
        }

        public void GenerateWall(Wall w, Tile t)
        {
            var translateTransform1 = new TranslateTransform();

            var b = new Border();
            var wid = Width / 2;
            var tilehalf = t.ScaleWidth / 2;

            var tmp = Math.Ceiling((wid - tilehalf) / t.ScaleWidth);

            _sumHeight = 0;
            if (w.IsCenter)
                _sumWidth = wid - tilehalf - t.ScaleWidth * tmp;
            else _sumWidth = 0;
            _rowNum = 0;

            while (_sumHeight <= Height)
            {
                _rowNum++;
                while (_sumWidth <= Width + t.ScaleWidth * tmp)
                {
                    b = new Border();
                    var myBrush = new ImageBrush();
                    b.BorderBrush = t.FugaColor;
                    b.BorderThickness = new Thickness(t.Fuga, t.Fuga, t.Fuga, t.Fuga);

                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(t.ImageFile);

                    bi.Rotation = t.ImageRotation;
                    bi.EndInit();
                    myBrush.ImageSource = bi;

                    if (t.ImageRotation == Rotation.Rotate90)
                    {
                        b.Height = t.ScaleHeight;
                        b.Width = t.ScaleWidth;
                    }
                    else
                    {
                        b.Height = t.ScaleHeight;
                        b.Width = t.ScaleWidth;
                    }

                    b.MouseLeftButtonDown += Tile_MouseLeftButtonDown;
                    b.MouseRightButtonDown += Tile_MouseRightButtonDown;
                    b.Background = myBrush;

                    if (_sumWidth == 0)
                    {
                        if (_rowNum % 2 == 0 && w.IsInvert)
                            translateTransform1 = new TranslateTransform(_sumWidth - b.Width / 2, _sumHeight);
                        else translateTransform1 = new TranslateTransform(_sumWidth, _sumHeight);
                        _sumWidth = b.Width;
                    }

                    else
                    {
                        if (_rowNum % 2 == 0 && w.IsInvert)
                            translateTransform1 = new TranslateTransform(_sumWidth - b.Width / 2, _sumHeight);

                        else translateTransform1 = new TranslateTransform(_sumWidth, _sumHeight);
                        _sumWidth = _sumWidth + b.Width;
                    }

                    b.RenderTransform = translateTransform1;

                    cnvWall.Children.Add(b);
                }

                if (w.IsCenter)
                    _sumWidth = wid - tilehalf - t.ScaleWidth * tmp;
                else _sumWidth = 0;

                _sumHeight = _sumHeight + b.Height;
            }
        }

        public WallWindow()
        {
            InitializeComponent();
            _sumWidth = 0;
            _sumHeight = 0;
            _rowNum = 0;
        }
    }
}