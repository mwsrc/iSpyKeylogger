
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


#region "SLCTheme"
class SLCTheme : ThemeContainer154
{

    private Pen P1;
    private Pen P2;
    private Color topc;
    private Color botc;
    private Color topc2;
    private Color botc2;

    private SolidBrush B1;




    public SLCTheme()
    {
        TransparencyKey = Color.Fuchsia;
        Header = 30;
        SetColor("top", Color.FromArgb(21, 18, 37));
        SetColor("bottom", Color.FromArgb(32, 35, 54));
        //(21, 18, 37)
        SetColor("top2", Color.FromArgb(32, 35, 54));
        SetColor("bottom2", Color.FromArgb(21, 18, 37));
        BackColor = Color.FromArgb(0, 57, 72);
        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(60, 60, 60));
        B1 = new SolidBrush(Color.FromArgb(50, 50, 50));

    }

    protected override void ColorHook()
    {
        topc = GetColor("top");
        botc = GetColor("bottom");
        topc2 = GetColor("top2");
        botc2 = GetColor("bottom2");
    }

    private GraphicsPath PrepareBorder()
    {
        GraphicsPath P = new GraphicsPath();

        List<Point> PS = new List<Point>();
        PS.Add(new Point(0, 2));
        PS.Add(new Point(2, 0));
        PS.Add(new Point(100, 0));
        PS.Add(new Point(115, 15));
        PS.Add(new Point(Width - 1 - 115, 15));
        PS.Add(new Point(Width - 1 - 100, 0));
        PS.Add(new Point(Width - 2, 0));
        PS.Add(new Point(Width - 1, 3));


        //PS.Add(New Point(Width - 1, Height - 1))

        //bottom
        PS.Add(new Point(Width - 1, Height - 3));
        PS.Add(new Point(Width - 3, Height - 1));
        PS.Add(new Point(Width - 100, Height - 1));
        PS.Add(new Point(Width - 115, Height - 15 - 1));
        PS.Add(new Point(116, Height - 15 - 1));
        PS.Add(new Point(101, Height - 1));
        PS.Add(new Point(2, Height - 1));
        PS.Add(new Point(0, Height - 2));

        P.AddPolygon(PS.ToArray());
        return P;
    }

    //Private Function FormInsideSQ()
    //    Dim P As New GraphicsPath()
    //    Dim PS As New List(Of Point)

    //    PS.Add(New Point(6, Height - 310))
    //    PS.Add(New Point(Width - 6, 64))
    //    PS.Add(New Point(Width - 6, Height - 6))
    //    PS.Add(New Point(Width - 100, Height - 6))
    //    PS.Add(New Point(Width - 116, Height - 22))
    //    PS.Add(New Point(Width - 522, Height - 22))
    //    PS.Add(New Point(Width - 538, Height - 6))
    //    PS.Add(New Point(6, Height - 6))
    //    P.AddPolygon(PS.ToArray())
    //    Return p
    //End Function



    protected override void PaintHook()
    {
        TransparencyKey = Color.Fuchsia;

        G.Clear(Color.Fuchsia);




        HatchBrush HB = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.FromArgb(38, 138, 201)), Color.FromArgb(80, Color.FromArgb(12, 40, 57)));
        LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(108, 137, 184), Color.FromArgb(13, 20, 25), 20f);

        G.FillRectangle(linear, new Rectangle(3, 3, Width - 5, Height - 3));

        G.FillRectangle(HB, new Rectangle(3, 3, Width - 5, Height - 3));


        G.DrawLine(Pens.Fuchsia, 1, 0, Width - 1, 0);
        G.DrawLine(Pens.Fuchsia, 1, 1, Width - 1, 1);
        G.DrawLine(new Pen(Color.FromArgb(26, 47, 59)), 1, 2, Width - 1, 2);

        G.DrawLine(Pens.Fuchsia, 1, Height - 1, Width - 1, Height - 1);
        G.DrawLine(Pens.Fuchsia, 1, Height - 2, Width - 1, Height - 2);
        G.DrawLine(new Pen(Color.FromArgb(26, 47, 59)), 1, Height - 2, Width - 4, Height - 2);




        GraphicsPath GPF = PrepareBorder();


        PathGradientBrush PB2 = default(PathGradientBrush);
        PB2 = new PathGradientBrush(GPF);
        PB2.CenterColor = Color.FromArgb(250, 250, 250);
        PB2.SurroundColors = new Color[] { Color.FromArgb(237, 237, 237) };
        PB2.FocusScales = new PointF(0.9f, 0.5f);

        G.SetClip(GPF);

        G.FillPath(PB2, GPF);
        G.DrawPath(new Pen(Color.White, 3), GPF);
        G.ResetClip();

        GraphicsPath tmpG = PrepareBorder();

        G.DrawPath(Pens.Gray, tmpG);



        LinearGradientBrush linear2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(13, 59, 85), Color.FromArgb(22, 35, 43), 180f);



        GraphicsPath barGP = new GraphicsPath();

        PathGradientBrush PB3 = default(PathGradientBrush);
        PB3 = new PathGradientBrush(GPF);
        PB3.CenterColor = Color.FromArgb(39, 60, 73);
        PB3.SurroundColors = new Color[]{ Color.FromArgb(31, 105, 152) };
        PB3.FocusScales = new PointF(0.5f, 0.5f);
        PB3.CenterPoint = new Point(Width / 2, 10);

        barGP.AddRectangle(new Rectangle(0, 39, Width - 1, 20));

        G.FillPath(PB3, barGP);
        G.FillPath(new HatchBrush(HatchStyle.NarrowHorizontal, Color.FromArgb(20, 34, 45), Color.Transparent), barGP);

        //// get rid of some pixels
        G.DrawRectangle(Pens.Fuchsia, new Rectangle(Width - 4, 40, 3, 17));
        G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 4, 40, 3, 17));

        G.DrawRectangle(Pens.Fuchsia, new Rectangle(0, 40, 3, 17));
        G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 40, 3, 17));


        //// inside square

        //Dim SQpth As GraphicsPath = FormInsideSQ()
        // G.DrawPath(Pens.Red, SQpth)



        DrawText(new SolidBrush(Color.FromArgb(30, Color.Black)), HorizontalAlignment.Left, 12, 6);
        DrawText(new SolidBrush(Color.FromArgb(20, Color.Black)), HorizontalAlignment.Left, 11, 5);
        DrawText(Brushes.Black, HorizontalAlignment.Left, 10, 4);





    }
}
#endregion
#region "SLCbtn"
class SLCbtn : ThemeControl154
{



    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Color.White);

        switch (State)
        {
            case MouseState.None:

                //// bnt form

                LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                GraphicsPath gp = new GraphicsPath();
                gp = CreateRound(0, 0, Width - 1, Height - 1, 7);
                G.FillPath(linear, gp);
                G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp);
                G.SetClip(gp);
                GraphicsPath btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                G.DrawPath(new Pen(Color.White, 1), btninsideborder);
                G.ResetClip();

                //// circle



                //Dim GPF As New GraphicsPath
                //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                //Dim PB2 As PathGradientBrush
                //PB2 = New PathGradientBrush(GPF)
                //PB2.CenterColor = Color.FromArgb(69, 128, 156)
                //PB2 .SurroundColors = new Color[]{Color.FromArgb(8, 25, 33)}
                //PB2.FocusScales = New PointF(0.9F, 0.9F)


                //G.FillPath(PB2, GPF)

                //G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)

                //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                DrawText(new SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1);
                break;
            case MouseState.Down:
                //// bnt form

                linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                gp = new GraphicsPath();
                gp = CreateRound(0, 0, Width - 1, Height - 1, 7);
                G.FillPath(linear, gp);
                G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp);
                G.SetClip(gp);
                btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                G.DrawPath(new Pen(Color.White, 1), btninsideborder);
                G.ResetClip();

                //// circle



                //Dim GPF As New GraphicsPath
                //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                //Dim PB2 As PathGradientBrush
                //PB2 = New PathGradientBrush(GPF)
                //PB2.CenterColor = Color.FromArgb(86, 161, 196)
                //PB2 .SurroundColors = new Color[]{Color.FromArgb(94, 176, 215)}
                //PB2.FocusScales = New PointF(0.9F, 0.9F)


                //G.FillPath(PB2, GPF)

                //G.DrawPath(New Pen(Color.FromArgb(105, 194, 236)), GPF)

                //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                DrawText(new SolidBrush(Color.FromArgb(86, 161, 196)), HorizontalAlignment.Left, 5, 1);

                break;
            case MouseState.Over:
                //// bnt form

                linear = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                gp = new GraphicsPath();
                gp = CreateRound(0, 0, Width - 1, Height - 1, 7);
                G.FillPath(linear, gp);
                G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp);
                G.SetClip(gp);
                btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                G.DrawPath(new Pen(Color.FromArgb(50, Color.Gray), 1), btninsideborder);
                G.ResetClip();

                //// circle


                //Dim GPF As New GraphicsPath
                //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                //Dim PB2 As PathGradientBrush
                //PB2 = New PathGradientBrush(GPF)
                //PB2.CenterColor = Color.FromArgb(69, 128, 156)
                //PB2 .SurroundColors = new Color[]{Color.FromArgb(8, 25, 33)}
                //PB2.FocusScales = New PointF(0.9F, 0.9F)


                //G.FillPath(PB2, GPF)

                //G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
                //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))
                DrawText(new SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1);
                break;
        }

    }
}
#endregion
#region "SLCTabControl"
class SLCTabControl : TabControl
{

