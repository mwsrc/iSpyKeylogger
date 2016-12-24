using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;
namespace iSpy_Keylogger
{

    public enum MouseState : byte
    {
	    None = 0,
	    Over = 1,
	    Down = 2
    }

    static class Draw
    {
	    public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
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
	    public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
	    {
		    Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
		    GraphicsPath P = new GraphicsPath();
		    int ArcRectangleWidth = Curve * 2;
		    P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
		    P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
		    P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
		    P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
		    P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
		    return P;
	    }
	    private static Image ImageFromCode(ref string str)
	    {
		    byte[] imageBytes = Convert.FromBase64String(str);
		    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length);
		    ms.Write(imageBytes, 0, imageBytes.Length);
		    Image i = Image.FromStream(ms, true);
		    return i;
	    }
	    public static TextureBrush TiledTextureFromCode(string str)
	    {
		    return new TextureBrush(Draw.ImageFromCode(ref str), WrapMode.Tile);
	    }
    }

    public class RedemptionButton : Control
    {
	    MouseState MouseState = MouseState.None;
	    public enum HorizontalAlignment : byte
	    {
		    Left,
		    Center,
		    Right
	    }
	    private HorizontalAlignment _TextAlign = HorizontalAlignment.Center;
	    public HorizontalAlignment TextAlign {
		    get { return _TextAlign; }
		    set {
			    _TextAlign = value;
			    Invalidate();
		    }
	    }

	    public RedemptionButton() : base()
	    {
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    DoubleBuffered = true;
		    BackColor = Color.Transparent;
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }
	    protected override void OnPaint(PaintEventArgs e)
	    {
		    int curve = 5;
		    Bitmap b = new Bitmap(Width, Height);
		    Graphics g = Graphics.FromImage(b);
		    g.SmoothingMode = SmoothingMode.HighQuality;
		    g.TextRenderingHint = TextRenderingHint.AntiAlias;
		    base.OnPaint(e);
		    if (Enabled) {
			    g.Clear(BackColor);
			    switch (MouseState) {
				    case MouseState.None:
					    LinearGradientBrush MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(55, 62, 70), Color.FromArgb(43, 44, 48), 90);
					    g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
					    LinearGradientBrush GlossPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(93, 98, 104), Color.Transparent, 90);
					    g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 1), curve + 1));
					    break;
				    case MouseState.Over:
					     MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(72, 79, 87), Color.FromArgb(48, 51, 56), 90);
					    g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
					     GlossPen = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(119, 124, 130), Color.FromArgb(64, 67, 72), 90);
					    g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), curve));
					    break;
				    case MouseState.Down:
					     MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(43, 44, 48), Color.FromArgb(51, 54, 59), 90);
					    g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
					     GlossPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(55, 56, 60), Color.Transparent, 90);
					    g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 1), curve + 1));
					    break;
			    }

			    g.DrawPath(new Pen(Color.FromArgb(31, 36, 42)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));

		    } else {
		    }


		    StringFormat sf = new StringFormat();
		    switch (TextAlign) {
			    case HorizontalAlignment.Center:
				    sf.Alignment = StringAlignment.Center;
				    sf.LineAlignment = StringAlignment.Center;
				    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(1, 2, Width - 1, Height - 1), sf);
				    g.DrawString(Text, Font, Brushes.White, new Rectangle(0, 1, Width - 1, Height - 1), sf);
				    break;
			    case HorizontalAlignment.Left:
				    sf.Alignment = StringAlignment.Near;
				    sf.LineAlignment = StringAlignment.Center;
				    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(6, 2, Width - 1, Height - 1), sf);
				    g.DrawString(Text, Font, Brushes.White, new Rectangle(5, 1, Width - 1, Height - 1), sf);
				    break;
			    case HorizontalAlignment.Right:
				    sf.Alignment = StringAlignment.Far;
				    sf.LineAlignment = StringAlignment.Center;
				    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(-3, 2, Width - 1, Height - 1), sf);
				    g.DrawString(Text, Font, Brushes.White, new Rectangle(-4, 1, Width - 1, Height - 1), sf);
				    break;
		    }


		    e.Graphics.DrawImage(b, new Point(0, 0));
		    g.Dispose();
		    b.Dispose();
	    }
	    protected override void OnMouseEnter(EventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseEnter(e);
			    MouseState = MouseState.Over;
			    Invalidate();
			    Cursor = Cursors.Hand;
		    }
	    }
	    protected override void OnMouseDown(MouseEventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseDown(e);
			    MouseState = MouseState.Down;
			    Invalidate();
			    Cursor = Cursors.Hand;
		    }
	    }
	    protected override void OnMouseUp(MouseEventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseUp(e);
			    MouseState = MouseState.Over;
			    Invalidate();
			    Cursor = Cursors.Hand;
		    }
	    }
	    protected override void OnMouseLeave(EventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseLeave(e);
			    MouseState = MouseState.None;
			    Invalidate();
			    Cursor = Cursors.Default;
		    }
	    }
	    protected override void OnTextChanged(EventArgs e)
	    {
		    base.OnTextChanged(e);
		    Invalidate();
	    }
    }

    public class RedemptionRoundButton : Control
    {
	    MouseState MouseState = MouseState.None;
	    public enum HorizontalAlignment : byte
	    {
		    Left,
		    Center,
		    Right
	    }
	    private HorizontalAlignment _TextAlign = HorizontalAlignment.Center;
	    public HorizontalAlignment TextAlign {
		    get { return _TextAlign; }
		    set {
			    _TextAlign = value;
			    Invalidate();
		    }
	    }

	    public RedemptionRoundButton() : base()
	    {
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    DoubleBuffered = true;
		    BackColor = Color.Transparent;
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }
	    protected override void OnPaint(PaintEventArgs e)
	    {
		    int curve = 13;
		    Bitmap b = new Bitmap(Width, Height);
		    Graphics g = Graphics.FromImage(b);
		    g.SmoothingMode = SmoothingMode.HighQuality;
		    g.TextRenderingHint = TextRenderingHint.AntiAlias;
		    base.OnPaint(e);
		    if (Enabled) {
			    g.Clear(BackColor);
			    switch (MouseState) {
				    case MouseState.None:
					    LinearGradientBrush MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(131, 198, 240), Color.FromArgb(24, 121, 218), 90);
					    g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
					    LinearGradientBrush GlossPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(145, 212, 254), Color.Transparent, 90);
					    g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 2), curve + 1));
					    break;
				    case MouseState.Over:
					     MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(150, 203, 235), Color.FromArgb(35, 135, 220), 90);
					    g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
					     GlossPen = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(173, 226, 255), Color.FromArgb(54, 155, 235), 90);
					    g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), curve));
					    break;
				    case MouseState.Down:
					     MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(30, 121, 210), Color.FromArgb(84, 172, 236), 90);
					    g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
					     GlossPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(54, 145, 234), Color.Transparent, 90);
					    g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 1), curve + 1));
					    break;
			    }
			    g.DrawPath(new Pen(Color.FromArgb(21, 38, 56)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
			    g.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(-1, -1, 2, 10));
			    g.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(-2, -1, 4, 9));

		    } else {
		    }


		    StringFormat sf = new StringFormat();
		    switch (TextAlign) {
			    case HorizontalAlignment.Center:
				    sf.Alignment = StringAlignment.Center;
				    sf.LineAlignment = StringAlignment.Center;
				    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(1, 2, Width - 1, Height - 1), sf);
				    g.DrawString(Text, Font, Brushes.White, new Rectangle(0, 1, Width - 1, Height - 1), sf);
				    break;
			    case HorizontalAlignment.Left:
				    sf.Alignment = StringAlignment.Near;
				    sf.LineAlignment = StringAlignment.Center;
				    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(6, 2, Width - 1, Height - 1), sf);
				    g.DrawString(Text, Font, Brushes.White, new Rectangle(5, 1, Width - 1, Height - 1), sf);
				    break;
			    case HorizontalAlignment.Right:
				    sf.Alignment = StringAlignment.Far;
				    sf.LineAlignment = StringAlignment.Center;
				    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(-3, 2, Width - 1, Height - 1), sf);
				    g.DrawString(Text, Font, Brushes.White, new Rectangle(-4, 1, Width - 1, Height - 1), sf);
				    break;
		    }


		    e.Graphics.DrawImage(b, new Point(0, 0));
		    g.Dispose();
		    b.Dispose();
	    }
	    protected override void OnMouseEnter(EventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseEnter(e);
			    MouseState = MouseState.Over;
			    Invalidate();
			    Cursor = Cursors.Hand;
		    }
	    }
	    protected override void OnMouseDown(MouseEventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseDown(e);
			    MouseState = MouseState.Down;
			    Invalidate();
			    Cursor = Cursors.Hand;
		    }
	    }
	    protected override void OnMouseUp(MouseEventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseUp(e);
			    MouseState = MouseState.Over;
			    Invalidate();
			    Cursor = Cursors.Hand;
		    }
	    }
	    protected override void OnMouseLeave(EventArgs e)
	    {
		    if (Enabled) {
			    base.OnMouseLeave(e);
			    MouseState = MouseState.None;
			    Invalidate();
			    Cursor = Cursors.Default;
		    }
	    }
	    protected override void OnTextChanged(EventArgs e)
	    {
		    base.OnTextChanged(e);
		    Invalidate();
	    }
    }

    public class RedemptionTextBox : Control
    {
	    private TextBox withEventsField_txtbox = new TextBox();
	    public TextBox txtbox {
		    get { return withEventsField_txtbox; }
		    set {
			    if (withEventsField_txtbox != null) {
				    withEventsField_txtbox.TextChanged -= TextChngTxtBox;
			    }
			    withEventsField_txtbox = value;
			    if (withEventsField_txtbox != null) {
				    withEventsField_txtbox.TextChanged += TextChngTxtBox;
			    }
		    }
		                                                                                                                                                                                                                                                                                                                                                            #region " Control Help - Properties & Flicker Control "
	}
	private bool _UsePassword = false;
	public new bool UseSystemPasswordChar {
		get { return _UsePassword; }
		set {
			txtbox.UseSystemPasswordChar = UseSystemPasswordChar;
			_UsePassword = value;
			Invalidate();
		}
	}
	private int _MaxCharacters = 32767;
	public new int MaxLength {
		get { return _MaxCharacters; }
		set {
			_MaxCharacters = value;
			txtbox.MaxLength = MaxLength;
			Invalidate();
		}
	}
	private HorizontalAlignment _TextAlignment;
	public new HorizontalAlignment TextAlign {
		get { return _TextAlignment; }
		set {
			_TextAlignment = value;
			Invalidate();
		}
	}
	private bool _MultiLine = false;
	public new bool MultiLine {
		get { return _MultiLine; }
		set {
			_MultiLine = value;
			txtbox.Multiline = value;
			OnResize(EventArgs.Empty);
			Invalidate();
		}
	}


	protected override void OnTextChanged(System.EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}
	protected override void OnBackColorChanged(System.EventArgs e)
	{
		base.OnBackColorChanged(e);
		Invalidate();
	}
	protected override void OnForeColorChanged(System.EventArgs e)
	{
		base.OnForeColorChanged(e);
		txtbox.ForeColor = ForeColor;
		Invalidate();
	}
	protected override void OnFontChanged(System.EventArgs e)
	{
		base.OnFontChanged(e);
		txtbox.Font = Font;
	}
	protected override void OnGotFocus(System.EventArgs e)
	{
		base.OnGotFocus(e);
		txtbox.Focus();
	}
    private void TextChngTxtBox(object sender, EventArgs e)
	{
		Text = txtbox.Text;
	}
    private void TextChng(object sender, EventArgs e)
	{
		txtbox.Text = Text;
	}
	public void NewTextBox()
	{
		var _with1 = txtbox;
		_with1.Multiline = false;
		_with1.BackColor = Color.FromArgb(49, 50, 54);
		_with1.ForeColor = ForeColor;
		_with1.Text = string.Empty;
		_with1.TextAlign = HorizontalAlignment.Center;
		_with1.BorderStyle = BorderStyle.None;
		_with1.Location = new Point(5, 4);
		_with1.Font = new Font("Arial", 8.25f, FontStyle.Bold);
		_with1.Size = new Size(Width - 10, Height - 11);
		_with1.UseSystemPasswordChar = UseSystemPasswordChar;

	}
	#endregion

	    public RedemptionTextBox() : base()
	    {
		    TextChanged += TextChng;

		    NewTextBox();
		    Controls.Add(txtbox);

		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);

		    Text = "";
		    BackColor = Color.Transparent;
		    ForeColor = Color.White;
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
		    Size = new Size(135, 24);
		    DoubleBuffered = true;
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    int Curve = 4;
		    G.SmoothingMode = SmoothingMode.HighQuality;

		    var _with2 = txtbox;
		    _with2.TextAlign = TextAlign;
		    _with2.UseSystemPasswordChar = UseSystemPasswordChar;

		    G.Clear(Color.Transparent);
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));

		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();
	    }

	    protected override void OnResize(EventArgs e)
	    {
		    base.OnResize(e);
		    if (!MultiLine) {
			    int TextBoxHeight = txtbox.Height;
			    txtbox.Location = new Point(10, (Height / 2) - (TextBoxHeight / 2) - 1);
			    txtbox.Size = new Size(Width - 20, TextBoxHeight);
		    } else {
			    int TextBoxHeight = txtbox.Height;
			    txtbox.Location = new Point(10, 10);
			    txtbox.Size = new Size(Width - 20, Height - 20);
		    }
	    }
    }

    public class RedemptionProgressBar : Control
    {

	                                                                                                                            #region "Properties"
	private int val;
	public int Value {
		get { return val; }
		set {
			if (value > max) {
				val = max;
			} else if (value < 0) {
				val = 0;
			} else {
				val = value;
			}
			Invalidate();
		}
	}
	private int max;
	public int Maximum {
		get { return max; }
		set {
			if (value < 1) {
				max = 1;
			} else {
				max = value;
			}

			if (value < val) {
				val = max;
			}

			Invalidate();
		}
	}
	#endregion
	    protected override void OnResize(EventArgs e)
	    {
		    base.OnResize(e);
	    }
	    public RedemptionProgressBar()
	    {
		    max = 100;
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    BackColor = Color.Transparent;
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    int curve = 6;
		    Bitmap b = new Bitmap(Width, Height);
		    Graphics g = Graphics.FromImage(b);
		    g.SmoothingMode = SmoothingMode.HighQuality;
		    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		    int Fill = Convert.ToInt32((Width - 1) * (val / max));

		    g.Clear(Color.Transparent);
		    g.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    g.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), curve));
		    }

		    if (Fill > 4) {
			    g.FillPath(new SolidBrush(Color.FromArgb(80, 164, 234)), Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
			    HatchBrush FillTexture = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 26, 127, 217), Color.Transparent);
			    LinearGradientBrush Gloss = new LinearGradientBrush(new Rectangle(0, 0, Fill, Height - 2), Color.FromArgb(75, Color.White), Color.FromArgb(65, Color.Black), 90);
			    g.FillPath(Gloss, Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
			    g.FillPath(FillTexture, Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
			    LinearGradientBrush FillGradientBorder = new LinearGradientBrush(new Rectangle(0, 0, Fill, Height - 2), Color.FromArgb(183, 223, 249), Color.FromArgb(41, 141, 226), 90);
			    g.DrawPath(new Pen(FillGradientBorder), Draw.RoundRect(new Rectangle(1, 1, Fill - 2, Height - 4), curve));
			    g.DrawPath(new Pen(Color.FromArgb(1, 44, 76)), Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));

		    }

		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    g.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
		    g.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));


		    e.Graphics.DrawImage((Image)b.Clone(), 0, 0);
		    g.Dispose();
		    b.Dispose();
	    }
    }

    public class RedemptionLabel : Control
    {
	    public RedemptionLabel()
	    {
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    DoubleBuffered = true;
		    ForeColor = Color.White;
		    BackColor = Color.FromArgb(51, 56, 60);
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }
	    protected override void OnTextChanged(EventArgs e)
	    {
		    base.OnTextChanged(e);
		    Invalidate();
	    }
	    protected override void OnPaint(PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);

		    base.OnPaint(e);
		    G.TextRenderingHint = TextRenderingHint.AntiAlias;
		    G.Clear(BackColor);
		    G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(1, 1, Width - 1, Height - 1), new StringFormat {
			    LineAlignment = StringAlignment.Center,
			    Alignment = StringAlignment.Near
		    });
		    G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat {
			    LineAlignment = StringAlignment.Center,
			    Alignment = StringAlignment.Near
		    });


		    e.Graphics.DrawImage(B, new Point(0, 0));
		    G.Dispose();
		    B.Dispose();
	    }
    }

    public class RedemptionTabControl : TabControl
    {

	    public enum HorizontalAlignments
	    {
		    Left,
		    Center,
		    Right
	    }
	    private HorizontalAlignments _Align = HorizontalAlignments.Left;
	    public HorizontalAlignments TextAlign {
		    get { return _Align; }
		    set {
			    _Align = value;
			    Invalidate();
		    }
	    }
	    private bool _BackgrounNoise;
	    public bool BackgroundNoise {
		    get { return _BackgrounNoise; }
		    set {
			    _BackgrounNoise = value;
			    Invalidate();
		    }
	    }

	    public RedemptionTabControl()
	    {
		    SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
		    DoubleBuffered = true;
		    SizeMode = TabSizeMode.Fixed;
		    BackColor = Color.Transparent;
		    ItemSize = new Size(35, 100);
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }
	    protected override void CreateHandle()
	    {
		    base.CreateHandle();
		    Alignment = TabAlignment.Left;
	    }

	    protected override void OnPaint(PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    int Curve = 6;
		    G.TextRenderingHint = TextRenderingHint.AntiAlias;
		    G.SmoothingMode = SmoothingMode.HighQuality;
		    try {
			    SelectedTab.BackColor = Color.FromArgb(47, 48, 52);
		    } catch {
		    }
		    G.Clear(Color.FromArgb(51, 56, 60));
		    if (BackgroundNoise) {
			    TextureBrush MatteNoise = Draw.TiledTextureFromCode("iVBORw0KGgoAAAANSUhEUgAAAEYAAABGCAIAAAD+THXTAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDo1OEU1MkNDNjNCQjBFMjExQjY2NkFFNERBQzEzREJERiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDpGQTIzMjhDQUIwM0IxMUUyOEY4NDk4NjlBRTkxQzE1QyIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpGQTIzMjhDOUIwM0IxMUUyOEY4NDk4NjlBRTkxQzE1QyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjU4RTUyQ0M2M0JCMEUyMTFCNjY2QUU0REFDMTNEQkRGIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjU4RTUyQ0M2M0JCMEUyMTFCNjY2QUU0REFDMTNEQkRGIi8+IDwvcmRmOkRlc2NyaXB0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");
			    G.FillRectangle(MatteNoise, new Rectangle(-1, -1, Width + 3, Height + 3));
			    G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), new Rectangle(-1, -1, Width + 3, Height + 3));
		    }
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(ItemSize.Height - 1, 0, Width - ItemSize.Height - 1 - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(ItemSize.Height - 1 + i + 1, i + 1, Width - ItemSize.Height - 1 - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(ItemSize.Height - 1, 0, Width - ItemSize.Height - 1 - 1, Height - 1), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(ItemSize.Height - 1, 0, Width - ItemSize.Height - 1 - 1, Height - 2), Curve));

		    for (int i = 0; i <= TabCount - 1; i++) {
			    if (i == SelectedIndex) {
				    Rectangle OuterBorder = new Rectangle(new Point(GetTabRect(i).Location.X - 1, GetTabRect(i).Location.Y + 3), new Size(GetTabRect(i).Width - 7, GetTabRect(i).Height - 7));
				    Rectangle InnerBorder = new Rectangle(new Point(GetTabRect(i).Location.X - 1, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 7, GetTabRect(i).Height - 8));
				    LinearGradientBrush MainBody = new LinearGradientBrush(OuterBorder, Color.FromArgb(72, 79, 87), Color.FromArgb(48, 51, 56), 90);
				    G.FillPath(MainBody, Draw.RoundRect(OuterBorder, Curve));
				    LinearGradientBrush GlossPen = new LinearGradientBrush(OuterBorder, Color.FromArgb(119, 124, 130), Color.FromArgb(64, 67, 72), 90);
				    G.DrawPath(new Pen(GlossPen), Draw.RoundRect(InnerBorder, Curve));
				    G.DrawPath(new Pen(Color.FromArgb(31, 36, 42)), Draw.RoundRect(OuterBorder, Curve));
			    }

			    switch (TextAlign) {
				    case HorizontalAlignments.Center:
					    Rectangle TextRectangle = new Rectangle(new Point(GetTabRect(i).Location.X - 4, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
					    Rectangle TextShadow = new Rectangle(new Point(GetTabRect(i).Location.X - 3, GetTabRect(i).Location.Y + 5), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
					    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), TextShadow, new StringFormat {
						    LineAlignment = StringAlignment.Center,
						    Alignment = StringAlignment.Center
					    });
					    G.DrawString(TabPages[i].Text, Font, Brushes.White, TextRectangle, new StringFormat {
						    LineAlignment = StringAlignment.Center,
						    Alignment = StringAlignment.Center
					    });
					    break;
				    case HorizontalAlignments.Left:
					    TextRectangle = new Rectangle(new Point(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
					    TextShadow = new Rectangle(new Point(GetTabRect(i).Location.X + 6, GetTabRect(i).Location.Y + 5), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
					    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), TextShadow, new StringFormat {
						    LineAlignment = StringAlignment.Center,
						    Alignment = StringAlignment.Near
					    });
					    G.DrawString(TabPages[i].Text, Font, Brushes.White, TextRectangle, new StringFormat {
						    LineAlignment = StringAlignment.Center,
						    Alignment = StringAlignment.Near
					    });
					    break;
				    case HorizontalAlignments.Right:
					    TextRectangle = new Rectangle(new Point(GetTabRect(i).Location.X - 9, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
					    TextShadow = new Rectangle(new Point(GetTabRect(i).Location.X - 8, GetTabRect(i).Location.Y + 5), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
					    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), TextShadow, new StringFormat {
						    LineAlignment = StringAlignment.Center,
						    Alignment = StringAlignment.Far
					    });
					    G.DrawString(TabPages[i].Text, Font, Brushes.White, TextRectangle, new StringFormat {
						    LineAlignment = StringAlignment.Center,
						    Alignment = StringAlignment.Far
					    });
					    break;
			    }
		    }
		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();
	    }
    }

    public class RedemptionNumericUpDown : Control
    {

	                                                                                                                                                                                                                                                                                                                                                                                                                                                #region " Properties & Flicker Control "
	private MouseState State = new MouseState();
	private int X;
	private int Y;
	private long _Value;
	private long _Max;
	private long _Min;
	private bool Typing;
	public long Value {
		get { return _Value; }
		set {
			if (value <= _Max & value >= _Min)
				_Value = value;
			Invalidate();
		}
	}
	public long Maximum {
		get { return _Max; }
		set {
			if (value > _Min)
				_Max = value;
			if (_Value > _Max)
				_Value = _Max;
			Invalidate();
		}
	}
	public long Minimum {
		get { return _Min; }
		set {
			if (value < _Max)
				_Min = value;
			if (_Value < _Min)
				_Value = _Min;
			Invalidate();
		}
	}
	protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseMove(e);
		X = e.Location.X;
		Y = e.Location.Y;
		Invalidate();
		if (e.X < Width - 23)
			Cursor = Cursors.IBeam;
		else
			Cursor = Cursors.Default;
	}
	protected override void OnResize(System.EventArgs e)
	{
		base.OnResize(e);
		this.Height = 26;
	}
	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseClick(e);
		if (X > this.Width - 17 && X < this.Width - 3) {
			if (Y < 13) {
				if ((Value + 1) <= _Max)
					_Value += 1;
			} else {
				if ((Value - 1) >= _Min)
					_Value -= 1;
			}
		} else {
			Typing = !Typing;
			Focus();
		}
		Invalidate();
	}
	protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
	{
		base.OnKeyPress(e);
		try {
			if (Typing)
				_Value = Convert.ToInt64(Convert.ToString(_Value) + e.KeyChar.ToString());
			if (_Value > _Max)
				_Value = _Max;
		} catch (Exception ex) {
		}
	}
	protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (e.KeyCode == Keys.Up) {
			if ((Value + 1) <= _Max)
				_Value += 1;
			Invalidate();
		} else if (e.KeyCode == Keys.Down) {
			if ((Value - 1) >= _Min)
				_Value -= 1;
		} else if (e.KeyCode == Keys.Back) {
			string tmp = _Value.ToString();
			tmp = tmp.Remove(Convert.ToInt32(tmp.Length - 1));
			if ((tmp.Length == 0))
				tmp = "0";
			_Value = Convert.ToInt32(tmp);
		}
		Invalidate();
	}
	protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
	{
		List<Point> points = new List<Point>();
		points.Add(FirstPoint);
		points.Add(SecondPoint);
		points.Add(ThirdPoint);
		G.FillPolygon(new SolidBrush(Clr), points.ToArray());
	}
	#endregion
	    public RedemptionNumericUpDown()
	    {
		    _Max = 9999999;
		    _Min = 0;
		    Cursor = Cursors.IBeam;
		    SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
		    BackColor = Color.Transparent;
		    ForeColor = Color.White;
		    DoubleBuffered = true;
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    int Curve = 4;
		    G.Clear(BackColor);

		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.TextRenderingHint = TextRenderingHint.AntiAlias;
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
		    LinearGradientBrush ButtonBackground = new LinearGradientBrush(new Rectangle(Width - 17, 0, 17, Height - 2), Color.FromArgb(75, 78, 87), Color.FromArgb(50, 51, 55), 90);
		    G.FillRectangle(ButtonBackground, ButtonBackground.Rectangle);
		    G.ResetClip();
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
		    DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 8), new Point(Width - 6, 8), new Point(Width - 9, 5), G);
		    DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 17), new Point(Width - 6, 17), new Point(Width - 9, 20), G);
		    G.SetClip(Draw.RoundRect(new Rectangle(Width - 17, 0, 17, Height - 2), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(82, 85, 92)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 4), Curve));
		    G.ResetClip();
		    G.DrawLine(new Pen(Color.FromArgb(29, 37, 40)), new Point(Width - 17, 0), new Point(Width - 17, Height - 2));
		    G.DrawLine(new Pen(Color.FromArgb(85, 92, 98)), new Point(Width - 16, 1), new Point(Width - 16, Height - 3));
		    G.DrawLine(new Pen(Color.FromArgb(29, 37, 40)), new Point(Width - 17, Height / 2 - 1), new Point(Width - 1, Height / 2 - 1));
		    G.DrawLine(new Pen(Color.FromArgb(85, 92, 98)), new Point(Width - 16, Height / 2), new Point(Width - 2, Height / 2));

		    G.DrawString(Value.ToString(), Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Point(8, 8));
            G.DrawString(Value.ToString(), Font, Brushes.White, new Point(7, 7));
		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();
	    }
    }

    public class RedemptionComboBox : ComboBox
    {
	                                                                                                                                                    #region " Control Help - Properties & Flicker Control "
	private int _StartIndex = 0;
	private int StartIndex {
		get { return _StartIndex; }
		set {
			_StartIndex = value;
			try {
				base.SelectedIndex = value;
			} catch {
			}
			Invalidate();
		}
	}
	public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
	{
		e.DrawBackground();
		try {
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(59, 60, 64)), e.Bounds);
			} else {
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(49, 50, 54)), e.Bounds);
			}
			using (SolidBrush b = new SolidBrush(e.ForeColor)) {
				e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
			}
		} catch {
		}
	}
	protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
	{
		List<Point> points = new List<Point>();
		points.Add(FirstPoint);
		points.Add(SecondPoint);
		points.Add(ThirdPoint);
		G.FillPolygon(new SolidBrush(Clr), points.ToArray());
	}

	#endregion

	    public RedemptionComboBox() : base()
	    {
		    DrawItem += ReplaceItem;
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.ResizeRedraw, true);
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.DoubleBuffer, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		    BackColor = Color.Transparent;
		    ForeColor = Color.FromArgb(182, 179, 171);
		    DropDownStyle = ComboBoxStyle.DropDownList;
		    StartIndex = 0;
		    ItemHeight = 18;
		    DoubleBuffered = true;
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }
	    protected override void OnResize(EventArgs e)
	    {
		    base.OnResize(e);
		    Height = 26;
	    }

	    protected override void OnPaint(PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    int Curve = 4;
		    G.Clear(BackColor);

		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.TextRenderingHint = TextRenderingHint.AntiAlias;
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));

		    LinearGradientBrush BodyGradient = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(57, 62, 68), Color.FromArgb(42, 43, 47), 90);
		    G.FillPath(BodyGradient, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));


		    G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
		    LinearGradientBrush ButtonBackground = new LinearGradientBrush(new Rectangle(Width - 17, 0, 17, Height - 2), Color.FromArgb(75, 78, 87), Color.FromArgb(50, 51, 55), 90);
		    G.FillRectangle(ButtonBackground, ButtonBackground.Rectangle);
		    G.ResetClip();


		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 1, Width - 1, Height - 2), Color.FromArgb(92, 97, 103), Color.Transparent, 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 2), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));


		    DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 8), new Point(Width - 6, 8), new Point(Width - 9, 5), G);
		    DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 14), new Point(Width - 6, 14), new Point(Width - 9, 17), G);
		    G.SetClip(Draw.RoundRect(new Rectangle(Width - 17, 0, 17, Height), Curve));
		    LinearGradientBrush ButtonPen = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(82, 85, 92), Color.FromArgb(66, 67, 72), 90);
		    G.DrawPath(new Pen(ButtonPen), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), Curve));
		    G.ResetClip();
		    G.DrawLine(new Pen(Color.FromArgb(29, 37, 40)), new Point(Width - 17, 0), new Point(Width - 17, Height - 2));
		    G.DrawLine(new Pen(Color.FromArgb(85, 92, 98)), new Point(Width - 16, 1), new Point(Width - 16, Height - 3));

		    try {
			    G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(7, 0, Width - 1, Height - 1), new StringFormat {
				    LineAlignment = StringAlignment.Center,
				    Alignment = StringAlignment.Near
			    });
			    G.DrawString(Text, Font, new SolidBrush(Color.White), new Rectangle(7, 1, Width - 1, Height - 1), new StringFormat {
				    LineAlignment = StringAlignment.Center,
				    Alignment = StringAlignment.Near
			    });
		    } catch {
		    }

		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();
	    }
    }

    [DefaultEvent("CheckedChanged")]
    public class RedemptionCheckBox : Control
    {

	                                                                                                                                                                                                                                #region " Control Help - MouseState & Flicker Control"
	private MouseState State = MouseState.None;
	protected override void OnMouseEnter(System.EventArgs e)
	{
		base.OnMouseEnter(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);
		State = MouseState.Down;
		Invalidate();
	}
	protected override void OnMouseLeave(System.EventArgs e)
	{
		base.OnMouseLeave(e);
		State = MouseState.None;
		Invalidate();
	}
	protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseUp(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnTextChanged(System.EventArgs e)
	{
		base.OnTextChanged(e);
        Width = Convert.ToInt32(CreateGraphics().MeasureString(Text, Font).Width + (2 * 3) + Height);
		Invalidate();
	}
	private bool _Checked;
	public bool Checked {
		get { return _Checked; }
		set {
			_Checked = value;
			Invalidate();
		}
	}
	protected override void OnResize(System.EventArgs e)
	{
		base.OnResize(e);
		Height = 19;
	}
	protected override void OnClick(System.EventArgs e)
	{
		_Checked = !_Checked;
		if (CheckedChanged != null) {
			CheckedChanged(this);
		}
		base.OnClick(e);
	}
	public event CheckedChangedEventHandler CheckedChanged;
	public delegate void CheckedChangedEventHandler(object sender);
	#endregion

	    public RedemptionCheckBox() : base()
	    {
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);

		    BackColor = Color.Transparent;
		    ForeColor = Color.White;
		    Size = new Size(147, 17);
		    DoubleBuffered = true;
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		    Rectangle CheckBoxRectangle = new Rectangle(0, 0, Height - 1, Height - 1);
		    int Curve = 1;

		    G.Clear(BackColor);

		    G.Clear(Color.Transparent);
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Height - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Height - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Height - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Height - 2, Height - 1), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Height - 2, Height - 2), Curve));


		    if (Checked) {
			    Rectangle chkPoly = new Rectangle(CheckBoxRectangle.X + CheckBoxRectangle.Width / 4, CheckBoxRectangle.Y + CheckBoxRectangle.Height / 4, CheckBoxRectangle.Width / 2, CheckBoxRectangle.Height / 2);
			    Point[] Poly = {
				    new Point(chkPoly.X + 1, chkPoly.Y + chkPoly.Height / 2),
				    new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height - 1),
				    new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
			    };
			    for (int i = 0; i <= Poly.Length - 2; i++) {
				    G.DrawLine(new Pen(Color.White, 2), Poly[i], Poly[i + 1]);
			    }
		    }

		    G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(21, 3), new StringFormat {
			    Alignment = StringAlignment.Near,
			    LineAlignment = StringAlignment.Near
		    });

		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();

	    }

    }

    [DefaultEvent("CheckedChanged")]
    public class RedemptionRadioButton : Control
    {

	                                                                                                                                                                                                                                                                                                                        #region " Control Help - MouseState & Flicker Control"
	private Rectangle R1;

	private LinearGradientBrush G1;
	private MouseState State = MouseState.None;
	protected override void OnMouseEnter(System.EventArgs e)
	{
		base.OnMouseEnter(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);
		State = MouseState.Down;
		Invalidate();
	}
	protected override void OnMouseLeave(System.EventArgs e)
	{
		base.OnMouseLeave(e);
		State = MouseState.None;
		Invalidate();
	}
	protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseUp(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnResize(System.EventArgs e)
	{
		base.OnResize(e);
		Height = 19;
	}
	protected override void OnTextChanged(System.EventArgs e)
	{
		base.OnTextChanged(e);
		Width = Convert.ToInt32(CreateGraphics().MeasureString(Text, Font).Width + (2 * 3) + Height);
		Invalidate();
	}
	private bool _Checked;
	public bool Checked {
		get { return _Checked; }
		set {
			_Checked = value;
			InvalidateControls();
			if (CheckedChanged != null) {
				CheckedChanged(this);
			}
			Invalidate();
		}
	}
	protected override void OnClick(EventArgs e)
	{
		if (!_Checked)
			Checked = true;
		base.OnClick(e);
	}
	public event CheckedChangedEventHandler CheckedChanged;
	public delegate void CheckedChangedEventHandler(object sender);
	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		InvalidateControls();
	}
	private void InvalidateControls()
	{
		try {
			if (!IsHandleCreated || !Checked)
				return;
			foreach (Control C in Parent.Controls) {
				if (!object.ReferenceEquals(C, this) && C is RedemptionRadioButton) {
					((RedemptionRadioButton)C).Checked = false;
				}
			}
		} catch {
		}
	}
	#endregion

	    public RedemptionRadioButton() : base()
	    {
		    SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
		    BackColor = Color.Transparent;
		    ForeColor = Color.White;
		    DoubleBuffered = true;
		    Size = new Size(177, 17);
		    Font = new Font("Arial", 8.25f, FontStyle.Bold);
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    dynamic RadioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		    G.Clear(BackColor);

		    G.Clear(Color.Transparent);
		    G.FillEllipse(new SolidBrush(Color.FromArgb(49, 50, 54)), new Rectangle(0, 0, Height - 1, Height - 1));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawEllipse(new Pen(GradientPen[i]), new Rectangle(i + 1, i + 1, Height - ((2 * i) + 3), Height - ((2 * i) + 3)));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Height - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawEllipse(new Pen(BorderPen), new Rectangle(0, 0, Height - 2, Height - 1));
		    G.DrawEllipse(new Pen(Color.FromArgb(32, 33, 37)), new Rectangle(0, 0, Height - 2, Height - 2));



		    if (Checked) {
			    G.FillEllipse(new SolidBrush(Color.White), new Rectangle(5, 5, Height - 12, Height - 12));
		    }

		    G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(21, 3), new StringFormat {
			    Alignment = StringAlignment.Near,
			    LineAlignment = StringAlignment.Near
		    });

		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();
	    }

    }

    [DefaultEvent("CheckedChanged")]
    public class RedemptionToggle : Control
    {

	                                                                                                                                                                                                                            #region " Control Help - MouseState & Flicker Control"
	private MouseState State = MouseState.None;
	protected override void OnMouseEnter(System.EventArgs e)
	{
		base.OnMouseEnter(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);
		State = MouseState.Down;
		Invalidate();
	}
	protected override void OnMouseLeave(System.EventArgs e)
	{
		base.OnMouseLeave(e);
		State = MouseState.None;
		Invalidate();
	}
	protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseUp(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnTextChanged(System.EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}
	private bool _Checked;
	public bool Checked {
		get { return _Checked; }
		set {
			_Checked = value;
			Invalidate();
		}
	}
	protected override void OnResize(System.EventArgs e)
	{
		base.OnResize(e);
		Size = new Size(60, 26);
	}
	protected override void OnClick(System.EventArgs e)
	{
		_Checked = !_Checked;
		if (CheckedChanged != null) {
			CheckedChanged(this);
		}
		base.OnClick(e);
	}
	public event CheckedChangedEventHandler CheckedChanged;
	public delegate void CheckedChangedEventHandler(object sender);
	#endregion

	    public RedemptionToggle() : base()
	    {
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    Size = new Size(60, 26);
		    BackColor = Color.Transparent;
		    ForeColor = Color.White;
		    DoubleBuffered = true;
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		    int Curve = 4;

		    G.Clear(BackColor);

		    G.Clear(Color.Transparent);
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 3), Curve));

		    switch (Checked) {
			    case false:
				    LinearGradientBrush CheckedBody = new LinearGradientBrush(new Rectangle(0, 0, 30, Height - 3), Color.FromArgb(72, 79, 87), Color.FromArgb(48, 52, 55), 90);
				    G.FillPath(CheckedBody, Draw.RoundRect(new Rectangle(0, 0, 30, Height - 3), Curve));
				    LinearGradientBrush CheckedBorderPen = new LinearGradientBrush(new Rectangle(0, 0, 30, Height - 3), Color.FromArgb(29, 34, 40), Color.FromArgb(33, 34, 38), 90);
				    G.DrawPath(new Pen(CheckedBorderPen), Draw.RoundRect(new Rectangle(0, 0, 30, Height - 3), Curve));
				    LinearGradientBrush CheckedBorderHighlight = new LinearGradientBrush(new Rectangle(1, 1, 28, Height - 5), Color.FromArgb(118, 123, 129), Color.FromArgb(66, 67, 71), 90);
				    G.DrawPath(new Pen(CheckedBorderHighlight), Draw.RoundRect(new Rectangle(1, 1, 28, Height - 5), Curve));
				    for (int i = 0; i <= 2; i++) {
					    G.DrawLine(new Pen(Color.FromArgb(82, 86, 95)), new Point(7, 7 + (i * 4)), new Point(22, 7 + (i * 4)));
					    G.DrawLine(new Pen(Color.FromArgb(47, 50, 57)), new Point(7, 7 + (i * 4) + 1), new Point(22, 7 + (i * 4) + 1));
				    }

				    break;
			    case true:
				     CheckedBody = new LinearGradientBrush(new Rectangle(29, 0, 30, Height - 3), Color.FromArgb(145, 204, 238), Color.FromArgb(35, 137, 222), 90);
				    G.FillPath(CheckedBody, Draw.RoundRect(new Rectangle(29, 0, 30, Height - 3), Curve));
				     CheckedBorderPen = new LinearGradientBrush(new Rectangle(29, 0, 30, Height - 3), Color.FromArgb(21, 37, 52), Color.FromArgb(18, 37, 54), 90);
				    G.DrawPath(new Pen(CheckedBorderPen), Draw.RoundRect(new Rectangle(29, 0, 30, Height - 3), Curve));
				     CheckedBorderHighlight = new LinearGradientBrush(new Rectangle(30, 1, 28, Height - 5), Color.FromArgb(169, 228, 255), Color.FromArgb(53, 155, 240), 90);
				    G.DrawPath(new Pen(CheckedBorderHighlight), Draw.RoundRect(new Rectangle(30, 1, 28, Height - 5), Curve));
				    for (int i = 0; i <= 2; i++) {
					    G.DrawLine(new Pen(Color.FromArgb(109, 188, 244)), new Point(36, 7 + (i * 4)), new Point(51, 7 + (i * 4)));
					    G.DrawLine(new Pen(Color.FromArgb(40, 123, 199)), new Point(36, 7 + (i * 4) + 1), new Point(51, 7 + (i * 4) + 1));
				    }

				    break;
		    }
		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();

	    }

    }

    [DefaultEvent("CheckedChanged")]
    public class RedemptionRoundedToggle : Control
    {
	                                                                                                                                                                                                                            #region " Control Help - MouseState & Flicker Control"
	private MouseState State = MouseState.None;
	protected override void OnMouseEnter(System.EventArgs e)
	{
		base.OnMouseEnter(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);
		State = MouseState.Down;
		Invalidate();
	}
	protected override void OnMouseLeave(System.EventArgs e)
	{
		base.OnMouseLeave(e);
		State = MouseState.None;
		Invalidate();
	}
	protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseUp(e);
		State = MouseState.Over;
		Invalidate();
	}
	protected override void OnTextChanged(System.EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}
	private bool _Checked;
	public bool Checked {
		get { return _Checked; }
		set {
			_Checked = value;
			Invalidate();
		}
	}
	protected override void OnResize(System.EventArgs e)
	{
		base.OnResize(e);
		Size = new Size(34, 21);
	}
	protected override void OnClick(System.EventArgs e)
	{
		_Checked = !_Checked;
		if (CheckedChanged != null) {
			CheckedChanged(this);
		}
		base.OnClick(e);
	}
	public event CheckedChangedEventHandler CheckedChanged;
	public delegate void CheckedChangedEventHandler(object sender);
	#endregion

	    public RedemptionRoundedToggle() : base()
	    {
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    Size = new Size(34, 21);
		    BackColor = Color.Transparent;
		    ForeColor = Color.White;
		    DoubleBuffered = true;
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		    Rectangle CheckBoxRectangle = new Rectangle(0, 0, Height - 1, Height - 1);
		    int Curve = 9;

		    G.Clear(BackColor);

		    G.Clear(Color.Transparent);
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 3), Curve));
		    //G.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(-1, 0, 2, 7));
		    switch (Checked) {
			    case false:
				    LinearGradientBrush CheckedBody = new LinearGradientBrush(new Rectangle(0, 0, Height - 3, Height - 3), Color.FromArgb(72, 79, 87), Color.FromArgb(48, 52, 55), 90);
				    G.FillEllipse(CheckedBody, new Rectangle(0, 0, Height - 3, Height - 3));
				    LinearGradientBrush CheckedBorderPen = new LinearGradientBrush(new Rectangle(0, 0, Height - 3, Height - 3), Color.FromArgb(29, 34, 40), Color.FromArgb(33, 34, 38), 90);
				    G.DrawEllipse(new Pen(CheckedBorderPen), new Rectangle(0, 0, Height - 3, Height - 3));
				    LinearGradientBrush CheckedBorderHighlight = new LinearGradientBrush(new Rectangle(1, 1, Height - 5, Height - 4), Color.FromArgb(118, 123, 129), Color.FromArgb(66, 67, 71), 90);
				    G.DrawEllipse(new Pen(CheckedBorderHighlight), new Rectangle(1, 1, Height - 5, Height - 5));
				    break;
			    case true:
				     CheckedBody = new LinearGradientBrush(new Rectangle(15, 0, Height - 3, Height - 3), Color.FromArgb(138, 211, 254), Color.FromArgb(56, 157, 229), 90);
				    G.FillEllipse(CheckedBody, new Rectangle(15, 0, Height - 3, Height - 3));
				     CheckedBorderPen = new LinearGradientBrush(new Rectangle(15, 0, Height - 3, Height - 3), Color.FromArgb(7, 39, 64), Color.FromArgb(26, 35, 42), 90);
				    G.DrawEllipse(new Pen(CheckedBorderPen), new Rectangle(15, 0, Height - 3, Height - 3));
				     CheckedBorderHighlight = new LinearGradientBrush(new Rectangle(16, 1, Height - 5, Height - 4), Color.FromArgb(176, 206, 230), Color.FromArgb(30, 107, 175), 90);
				    G.DrawEllipse(new Pen(CheckedBorderHighlight), new Rectangle(16, 1, Height - 5, Height - 5));
				    break;
		    }
		    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
		    G.Dispose();
		    B.Dispose();

	    }
    }

    public class RedemptionListBox : ListBox
    {
	    public RedemptionListBox()
	    {
		    SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
		    BackColor = Color.Transparent;
		    DoubleBuffered = true;
		    DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		    ForeColor = Color.White;
		    BackColor = Color.FromArgb(47, 48, 52);
		    BorderStyle = System.Windows.Forms.BorderStyle.None;
	    }
	    protected override void OnPaint(PaintEventArgs e)
	    {
		    Graphics G = e.Graphics;
		    int Curve = 5;
		    base.OnPaint(e);
		    G.Clear(Color.Transparent);
		    G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    Color[] GradientPen = {
			    Color.FromArgb(43, 44, 48),
			    Color.FromArgb(44, 45, 49),
			    Color.FromArgb(45, 46, 50),
			    Color.FromArgb(46, 47, 51),
			    Color.FromArgb(47, 48, 52),
			    Color.FromArgb(48, 49, 53)
		    };
		    for (int i = 0; i <= 5; i++) {
			    G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));

	    }
	    protected override void OnDrawItem(DrawItemEventArgs e)
	    {
		    Graphics G = e.Graphics;
		    int Curve = 5;
		    G.TextRenderingHint = TextRenderingHint.AntiAlias;
		    G.SmoothingMode = SmoothingMode.HighQuality;
		    G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width, Height), Curve));
		    G.FillRectangle(new SolidBrush(BackColor), new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height + 3));

		    if (e.State.ToString().Contains("Selected,")) {
			    LinearGradientBrush MainBody = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(55, 62, 70), Color.FromArgb(43, 44, 48), 90);
			    G.FillRectangle(MainBody, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
			    LinearGradientBrush GlossPen = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(100, 93, 98, 104), Color.Transparent, 90);
			    G.DrawRectangle(new Pen(GlossPen), new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));

		    } else {
			    G.FillRectangle(new SolidBrush(BackColor), e.Bounds);
		    }

		    try {
			    G.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(100, Color.Black)), new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height), new StringFormat {
				    LineAlignment = StringAlignment.Center,
				    Alignment = StringAlignment.Near
			    });
			    G.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(ForeColor), new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), new StringFormat {
				    LineAlignment = StringAlignment.Center,
				    Alignment = StringAlignment.Near
			    });
		    } catch {
		    }
		    LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
		    G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
		    G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 3), Curve));
	    }
    }

    public class RedemptionForm : ContainerControl
    {
	                                                                                                                                                                                                                            #region " Control Help - Movement & Flicker Control "
	private Color TransparentColor = Color.Fuchsia;
	private Point MouseP = new Point(0, 0);
	private bool Cap = false;
	private int MoveHeight;
	private int pos = 0;
	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == System.Windows.Forms.MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location)) {
			Cap = true;
			MouseP = e.Location;
		}
	}
	protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (Cap) {
			Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
		}
	}
	protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseUp(e);
		Cap = false;
	}
	protected override void OnTextChanged(System.EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate();
	}
	protected override void OnResize(System.EventArgs e)
	{
		base.OnResize(e);
		Invalidate();
	}
	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		this.ParentForm.FormBorderStyle = FormBorderStyle.None;
	}
	protected override void CreateHandle()
	{
		base.CreateHandle();
		ParentForm.FindForm().TransparencyKey = TransparentColor;
	}

	private bool _BackgroundNoise = true;
	public bool BackgroundNoise {
		get { return _BackgroundNoise; }
		set {
			_BackgroundNoise = value;
			Invalidate();
		}
	}


	#endregion

	    public RedemptionForm() : base()
	    {
		    Dock = DockStyle.Fill;
		    MoveHeight = 29;
		    Font = new Font("Verdana", 8.25f);
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
	    }

	    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
		    base.OnPaint(e);
		    G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		    G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

		    TextureBrush MatteNoise = Draw.TiledTextureFromCode("iVBORw0KGgoAAAANSUhEUgAAAEYAAABGCAIAAAD+THXTAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDo1OEU1MkNDNjNCQjBFMjExQjY2NkFFNERBQzEzREJERiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDpGQTIzMjhDQUIwM0IxMUUyOEY4NDk4NjlBRTkxQzE1QyIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpGQTIzMjhDOUIwM0IxMUUyOEY4NDk4NjlBRTkxQzE1QyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjU4RTUyQ0M2M0JCMEUyMTFCNjY2QUU0REFDMTNEQkRGIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjU4RTUyQ0M2M0JCMEUyMTFCNjY2QUU0REFDMTNEQkRGIi8+IDwvcmRmOkRlc2NyaXB0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");
		    G.FillRectangle(MatteNoise, ClientRectangle);
		    G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, 0, Width - 1, 28));
		    G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, 28, 6, Height - 35));
		    G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(Width - 7, 28, 7, Height - 35));
		    G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, Height - 7, Width - 1, 7));
		    G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), new Rectangle(6, 28, Width - 13, Height - 35));
		    G.DrawLine(new Pen(Color.FromArgb(44, 45, 48)), new Point(6, 29), new Point(Width - 7, 29));
		    G.DrawLine(new Pen(Color.FromArgb(37, 38, 40)), new Point(6, 30), new Point(Width - 7, 30));
		    G.DrawLine(new Pen(Color.FromArgb(75, 60, 61, 62)), new Point(6, 31), new Point(Width - 7, 31));
		    G.DrawLine(new Pen(Color.FromArgb(56, 57, 60)), new Point(5, 31), new Point(5, Height - 7));
		    G.DrawLine(new Pen(Color.FromArgb(77, 78, 79)), new Point(6, 31), new Point(6, Height - 7));
		    G.DrawLine(new Pen(Color.FromArgb(56, 57, 60)), new Point(Width - 7, 31), new Point(Width - 7, Height - 7));
		    G.DrawLine(new Pen(Color.FromArgb(77, 78, 79)), new Point(Width - 8, 31), new Point(Width - 8, Height - 7));
		    G.DrawLine(new Pen(Color.FromArgb(63, 64, 65)), new Point(6, Height - 8), new Point(Width - 7, Height - 8));
		    G.DrawLine(new Pen(Color.FromArgb(63, 63, 63)), new Point(5, Height - 7), new Point(Width - 6, Height - 7));
		    G.DrawLine(new Pen(Color.FromArgb(85, 86, 88)), new Point(0, 1), new Point(Width - 1, 1));
		    G.DrawRectangle(new Pen(Color.FromArgb(21, 23, 25)), ClientRectangle);

		    Color[] ColorList = {
			    Color.FromArgb(200, 34, 36, 39),
			    Color.FromArgb(200, 5, 185, 238),
			    Color.FromArgb(200, 34, 36, 39)
		    };
		    float[] PointList = {
			    0 / 2,
			    1 / 2,
			    2 / 2
		    };
		    LinearGradientBrush AccentBrush = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Black, Color.White, 90);
		    ColorBlend AccentBlend = new ColorBlend {
			    Colors = ColorList,
			    Positions = PointList
		    };
		    AccentBrush.InterpolationColors = AccentBlend;
		    G.DrawRectangle(new Pen(AccentBrush), new Rectangle(0, 0, Width - 1, Height - 1));

		    StringFormat TextFormat = new StringFormat {
			    Alignment = StringAlignment.Near,
			    LineAlignment = StringAlignment.Center
		    };
		    G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(200, Color.Black)), new Rectangle(8, 1, Width - 1, 28), TextFormat);
		    G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(8, 2, Width - 1, 28), TextFormat);


		    e.Graphics.DrawImage(B, new Point(0, 0));
		    G.Dispose();
		    B.Dispose();
	    }

    }

    public class RedemptionControlBox : Control
    {

	    public RedemptionControlBox() : base()
	    {
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    SetStyle(ControlStyles.ResizeRedraw, true);
		    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    ForeColor = Color.White;
		    BackColor = Color.Transparent;
		    Anchor = AnchorStyles.Top | AnchorStyles.Right;
	    }
	    protected override void OnResize(EventArgs e)
	    {
		    base.OnResize(e);
		    Size = new Size(60, 25);
	    }
	    public enum ButtonHover
	    {
		    Minimize,
		    Maximize,
		    Close,
		    None
	    }
	    ButtonHover ButtonState = ButtonHover.None;
	    protected override void OnMouseMove(MouseEventArgs e)
	    {
		    base.OnMouseMove(e);
		    int X = e.Location.X;
		    int Y = e.Location.Y;
		    if (Y > 0 && Y < (Height - 2)) {
			    if (X > 0 && X < 30) {
				    ButtonState = ButtonHover.Minimize;
			    } else if (X > 31 && X < Width) {
				    ButtonState = ButtonHover.Close;
			    } else {
				    ButtonState = ButtonHover.None;
			    }
		    } else {
			    ButtonState = ButtonHover.None;
		    }
		    Invalidate();
	    }
	    protected override void OnPaint(PaintEventArgs e)
	    {
		    Bitmap B = new Bitmap(Width, Height);
		    Graphics G = Graphics.FromImage(B);
		    G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		    base.OnPaint(e);

		    G.Clear(BackColor);
		    Font ButtonFont = new Font("Marlett", 10f);
		    G.DrawString("r", ButtonFont, new SolidBrush(Color.FromArgb(200, 200, 200)), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });
		    G.DrawString("0", ButtonFont, new SolidBrush(Color.FromArgb(200, 200, 200)), new Point(20, 7), new StringFormat { Alignment = StringAlignment.Center });

		    switch (ButtonState) {
			    case ButtonHover.Minimize:
				    G.DrawString("0", ButtonFont, new SolidBrush(Color.White), new Point(20, 7), new StringFormat { Alignment = StringAlignment.Center });
				    break;
			    case ButtonHover.Close:
				    G.DrawString("r", ButtonFont, new SolidBrush(Color.White), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });
				    break;
		    }



		    e.Graphics.DrawImage(B, new Point(0, 0));
		    G.Dispose();
		    B.Dispose();
	    }
	    protected override void OnMouseUp(MouseEventArgs e)
	    {
		    base.OnMouseDown(e);
		    switch (ButtonState) {
			    case ButtonHover.Close:
				    Parent.FindForm().Close();
				    break;
			    case ButtonHover.Minimize:
				    Parent.FindForm().WindowState = FormWindowState.Minimized;
				    break;
			    case ButtonHover.Maximize:
				    Parent.FindForm().WindowState = FormWindowState.Maximized;
				    break;
		    }
		    Invalidate();
	    }
	    protected override void OnMouseLeave(EventArgs e)
	    {
		    base.OnMouseLeave(e);
		    ButtonState = ButtonHover.None;
		    Invalidate();
	    }
    }
}


