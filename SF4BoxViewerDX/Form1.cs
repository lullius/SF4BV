using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryEditor;
using SlimDX;
using SlimDX.Direct2D;
using SlimDX.Direct3D9;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SlimDX.Windows;

namespace SF4BoxViewerDX
{
    public partial class Form1 : Form
    {       
        public Form1()
        {            
            settingsForm settings = new settingsForm();
            settings.Show();
          
            InitializeComponent();

            SetWindowLong(this.Handle, GWL_EXSTYLE,
                   (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) ^ WS_EX_LAYERED ^ WS_EX_TRANSPARENT));
            
            //Set the Alpha on the Whole Window to 255 (solid)
            SetLayeredWindowAttributes(this.Handle, 0, 255, LWA_ALPHA);
            TopMost = true;
        }

        public struct LineVertex
        {
            public Vector3 Position { get; set; }
            public int Color { get; set; }
        }

        Direct3D d3d;
        Device device;
        public static int[] hurtboxes;

        protected override void OnLoad(EventArgs e)
        {
            if (!readMemory.openProcess())
            {
                if (MessageBox.Show("SF4 needs to be open before you start SF4 Box Viewer", "Open SF4", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            RECT rct;
           
            GetWindowRect(new HandleRef(this, FindWindow(null, "SSFIVAE ")), out rct);
         
            Left = rct.Left-5;
            Top = rct.Top -5;
            Width = rct.Right - rct.Left +10;
            Height = rct.Bottom - rct.Top +10;
            Console.WriteLine(Width + "x" + Height);
                
            d3d = new Direct3D();

            PresentParameters pp = new PresentParameters();
            pp.SwapEffect = SwapEffect.Discard;
            pp.DeviceWindowHandle = Handle;
            pp.Windowed = true;
            pp.BackBufferWidth = Width;
            pp.BackBufferHeight = Height;
            pp.BackBufferFormat = Format.A8R8G8B8;
            if (Properties.Settings.Default.vsync)
            {
                pp.PresentationInterval = PresentInterval.Default; //Vsync
            }
            pp.Multisample = MultisampleType.FourSamples; //Make it pretty

            device = new Device(d3d, 0, DeviceType.Hardware, Handle,
                                CreateFlags.HardwareVertexProcessing, pp);

            http://stackoverflow.com/questions/7559054/slimdx-terminate-thread
            var form = new RenderForm("SF4 Box Viewer");
            try
            {
                MessagePump.Run(form, () =>
                    {
                        Render();
                    });
            }
            catch 
            {
            }

        }

        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        private Margins marg;

        //this is used to specify the boundaries of the transparent area
        internal struct Margins
        {
            public int Left, Right, Top, Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lp1, string lp2);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        public const int GWL_EXSTYLE = -20;

        public const int WS_EX_LAYERED = 0x80000;

        public const int WS_EX_TRANSPARENT = 0x20;

        public const int LWA_ALPHA = 0x2;

        public const int LWA_COLORKEY = 0x1;

        [DllImport("dwmapi.dll")]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);

        protected override void OnClosed(EventArgs e)
        {
            device.Dispose();
            d3d.Dispose();
        }

        public void Render()
        {
            device.Clear(ClearFlags.Target, Color.FromArgb(0, 0, 0, 0), 1.0f, 0);
            device.Clear(ClearFlags.ZBuffer, Color.FromArgb(0, 0, 0, 0), 1.0f, 0);

            RECT rct;

            GetWindowRect(new HandleRef(this, FindWindow(null, "SSFIVAE ")), out rct); //Keep this window on top of ssfiv. Not pretty but works

            Left = rct.Left - 5;
            Top = rct.Top - 5;
            Width = rct.Right - rct.Left + 10;
            Height = rct.Bottom - rct.Top + 10;
            
            //Setting up the camera
          Vector3 eye = new Vector3();
          eye.X = readMemory.GetCamX();
          eye.Y = readMemory.GetCamY();
          eye.Z = readMemory.GetCamZ();
            
            Vector3 target = new Vector3();
            target.X = readMemory.GetCamXp();
            target.Y = readMemory.GetCamYp();
            target.Z = readMemory.GetCamZp();

            float zoom = readMemory.GetCamZoom();

            Vector3 up = new Vector3(0, 1, 0);


            try
            {
                device.BeginScene();
            }
            catch 
            {
            }
         
            device.SetRenderState(RenderState.Lighting, false); //We don't need light for this...
            device.SetTransform(TransformState.View, Matrix.LookAtLH(eye, target, new Vector3(0, 1, 0)));
            device.SetTransform(TransformState.Projection, Matrix.PerspectiveLH(0.1f * 16 / 9 * zoom + 0.008f, 0.1f * zoom + 0.008f, 0.1F, 100.0F)); //Fix this shit later!

            //Draw everything...

            if (Properties.Settings.Default.P1Basic)
            {
                drawBasicBoxes(1);
            }

            if (Properties.Settings.Default.P2Basic)
            {
                drawBasicBoxes(2);
            }
              
            if (Properties.Settings.Default.P1Hit)
            {
                DrawHitbox(1);
            }

            if (Properties.Settings.Default.P2Hit)
            {
                DrawHitbox(2);
            }

            if (Properties.Settings.Default.P1Grab)
            {
                drawGrabBox(1);
            }

            if (Properties.Settings.Default.P2Grab)
            {
                drawGrabBox(2);
            }

            if (Properties.Settings.Default.P1Projectile)
            {
                drawProjectileBox(1);
            }

            if (Properties.Settings.Default.P2Projectile)
            {
                drawProjectileBox(2);
            }

            if (Properties.Settings.Default.P1Prox)
            {
                drawProxBox(1);
            }

            if (Properties.Settings.Default.P2Prox)
            {
                drawProxBox(2);
            }
        
            try
            {
                device.EndScene();
            }
            catch { }

            try
            {
                device.Present();
            }
            catch { }
        }

        public void drawBasicBoxes(int player) //Draws basic boxes (throw, hurt, physics...)
        {
            byte[] boxes;
            if (player == 1)
            {
                boxes = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0x8, 0x21e0 }, 25248); //hurtboxes P1             
            }
            else
            {
                boxes = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0xc, 0x21e0 }, 25248); //P2 0xbc90?
            }

            DrawQuadFromArray(boxes, 0x530, getColor("green"));
            DrawQuadFromArray(boxes, 0x5d0, getColor("green"));
            DrawQuadFromArray(boxes, 0x350, getColor("green"));
            DrawQuadFromArray(boxes, 0x3f0, getColor("green"));
            DrawQuadFromArray(boxes, 0x2a10, getColor("green")); //Head

            DrawBoxFromArray(boxes, 0x490, getColor("yellow"));
            DrawBoxFromArray(boxes, 0x350, getColor("yellow")); //There's at least one missing.
            DrawBoxFromArray(boxes, 0x3f0, getColor("yellow"));
            // DrawBoxFromArray(testread, 0x2330, getColor("yellow")); should this be here?

            DrawQuadFromArray(boxes, 0x2650, getColor("blue"));
            DrawQuadFromArray(boxes, 0x2330, getColor("blue")); //There's at least 1 missing!
            DrawQuadFromArray(boxes, 0x25b0, getColor("blue"));
            //   DrawQuadFromArray(testread, 0x170, getColor("blue")); //should this be here?

            if (hurtboxes != null) //These are extra boxes, unknown, broken, empty, missing etc....
            {
                foreach (int i in hurtboxes)
                {
                    DrawQuadFromArray(boxes, i, getColor("green"));
                }
            }
        }

        public void DrawHitbox(int player) //This draws the HIT(red) boxes of a player
        {
            byte[] hit;
            if (player == 1)
            {
                hit = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0x8, 0x124, 0x0, 0x0, 0x0 }, 25248); //hitboxes P1               
            }
            else
            {
                hit = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0xc, 0x124, 0x0, 0x0, 0x0 }, 25248);//P2
            }

            //Because of how fireballs and HIT(red)boxes work, 
            //I did this ugly hack. They are either d0 or e0 apart, but you don't know if they start with d0 or e0, so I did both.
            //They are checked later either way (byte 0xac from the fireball-box must be 0x2 for it to display on screen).
            bool d0e0 = false;
            for (int i = 0x0; i <= 0x2420; i += 0xd0)   
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(hit, i, getColor("red"));
            }
            d0e0 = false;
            for (int i = 0xd0; i <= 0x2420; i += 0xd0)   
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(hit, i, getColor("red"));
            }    
        }

        public void drawGrabBox(int player) //Draw grab box
        { 
            byte[] grab;
            if (player == 1)
            {
                grab = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0x8, 0x128, 0x0, 0x0, 0x0 }, 0xad); //grab box P1               
            }
            else
            {
                grab = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0xc, 0x128, 0x0, 0x0, 0x0 }, 0xad); //grab box P2
            }
            DrawBoxFromArrayOnHit(grab, 0x0, getColor("green"));
        }

        public void drawProxBox(int player) //Draw the proximity box
        {
            byte[] prox;
            if (player == 1)
            {
                prox =readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0x8, 0x120, 0x0, 0x0, 0x0 }, 0xad); //Proximity box P1         
            }
            else
            {
                prox = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0xc, 0x120, 0x0, 0x0, 0x0 }, 0xad); //P2
            }

            DrawBoxFromArrayOnHit(prox, 0x0, getColor("yellow"));    
        }

        public void drawProjectileBox(int player)
        {
            byte[] projectile1;
            byte[] projectile2;
            byte[] projectile3;
            if (player == 1)
            {
                projectile1 = readMemory.readMemoryAOB(0x0080F0E8 + readMemory.steamoffset, new int[] { 0x8, 0x98, 0x0, 0xF8, 0x1b0 }, 0x25000); //P1 fireball
                projectile2 = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0x8, 0x128, 0x0, 0x1F8, 0x1b0 }, 0x190); //P1 yogaflame (maybe only 2 boxes?)
                projectile3 = readMemory.readMemoryAOB(0x0080F0E8 + readMemory.steamoffset, new int[] { 0x8, 0x90, 0x0, 0xF8, 0x1b0 }, 0x500); //P1 knives (kunai too!) (maybe only 4 boxes?)               
            }
            else
            {
                projectile1 = readMemory.readMemoryAOB(0x0080F0E8 + readMemory.steamoffset, new int[] { 0xc, 0x98, 0x0, 0xF8, 0x1b0 }, 0x25000); //P2 fireball
                projectile2 = readMemory.readMemoryAOB(0x0080F0CC + readMemory.steamoffset, new int[] { 0xc, 0x128, 0x0, 0x1F8, 0x1b0 }, 0x190); //P2 yogaflame (maybe only 2 boxes?)
                projectile3 = readMemory.readMemoryAOB(0x0080F0E8 + readMemory.steamoffset, new int[] { 0xc, 0x90, 0x0, 0xF8, 0x1b0 }, 0x500); //P2 knives (kunai too!) (maybe only 4 boxes?)
            }

            //Because of how fireballs and HIT(red)boxes work, 
            //I did this ugly hack. They are either d0 or e0 apart, but you don't know if they start with d0 or e0, so I did both.
            //They are checked later either way (byte 0xac from the fireball-box must be 0x2 for it to display on screen).
            bool d0e0 = false; //Regular fireball
            for (int i = 0x0; i <= 0x2420; i += 0xd0)
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(projectile1, i, getColor("green"));
            }

            d0e0 = false;
            for (int i = 0xd0; i <= 0x2420; i += 0xd0)
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(projectile1, i, getColor("green"));
            }

            d0e0 = false;  //Yoga flame!
            for (int i = 0x0; i <= 0x180; i += 0xd0)
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(projectile2, i, getColor("green"));
            }
            d0e0 = false;  //Yoga flame!
            for (int i = 0xd0; i <= 0x180; i += 0xd0)
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(projectile2, i, getColor("green"));
            }

            d0e0 = false;  //Knife/Kunai
            for (int i = 0x0; i <= 0x350; i += 0xd0)
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(projectile3, i, getColor("green"));
            }
            d0e0 = false;  //Knife/Kunai
            for (int i = 0xd0; i <= 0x350; i += 0xd0)
            {
                if (d0e0)
                {
                    i += 0x10;
                    d0e0 = false;
                }
                else
                {
                    d0e0 = true;
                }
                DrawBoxFromArrayOnHit(projectile3, i, getColor("green"));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            marg.Left = 0;
            marg.Top = 0;
            marg.Right = this.Width;
            marg.Bottom = this.Height;

            DwmExtendFrameIntoClientArea(this.Handle, ref marg);  
        }

        protected override void OnResize(EventArgs e)
        {
            //Reset the device?
        }

        public Color getColor(string color) //hahaha, fix this later!
        {
            Color thecolor = new Color();
            if (color == "green")
            {
                thecolor = Color.FromArgb(120, 0, 120, 0);
                return thecolor;
            }
            else if (color == "red")
            {
                thecolor = Color.FromArgb(120, 120, 0, 0);
                return thecolor;
            }
            else if (color == "yellow")
            {
                thecolor = Color.FromArgb(60, 60, 60, 0);
                return thecolor;
            }
            else if (color == "blue")
            {
                thecolor = Color.FromArgb(120, 0, 0, 120);
                return thecolor;
            }
            else
            {
                thecolor = Color.FromArgb(60, 60, 60, 0);
                return thecolor;
            }
        }

        public void DrawLine(float x1, float y1, float z1, float x2, float y2, float z2, Color color) //Draw simple colored 3d line
        {
            LineVertex[] lineData = new LineVertex[2];

            lineData[0].Position = new Vector3(x1, y1, z1);
            lineData[0].Color = color.ToArgb();
            lineData[1].Position = new Vector3(x2, y2, z2);
            lineData[1].Color = color.ToArgb();

            device.VertexFormat = VertexFormat.Position | VertexFormat.Diffuse;
            device.DrawUserPrimitives<LineVertex>(PrimitiveType.LineList, 0, lineData.Length / 2, lineData);
        }

        public void DrawBox(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4, Color color) //Draw simple colored filled box
        {
            LineVertex[] lineData = new LineVertex[4];

            lineData[0].Position = new Vector3(x1, y1, z1);
            lineData[0].Color = color.ToArgb();
            lineData[1].Position = new Vector3(x2, y2, z2);
            lineData[1].Color = color.ToArgb();

            lineData[2].Position = new Vector3(x3, y3, z3);
            lineData[2].Color = color.ToArgb();
            lineData[3].Position = new Vector3(x4, y4, z4);
            lineData[3].Color = color.ToArgb();

            device.VertexFormat = VertexFormat.Position | VertexFormat.Diffuse;
            device.DrawUserPrimitives<LineVertex>(PrimitiveType.TriangleFan, 0, lineData.Length / 2, lineData);
        }       

        public void DrawQuad(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4, Color color) //Draw a non-filled box
        {
            DrawLine(x1, y1, z1, x2, y2, z2, color);
            DrawLine(x2, y2, z2, x3, y3, z3, color);
            DrawLine(x3, y3, z3, x4, y4, z4, color);
            DrawLine(x4, y4, z4, x1, y1, z1, color);
        }

        public void DrawQuadFromArray(byte[] array, int startindex, Color color) //Draw a non-filled box from array
        {
            DrawQuad(
                getBoxFromArray(array, startindex).x4, 
                getBoxFromArray(array, startindex).y4,
                getBoxFromArray(array, startindex).z4,
                getBoxFromArray(array, startindex).x1,
                getBoxFromArray(array, startindex).y1,
                getBoxFromArray(array, startindex).z1,
                getBoxFromArray(array, startindex).x2,
                getBoxFromArray(array, startindex).y2,
                getBoxFromArray(array, startindex).z2,
                getBoxFromArray(array, startindex).x3,
                getBoxFromArray(array, startindex).y3,
                getBoxFromArray(array, startindex).z3,
                color
                );
        }

        public void DrawBoxFromArray(byte[] array, int startindex, Color color) //Draw a filled box from an array of coordinates
        {
            DrawBox(
                getBoxFromArray(array, startindex).x4,
                getBoxFromArray(array, startindex).y4,
                getBoxFromArray(array, startindex).z4,
                getBoxFromArray(array, startindex).x1,
                getBoxFromArray(array, startindex).y1,
                getBoxFromArray(array, startindex).z1,
                getBoxFromArray(array, startindex).x2,
                getBoxFromArray(array, startindex).y2,
                getBoxFromArray(array, startindex).z2,
                getBoxFromArray(array, startindex).x3,
                getBoxFromArray(array, startindex).y3,
                getBoxFromArray(array, startindex).z3,
                color
                );
        }

        public void DrawBoxFromArrayOnHit(byte[] array, int startindex, Color color) //Draws box from array only if it's active
        {
            if (array[startindex + 0xac] != 0x2) //This byte should be 0x2 when the box is active, but for some reason that is not always the case....
                return;
   
            DrawBox(
                getBoxFromArray(array, startindex).x4,
                getBoxFromArray(array, startindex).y4,
                getBoxFromArray(array, startindex).z4,
                getBoxFromArray(array, startindex).x1,
                getBoxFromArray(array, startindex).y1,
                getBoxFromArray(array, startindex).z1,
                getBoxFromArray(array, startindex).x2,
                getBoxFromArray(array, startindex).y2,
                getBoxFromArray(array, startindex).z2,
                getBoxFromArray(array, startindex).x3,
                getBoxFromArray(array, startindex).y3,
                getBoxFromArray(array, startindex).z3,
                color
                );
        }

        public struct boxpoints    //Struct used in other functions (to store coordinates)
        {
            public float x1;
            public float x2;
            public float y1;
            public float y2;

            public float x3;
            public float x4;
            public float y3;
            public float y4;

            public float z1;
            public float z2;
            public float z3;
            public float z4;
        };

        public boxpoints getBoxFromArray(byte[] array, int startindex)  //Returns a struct with coordinates
        {
            boxpoints hitbox = new boxpoints();

            
            hitbox.x1 = System.BitConverter.ToSingle(array, startindex);
            hitbox.y1 = System.BitConverter.ToSingle(array, startindex + 0x4);
            hitbox.z1 = System.BitConverter.ToSingle(array, startindex + 0x8);

            hitbox.x2 = System.BitConverter.ToSingle(array, startindex + 0x10);
            hitbox.y2 = System.BitConverter.ToSingle(array, startindex + 0x14);
            hitbox.z2 = System.BitConverter.ToSingle(array, startindex + 0x18);

            hitbox.x3 = System.BitConverter.ToSingle(array, startindex + 0x20);
            hitbox.y3 = System.BitConverter.ToSingle(array, startindex + 0x24);
            hitbox.z3 = System.BitConverter.ToSingle(array, startindex + 0x28);

            hitbox.x4 = System.BitConverter.ToSingle(array, startindex + 0x30);
            hitbox.y4 = System.BitConverter.ToSingle(array, startindex + 0x34);
            hitbox.z4 = System.BitConverter.ToSingle(array, startindex + 0x38);

            return hitbox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