    public SLCTabControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        SizeMode = TabSizeMode.Fixed;
        ItemSize = new Size(30, 120);

    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        Alignment = TabAlignment.Left;
    }

    public GraphicsPath Borderpts()
    {
        GraphicsPath P = new GraphicsPath();
        List<Point> PS = new List<Point>();

        PS.Add(new Point(0, 0));
        PS.Add(new Point(Width - 1, 0));
        PS.Add(new Point(Width - 1, Height - 1));
        PS.Add(new Point(0, Height - 1));



        P.AddPolygon(PS.ToArray());
        return P;
    }

    public GraphicsPath BorderptsInside()
    {
        GraphicsPath P = new GraphicsPath();
        List<Point> PS = new List<Point>();

        PS.Add(new Point(1, 1));
        PS.Add(new Point(122, 1));
        PS.Add(new Point(122, Height - 2));
        PS.Add(new Point(1, Height - 2));



        P.AddPolygon(PS.ToArray());
        return P;
    }

    public GraphicsPath BigBorder()
    {
        GraphicsPath P = new GraphicsPath();
        List<Point> PS = new List<Point>();

        PS.Add(new Point(50, 1));
        PS.Add(new Point(349, 50));
        PS.Add(new Point(349, 50));
        PS.Add(new Point(50, 349));

        P.AddPolygon(PS.ToArray());
        return P;
    }


    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {


        Bitmap b = new Bitmap(Width, Height);
        Graphics g = Graphics.FromImage(b);
        g.Clear(Color.White);




        ////Big square shadow







        GraphicsPath GP1 = Borderpts();
        g.DrawPath(Pens.LightGray, GP1);


        //// small border
        GraphicsPath tmp1 = BorderptsInside();

        PathGradientBrush PB2 = default(PathGradientBrush);
        PB2 = new PathGradientBrush(tmp1);
        PB2.CenterColor = Color.FromArgb(250, 250, 250);
        PB2.SurroundColors = new Color[] { Color.FromArgb(237, 237, 237) };
        PB2.FocusScales = new PointF(0.9f, 0.9f);

        g.FillPath(PB2, tmp1);
        g.DrawPath(Pens.Gray, tmp1);




        //// items







        for (int i = 0; i <= TabCount - 1; i++)
        {
            Rectangle rec = GetTabRect(i);
            Rectangle rec2 = rec;


            ////inside small 
            rec2.Width -= 3;
            rec2.Height -= 3;
            rec2.Y += 1;
            rec2.X += 1;

            if (i == SelectedIndex)
            {


                LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);
                LinearGradientBrush linear3 = new LinearGradientBrush(new Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);


                g.FillRectangle(new SolidBrush(Color.FromArgb(242, 242, 242)), rec2);
                g.DrawRectangle(Pens.White, rec2);
                g.DrawRectangle(new Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec);
                g.FillRectangle(linear, new Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1));
                g.FillRectangle(linear3, new Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1));
                //// circle


                g.SmoothingMode = SmoothingMode.HighQuality;
                //    g.DrawEllipse(New Pen(Color.FromArgb(200, 200, 200), 3), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))
                // g.DrawEllipse(New Pen(Color.FromArgb(150, 150, 150), 1), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))


                GraphicsPath GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                PathGradientBrush PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(rec2.X - 10, rec2.Y - 10);
                PB3.CenterColor = Color.FromArgb(56, 142, 196);
                PB3.SurroundColors = new Color[] { Color.FromArgb(64, 106, 140) };
                PB3.FocusScales = new PointF(0.9f, 0.9f);


                g.FillPath(PB3, GPF);

                g.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
                g.SetClip(GPF);
                g.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(rec2.X + 10, rec2.Y + 11, 6, 6));
                g.ResetClip();



                g.SmoothingMode = SmoothingMode.None;


            }
            else
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);
                LinearGradientBrush linear3 = new LinearGradientBrush(new Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);


                g.FillRectangle(new SolidBrush(Color.FromArgb(242, 242, 242)), rec2);
                g.DrawRectangle(Pens.White, rec2);
                g.DrawRectangle(new Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec);
                g.FillRectangle(linear, new Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1));
                g.FillRectangle(linear3, new Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1));


                g.FillEllipse(Brushes.LightGray, new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                g.DrawEllipse(new Pen(Color.FromArgb(100, 100, 100), 1), new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                g.SmoothingMode = SmoothingMode.None;

            }

            g.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(56, 106, 137)), rec, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }




        e.Graphics.DrawImage(b, 0, 0);
        g.Dispose();
        b.Dispose();
        base.OnPaint(e);
    }
}
#endregion
#region "SLCTextbox"
[DefaultEvent("TextChanged")]
class SLCTextBox : Control
{

