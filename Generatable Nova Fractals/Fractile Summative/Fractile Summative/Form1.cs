using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics;
using System.Collections;

namespace Fractile_Summative
{
    public partial class fractalForm : Form
    {
        private Bitmap fractalBitmap = new Bitmap(900, 900);
        public fractalForm()
        {
            //Sets Window's Size, Location, and Starting Text
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Size = new Size(930, 750);
            fractalPictureBox.BorderStyle = BorderStyle.FixedSingle;
            fractalPictureBox.BackColor = Color.AliceBlue;
            informationLabel.Text = "Click A Fractal Button At The\nBottom, Enter The Desired\nInputs For A Nova Fractal.\nSome Fractals May Take A\nWhile To Load. Buttons, Labels\nAnd Input Fields Will Be Disabled\nUntil The Fractal Loads, These\nWill Come Back Once The Fractal\nIs Loaded. Inputs Must Be\n Less Than 65000.";
            inputLabel.Text = "Nova Fractal \n     Inputs";
            
        }

        private void fractalPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Refreshes Picturebox
            fractalPictureBox.BackColor = Color.AliceBlue;
            e.Graphics.DrawImage(fractalBitmap, 0, 0);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //When a textbox text is changed, this method ensures only numbers and negative signs are in the text.
            string numbers = "-0123456789";
            string text = "";
            TextBox textbox = sender as TextBox;
            for (int i = 0; i < textbox.Text.Length; i++)
            {
                if (numbers.Contains(textbox.Text[i]))
                {
                    text = text + textbox.Text[i];
                }
            }
            textbox.Text = text;
            textbox.SelectionStart = textbox.Text.Length;
        }
        private void textBoxScale_TextChanged(object sender, EventArgs e)
        {
            //When a textbox text is changed, this method ensures only numbers, negative signs, and decimals are in the text.
            //This method is used for the scale factor (R), and the shift (C) inputs.
            string numbers = "-.0123456789";
            string text = "";
            TextBox textbox = sender as TextBox;
            for (int i = 0; i < textbox.Text.Length; i++)
            {
                if (numbers.Contains(textbox.Text[i]))
                {
                    text = text + textbox.Text[i];
                }
            }
            textbox.Text = text;
            textbox.SelectionStart = textbox.Text.Length;
        }
        
