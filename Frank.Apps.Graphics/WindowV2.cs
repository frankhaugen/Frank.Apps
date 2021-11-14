
//using System.Drawing;
//using System.Drawing.Imaging;
//using OpenTK.Graphics.OpenGL.Compatibility;
//using OpenTK.Mathematics;
//using OpenTK.Windowing.Common;
//using OpenTK.Windowing.Desktop;

//namespace Frank.Apps.Graphics
//{
//    public class WindowV2 : GameWindow
//    {
//        int texture;
//        float x, y;
        

//        protected override void OnLoad()
//        {
//            GL.ClearColor(Color4.Salmon);
//            GL.Ortho(0, 800, 600, 0, -1, 1);
//            GL.Viewport(0, 0, 800, 600);

//            GL.Enable(EnableCap.Texture2D);
//            GL.Enable(EnableCap.Blend);
//            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

//            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

//            GL.GenTextures(1, out this.texture);
//            GL.BindTexture(TextureTarget.Texture2D, this.texture);

//            Bitmap bitmap = new Bitmap("ship.png");
//            bitmap.MakeTransparent(Color.Magenta);

//            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
//                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

//            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
//                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

//            bitmap.UnlockBits(data);
//            bitmap.Dispose();

//            GL.Texpa.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
//            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

//            this.x = 40f;
//            this.y = 41.5f;

//            base.OnLoad();
//        }

//        protected override void OnUpdateFrame(FrameEventArgs e)
//        {
//base.OnUpdateFrame(e);

//            float dx = 0.0f;
//            float dy = 0.0f;

//            if (this.Keyboard[Key.Left])
//                dx = -1.0f;
//            else if (this.Keyboard[Key.Right])
//                dx = 1.0f;

//            if (this.Keyboard[Key.Up])
//                dy = -1.0f;
//            else if (this.Keyboard[Key.Down])
//                dy = 1.0f;

//            this.x += 100.0f * dx * (float)e.Time;
//            this.y += 100.0f * dy * (float)e.Time;
//        }

//        protected override void OnRenderFrame(FrameEventArgs e)
//        {
//            base.OnRenderFrame(e);

//            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

//            GL.MatrixMode(MatrixMode.Projection);
//            GL.LoadIdentity();

//            GL.Begin(BeginMode.Quads);
//            GL.TexCoord2(0, 0);
//            GL.Vertex2(this.x - 40.0f, this.y - 41.5f);
//            GL.TexCoord2(1, 0);
//            GL.Vertex2(this.x + 40.0f, this.y - 41.5f);
//            GL.TexCoord2(1, 1);
//            GL.Vertex2(this.x + 40.0f, this.y + 41.5f);
//            GL.TexCoord2(0, 1);
//            GL.Vertex2(this.x - 40.0f, this.y + 41.5f);
//            GL.End();

//            GL.Flush();
//            this.SwapBuffers();
//        }

//        [STAThread]
//        public static void Main()
//        {
//            AppWindow window = new AppWindow();
//            window.Run(60);
//        }

//        public WindowV2(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
//        {
//        }
//    }
//}