    #region " Variables"
    private TextBox TB;
    #endregion
    private MouseState State = MouseState.None;

    #region " Properties"
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Over;
        Invalidate();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = MouseState.Down;
        Invalidate();
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        Invalidate();
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = MouseState.Over;
        TB.Focus();
        Invalidate();
    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);
        TB.Focus();
        Invalidate();
    }
    protected override void OnLeave(EventArgs e)
    {
        base.OnLeave(e);
        Invalidate();
    }
    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        Invalidate();
    }

    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    public HorizontalAlignment TextAlign
    {
        get { return _TextAlign; }
        set
        {
            _TextAlign = value;
            if (TB != null)
            {
                TB.TextAlign = value;
            }
        }
    }
    private int _MaxLength = 3276799;
    public int MaxLength
    {
        get { return _MaxLength; }
        set
        {
            _MaxLength = value;
            if (TB != null)
            {
                TB.MaxLength = value;
            }
        }
    }
    private bool _ReadOnly;
    public bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (TB != null)
            {
                TB.ReadOnly = value;
            }
        }
    }
    private bool _UseSystemPasswordChar;
    public bool UseSystemPasswordChar
    {
        get { return _UseSystemPasswordChar; }
        set
        {
            _UseSystemPasswordChar = value;
            if (TB != null)
            {
                TB.UseSystemPasswordChar = value;
            }
        }
    }
    private bool _Multiline;
    public bool Multiline
    {
        get { return _Multiline; }
        set
        {
            _Multiline = value;
            if (TB != null)
            {
                TB.Multiline = value;

                if (value)
                {
                    TB.Height = Height - 11;
                }
                else
                {
                    Height = TB.Height + 11;
                }

            }
        }
    }
    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            if (TB != null)
            {
                TB.Text = value;
            }
        }
    }
    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            if (TB != null)
            {
                TB.Font = value;
                TB.Location = new Point(3, 5);
                TB.Width = Width - 6;

                if (!_Multiline)
                {
                    Height = TB.Height + 11;
                }
            }
        }
    }
    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        if (!Controls.Contains(TB))
        {
            Controls.Add(TB);
        }
    }
    private void OnBaseTextChanged(object s, EventArgs e)
    {
        Text = TB.Text;
    }
    private void OnBaseKeyDown(object s, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            TB.SelectAll();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.C)
        {
            TB.Copy();
            e.SuppressKeyPress = true;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        TB.Location = new Point(5, 5);
        TB.Width = Width - 10;

        if (_Multiline)
        {
            TB.Height = Height - 11;
        }
        else
        {
            Height = TB.Height + 11;
        }

        base.OnResize(e);
    }
    #endregion

    public SLCTextBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.Selectable, true);

        DoubleBuffered = true;

        TB = new TextBox();
        TB.Font = new Font("Tahoma", 8);
        TB.BackColor = Color.White;
        TB.ForeColor = Color.FromArgb(1, 75, 124);
        TB.MaxLength = _MaxLength;
        TB.Multiline = _Multiline;
        TB.ReadOnly = _ReadOnly;
        TB.UseSystemPasswordChar = _UseSystemPasswordChar;
        TB.BorderStyle = BorderStyle.None;
        TB.Location = new Point(5, 5);
        TB.Width = Width - 10;

        TB.Cursor = Cursors.IBeam;

        if (_Multiline)
        {
            TB.Height = Height - 11;
        }
        else
        {
            Height = TB.Height + 11;
        }

        TB.TextChanged += OnBaseTextChanged;
        TB.KeyDown += OnBaseKeyDown;
    }
    public Rectangle Borderpts()
    {
        Rectangle P = new Rectangle();


        P = new Rectangle(2, 2, Width - 5, Height - 5);
        return P;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);


        PathGradientBrush PB1 = default(PathGradientBrush);
        GraphicsPath GP1 = RoundRec(Borderpts(), 2);





        var _with1 = G;
        _with1.SmoothingMode = SmoothingMode.HighQuality;
        _with1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
        _with1.Clear(Color.White);

        PB1 = new PathGradientBrush(GP1);
        PB1.CenterColor = Color.White;
        PB1.SurroundColors = new Color[] { Color.FromArgb(234, 234, 234) };
        PB1.FocusScales = new PointF(0.9f, 0.5f);



        _with1.FillPath(PB1, GP1);
        _with1.DrawPath(new Pen(Color.FromArgb(125, 125, 125)), GP1);


        base.OnPaint(e);
        G.Dispose();
        e.Graphics.InterpolationMode = InterpolationMode.Default;
        e.Graphics.DrawImageUnscaled(B, 0, 0);
        B.Dispose();
    }

    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }
}
#endregion
#region "SLCRadioButton"
[DefaultEvent("CheckedChanged")]
class SLCRadionButton : Control
{

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    public SLCRadionButton()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        BackColor = Color.White;

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Brushes.Red);
    }

    private bool _Checked;
    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;

            if (_Checked)
            {
                InvalidateParent();
            }

            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            Invalidate();
        }
    }

    private void InvalidateParent()
    {
        if (Parent == null)
            return;

        foreach (Control C in Parent.Controls)
        {
            if ((!object.ReferenceEquals(C, this)) && (C is SLCRadionButton))
            {
                ((SLCRadionButton)C).Checked = false;
            }
        }
    }


    private GraphicsPath GP1;
    private SizeF SZ1;

    private PointF PT1;
    private Pen P1;

    private Pen P2;

    private PathGradientBrush PB1;
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = default(Graphics);
        G = e.Graphics;


        G.Clear(BackColor);
        G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = new GraphicsPath();
        GP1.AddEllipse(0, 2, Height - 5, Height - 5);

        PB1 = new PathGradientBrush(GP1);
        PB1.CenterColor = Color.FromArgb(50, 50, 50);
        PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
        PB1.FocusScales = new PointF(0.3f, 0.3f);

        // G.FillPath(PB1, GP1)

        G.DrawEllipse(P1, 4, 4, Height - 11, Height - 11);
        // G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7)

        if (_Checked)
        {
            GraphicsPath GPF = new GraphicsPath();
            GPF.AddEllipse(new Rectangle(Height - 18, Height - 19, 12, 12));
            PathGradientBrush PB3 = default(PathGradientBrush);
            PB3 = new PathGradientBrush(GPF);
            PB3.CenterPoint = new Point(Height - 18, Height - 20);
            PB3.CenterColor = Color.FromArgb(56, 142, 196);
            PB3.SurroundColors = new Color[] { Color.FromArgb(64, 106, 140) };
            PB3.FocusScales = new PointF(0.9f, 0.9f);


            G.FillPath(PB3, GPF);

            G.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
            G.SetClip(GPF);
            G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Height - 16, Height - 18, 6, 6));
            G.ResetClip();
        }

        SZ1 = G.MeasureString(Text, Font);
        PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);


        G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Checked = true;
        base.OnMouseDown(e);
    }

}
#endregion
#region "SLCComboBox"
class SLCComboBox : ComboBox
{

