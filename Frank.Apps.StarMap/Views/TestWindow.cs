using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Frank.Apps.StarMap.Views
{
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            //InitializeComponent();

            //working and finalized functions code
            //GetDecSeparator(); //Initiating the function GetComma
            //funtions undergoing testing and development
            TestAddLine(); //testing
            //uiScaleSlider.MouseDoubleClick += new MouseButtonEventHandler(RestoreScalingFactor); //zoom func
        }

        //Funtion to add stars (ellipses) to the XAML canvas 'starfield', from the 'stars_db' database
        public void AddStarsFromDB(object StarID, object HIP, object HD, object Gliese, object BayerFlamsteed, object ProperName, object Distance, object Spectrum, object ColorIndex, object X, object Y, object Z)
        {
            //set up all information from DB as string variables, with explanatory names
            String StarID_str = StarID.ToString();
            String HIP_str = HIP.ToString();
            String HD_str = HD.ToString();
            String Gliese_str = Gliese.ToString();
            String BayerFlamsteed_str = BayerFlamsteed.ToString();
            String ProperName_str = ProperName.ToString();
            String Distance_str = Distance.ToString();
            String Spectrum_str = Spectrum.ToString();
            String ColorIndex_str = ColorIndex.ToString();
            String X_str = X.ToString();
            String Y_str = Y.ToString();
            String Z_str = Z.ToString();

            //converting X-coordinates to double then converting to light-years and multiplying by 10
            double X_ly = double.Parse(X_str);
            X_ly = X_ly * 3.26163344 * 10;

            //converting Y-coordinates to double then converting to light-years and multiplying by 10
            double Y_ly = double.Parse(Y_str);
            Y_ly = Y_ly * 3.26163344 * 10;

            //converting Z-coordinates to double then converting to light-years and multiplying by 10
            double Z_ly = double.Parse(Z_str);
            Z_ly = Z_ly * 3.26163344 * 10;

            //Get star classifications using dedicated function
            int StarType = Int32.MaxValue;// DetermineStarType(Spectrum_str);

            //Ellipse size and color settings based on star type
            int HeightWidthValTmp = 0;
            String StarColorValTmp = null;
            int xIndexVal = 0;


            //declearing variables to make 
            int StarSizeHeightWidth = HeightWidthValTmp;
            string StarColorVal = StarColorValTmp;
            int CoordOffsetVal = StarSizeHeightWidth / 2 * -1;

            //Setting up a "tooltip" to give information on stars
            var StarInfo = new StackPanel();
            StarInfo.Children.Add(new TextBlock() { Text = "name: " + ProperName_str + ", " + BayerFlamsteed_str });
            StarInfo.Children.Add(new TextBlock() { Text = "Catalog no: " + Gliese_str + ", HD: " + HD_str });
            StarInfo.Children.Add(new TextBlock() { Text = "coordinates: " + X_ly / 10 + ";" + Y_ly / 10 + ";" + Z_ly / 10 + " ly" });
            //StarInfo.Children.Add(new TextBlock() { Text = "Distance from sol: " + ParsecToLightYearConverter(double.Parse(Distance_str)) + "ly" });

            //creates a colorbrush from string
            BrushConverter conv = new BrushConverter();
            SolidColorBrush brush = conv.ConvertFromString(StarColorVal) as SolidColorBrush;

            //setting up and adding new star
            var star = new Ellipse
            {
                Height = StarSizeHeightWidth,
                Width = StarSizeHeightWidth,
                Fill = brush,
                RenderTransform = new TranslateTransform(CoordOffsetVal, CoordOffsetVal),
                ToolTip = StarInfo,
                Cursor = Cursors.Hand
            };
            star.SetValue(Canvas.LeftProperty, X_ly);   //left-right distance from center in pixles
            star.SetValue(Canvas.TopProperty, Y_ly);    //top-bottom distance from center in pixles
            star.SetValue(Canvas.ZIndexProperty, -400 + xIndexVal); //

            //starfield.Children.Add(star);

        }



        //Function to convert a string to double
        public double stringToDouble(string X)
        {
            double doubledString = Convert.ToDouble(X);
            return doubledString;
        }




        // Add a Line Element
        public void TestAddLine()
        {
            var myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.White;
            myLine.X1 = 1;
            myLine.X2 = 50;
            myLine.Y1 = 1;
            myLine.Y2 = 50;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 1;
            //starfield.Children.Add(myLine);
        }

        //Handle button event to turn on or of the map-grid
        private void btnGridVis_Click(object sender, RoutedEventArgs e)
        {
            //if (gridPattern.Visibility == Visibility.Visible)
            //{
            //    gridPattern.Visibility = Visibility.Hidden;
            //}
            //else
            //{
            //    gridPattern.Visibility = Visibility.Visible;
            //}
        }
    }
}
