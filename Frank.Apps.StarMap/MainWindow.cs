using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using CsvHelper.Configuration;
using Frank.Apps.StarMap.Models;
using Path = System.IO.Path;

namespace Frank.Apps.StarMap
{
    public class MainWindow : Window
    {
        private readonly IEnumerable<Star> _stars;
        private readonly CsvConfiguration _options = new CsvConfiguration(CultureInfo.InvariantCulture, delimiter: ";", hasHeaderRecord: true);
        private Canvas _canvas;

        public MainWindow()
        {
            _stars = GetEnumerable(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Stars.csv")));
            _canvas = new Canvas();

            CreateScene();

            Content = _canvas;

        }

        public MeshGeometry3D GetMeshGeometry3D()
        {

            var star = new StarModel();
            //star.Points.Add(new(0, 0, 0));
            //star.Radius = 50;
            //star.Separators = 5;

            return new MeshGeometry3D() { Positions = star.Points, TriangleIndices = star.TriangleIndices };
        }

        public MeshGeometry3D CreateStar()
        {
            var star = new StarModel();
            star.Radius = 50;
            star.Separators = 5;

            return new MeshGeometry3D() { Positions = star.Points, TriangleIndices = star.TriangleIndices };
        }

        /// <summary>
        /// Creates a scene and start animation
        /// </summary>
        private void CreateScene()
        {
            // create cube
            var cube = new GeometryModel3D();
            var cubeMesh = CreateStar();
            //var cubeMesh = GetCube();
            cube.Geometry = cubeMesh;

            cube.Material = new DiffuseMaterial(new SolidColorBrush(Colors.GreenYellow));

            // create directional light
            var light = new DirectionalLight();
            light.Color = Colors.White;
            light.Direction = new Vector3D(-1, -1, -1);

            // create camera
            var camera = new PerspectiveCamera();
            camera.FarPlaneDistance = 2000;
            camera.NearPlaneDistance = 1;
            camera.FieldOfView = 45;
            camera.Position = new Point3D(200, 200, 300);
            camera.LookDirection = new Vector3D(-20, -20, -30);
            camera.UpDirection = new Vector3D(0, 1, 0);

            // collect cube and light in one model
            var modelGroup = new Model3DGroup();
            modelGroup.Children.Add(cube);
            modelGroup.Children.Add(light);
            var modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            // create scene
            var viewport = new Viewport3D();
            viewport.Camera = camera;
            viewport.Children.Add(modelsVisual);
            _canvas.Children.Add(viewport);
            viewport.MinHeight = 600;
            viewport.MinWidth = 600;
            Canvas.SetTop(viewport, 0);
            Canvas.SetLeft(viewport, 0);
            Width = viewport.Width;
            Height = viewport.Height;

            // create and start animation
            //var axis = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            //var rotate = new RotateTransform3D(axis);
            //cube.Transform = rotate;
            //var animation = new DoubleAnimation();
            //animation.From = 0;
            //animation.To = 360;
            //animation.Duration = new Duration(TimeSpan.FromSeconds(20.0));
            //animation.RepeatBehavior = RepeatBehavior.Forever;
            //NameScope.SetNameScope(_canvas, new NameScope());
            //_canvas.RegisterName("cubeaxis", axis);
            //Storyboard.SetTargetName(animation, "cubeaxis");
            //Storyboard.SetTargetProperty(animation, new PropertyPath(AxisAngleRotation3D.AngleProperty));
            //var rotCube = new Storyboard();
            //rotCube.Children.Add(animation);
            //rotCube.Begin(_canvas);
        }

        /// <summary>
        /// Create and returns a cubic mesh
        /// </summary>
        MeshGeometry3D GetCube()
        {
            var cube = new MeshGeometry3D();
            var corners = new Point3DCollection
            {
                new Point3D(0.5, 0.5, 0.5),
                new Point3D(-0.5, 0.5, 0.5),
                new Point3D(-0.5, -0.5, 0.5),
                new Point3D(0.5, -0.5, 0.5),
                new Point3D(0.5, 0.5, -0.5),
                new Point3D(-0.5, 0.5, -0.5),
                new Point3D(-0.5, -0.5, -0.5),
                new Point3D(0.5, -0.5, -0.5)
            };
            cube.Positions = corners;

            int[] indices ={
                //Front
                0,1,2,
                0,2,3,
                //Back
                4,7,6,
                4,6,5,
                //Right
                4,0,3,
                4,3,7,
                //Left
                1,5,6,
                1,6,2,
                //Top
                1,0,4,
                1,4,5,
                //Bottom
                2,6,7,
                2,7,3 };

            var triangles = new Int32Collection();
            foreach (var index in indices)
            {
                triangles.Add(index);
            }
            cube.TriangleIndices = triangles;
            return cube;
        }
    }
}