    public SLCComboBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;


        DrawMode = DrawMode.OwnerDrawFixed;


    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.Clear(Color.White);





        //inside borders



        GraphicsPath GP = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 5);
        GraphicsPath GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 5);
        GraphicsPath GP3 = RoundRec(new Rectangle(2, 2, Width - 5, Height - 5), 5);


        G.SmoothingMode = SmoothingMode.HighQuality;

        G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), GP3);
        G.DrawPath(new Pen(Color.FromArgb(60, Color.LightGray), 4), GP2);
        G.DrawPath(new Pen(Color.FromArgb(100, Color.FromArgb(15, 15, 15))), GP);
        // G.DrawPath(New Pen(Color.FromArgb(60, Color.LightGray), 4), GP3)
        G.SmoothingMode = SmoothingMode.None;

        Rectangle rect1 = new Rectangle(Width - 26, 0, 1, Height);
        Rectangle rect2 = new Rectangle(Width - 27, 0, 2, Height);
        G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.FromArgb(1, 75, 124))), rect1);
        G.DrawRectangle(new Pen(Color.FromArgb(60, Color.FromArgb(61, 113, 153))), rect1);



        //little arrow shit

        G.SmoothingMode = SmoothingMode.HighQuality;


        G.DrawArc(new Pen(Color.FromArgb(97, 152, 195)), new Rectangle(Width - 18, Height - 19, 8, 8), 20, 140);

        G.DrawArc(new Pen(Color.LightGray), new Rectangle(Width - 18, Height - 18, 8, 8), 10, 160);
        G.DrawArc(new Pen(Color.FromArgb(78, 121, 154), 1), new Rectangle(Width - 18, Height - 20, 8, 8), 20, 140);



        G.DrawArc(new Pen(Color.FromArgb(97, 152, 195)), new Rectangle(Width - 19, Height - 16, 10, 10), 20, 140);

        G.DrawArc(new Pen(Color.LightGray), new Rectangle(Width - 19, Height - 15, 10, 10), 10, 160);
        G.DrawArc(new Pen(Color.FromArgb(78, 121, 154), 1), new Rectangle(Width - 19, Height - 17, 10, 10), 20, 140);
        G.SmoothingMode = SmoothingMode.None;


        PointF PT1 = new PointF(3, Height - 18);

        G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
    }


    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
        }
        else
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), e.Bounds);
        }

        if (!(e.Index == -1))
        {
            e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(1, 75, 124)), e.Bounds);
        }
    }

    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }
}
#endregion
#region "SLCProgrssBar"
class SLCProgrssBar : Control
{

    private int _Minimum;
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Property value is not valid.");
            }

            _Minimum = value;
            if (value > _Value)
                _Value = value;
            if (value > _Maximum)
                _Maximum = value;
            Invalidate();
        }
    }

    private int _Maximum = 100;
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Property value is not valid.");
            }

            _Maximum = value;
            if (value < _Value)
                _Value = value;
            if (value < _Minimum)
                _Minimum = value;
            Invalidate();
        }
    }

    private int _Value;
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > _Maximum || value < _Minimum)
            {
                throw new Exception("Property value is not valid.");
            }

            _Value = value;
            Invalidate();
        }
    }

    private void Increment(int amount)
    {
        Value += amount;
    }

    public SLCProgrssBar()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);


        P2 = new Pen(Color.FromArgb(55, 55, 55));
        B1 = new SolidBrush(Color.FromArgb(0, 214, 37));
    }

    private GraphicsPath GP1;
    private GraphicsPath GP2;

    private GraphicsPath GP3;
    private Rectangle R1;

    private Rectangle R2;
    private Pen P2;
    private SolidBrush B1;
    private LinearGradientBrush GB1;

    private LinearGradientBrush GB2;

    private int I1;
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle R3 = new Rectangle();
        HatchBrush HB = default(HatchBrush);

        G.Clear(Color.White);
        G.SmoothingMode = SmoothingMode.HighQuality;

        GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4);
        GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 4);

        R1 = new Rectangle(0, 2, Width - 1, Height - 1);
        GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);





        G.SetClip(GP1);
        //gloss
        PathGradientBrush PB = new PathGradientBrush(GP1);
        PB.CenterColor = Color.FromArgb(230, 230, 230);
        PB .SurroundColors = new Color[]{ Color.FromArgb(255, 255, 255) };
        PB.CenterPoint = new Point(0, Height);
        PB.FocusScales = new PointF(1, 0);

        G.FillRectangle(PB, R1);

        G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), RoundRec(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));

        I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3));


        if (I1 > 1)
        {




            GP3 = RoundRec(new Rectangle(1, 1, I1, Height - 3), 4);

            //grad
            HB = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.Black), Color.Transparent);



            //bar
            R2 = new Rectangle(1, 1, I1, Height - 3);
            GB2 = new LinearGradientBrush(R2, Color.FromArgb(20, 34, 45), Color.FromArgb(27, 84, 121), 90f);

            G.FillPath(GB2, GP3);
            G.DrawPath(new Pen(Color.FromArgb(120, 134, 145)), GP3);

            G.SetClip(GP3);
            G.SmoothingMode = SmoothingMode.None;



            G.FillRectangle(new SolidBrush(Color.FromArgb(32, 100, 144)), R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

            R3 = new Rectangle(1, 1, I1, Height - 1);

            G.FillRectangle(HB, R3);

            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.ResetClip();
        }



        G.DrawPath(new Pen(Color.FromArgb(125, 125, 125)), GP2);
        G.DrawPath(new Pen(Color.FromArgb(80, Color.LightGray)), GP1);
    }
    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }

}
#endregion
#region "SLCCheckbox"
[DefaultEvent("CheckedChanged")]
class SLCCheckbox : Control
{

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    public SLCCheckbox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P11 = new Pen(Color.LightGray);
        P22 = new Pen(Color.FromArgb(35, 35, 35));
        P3 = new Pen(Color.Black, 2f);
        P4 = new Pen(Color.White, 2f);
    }

    private bool _Checked;
    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }

            Invalidate();
        }
    }

    private GraphicsPath GP1;

    private GraphicsPath GP2;
    private SizeF SZ1;

    private PointF PT1;
    private Pen P11;
    private Pen P22;
    private Pen P3;

    private Pen P4;

    private PathGradientBrush PB1;
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;


        g.Clear(Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = RoundRec(new Rectangle(0, 2, Height - 5, Height - 5), 1);
        GP2 = RoundRec(new Rectangle(1, 3, Height - 7, Height - 7), 1);

        GraphicsPath GPF = new GraphicsPath();
        GPF.AddPath(RoundRec(new Rectangle(Height - 18, Height - 20, 14, 14), 2), true);
        PathGradientBrush PB3 = default(PathGradientBrush);
        PB3 = new PathGradientBrush(GPF);
        //  PB3.CenterPoint = New Point(Height - 18, Height - 21)
        PB3.CenterColor = Color.FromArgb(240, 240, 240);
        PB3 .SurroundColors = new Color[]{ Color.FromArgb(90, 90, 90) };
        PB3.FocusScales = new PointF(0.4f, 0.4f);

        HatchBrush hb = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(70, Color.FromArgb(15, 54, 80)), Color.Transparent);

        g.FillPath(PB3, GPF);
        g.FillPath(hb, GPF);


        g.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
        g.SetClip(GPF);
        g.FillEllipse(new SolidBrush(Color.FromArgb(70, Color.DarkGray)), new Rectangle(Height - 16, Height - 18, 6, 6));
        g.DrawPath(Pens.White, RoundRec(new Rectangle(5, 4, Height - 11, Height - 11), 2));
        g.ResetClip();




        if (_Checked)
        {
            //g.DrawLine(Pens.Red, New PointF(7, Height - 10), New PointF(Height - 10, 5))
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(1, 75, 124)), 2), new Point(8, Height - 9), new Point(Height - 8, 6));


            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(1, 75, 124)), 2), 7, Height - 13, 8, Height - 10);


        }

        SZ1 = g.MeasureString(Text, Font);
        PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);


        g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Checked = !Checked;
    }

    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }

}

