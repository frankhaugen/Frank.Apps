using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.WpfExtensions;
using Image = System.Windows.Controls.Image;
using Window = System.Windows.Window;

namespace Frank.Apps.SecurityCam
{
    public class MainWindow : Window
    {
        private Image _image = new Image();
        private Button _button = new Button();

        private readonly BackgroundWorker worker = new BackgroundWorker();

        private readonly VideoCapture capture;
        private readonly CascadeClassifier cascadeClassifier;
        public MainWindow()
        {
            Width = 512;
            Height = 512;

            var stringBuilder = new StringBuilder();
            var stackpanel = new StackPanel();
            stackpanel.Children.Add(_image);
            stackpanel.Children.Add(_button);

            Content = stackpanel;

            _button.Content = "Start";
            //_button.Click += (sender, args) =>;

            _image.Width = 512;
            _image.Height = 445;


            capture = new VideoCapture();
            cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");

            worker.DoWork += backgroundWorker1_DoWork;
            worker.ProgressChanged += backgroundWorker1_ProgressChanged;

            Loaded += OnLoaded;
            Closing += OnClosing;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            capture.Open(0, VideoCaptureAPIs.ANY);
            if (!capture.IsOpened())
            {
                MessageBox.Show("MOW!!");
                Close();
                return;
            }

            //ClientSize = new System.Drawing.Size(capture.FrameWidth, capture.FrameHeight);

            worker.RunWorkerAsync();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            //worker..CancelAsync();
            capture.Dispose();
            cascadeClassifier.Dispose();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;

            while (!bgWorker.CancellationPending)
            {
                using (var frameMat = capture.RetrieveMat())
                {
                    var rects = cascadeClassifier.DetectMultiScale(frameMat, 1.1, 5, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(30, 30));
                    if (rects.Length > 0)
                    {
                        Cv2.Rectangle(frameMat, rects[0], Scalar.Red);
                    }

                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);
                }
                Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var frameBitmap = (Bitmap)e.UserState;
            //_image..Image?.Dispose();
            _image.Source = frameBitmap?.ToBitmapSource();
        }
    }
}
