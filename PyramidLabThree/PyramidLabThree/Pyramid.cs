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
        public Pyramid(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        
            base.OnUpdateFrame(e);
        }

        public void afterLoad()
        {

        }
        public void setTransparency(string key)
        {
            if (key.Equals("yes"))
                transparent = true;
            else
                transparent = false;

          
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
                        light_position[2] = 50.0f;
                    }; break;
                case "Top Left": {
                        light_position[0] = -50.0f;
                        light_position[1] = 50.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Top Right": {
                        light_position[0] = 50.0f;
                        light_position[1] = 50.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Center": {
                        light_position[0] = 0.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Center Right": {
                        light_position[0] = 50.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Center Left": {
                        light_position[0] = -50.0f;
                        light_position[1] = 0.0f;
                        light_position[2] = 50.0f;
                    }; break;
                case "Bottom": {
                        light_position[0] = 0.0f;
                        light_position[1] = -50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Bottom Right": {
                        light_position[0] = 50.0f;
                        light_position[1] = -50.0f;
                        light_position[2] = 0.0f;
                    }; break;
                case "Bottom Left": {
                        light_position[0] = -50.0f;
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
                          light_position[2] = 50.0f;
                        }; break;
            }





            float[] light_diffuse = { 1.0f, 1.0f, 0.0f };

            float[] light_ambiant = { 0.5f, 0.5f, 1.0f };

            float[] light_specular = {1.0f,1.0f, 1.0f}; 

            GL.Light(LightName.Light0, LightParameter.Position, light_position);

            GL.Light(LightName.Light0, LightParameter.Diffuse, light_diffuse);

            GL.Light(LightName.Light0, LightParameter.Ambient, light_ambiant);

           // GL.Light(LightName.Light0, LightParameter.Specular, light_specular);

            GL.Enable(EnableCap.Light0);

        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            //light

            light();


            if(transparent)
            transparency();



            base.OnLoad(e);
        }

        public void renderFrame()
        {

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
           // base.OnRenderFrame(e);
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
            // GL.PushMatrix();

          

           // drawBackGround();

            

            if (sides == 4)
                drawPyramid4();
            else
                drawPyramid3();


            // GL.PopMatrix();

            // GL.Translate(0.0, 0.0, -45.0);

            //  GL.Scale(0.5, 0.5, 0.5);

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

        private void drawPyramid4()
        {
            if(transparent)
            GL.Disable(EnableCap.Lighting);

            GL.Begin(PrimitiveType.Quads);

            GL.Color4(1.0, 1.0, 1.0,0.4);

            //left
            GL.Normal3(-1.0, 0.0, 0.0);

            GL.Vertex3(0.0, 10.0, 0.0);
            GL.Vertex3(0.0, 10.0, 0.0);
            GL.Vertex3(-10.0, -10.0, -10.0);//
            GL.Vertex3(-10.0, -10.0, 10.0);//

            //right
            GL.Normal3(1.0, 0.0, 0.0);

            GL.Vertex3(0.0, 10.0, 0.0);
            GL.Vertex3(0.0, 10.0, 0.0);
            GL.Vertex3(10.0, -10.0, -10.0);//
            GL.Vertex3(10.0, -10.0, 10.0);//

            //bottom
            GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            //back
            GL.Normal3(0.0, 0.0, -1.0);

            GL.Vertex3(0.0, 10.0, 0.0); 
            GL.Vertex3(10.0, -10.0, -10.0); //
            GL.Vertex3(-10.0, -10.0, -10.0); //
            GL.Vertex3(0.0, 10.0, 0.0);

            //front
            GL.Normal3(0.0, 0.0, 1.0);

            GL.Vertex3(0.0, 10.0, 0.0);
            GL.Vertex3(10.0, -10.0, 10.0); //

            GL.Vertex3(-10.0, -10.0, 10.0); //
            GL.Vertex3(0.0, 10.0, 0.0);  

            GL.End();
            GL.Enable(EnableCap.Lighting);

        }

        public void resize()
        {

        }

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