#endregion
#region "SLCListview"
class SLCListView : Control
{

    public class NSListViewItem
    {
        public string Text { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<NSListViewSubItem> SubItems { get; set; }


        protected Guid UniqueId;
        public NSListViewItem()
        {
            UniqueId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            if (obj is NSListViewItem)
            {
                return (((NSListViewItem)obj).UniqueId == UniqueId);
            }

            return false;
        }


    }

    public class NSListViewSubItem
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class NSListViewColumnHeader
    {
        public string Text { get; set; }
        public int Width { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    private List<NSListViewItem> _Items = new List<NSListViewItem>();
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NSListViewItem[] Items
    {
        get { return _Items.ToArray(); }
        set
        {
            _Items = new List<NSListViewItem>(value);
            InvalidateScroll();
        }
    }

    private List<NSListViewItem> _SelectedItems = new List<NSListViewItem>();
    public NSListViewItem[] SelectedItems
    {
        get { return _SelectedItems.ToArray(); }
    }

    private List<NSListViewColumnHeader> _Columns = new List<NSListViewColumnHeader>();
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NSListViewColumnHeader[] Columns
    {
        get { return _Columns.ToArray(); }
        set
        {
            _Columns = new List<NSListViewColumnHeader>(value);
            InvalidateColumns();
        }
    }

    private bool _MultiSelect = true;
    public bool MultiSelect
    {
        get { return _MultiSelect; }
        set
        {
            _MultiSelect = value;

            if (_SelectedItems.Count > 1)
            {
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);
            }

            Invalidate();
        }
    }

    private int ItemHeight = 24;
    public override Font Font
    {
        get { return base.Font; }
        set
        {
            ItemHeight = Convert.ToInt32(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6;

            if (VS != null)
            {
                VS.SmallChange = ItemHeight;
                VS.LargeChange = ItemHeight;
            }

            base.Font = value;
            InvalidateLayout();
        }
    }

    #region " Item Helper Methods "

    //Ok, you've seen everything of importance at this point; I am begging you to spare yourself. You must not read any further!

    public void AddItem(string text, params string[] subItems)
    {
        List<NSListViewSubItem> Items = new List<NSListViewSubItem>();
        foreach (string I in subItems)
        {
            NSListViewSubItem SubItem = new NSListViewSubItem();
            SubItem.Text = I;
            Items.Add(SubItem);
        }

        NSListViewItem Item = new NSListViewItem();
        Item.Text = text;
        Item.SubItems = Items;

        _Items.Add(Item);
        InvalidateScroll();
    }

    public void RemoveItemAt(int index)
    {
        _Items.RemoveAt(index);
        InvalidateScroll();
    }

    public void RemoveItem(NSListViewItem item)
    {
        _Items.Remove(item);
        InvalidateScroll();
    }

    public void RemoveItems(NSListViewItem[] items)
    {
        foreach (NSListViewItem I in items)
        {
            _Items.Remove(I);
        }

        InvalidateScroll();
    }

    #endregion


    private SLCScrollBar VS;
    public SLCListView()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, true);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));
        P3 = new Pen(Color.FromArgb(65, 65, 65));

        B1 = new SolidBrush(Color.FromArgb(62, 62, 62));
        B2 = new SolidBrush(Color.FromArgb(65, 65, 65));
        B3 = new SolidBrush(Color.FromArgb(47, 47, 47));
        B4 = new SolidBrush(Color.FromArgb(50, 50, 50));

        VS = new SLCScrollBar();
        VS.SmallChange = ItemHeight;
        VS.LargeChange = ItemHeight;

        VS.Scroll += HandleScroll;
        VS.MouseDown += VS_MouseDown;
        Controls.Add(VS);

