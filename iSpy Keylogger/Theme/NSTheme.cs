using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Text;

//IMPORTANT:
//Please leave these comments in place as they help protect intellectual rights and allow
//developers to determine the version of the theme they are using. The preffered method
//of distributing this theme is through the Nimoru Software home page at nimoru.com.

//Name: Net Seal Theme
//Created: 6/21/2013
//Version: 1.0.0.2 beta
//Site: http://nimoru.com/

//This work is licensed under a Creative Commons Attribution 3.0 Unported License.
//To view a copy of this license, please visit http://creativecommons.org/licenses/by/3.0/

//Copyright © 2013 Nimoru Software

static class ThemeModule
{

    static ThemeModule()
    {
        TextBitmap = new Bitmap(1, 1);
        TextGraphics = Graphics.FromImage(TextBitmap);
    }

    private static Bitmap TextBitmap;

    private static Graphics TextGraphics;
    static internal SizeF MeasureString(string text, Font font)
    {
        return TextGraphics.MeasureString(text, font);
    }

    static internal SizeF MeasureString(string text, Font font, int width)
    {
        return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic);
    }

    private static GraphicsPath CreateRoundPath;

    private static Rectangle CreateRoundRectangle;
    static internal GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
    {
        CreateRoundRectangle = new Rectangle(x, y, width, height);
        return CreateRound(CreateRoundRectangle, slope);
    }

    static internal GraphicsPath CreateRound(Rectangle r, int slope)
    {
        CreateRoundPath = new GraphicsPath(FillMode.Winding);
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }

}


[DefaultEvent("ValueChanged")]
class NSRandomPool : Control
{

    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender);

    private StringBuilder _Value = new StringBuilder();
    public string Value
    {
        get { return _Value.ToString(); }
    }

    public string FullValue
    {
        get { return BitConverter.ToString(Table).Replace("-", ""); }
    }


    private Random RNG = new Random();
    private int ItemSize = 9;

    private int DrawSize = 8;

    private Rectangle WA;
    private int RowSize;

    private int ColumnSize;
    public NSRandomPool()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));

        B1 = new SolidBrush(Color.FromArgb(30, 30, 30));
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        UpdateTable();
        base.OnHandleCreated(e);
    }

    private byte[] Table;
    private void UpdateTable()
    {
        WA = new Rectangle(5, 5, Width - 10, Height - 10);

        RowSize = WA.Width / ItemSize;
        ColumnSize = WA.Height / ItemSize;

        WA.Width = RowSize * ItemSize;
        WA.Height = ColumnSize * ItemSize;

        WA.X = (Width / 2) - (WA.Width / 2);
        WA.Y = (Height / 2) - (WA.Height / 2);

        Table = new byte[(RowSize * ColumnSize)];

        for (int I = 0; I <= Table.Length - 1; I++)
        {
            Table[I] = Convert.ToByte(RNG.Next(100));
        }

        Invalidate();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        UpdateTable();
    }

    private int Index1 = -1;

    private int Index2;

    private bool InvertColors;
    protected override void OnMouseMove(MouseEventArgs e)
    {
        HandleDraw(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        HandleDraw(e);
        base.OnMouseDown(e);
    }

    private void HandleDraw(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (!WA.Contains(e.Location))
                return;

            InvertColors = (e.Button == System.Windows.Forms.MouseButtons.Right);

            Index1 = GetIndex(e.X, e.Y);
            if (Index1 == Index2)
                return;

            bool L = !(Index1 % RowSize == 0);
            bool R = !(Index1 % RowSize == (RowSize - 1));

            Randomize(Index1 - RowSize);
            if (L)
                Randomize(Index1 - 1);
            Randomize(Index1);
            if (R)
                Randomize(Index1 + 1);
            Randomize(Index1 + RowSize);

            _Value.Append(Table[Index1].ToString("X"));
            if (_Value.Length > 32)
                _Value.Remove(0, 2);

            if (ValueChanged != null)
            {
                ValueChanged(this);
            }

            Index2 = Index1;
            Invalidate();
        }
    }

    private GraphicsPath GP1;

    private GraphicsPath GP2;
    private Pen P1;
    private Pen P2;
    private SolidBrush B1;

    private SolidBrush B2;

    private PathGradientBrush PB1;
    private Graphics G;

    protected override void OnPaint(PaintEventArgs e)
	{
		G = e.Graphics;

		G.Clear(BackColor);
		G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

		PB1 = new PathGradientBrush(GP1);
		PB1.CenterColor = Color.FromArgb(50, 50, 50);
		PB1.SurroundColors = new Color[]{ Color.FromArgb(45, 45, 45) };
		PB1.FocusScales = new PointF(0.9f, 0.5f);

		G.FillPath(PB1, GP1);

		G.DrawPath(P1, GP1);
		G.DrawPath(P2, GP2);

		G.SmoothingMode = SmoothingMode.None;

		for (int I = 0; I <= Table.Length - 1; I++) {
			int C = Math.Max(Table[I], (byte)75);

			int X = ((I % RowSize) * ItemSize) + WA.X;
			int Y = ((I / RowSize) * ItemSize) + WA.Y;

			B2 = new SolidBrush(Color.FromArgb(C, C, C));

			G.FillRectangle(B1, X + 1, Y + 1, DrawSize, DrawSize);
			G.FillRectangle(B2, X, Y, DrawSize, DrawSize);

			B2.Dispose();
		}

	}

    private int GetIndex(int x, int y)
    {
        return (((y - WA.Y) / ItemSize) * RowSize) + ((x - WA.X) / ItemSize);
    }

    private void Randomize(int index)
    {
        if (index > -1 && index < Table.Length)
        {
            if (InvertColors)
            {
                Table[index] = Convert.ToByte(RNG.Next(100));
            }
            else
            {
                Table[index] = Convert.ToByte(RNG.Next(100, 256));
            }
        }
    }

}