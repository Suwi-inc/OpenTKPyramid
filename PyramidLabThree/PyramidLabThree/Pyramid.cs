using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLabThree
{
   
    internal class Pyramid : GameWindow
    {
        private double xtheta = 0.0;
        private double ytheta = 0.0;
        private double ztheta = 0.0;
        private string lightSource;
        private int sides = 0;
        private float viewDepth = 0;
        private bool transparent;
        private float pHight ;
        private float pWidth ;
        private float pDepth ;
        private bool autospin = false;

        public Pyramid(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) {
            
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        
            base.OnUpdateFrame(e);
        }

        public void setSpin(string spin)
        {
            if (spin.Equals("Yes"))
                autospin = true;
            else
                autospin = false;

        }
        public void setTransparency(string key)
        {
            if (key.Equals("Semi-Transparent"))
                transparent = true;
            else
                transparent = false;
  
        }
        public void setShapeSizes(double _height, double _width, double _depth)
        {
            pHight = (float)(_height / 2);
            pWidth = (float)_width / 2;
            pDepth = (float)_depth / 2;

        }

        public void setLightSource(string lightSource)
        {
           this.lightSource = lightSource; 
        }
        public void setViewDepth(float viewDepth)
        {
            this.viewDepth = viewDepth;
        }

        struct position
        {
            public double x;
            public double y;
            public double z;
        }

        protected void transparency()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);
        }
        protected void light()
        {
            GL.Enable(EnableCap.Lighting);

            float[] light_position = new float[3];

            switch (lightSource)
            {
                case "Top": {
                        light_position[0] = 0.0f;
                        light_position[1] = 50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Top Left": {
                        light_position[0] = 50.0f;
                        light_position[1] = 50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Top Right": {
                        light_position[0] = -50.0f;
                        light_position[1] = 50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Center": {
                        light_position[0] = 0.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Center Right": {
                        light_position[0] = -50.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Center Left": {
                        light_position[0] = 50.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Bottom": {
                        light_position[0] = 0.0f;
                        light_position[1] = -50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Bottom Right": {
                        light_position[0] = -50.0f;
                        light_position[1] = -50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Bottom Left": {
                        light_position[0] = 50.0f;
                        light_position[1] = -50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Back": {
                        light_position[0] = 0.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = -50.0f;
                    }; break;
                default: { light_position[0] = 0.0f;
                          light_position[1] = 50.0f;
                          light_position[2] = 0.0f;
                        }; break;
            }



            float[] light_diffuse = { 0.443f, 0.039f, 0.356f };  // 0.443, 0.039, 0.356

            float[] light_ambiant = { 0.443f, 0.039f, 0.356f };

            float[] light_specular = { 0.443f, 0.039f, 0.356f };

            GL.Light(LightName.Light0, LightParameter.Position, light_position);

            GL.Light(LightName.Light0, LightParameter.Diffuse, light_diffuse);

            GL.Light(LightName.Light0, LightParameter.Ambient, light_ambiant);

            GL.Light(LightName.Light0, LightParameter.Specular, light_specular);

            GL.Enable(EnableCap.Light0);

        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            //light

            light();

            //transparency
            if(transparent)
            transparency();



            base.OnLoad(e);
        }

        
        public void rotateXaxis()
        {

            GL.LoadIdentity();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
           
            GL.Translate(0.0, 0.0, viewDepth);

            //drawBackGround();

            GL.Rotate(xtheta, 1.0, 0.0, 0.0);


            if (sides == 4)
                drawPyramid4();
            else
                drawPyramid3();

            xtheta += 1;
            Context.SwapBuffers();
         
        }
        public void rotateYaxis()
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(0.0, 0.0, viewDepth);

            //drawBackGround();

            GL.Rotate(ytheta, 0.0, 1.0, 0.0);


            if (sides == 4)
                drawPyramid4();
            else
                drawPyramid3();

            ytheta += 1;
            Context.SwapBuffers();

        }
        public void rotateZaxis()
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(0.0, 0.0, viewDepth);

            //drawBackGround();

            GL.Rotate(ztheta, 0.0, 0.0, 1.0);

            if (sides == 4)
                drawPyramid4();
            else
                drawPyramid3();

            ztheta += 1;
            Context.SwapBuffers();

        }

        private void drawBackGround()
        {
           
            GL.Begin(PrimitiveType.Quads);
           
            GL.Color3(0.9, 0.0, 0.0);

            GL.Normal3(0.0, 0.0, 1.0);

            GL.Vertex3(20.0, 20.0, -50.0);
            GL.Vertex3(20.0, -20.0, -50.0);
            GL.Vertex3(-20.0, -20.0, -50.0);
            GL.Vertex3(-20.0, 20.0, -50.0);

            

            GL.End();
           
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.LoadIdentity();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(0.0, 0.0, viewDepth);

           // drawBackGround();
           if(autospin)
            {
                GL.Rotate(ztheta, 0.0, 0.0, 0.5);
                GL.Rotate(ztheta, 0.5, 0.0, 0.5);

                ztheta += 1;
            }
            

            if (sides == 4)
                drawPyramid4();
            else
                drawPyramid3();


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        public void setSides(int sides)
        {
            this.sides = sides;
        }
        private void drawPyramid3()
        {
            GL.Begin(PrimitiveType.Triangles);

            position midpoint; 

            midpoint.x = (-10+10)/2;
            midpoint.y = (10+10)/2;
            midpoint.z = (10+10)/2;

            //midpoint of c and midpoint
            position topoint;

            topoint.x = (midpoint.x + -10) / 2;
            topoint.y = (midpoint.y + 0) / 2;
            topoint.z = (midpoint.z + -10) / 2;


           // GL.Color3(1.0, 0.0, 0.0);

            //bottom
            GL.Normal3(0.0, -1.0, 0.0);

            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);


            //left
            GL.Normal3(-1.0, 0.0, 0.0);

            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(topoint.x, topoint.y, topoint.z);//
            

            //right
            GL.Normal3(1.0, 0.0, 0.0);

            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(topoint.x, topoint.y, topoint.z);//



            //front
            GL.Normal3(0.0, 0.0, 1.0);

            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(topoint.x, topoint.y, topoint.z);//

            GL.End();

        }

        //draw shape


        Vector3 getNormal(Vector3 _a, Vector3 _b, Vector3 _c)
        {
            Vector3 result = new Vector3();

            Vector3 A = _b - _a;
            Vector3 B = _c - _a;

            result.X = (A.Y * B.Z) - (A.Z * B.Y);
            result.Y = (A.X * B.Z) - (A.Z * B.X);
            result.Z = (A.X * B.Y) - (A.Y * B.X);

            result.Normalize();

            return result;
        }


        private void drawPyramid4()
        {
            Vector3 normal;
            Vector3 one;
            Vector3 two;
            Vector3 three;
            Vector3 four;

            if (transparent)
            GL.Disable(EnableCap.Lighting);



            //bottom
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(1.0, 1.0, 1.0, 0.4);

            one = new Vector3(pWidth, -pHight, pDepth);
            two = new Vector3(pWidth, -pHight, -pDepth);    
            three = new Vector3(-pWidth, -pHight, -pDepth);
            four = new Vector3(-pWidth, -pHight, pDepth);

            normal = getNormal(one, two, three);

            GL.Normal3(normal);
            GL.Vertex3(one.X, one.Y, one.Z);
            GL.Vertex3(two.X, two.Y, two.Z);
            GL.Vertex3(three.X, three.Y, three.Z);
            GL.Vertex3(four.X, four.Y, four.Z);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(1.0, 1.0, 1.0, 0.4);

            //left

            one = new Vector3(0.0f, pHight, 0.0f);
            two = new Vector3(-pWidth, -pHight, -pDepth);
            three = new Vector3(-pWidth, -pHight, pDepth);
           

            normal = getNormal(one, two, three);


            GL.Normal3(-normal);
            GL.Vertex3(one.X, one.Y, one.Z);
            GL.Vertex3(two.X, two.Y, two.Z); //
            GL.Vertex3(three.X, three.Y, three.Z); //



            //right

            one = new Vector3(0.0f, pHight, 0.0f);
            two = new Vector3(pWidth, -pHight, -pDepth);
            three = new Vector3(pWidth, -pHight, pDepth);


            normal = getNormal(one, two, three);


            GL.Normal3(normal);
            GL.Vertex3(one.X, one.Y, one.Z);
            GL.Vertex3(two.X, two.Y, two.Z); //
            GL.Vertex3(three.X, three.Y, three.Z); //


            //back

            one = new Vector3(0.0f, pHight, 0.0f);
            two = new Vector3(pWidth, -pHight, -pDepth);
            three = new Vector3(-pWidth, -pHight, -pDepth);


            normal = getNormal(one, two, three);


            GL.Normal3(-normal);
            GL.Vertex3(one.X, one.Y, one.Z);
            GL.Vertex3(two.X, two.Y, two.Z); //
            GL.Vertex3(three.X, three.Y, three.Z); //



          
            //front
         

            one = new Vector3(0.0f, pHight, 0.0f);
            two = new Vector3(pWidth, -pHight, pDepth);
            three = new Vector3(-pWidth, -pHight, pDepth);


            normal = getNormal(one, two, three);


            GL.Normal3(normal);
            GL.Vertex3(one.X, one.Y, one.Z);
            GL.Vertex3(two.X, two.Y, two.Z); //
            GL.Vertex3(three.X, three.Y, three.Z); //



            GL.End();
            GL.Enable(EnableCap.Lighting);

            

        }

        //projection
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //3d
            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(0.78f, Width / Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);

            base.OnResize(e);
        }



    }
}
