using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;


namespace Tiles
{


    public static class ProgramProperties
    {
        public static int Scale = 5;
        public static string TilesDirectory = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Images\\";
        

    }

    public class Wall
    {
        public double Height= 0;
        public double Width=0;

        public int TilesCnt = 0;
        public bool IsInvert = false;
        public bool IsCenter = false;

        public double ScaleHeight => Height * ProgramProperties.Scale;
        public double ScaleWidth => Width * ProgramProperties.Scale;
    }

    public class Tile
    {
        public double Height=0;
        public double Width=0;

     
        public string ImageFile;
        public int Fuga;
        public Rotation ImageRotation;
        public Brush FugaColor;

        public double ScaleHeight => Height * ProgramProperties.Scale;
        public double ScaleWidth => Width * ProgramProperties.Scale;

    }




    public class Element

    {
        private IInputElement _inputElement = null;
        public Element() { }


        public IInputElement InputElement

        {

            get => this._inputElement;
            set

            {
                this._inputElement = value;
                this.IsDragging = false;
            }

        }

        public double X { get; set; }
        public double Y { get; set; } = 0;

        public bool IsDragging { get; set; } = false;
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Wall NewWall;
        public WallWindow Ww;
        public Tile NewTile;
        public BitmapImage Bi;
        public string FileName;
        public static int Scale = 5;

        public MainWindow()
        {
            InitializeComponent();
            txtOpenImage.Text = ProgramProperties.TilesDirectory;
            NewWall = new Wall();
            NewTile = new Tile();



            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "wall.jpg");
            bi2.EndInit();

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "tile.png");
            bi3.EndInit();



            imgPhotoWall.Source = bi2;
            imgPhotoTile.Source = bi3;


            Ww = new WallWindow();
            Ww.Show();
        }


        private void txtWidth_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (NewTile != null)
            {
                var t = (TextBox)e.Source;

                if (t.Text != "")
                {
                    NewTile.Width = Convert.ToDouble(t.Text);
                }
            }
        }

        private void txtHeight_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (NewTile != null)
            {
                var t = (TextBox)e.Source;
                if (t.Text != "")
                {
                    NewTile.Height = Convert.ToDouble(t.Text);
                }
            }
        }

    

        private void txtWidthWall_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Ww != null)
            {
                var t = (TextBox)e.Source;
                if (t.Text != "")
                {
                    NewWall.Width = Convert.ToDouble(t.Text);
                    Ww.Width = NewWall.ScaleWidth;
                }
            }
        }

        private void txtHeightWall_SelectionChanged(object sender, RoutedEventArgs e)
        {
          
            if (Ww != null)
            {
                var t = (TextBox)e.Source;
                if (t.Text != "")
                {
                    NewWall.Height = Convert.ToDouble(t.Text);
                    Ww.Height = NewWall.ScaleHeight;

                }
            }
          
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(FileName)) return;
            NewTile.Height = Convert.ToDouble(txtHeight.Text);
            NewTile.Width = Convert.ToDouble(txtWidth.Text);
            NewTile.Fuga = (int)sldFuga.Value/2;
            NewTile.FugaColor = brdImage.BorderBrush;
            NewTile.ImageRotation = Bi.Rotation;
            if (chkInvert.IsChecked != null) NewWall.IsInvert = chkInvert.IsChecked.Value;
            if (chkCenter.IsChecked != null) NewWall.IsCenter = chkCenter.IsChecked.Value;
            NewTile.ImageFile = FileName;
            Ww.GenerateWall(NewWall, NewTile);

        }

  

        private void MainWin_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            var op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            op.InitialDirectory = ProgramProperties.TilesDirectory;
            if (op.ShowDialog() == true)
            {
                FileName = op.FileName;

                var myBrush = new ImageBrush();

                Bi = new BitmapImage();
                Bi.BeginInit();
                Bi.UriSource = new Uri(FileName);
                Bi.Rotation = Rotation.Rotate0;
                Bi.EndInit();

                imgPhoto.Source = Bi;
                txtOpenImage.Text = op.InitialDirectory + op.FileName;
            }


        }

        private void imgPhoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Bi.Rotation == Rotation.Rotate0)
            {
                Bi = new BitmapImage();
                Bi.BeginInit();
                Bi.UriSource = new Uri(FileName);
                Bi.Rotation = Rotation.Rotate90;
                Bi.EndInit();
                imgPhoto.Source = Bi;
            }

            else
            {
                Bi = new BitmapImage();
                Bi.BeginInit();
                Bi.UriSource = new Uri(FileName);
                Bi.Rotation = Rotation.Rotate0;
                Bi.EndInit();
                imgPhoto.Source = Bi;



            }
        }

        private void sldFuga_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var c = (Slider)sender;
            brdImage.BorderThickness = new Thickness(c.Value, c.Value, c.Value, c.Value);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewTile = new Tile
            {
                Height = Convert.ToDouble(txtHeight.Text),
                Width = Convert.ToDouble(txtWidth.Text),
                Fuga = (int)sldFuga.Value / 2,
                FugaColor = brdImage.BorderBrush,
                ImageRotation = Bi.Rotation,
                ImageFile = FileName
            };


            Ww.AddTile(NewTile,Convert.ToInt16(string.IsNullOrEmpty(txtTileCnt.Text) ? "0" : txtTileCnt.Text));
        }

        private void txtWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clpFuga_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var c = (ColorPicker)sender;
            if (c.SelectedColor != null) brdImage.BorderBrush = new SolidColorBrush(c.SelectedColor.Value);
        }
    }
}