        InvalidateLayout();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateLayout();
        base.OnSizeChanged(e);
    }

    private void HandleScroll(object sender)
    {
        Invalidate();
    }

    private void InvalidateScroll()
    {
        VS.Maximum = (_Items.Count * ItemHeight);
        Invalidate();
    }

    private void InvalidateLayout()
    {
        VS.Location = new Point(Width - VS.Width - 1, 1);
        VS.Size = new Size(18, Height - 2);

        Invalidate();
    }

    private int[] ColumnOffsets;
    private void InvalidateColumns()
    {
        int Width = 3;
        ColumnOffsets = new int[_Columns.Count];

        for (int I = 0; I <= _Columns.Count - 1; I++)
        {
            ColumnOffsets[I] = Width;
            Width += Columns[I].Width;
        }

        Invalidate();
    }

    private void VS_MouseDown(object sender, MouseEventArgs e)
    {
        Focus();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Focus();

        if (e.Button == MouseButtons.Left)
        {
            int Offset = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))));
            int Index = ((e.Y + Offset - ItemHeight) / ItemHeight);

            if (Index > _Items.Count - 1)
                Index = -1;

            if (!(Index == -1))
            {
                //TODO: Handle Shift key

                if (ModifierKeys == Keys.Control && _MultiSelect)
                {
                    if (_SelectedItems.Contains(_Items[Index]))
                    {
                        _SelectedItems.Remove(_Items[Index]);
                    }
                    else
                    {
                        _SelectedItems.Add(_Items[Index]);
                    }
                }
                else
                {
                    _SelectedItems.Clear();
                    _SelectedItems.Add(_Items[Index]);
                }
            }

            Invalidate();
        }

        base.OnMouseDown(e);
    }

    private Pen P1;
    private Pen P2;
    private Pen P3;
    private SolidBrush B1;
    private SolidBrush B2;
    private SolidBrush B3;
    private SolidBrush B4;

    private LinearGradientBrush GB1;
    //I am so sorry you have to witness this. I tried warning you. ;.;

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G = e.Graphics;

        G.Clear(Color.White);

        int X = 0;
        int Y = 0;
        float H = 0;

        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(50, Color.LightGray))), 1, 1, Width - 3, Height - 3);

        Rectangle R1 = default(Rectangle);
        NSListViewItem CI = null;

        int Offset = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))));

        int StartIndex = 0;
        if (Offset == 0)
            StartIndex = 0;
        else
            StartIndex = (Offset / ItemHeight);

        int EndIndex = Math.Min(StartIndex + (Height / ItemHeight), _Items.Count - 1);

        for (int I = StartIndex; I <= EndIndex; I++)
        {
            CI = Items[I];

            R1 = new Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1);

            H = G.MeasureString(CI.Text, Font).Height;
            Y = R1.Y + Convert.ToInt32((ItemHeight / 2) - (H / 2));

            if (_SelectedItems.Contains(CI))
            {
                if (I % 2 == 0)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.LightGray)), R1);
                }
                else
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.LightGray)), R1);
                }
            }
            else
            {
                if (I % 2 == 0)
                {
                    G.FillRectangle(Brushes.White, R1);
                }
                else
                {
                    G.FillRectangle(Brushes.White, R1);
                }
            }

            G.DrawLine(Pens.LightGray, 0, R1.Bottom, Width, R1.Bottom);

            if (Columns.Length > 0)
            {
                R1.Width = Columns[0].Width;
                G.SetClip(R1);
            }

            //TODO: Ellipse text that overhangs seperators.
            G.DrawString(CI.Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), 10, Y + 1);


            if (CI.SubItems != null)
            {
                for (int I2 = 0; I2 <= Math.Min(CI.SubItems.Count, _Columns.Count) - 1; I2++)
                {
                    X = ColumnOffsets[I2 + 1] + 4;

                    R1.X = X;
                    R1.Width = Columns[I2].Width;
                    G.SetClip(R1);

                    G.DrawString(CI.SubItems[I2].Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), X + 1, Y + 1);

                }
            }

            G.ResetClip();
        }

        R1 = new Rectangle(0, 0, Width, ItemHeight);

        GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90f);
        G.FillRectangle(GB1, R1);
        G.SetClip(R1);
        G.FillRectangle(Brushes.White, new Rectangle(0, 0, R1.Width - 1, R1.Height / 2 - 1));
        G.ResetClip();
        G.DrawRectangle(Pens.White, 1, 1, Width - 22, ItemHeight - 2);

        int LH = Math.Min(VS.Maximum + ItemHeight - Offset, Height);

        NSListViewColumnHeader CC = null;
        for (int I = 0; I <= _Columns.Count - 1; I++)
        {
            CC = Columns[I];

            H = G.MeasureString(CC.Text, Font).Height;
            Y = Convert.ToInt32((ItemHeight / 2) - (H / 2));
            X = ColumnOffsets[I];

            G.DrawString(CC.Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), X + 1, Y + 1);


            G.DrawLine(Pens.LightGray, X - 3, 0, X - 3, LH);
            G.DrawLine(Pens.White, X - 2, 0, X - 2, ItemHeight);
        }

        G.DrawRectangle(Pens.LightGray, 0, 0, Width - 1, Height - 1);

        G.DrawLine(new Pen(new SolidBrush(Color.LightGray)), 0, ItemHeight, Width, ItemHeight);
        G.DrawLine(new Pen(Brushes.LightGray), VS.Location.X - 1, 0, VS.Location.X - 1, Height);

        G.FillRectangle(Brushes.White, Width - 19, 0, Width, Height);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        int Move = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (ItemHeight / 2));

        int Value = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum);
        VS.Value = Value;

        base.OnMouseWheel(e);
    }

}

#endregion
#region "SLCScrollBar"
[DefaultEvent("Scroll")]
class SLCScrollBar : Control
{

    public event ScrollEventHandler Scroll;
    public delegate void ScrollEventHandler(object sender);