        private void fernButton_Click(object sender, EventArgs e)
        {
            //This for loop removes the labels and buttons from the form. It is done so the user cannot click buttons 
            //while the fractal is loading. The user is also unable to input values, or read text that doesnt correspond to
            //the fractal being generated.  
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = false;
            }
            Graphics fernGraphic = Graphics.FromImage(fractalBitmap);
            SolidBrush brush = new SolidBrush(Color.ForestGreen);
            Random randObj = new Random();
            fernGraphic.Clear(fractalPictureBox.BackColor);
            barnleysFern(fernGraphic, brush, 0, 0, randObj);
            fractalPictureBox.Refresh();
            informationLabel.Text = "This fractal is generated using\n75,000 points. It starts with 1 dot,\nand then based on certain \nprobabilities of moving \nthat point in specific directions \nand drawing a new point at that \nlocation, a leaf is formed.\nIf the button is clicked again, \nthe leaf will look slightly different.";
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = true;
            }
        }
        private void mandelbrotButton_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = false;
            }
            Graphics mandelbrotGraphics = Graphics.FromImage(fractalBitmap);
            mandelbrotGraphics.Clear(fractalPictureBox.BackColor);
            mandelbrotSet(mandelbrotGraphics);
            fractalPictureBox.Refresh();
            informationLabel.Text = "This fractal is generated by\nconverting the window coordinates\ninto complex numbers.The\nnumbers are then run through\na recursive formula of  \nz=x^2 + the complex number\nwhere the value of x starts at 0, \nand then the output of z,becomes\nthe new x input if this value tends\ntowards infinity, the number is\nshaded purple (based on how long\nthe number takes to increase in\nsize.The center black portion are\nthe numbers that do not tend\ntowards infinity.In this fractal the\nimaginary axis is the x - axis, while\nthe real axis is the y - axis forming\na Buddha like pattern.";
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = true;
            }
        }
        private void fractalPlant_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = false;
            }
            Graphics plantGraphics = Graphics.FromImage(fractalBitmap);
            SolidBrush brush = new SolidBrush(Color.DarkOliveGreen);
            int RecursionDepth = 5;

            plantGraphics.Clear(fractalPictureBox.BackColor);

            fractalPlantLSystem(plantGraphics, brush, 150, 600, RecursionDepth, Math.PI/2 + 0.436332);
            fractalPictureBox.Refresh();
            informationLabel.Text = "This fractal is generated using\nL-Systems. If you start with a string \n'X'.For each iteration you do, \nthe characters in that \nstring get replaced with other \ncharacters. 'X' is replaced with \n'F+[[X]-X]-F[-FX]+X'\nEach character corresponds to a \ndifferent drawing action.";
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = true;
            }
        }
        private void mengerSponge_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = false;
            }
            Graphics spongeGraphics = Graphics.FromImage(fractalBitmap);

            spongeGraphics.Clear(fractalPictureBox.BackColor);
            SolidBrush brush = new SolidBrush(Color.Blue);
            int RecursionDepth = 4;

            drawMengerSponge(spongeGraphics, brush, 300, 75, 250, RecursionDepth);
            
            fractalPictureBox.Refresh();
            informationLabel.Text = "The fractal is generated by first\ncreating a cube, and cutting out\nthe appropriate sections.This\nsponge is the 3d generalization\nof the Sierpinski’s Carpet, which\nitself is the 2d generalization of\nthe Cantor Set.Each of the\nfaces consist of a Sierpinski’s\nCarpet.";
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = true;
            }

        }
        private void novaButton_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (control is TextBox)
                    defaultText((TextBox)control);
            }
            //If the user accidently double clicks the Nova Button it will take a long time to load both Nova Fractals, so the button gets disabled as soon as it can be.
            novaButton.Enabled = false;
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = false;
            }
            Graphics novaGraphics = Graphics.FromImage(fractalBitmap);
            novaGraphics.Clear(fractalPictureBox.BackColor);
            //If the user enters a value greater or less than an Int16 can hold, a message will pop up, and the default fractal will be generated.
            try
             {
                novaFractal(novaGraphics, Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text), Convert.ToInt16(textBox3.Text), Convert.ToInt16(textBox4.Text), new Complex(Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox7.Text)), new Complex(Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox8.Text)));
            }
            catch
            {
                MessageBox.Show("Invalid Input. Fractal Inputs Changed To Default");
                novaFractal(novaGraphics,1,0,0,-1, new Complex(1.47, 1), new Complex(0,0));
            }


            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (!(control is PictureBox))
                    control.Visible = true;
            }
            informationLabel.Text = "This fractal is generated by\nconverting the window coordinates\nInto complex numbers.The\nnumbers are then run through\na recursive formula of\nz = x - R * (f(x) / f’(x)) +C\nwhere the value of x starts at\nthe complex number, and then\nthe output of z becomes the new\ninput for x.f(x) is a given function\nwith integer coefficients, while R is\na complex multiplier, and C is a\ncomplex shift.The color of the\nfractal is randomized.Try out\nthe function x ^ 3 - 1, with a\nmultiplier of 1.47 + 1i, for a nice\nfractal.";
  
            novaButton.Enabled = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Graphics clearGraphic = Graphics.FromImage(fractalBitmap);
            clearGraphic.Clear(fractalPictureBox.BackColor);
            fractalPictureBox.Refresh();
        }

        private void defaultText(TextBox textbox)
        {
            //This method is called when a textbox is left empty
            if (textbox.Text == "")
                textbox.Text = "0";
        }

        private void barnleysFern(Graphics drawingSurface, Brush drawingBrush, double x, double y, Random rand)
        {
            for (int i = 0; i < 75000; i++)
            {
                drawingSurface.FillRectangle(drawingBrush, (float)(280+(50 * x)), (float)(570-((50 * y))), 1, 1);
                int direction = rand.Next(1, 101);
                if (direction == 1)
                {
                    x = 0;
                    y = (0.16 * y);
                }
                else if (direction > 1 && direction <= 87)
                {
                    x = (0.85 * x + 0.04 * y);
                    y = (1.6 + -0.04 * x + 0.85 * y);
                }
                else if (direction > 87 && direction < 94)
                {
                    x = (0.2 * x + -0.22 * y);
                    y = (1.6 + 0.23 * x + 0.22 * y);
                }
                else
                {
                    x = (-0.15 * x + 0.28 * y);
                    y = (0.44 + 0.26 * x + 0.24 * y);
                }
            }
        }

        private void mandelbrotSet(Graphics drawingSurface)
        {

            int width = fractalPictureBox.Width;
            int height = fractalPictureBox.Height;
            double realStartValue = -1.5;
            double realEndValue = 0.5;
            double imagiStartValue = -1;
            double imagiEndValue = 1;
            Color color = new Color();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Complex c = new Complex((realStartValue + ((y / (double)height) * (double)(realEndValue - realStartValue))), (imagiStartValue + (x / (double)width) * ((imagiEndValue - imagiStartValue))));
                    int temp = checkMandelbrot(c);

                    if (temp<16)
                        color = Color.FromArgb(temp*5, temp * 3, (int)Math.Pow(temp,2));
                    else
                        color = Color.Purple;
                    drawingSurface.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
                fractalPictureBox.Refresh();
            }
        }
        private int checkMandelbrot(Complex num)
        {
            Complex z = 0;
            int counter = 1;
            while (counter < 255)
            {
                z = z * z;
                z += num;
                counter++;
                if (z.Magnitude > 2)
                    return counter;
            }
            return 0;
        }

        private void fractalPlantLSystem(Graphics drawingSurface, Brush drawingBrush, int x, int y, int RecursionDepth, double angle)
        {

            Point point1 = new Point(x, y);
            Stack angles = new Stack();
            Stack points = new Stack();


            string sequence = "X";

            for (int i = 0; i < RecursionDepth; i++)
            {
                string newSequence = "";
                for (int j = 0; j < sequence.Count(); j++)
                {
                    if ((sequence[j]).ToString() == "X")
                        newSequence = newSequence + "F+[[X]-X]-F[-FX]+X";
                    else if ((sequence[j]).ToString() == "F")
                        newSequence += "FF";
                    else
                        newSequence += sequence[j].ToString();
                }
                sequence = newSequence;
            }

            sequence = sequence.Replace("X", "");

            for (int i=0; i < sequence.Count(); i++)
            {
                string step = sequence[i].ToString();
                if (step == "F")
                {
                    Point point2 = new Point((int)(point1.X - 7*Math.Cos(angle)), (int)(point1.Y - 7*Math.Sin(angle)));
                    drawingSurface.DrawLine(new Pen(drawingBrush, 1), point1, point2);
                    point1 = point2;
                }
                else if (step == "+")
                {
                    angle -= 0.436332;
                }
                else if (step == "-")
                {
                    angle += 0.436332;
                }
                else if (step == "[")
                {
                    angles.Push(angle);
                    points.Push(point1);
                }
                else
                {
                    angle = (double)angles.Pop();
                    point1 = (Point)points.Pop();
                }
            }

        }

        private void drawMengerSponge(Graphics drawingSurface, Brush brush, int size, int x, int y, int RecursionDepth)
        {
            Rectangle R = new Rectangle(x, y, size, size);
            drawingSurface.FillRectangle(brush, R);
            int skew = size / 2;
            Point[] pointArray = { new Point(x, y), new Point(x + skew, y - skew), new Point(x + size + skew, y - skew), new Point(x + skew + size, y - skew + size), new Point(x + size, y + size) };
            drawingSurface.FillPolygon(brush, pointArray);


            //tl,bl,br,tr
            cutMengerSpongeTop(drawingSurface, x, y, size, RecursionDepth);

            //bl,tl,tr,br
            cutMengerSpongeRight(drawingSurface, x+size, y, size, RecursionDepth);

            cutMengerSpongeFront(drawingSurface, x, y, size, RecursionDepth);

        }
        private void cutMengerSpongeTop(Graphics drawingSurface, int x, int y, int size, int RecursionDepth)
        {
            if (RecursionDepth >= 1)
            {
                int skew = size / 2;
                Point[] pointArrayTop = { new Point(x + skew + skew / 3, y - 2 * skew / 3), new Point(x + skew, y - skew / 3), new Point(x + skew + 2 * skew / 3, y - skew / 3), new Point(x + skew + skew, y - 2 * skew / 3) };
                drawingSurface.FillPolygon(new SolidBrush(Color.White), pointArrayTop);

                cutMengerSpongeTop(drawingSurface, x + 2 * skew / 3, y - 2 * skew / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x + skew + skew / 3, y - 2 * skew / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x + skew + skew, y - 2 * skew / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x + skew / 3, y - skew / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x + +skew+2*skew / 3, y - skew / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x,y, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x+2*skew/3, y, size / 3, RecursionDepth - 1);
                cutMengerSpongeTop(drawingSurface, x+skew+skew/3, y, size / 3, RecursionDepth - 1);
            }
        }
        private void cutMengerSpongeRight(Graphics drawingSurface, int x, int y, int size, int RecursionDepth)
        {
            if (RecursionDepth >= 1)
            {
                int skew = size / 2;
                Point[] pointArrayRight = { new Point(x + skew / 3, y + 3 * skew / 3), new Point(x + skew / 3, y + skew / 3), new Point(x + 2 * skew / 3, y), new Point(x + 2 * skew / 3, y + 2 * skew / 3) };
                drawingSurface.FillPolygon(new SolidBrush(Color.White), pointArrayRight);


                cutMengerSpongeRight(drawingSurface, x, y, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x+skew/3, y-skew/3, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x+2*skew/3, y-2*skew/3, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x, y+2*skew/3, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x + 2 * skew / 3, y, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x, y+4*skew/3, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x + skew / 3, y + skew, size / 3, RecursionDepth - 1);
                cutMengerSpongeRight(drawingSurface, x + 2 * skew / 3, y + 2*skew/3, size / 3, RecursionDepth - 1);

            }
        }
        private void cutMengerSpongeFront(Graphics drawingSurface, int x, int y, int size, int RecursionDepth)
        {
            if (RecursionDepth >= 1)
            {

                Rectangle R2 = new Rectangle(x + (size / 3), y + (size / 3), size / 3, size / 3);
                drawingSurface.FillRectangle(new SolidBrush(Color.White), R2);

                cutMengerSpongeFront(drawingSurface, x, y, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x+size/3, y, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x+2*size/3, y, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x, y+size/3, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x+2*size/3, y + size / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x, y + 2*size / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x+size/3, y + 2*size / 3, size / 3, RecursionDepth - 1);
                cutMengerSpongeFront(drawingSurface, x+2*size/3, y + 2*size / 3, size / 3, RecursionDepth - 1);
            }
        }

        private void novaFractal(Graphics drawingSurface, int CubeCoefficient, int SquareCoefficient, int LinearCoefficient, int Constant, Complex ScaleConstant, Complex ShiftConstant )
        {
            //If all the coefficient's are 0, the fractal takes very long to load, and is a square colored in with a single character.
            //To prevent this, the leading coefficient is changed to 1.
            if (CubeCoefficient == SquareCoefficient && SquareCoefficient == LinearCoefficient && LinearCoefficient == 0)
            {
                CubeCoefficient = 1;
            }
            List<Complex> solutions = findSolutions(CubeCoefficient,SquareCoefficient,LinearCoefficient,Constant);
            int width = fractalBitmap.Width;
            int height = fractalBitmap.Height;
            double realStartValue = -500;
            int realEndValue = 500;
            int imagiStartValue = -500;
            int imagiEndValue = 500;
            Random randobj = new Random();
            List<Color> colors = new List<Color> { };
            for (int x = 0; x < 3; x++)
            {
                int r = randobj.Next(1, 256);
                int b = randobj.Next(1, 256);
                int g = randobj.Next(1, 256);

                Color color = Color.FromArgb(r, b, g);
                colors.Add(color);
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Complex c = new Complex((realStartValue + ((x / (double)width) * (double)(realEndValue - realStartValue))), (imagiStartValue + (y / (double)height) * ((imagiEndValue - imagiStartValue))));
                    int temp = checkNova(c, solutions, CubeCoefficient, SquareCoefficient, LinearCoefficient, Constant, ScaleConstant, ShiftConstant);

                    SolidBrush brush = new SolidBrush(colors[temp]);
                    drawingSurface.FillRectangle(brush, x, y, 1, 1);
                }   
                fractalPictureBox.Refresh();
            }
        }
        private List<Complex> findSolutions(int CubeCoefficient, int SquareCoefficient, int LinearCoefficient, int Constant)
        {
            //Gets all the complex Roots of a cubic cubic function.
            List<Complex> solutions = new List<Complex>();
            Tuple<Complex,Complex,Complex> roots = FindRoots.Cubic(Constant, LinearCoefficient, SquareCoefficient, CubeCoefficient); 
            solutions.Add(roots.Item1);
            solutions.Add(roots.Item2);
            solutions.Add(roots.Item3);
            
            return solutions;

        }
        private int checkNova(Complex c, List<Complex> solutions, int CubeCoefficient, int SquareCoefficient, int LinearCoefficient, int Constant, Complex ScaleConstant, Complex ShiftConstant)
        {
            Complex z = c;
            for (int i = 0; i < 20; i++)
            {
                Complex derivative = (CubicFunction(z + new Complex(0.000001, 0.000001),CubeCoefficient,SquareCoefficient,LinearCoefficient,Constant) - CubicFunction(z, CubeCoefficient, SquareCoefficient, LinearCoefficient, Constant)) / new Complex(0.000001, 0.000001);
                z = z - (ScaleConstant * (((CubicFunction(z, CubeCoefficient,SquareCoefficient,LinearCoefficient,Constant) / derivative)))) + ShiftConstant;
            }
            List<double> diff = new List<double>();
            for (int x = 0; x < 3; x++)
            {
                Complex distanceToSolutionComplex = Complex.Abs(z - solutions[x]);
                double dist = Math.Sqrt(Math.Pow(distanceToSolutionComplex.Real, 2) + Math.Pow(distanceToSolutionComplex.Imaginary, 2));
                diff.Add(dist);
            }
            double min = diff.Min();
            for (int x = 0; x < diff.Count; x++)
            {
                if (diff[x] == min)
                    return x;
            }
            return 0;
        }
        private Complex CubicFunction(Complex z, int CubeCoefficient, int SquareCoefficient, int LinearCoefficient, int Constant)
        {
            //Complex.Pow(z,3) is significantly slower than z*z*z
            return (CubeCoefficient * z*z*z + (SquareCoefficient * z*z) + (LinearCoefficient * z) + (Constant));
        }

    }
}
