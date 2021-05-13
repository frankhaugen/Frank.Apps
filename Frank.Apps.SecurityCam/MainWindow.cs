using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using Image = System.Windows.Controls.Image;
using Window = System.Windows.Window;

namespace Frank.Apps.SecurityCam
{
    public class MainWindow : Window
    {



        VideoCaptureDevice LocalWebCam;
        public FilterInfoCollection LoaclWebCamsCollection;



        private Image _image = new Image();
        private Frame _frame = new Frame();
        private ImageSource _imageSource;
        private Button _button = new Button();
        private bool _isRunning = true;
        private FilterInfoCollection _devices;
        private VideoSourcePlayer _player = new VideoSourcePlayer();

        public MainWindow()
        {
            Width = 512;
            Height = 512;

            var stringBuilder = new StringBuilder();
            var stackpanel = new StackPanel();

            //var ffff = new VlcVideoSourceProvider(Dispatcher.CurrentDispatcher).VideoSource;

            //var videoControl = new VlcControl() { Width = 512, Height = 445 };
            //videoControl.
            _devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (_devices.Count != 0)
            {
                //add all devices to combo
                foreach (FilterInfo device in _devices)
                {
                    stringBuilder.AppendLine($"{device.Name} - {device.MonikerString}");
                    //comboBox1.Items.Add(device.Name);
                    //_logger.LogInformation(device.MonikerString + " - " + device.Name);
                }
            }
            else
            {
                //comboBox1.Items.Add("No DirectShow devices found");
            }

            //comboBox1.SelectedIndex = 0;

            //stackpanel.Children.Add(webcam);
            //stackpanel.Children.Add(videoControl);



            var label = new Label() { Content = stringBuilder.ToString(), Height = 445, Width = 512 };


            stackpanel.Children.Add(_image);
            stackpanel.Children.Add(_button);

            Content = stackpanel;

            _button.Content = "Start";
            _button.Click += OnLoaded;
            //_button.Click += _button_Click;
            //Closing += (sender, args) => _isRunning = false;

            _image.Width = 512;
            _image.Height = 445;
            //Player

            //Loaded += OnLoaded;


            //_image.Source = _imageSource;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoaclWebCamsCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            LocalWebCam = new VideoCaptureDevice(LoaclWebCamsCollection[0].MonikerString);
            LocalWebCam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);

            LocalWebCam.Start();
        }

        void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                System.Drawing.Image img = (Bitmap)eventArgs.Frame.Clone();

                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();

                bi.Freeze();
                Dispatcher.BeginInvoke(new ThreadStart(delegate
                {
                    _image.Source = bi;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


















        private async void _button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //var capture = new VideoCapture(0);
            //var window = new OpenCvSharp.Window("El Bruno – OpenCVSharp demo");

            //var page = new Page();

            //_frame.Content = page;

            //var image = new Mat();
            //while (_isRunning)
            //{
            //    capture.Read(image);
            //    if (image.Empty()) break;
            //    window.ShowImage(image);
            //    if (Cv2.WaitKey(1) == 113) // Q
            //        break;
            //}
        }

        private void OpenCamera()
        {
            try
            {
                var usbcamera = _devices[0];

                var videoDevice = new VideoCaptureDevice(_devices[Convert.ToInt32(usbcamera)].MonikerString);
                var snapshotCapabilities = videoDevice.SnapshotCapabilities;
                if (snapshotCapabilities.Length == 0)
                {
                    //MessageBox.Show("Camera Capture Not supported");
                }

                OpenVideoSource(videoDevice);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }



        public void OpenVideoSource(IVideoSource source)
        {
            try
            {
                // set busy cursor
                //this.Cursor = Cursors.WaitCursor;

                // stop current video source
                //CloseCurrentVideoSource();

                // start new video source
                _player.VideoSource = source;
                //_player.Start();

                // reset stop watch
                //stopWatch = null;


                //this.Cursor = Cursors.Default;
            }
            catch { }
        }
    }
}