    private int _Minimum;
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Property value is not valid.");
            }

            _Minimum = value;
            if (value > _Value)
                _Value = value;
            if (value > _Maximum)
                _Maximum = value;

            InvalidateLayout();
        }
    }

    private int _Maximum = 100;
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < 1)
                value = 1;

            _Maximum = value;
            if (value < _Value)
                _Value = value;
            if (value < _Minimum)
                _Minimum = value;

            InvalidateLayout();
        }
    }

    private int _Value;
    public int Value
    {
        get
        {
            if (!ShowThumb)
                return _Minimum;
            return _Value;
        }
        set
        {
            if (value == _Value)
                return;

            if (value > _Maximum || value < _Minimum)
            {
                throw new Exception("Property value is not valid.");
            }

            _Value = value;
            InvalidatePosition();

            if (Scroll != null)
            {
                Scroll(this);
            }
        }
    }

    public double _Percent { get; set; }
    public double Percent
    {
        get
        {
            if (!ShowThumb)
                return 0;
            return GetProgress();
        }
    }

    private int _SmallChange = 1;
    public int SmallChange
    {
        get { return _SmallChange; }
        set
        {
            if (value < 1)
            {
                throw new Exception("Property value is not valid.");
            }

            _SmallChange = value;
        }
    }

    private int _LargeChange = 10;
    public int LargeChange
    {
        get { return _LargeChange; }
        set
        {
            if (value < 1)
            {
                throw new Exception("Property value is not valid.");
            }

            _LargeChange = value;
        }
    }

    private int ButtonSize = 16;
    // 14 minimum
    private int ThumbSize = 24;

    private Rectangle TSA;
    private Rectangle BSA;
    private Rectangle Shaft;

    private Rectangle Thumb;
    private bool ShowThumb;

    private bool ThumbDown;
    public SLCScrollBar()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Width = 18;


    }

    private GraphicsPath GP1;
    private GraphicsPath GP2;
    private GraphicsPath GP3;

    private GraphicsPath GP4;



    int I1;
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G = e.Graphics;
        G.Clear(Color.FromArgb(255, 255, 255));

        GP1 = DrawArrow(4, 6, false);
        GP2 = DrawArrow(5, 7, false);

        G.FillPath(new SolidBrush(Color.LightGray), GP2);
        G.FillPath(new SolidBrush(Color.FromArgb(83, 123, 168)), GP1);

        GP3 = DrawArrow(4, Height - 11, true);
        GP4 = DrawArrow(5, Height - 10, true);

        G.FillPath(new SolidBrush(Color.LightGray), GP4);
        G.FillPath(new SolidBrush(Color.FromArgb(83, 123, 168)), GP3);

        if (ShowThumb)
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), Thumb);
            G.DrawRectangle(Pens.LightGray, Thumb);
            G.DrawRectangle(Pens.White, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

            int Y = 0;
            int LY = Thumb.Y + (Thumb.Height / 2) - 3;

            for (int I = 0; I <= 2; I++)
            {
                Y = LY + (I * 3);

                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(68, 95, 127))), Thumb.X + 5, Y, Thumb.Right - 5, Y);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(50, Color.FromArgb(68, 95, 127)))), Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1);
            }
        }
        G.SmoothingMode = SmoothingMode.HighQuality;
        //G.DrawRectangle(New Pen(New SolidBrush(Color.Red)), 0, 0, Width - 1, Height - 1)
        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(59, 122, 165))), RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 4));
        G.SmoothingMode = SmoothingMode.None;
    }

    private GraphicsPath DrawArrow(int x, int y, bool flip)
    {
        GraphicsPath GP = new GraphicsPath();

        int W = 9;
        int H = 5;

        if (flip)
        {
            GP.AddLine(x + 1, y, x + W + 1, y);
            GP.AddLine(x + W, y, x + H, y + H - 1);
        }
        else
        {
            GP.AddLine(x, y + H, x + W, y + H);
            GP.AddLine(x + W, y + H, x + H, y);
        }

        GP.CloseFigure();
        return GP;
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateLayout();
    }

    private void InvalidateLayout()
    {
        TSA = new Rectangle(0, 0, Width, ButtonSize);
        BSA = new Rectangle(0, Height - ButtonSize, Width, ButtonSize);
        Shaft = new Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1);

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height);

        if (ShowThumb)
        {
            //ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = new Rectangle(1, 0, Width - 3, ThumbSize);
        }

        if (Scroll != null)
        {
            Scroll(this);
        }
        InvalidatePosition();
    }

    private void InvalidatePosition()
    {
        Thumb.Y = Convert.ToInt32(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && ShowThumb)
        {
            if (TSA.Contains(e.Location))
            {
                I1 = _Value - _SmallChange;
            }
            else if (BSA.Contains(e.Location))
            {
                I1 = _Value + _SmallChange;
            }
            else
            {
                if (Thumb.Contains(e.Location))
                {
                    ThumbDown = true;
                    base.OnMouseDown(e);
                    return;
                }
                else
                {
                    if (e.Y < Thumb.Y)
                    {
                        I1 = _Value - _LargeChange;
                    }
                    else
                    {
                        I1 = _Value + _LargeChange;
                    }
                }
            }

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
            InvalidatePosition();
        }

        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (ThumbDown && ShowThumb)
        {
            int ThumbPosition = e.Y - TSA.Height - (ThumbSize / 2);
            int ThumbBounds = Shaft.Height - ThumbSize;

            I1 = Convert.ToInt32((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
            InvalidatePosition();
        }

        base.OnMouseMove(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        ThumbDown = false;
        base.OnMouseUp(e);
    }

    private double GetProgress()
    {
        return (_Value - _Minimum) / (_Maximum - _Minimum);
    }

    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }
}
#endregion
#region "SLCOnOffBox"
[DefaultEvent("CheckedChanged")]
class SLCOnOffBox : Control
{

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);


    protected MouseState State;

    public SLCOnOffBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));
        P3 = new Pen(Color.FromArgb(65, 65, 65));

        B1 = new SolidBrush(Color.FromArgb(35, 35, 35));
        B2 = new SolidBrush(Color.FromArgb(85, 85, 85));
        B3 = new SolidBrush(Color.FromArgb(65, 65, 65));
        B4 = new SolidBrush(Color.FromArgb(205, 150, 0));
        B5 = new SolidBrush(Color.FromArgb(40, 40, 40));

        SF1 = new StringFormat();
        SF1.LineAlignment = StringAlignment.Center;
        SF1.Alignment = StringAlignment.Near;

        SF2 = new StringFormat();
        SF2.LineAlignment = StringAlignment.Center;
        SF2.Alignment = StringAlignment.Far;

        Size = new Size(56, 24);
        MinimumSize = Size;
        MaximumSize = Size;
    }

    private bool _Checked;
    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }

            Invalidate();
        }
    }

    private GraphicsPath GP1;
    private GraphicsPath GP2;
    private GraphicsPath GP3;

    private GraphicsPath GP4;
    private Pen P1;
    private Pen P2;
    private Pen P3;
    private SolidBrush B1;
    private SolidBrush B2;
    private SolidBrush B3;
    private SolidBrush B4;

    private SolidBrush B5;
    private PathGradientBrush PB1;

    private LinearGradientBrush GB1;
    private Rectangle R1;
    private Rectangle R2;
    private Rectangle R3;
    private StringFormat SF1;

    private StringFormat SF2;

    private int Offset;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.Clear(Color.White);
        G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 7);
        GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 7);

        PB1 = new PathGradientBrush(GP1);
        PB1.CenterColor = Color.FromArgb(250, 250, 250);
        PB1 .SurroundColors = new Color[]{ Color.FromArgb(245, 245, 245) };
        PB1.FocusScales = new PointF(0.3f, 0.3f);

        G.FillPath(PB1, GP1);
        G.DrawPath(Pens.LightGray, GP1);
        G.DrawPath(Pens.White, GP2);

        R1 = new Rectangle(5, 0, Width - 10, Height + 2);
        R2 = new Rectangle(6, 1, Width - 10, Height + 2);

        R3 = new Rectangle(1, 1, (Width / 2) - 1, Height - 3);



        if (_Checked)
        {
            // G.DrawString("On", Font, Brushes.Black, R2, SF1)
            G.DrawString("On", Font, new SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF1);

            R3.X += (Width / 2) - 1;
        }
        else
        {
            //G.DrawString("Off", Font, B1, R2, SF2)
            G.DrawString("Off", Font, new SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF2);
        }

        GP3 = RoundRec(R3, 7);
        GP4 = RoundRec(new Rectangle(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2), 7);

        GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90f);

        G.FillPath(GB1, GP3);
        G.DrawPath(Pens.LightGray, GP3);
        G.DrawPath(Pens.White, GP4);


        Offset = R3.X + (R3.Width / 2) - 3;

        for (int I = 0; I <= 1; I++)
        {
            if (_Checked)
            {
                //G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
            }
            else
            {
                // G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
            }

            G.SmoothingMode = SmoothingMode.None;


            if (_Checked)
            {
                G.SmoothingMode = SmoothingMode.HighQuality;

                GraphicsPath GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(Width - 20, Height - 17, 10, 10));
                PathGradientBrush PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(Height - 18, Height - 20);
                PB3.CenterColor = Color.FromArgb(53, 152, 74);
                PB3 .SurroundColors = new Color[]{ Color.FromArgb(86, 216, 114) };
                PB3.FocusScales = new PointF(0.9f, 0.9f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.FromArgb(85, 200, 109)), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                G.ResetClip();


                //  G.FillRectangle(New SolidBrush(Color.FromArgb(85, 158, 203)), Offset + (I * 5), 7, 2, Height - 14)
            }
            else
            {
                G.SmoothingMode = SmoothingMode.HighQuality;

                GraphicsPath GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(Height - 15, Height - 17, 10, 10));
                PathGradientBrush PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(Height - 18, Height - 20);
                PB3.CenterColor = Color.FromArgb(185, 65, 65);
                PB3 .SurroundColors = new Color[]{ Color.Red };
                PB3.FocusScales = new PointF(0.9f, 0.9f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.FromArgb(152, 53, 53)), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Height - 16, Height - 18, 6, 6));
                G.ResetClip();



                //  G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
            }

            G.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }

    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Checked = !Checked;
        base.OnMouseDown(e);
    }

}
#endregion
#region "SLCGroupBox"
class SLCGroupBox : ContainerControl
{

    private bool _DrawSeperator;
    public bool DrawSeperator
    {
        get { return _DrawSeperator; }
        set
        {
            _DrawSeperator = value;
            Invalidate();
        }
    }

    private string _Title = "GroupBox";
    public string Title
    {
        get { return _Title; }
        set
        {
            _Title = value;
            Invalidate();
        }
    }

    private string _SubTitle = "Details";
    public string SubTitle
    {
        get { return _SubTitle; }
        set
        {
            _SubTitle = value;
            Invalidate();
        }
    }

    private Font _TitleFont;

    private Font _SubTitleFont;
    public SLCGroupBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        _TitleFont = new Font("Verdana", 10f);
        _SubTitleFont = new Font("Verdana", 6.5f);


    }

    private GraphicsPath GP1;

    private GraphicsPath GP2;
    private PointF PT1;
    private SizeF SZ1;

    private SizeF SZ2;



    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G = e.Graphics;


        G.Clear(Color.White);
        G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 7);
        GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 7);


        G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), GP2);
        G.SetClip(GP2);
        PathGradientBrush PB = new PathGradientBrush(GP2);
        PB.CenterColor = Color.FromArgb(255, 255, 255);
        PB .SurroundColors = new Color[]{ Color.FromArgb(250, 250, 250) };
        PB.FocusScales = new PointF(1, 1);
        G.FillPath(PB, GP2);
        G.ResetClip();

        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(70, Color.LightGray))), GP1);
        G.DrawPath(Pens.Gray, GP2);

        SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic);
        SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic);


        G.DrawString(_Title, _TitleFont, new SolidBrush(Color.FromArgb(1, 75, 124)), 5, 5);

        PT1 = new PointF(6f, SZ1.Height + 4f);


        G.DrawString(_SubTitle, _SubTitleFont, new SolidBrush(Color.Black), PT1.X, PT1.Y);


    }

    public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return P;
    }

}
#endregion
#region "SLCContextMenu"
class SLCContextMenu : ContextMenuStrip
{

    public SLCContextMenu()
    {
        Renderer = new ToolStripProfessionalRenderer(new SLCColorTable());
        ForeColor = Color.FromArgb(1, 75, 124);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);
        base.OnPaint(e);
    }

}

#endregion
#region "SCLCT"

class SLCColorTable : ProfessionalColorTable
{


    private Color BackColor = Color.White;
    public override Color ButtonSelectedBorder
    {
        get { return BackColor; }
    }

    public override Color CheckBackground
    {
        get { return BackColor; }
    }

    public override Color CheckPressedBackground
    {
        get { return BackColor; }
    }

    public override Color CheckSelectedBackground
    {
        get { return BackColor; }
    }

    public override Color ImageMarginGradientBegin
    {
        get { return BackColor; }
    }

    public override Color ImageMarginGradientEnd
    {
        get { return BackColor; }
    }

    public override Color ImageMarginGradientMiddle
    {
        get { return BackColor; }
    }

    public override Color MenuBorder
    {
        get { return Color.FromArgb(1, 75, 124); }
    }

    public override Color MenuItemBorder
    {
        get { return BackColor; }
    }

    public override Color MenuItemSelected
    {
        get { return Color.FromArgb(50, Color.LightGray); }
    }

    public override Color SeparatorDark
    {
        get { return Color.FromArgb(35, 35, 35); }
    }

    public override Color ToolStripDropDownBackground
    {
        get { return BackColor; }
    }

}
#endregion
#region "SLCLABEL"
class SLCLabel : Control
{
    Label lb = new Label();
    public SLCLabel()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Font = new Font("Verdana", 8f, FontStyle.Regular);
        Size = new Size(39, 13);


    }

    private string _text = "SLCLabel";
    public override string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            Invalidate();
        }
    }


    private PointF PT1;

    private SizeF SZ1;
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G = e.Graphics;

        G.Clear(Color.White);


        PT1 = new PointF(0, 0);

        G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);

    }

}
#endregion
#region "SLCClose"
class SLCClose : ThemeControl154
{
    Label LB = new Label();

    protected override void ColorHook()
    {
    }

    public SLCClose()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        Size = new Size(20, 20);


    }

    protected override void PaintHook()
    {
        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Color.FromArgb(51, 123, 132));
        G.FillRectangle(new SolidBrush(Color.FromArgb(239, 239, 239)), new Rectangle(-1, -1, Width + 1, Height + 1));



        switch (State)
        {
            case MouseState.None:


                //// circle

                G.SmoothingMode = SmoothingMode.HighQuality;

                GraphicsPath GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                PathGradientBrush PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(Height - 18, Height - 20);
                PB3.CenterColor = Color.FromArgb(193, 26, 26);
                PB3 .SurroundColors = new Color[]{ Color.FromArgb(229, 110, 110) };
                PB3.FocusScales = new PointF(0.6f, 0.6f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.FromArgb(159, 41, 41)), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                G.ResetClip();
                break;
            case MouseState.Down:
                //// circle

                G.SmoothingMode = SmoothingMode.HighQuality;

                GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(Height - 18, Height - 20);
                PB3.CenterColor = Color.FromArgb(221, 32, 32);
                PB3 .SurroundColors = new Color[]{ Color.FromArgb(229, 110, 110) };
                PB3.FocusScales = new PointF(0.6f, 0.6f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.White), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                G.ResetClip();
                break;
            case MouseState.Over:
                //// circle

                G.SmoothingMode = SmoothingMode.HighQuality;

                GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point(Height - 18, Height - 20);
                PB3.CenterColor = Color.FromArgb(221, 32, 32);
                PB3 .SurroundColors = new Color[]{ Color.FromArgb(229, 110, 110) };
                PB3.FocusScales = new PointF(0.6f, 0.6f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.FromArgb(159, 41, 41)), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                G.ResetClip();
                break;
        }

    }
}
#endregion