#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

#endregion
#region RoundRectangle

static class RoundRectangle
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
    public static GraphicsPath RoundedTopRect(Rectangle Rectangle, int Curve)
    {
        GraphicsPath P = new GraphicsPath();
        int ArcRectangleWidth = Curve * 2;
        P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
        P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
        P.AddLine(new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height - 1));
        P.AddLine(new Point(Rectangle.X, Rectangle.Height - 1 + Rectangle.Y), new Point(Rectangle.X, Rectangle.Y + Curve));
        return P;
    }
}

#endregion

//|------DO-NOT-REMOVE------|
//
// Creator: HazelDev
// Site   : HazelDev.co.nr
// Created: 20.Aug.2014
// Changed: 8.Sep.2014
// Version: 1.0.0
//
//|------DO-NOT-REMOVE------|

#region  ThemeContainer

public class Ambiance_ThemeContainer : ContainerControl
{

    #region  Enums

    public enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    #endregion
    #region  Variables

    private Rectangle HeaderRect;
    protected MouseState State;
    private int MoveHeight;
    private Point MouseP = new Point(0, 0);
    private bool Cap = false;
    private bool HasShown;

    #endregion
    #region  Properties

    private bool _Sizable = true;
    public bool Sizable
    {
        get
        {
            return _Sizable;
        }
        set
        {
            _Sizable = value;
        }
    }

    private bool _SmartBounds = true;
    public bool SmartBounds
    {
        get
        {
            return _SmartBounds;
        }
        set
        {
            _SmartBounds = value;
        }
    }

    private bool _RoundCorners = true;
    public bool RoundCorners
    {
        get
        {
            return _RoundCorners;
        }
        set
        {
            _RoundCorners = value;
            Invalidate();
        }
    }

    private bool _IsParentForm;
    protected bool IsParentForm
    {
        get
        {
            return _IsParentForm;
        }
    }

    protected bool IsParentMdi
    {
        get
        {
            if (Parent == null)
            {
                return false;
            }
            return Parent.Parent != null;
        }
    }

    private bool _ControlMode;
    protected bool ControlMode
    {
        get
        {
            return _ControlMode;
        }
        set
        {
            _ControlMode = value;
            Invalidate();
        }
    }

    private FormStartPosition _StartPosition = FormStartPosition.CenterScreen;
    public FormStartPosition StartPosition
    {
        get
        {
            if (_IsParentForm && !_ControlMode)
            {
                return ParentForm.StartPosition;
            }
            else
            {
                return _StartPosition;
            }
        }
        set
        {
            _StartPosition = value;

            if (_IsParentForm && !_ControlMode)
            {
                ParentForm.StartPosition = value;
            }
        }
    }

    #endregion
    #region  EventArgs

    protected sealed override void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);

        if (Parent == null)
        {
            return;
        }
        _IsParentForm = Parent is Form;

        if (!_ControlMode)
        {
            InitializeMessages();

            if (_IsParentForm)
            {
                this.ParentForm.FormBorderStyle = FormBorderStyle.None;
                this.ParentForm.TransparencyKey = Color.Fuchsia;

                if (!DesignMode)
                {
                    ParentForm.Shown += FormShown;
                }
            }
            Parent.BackColor = BackColor;
            Parent.MinimumSize = new Size(261, 65);
        }
    }

    protected sealed override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (!_ControlMode)
        {
            HeaderRect = new Rectangle(0, 0, Width - 14, MoveHeight - 7);
        }
        Invalidate();
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            SetState(MouseState.Down);
        }
        if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
        {
            if (HeaderRect.Contains(e.Location))
            {
                Capture = false;
                WM_LMBUTTONDOWN = true;
                DefWndProc(ref Messages[0]);
            }
            else if (_Sizable && !(Previous == 0))
            {
                Capture = false;
                WM_LMBUTTONDOWN = true;
                DefWndProc(ref Messages[Previous]);
            }
        }
    }

    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Cap = false;
    }

    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
        {
            if (_Sizable && !_ControlMode)
            {
                InvalidateMouse();
            }
        }
        if (Cap)
        {
            Parent.Location = (System.Drawing.Point)((object)(System.Convert.ToDouble(MousePosition) - System.Convert.ToDouble(MouseP)));
        }
    }

    protected override void OnInvalidated(System.Windows.Forms.InvalidateEventArgs e)
    {
        base.OnInvalidated(e);
        ParentForm.Text = Text;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    private void FormShown(object sender, EventArgs e)
    {
        if (_ControlMode || HasShown)
        {
            return;
        }

        if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
        {
            Rectangle SB = Screen.PrimaryScreen.Bounds;
            Rectangle CB = ParentForm.Bounds;
            ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
        }
        HasShown = true;
    }

    #endregion
    #region  Mouse & Size

    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    private Point GetIndexPoint;
    private bool B1x;
    private bool B2x;
    private bool B3;
    private bool B4;
    private int GetIndex()
    {
        GetIndexPoint = PointToClient(MousePosition);
        B1x = GetIndexPoint.X < 7;
        B2x = GetIndexPoint.X > Width - 7;
        B3 = GetIndexPoint.Y < 7;
        B4 = GetIndexPoint.Y > Height - 7;

        if (B1x && B3)
        {
            return 4;
        }
        if (B1x && B4)
        {
            return 7;
        }
        if (B2x && B3)
        {
            return 5;
        }
        if (B2x && B4)
        {
            return 8;
        }
        if (B1x)
        {
            return 1;
        }
        if (B2x)
        {
            return 2;
        }
        if (B3)
        {
            return 3;
        }
        if (B4)
        {
            return 6;
        }
        return 0;
    }

    private int Current;
    private int Previous;
    private void InvalidateMouse()
    {
        Current = GetIndex();
        if (Current == Previous)
        {
            return;
        }

        Previous = Current;
        switch (Previous)
        {
            case 0:
                Cursor = Cursors.Default;
                break;
            case 6:
                Cursor = Cursors.SizeNS;
                break;
            case 8:
                Cursor = Cursors.SizeNWSE;
                break;
            case 7:
                Cursor = Cursors.SizeNESW;
                break;
        }
    }

    private Message[] Messages = new Message[9];
    private void InitializeMessages()
    {
        Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
        for (int I = 1; I <= 8; I++)
        {
            Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
        }
    }

    private void CorrectBounds(Rectangle bounds)
    {
        if (Parent.Width > bounds.Width)
        {
            Parent.Width = bounds.Width;
        }
        if (Parent.Height > bounds.Height)
        {
            Parent.Height = bounds.Height;
        }

        int X = Parent.Location.X;
        int Y = Parent.Location.Y;

        if (X < bounds.X)
        {
            X = bounds.X;
        }
        if (Y < bounds.Y)
        {
            Y = bounds.Y;
        }

        int Width = bounds.X + bounds.Width;
        int Height = bounds.Y + bounds.Height;

        if (X + Parent.Width > Width)
        {
            X = Width - Parent.Width;
        }
        if (Y + Parent.Height > Height)
        {
            Y = Height - Parent.Height;
        }

        Parent.Location = new Point(X, Y);
    }

    private bool WM_LMBUTTONDOWN;
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (WM_LMBUTTONDOWN && m.Msg == 513)
        {
            WM_LMBUTTONDOWN = false;

            SetState(MouseState.Over);
            if (!_SmartBounds)
            {
                return;
            }

            if (IsParentMdi)
            {
                CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
            }
            else
            {
                CorrectBounds(Screen.FromControl(Parent).WorkingArea);
            }
        }
    }

    #endregion

    protected override void CreateHandle()
    {
        base.CreateHandle();
    }

    public Ambiance_ThemeContainer()
    {
        SetStyle((ControlStyles)(139270), true);
        BackColor = Color.FromArgb(244, 241, 243);
        Padding = new Padding(20, 56, 20, 16);
        DoubleBuffered = true;
        Dock = DockStyle.Fill;
        MoveHeight = 48;
        Font = new Font("Segoe UI", 9);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics G = e.Graphics;
        G.Clear(Color.FromArgb(69, 68, 63));

        G.DrawRectangle(new Pen(Color.FromArgb(38, 38, 38)), new Rectangle(0, 0, Width - 1, Height - 1));
        // Use [Color.FromArgb(87, 86, 81), Color.FromArgb(60, 59, 55)] for a darker taste
        // And replace each (60, 59, 55) with (69, 68, 63)
        G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, 36), Color.FromArgb(87, 85, 77), Color.FromArgb(69, 68, 63)), new Rectangle(1, 1, Width - 2, 36));
        G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(69, 68, 63), Color.FromArgb(69, 68, 63)), new Rectangle(1, 36, Width - 2, Height - 46));

        G.DrawRectangle(new Pen(Color.FromArgb(38, 38, 38)), new Rectangle(9, 47, Width - 19, Height - 55));
        G.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), new Rectangle(10, 48, Width - 20, Height - 56));

        if (_RoundCorners == true)
        {

            // Draw Left upper corner
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);

            G.FillRectangle(Brushes.Black, 1, 3, 1, 1);
            G.FillRectangle(Brushes.Black, 1, 2, 1, 1);
            G.FillRectangle(Brushes.Black, 2, 1, 1, 1);
            G.FillRectangle(Brushes.Black, 3, 1, 1, 1);

            // Draw right upper corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1);

            G.FillRectangle(Brushes.Black, Width - 2, 3, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 2, 2, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 3, 1, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 4, 1, 1, 1);

            // Draw Left bottom corner
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1);

            G.FillRectangle(Brushes.Black, 1, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Black, 1, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Black, 3, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Black, 2, Height - 2, 1, 1);

            // Draw right bottom corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1);

            G.FillRectangle(Brushes.Black, Width - 2, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 2, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 4, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 3, Height - 2, 1, 1);
        }

        G.DrawString(Text, new Font("Tahoma", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(223, 219, 210)), new Rectangle(0, 14, Width - 1, Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
    }
}

#endregion
#region  ControlBox

public class Ambiance_ControlBox : Control
{

    #region  Enums

    public enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    #endregion
    #region  MouseStates
    MouseState State = MouseState.None;
    int X;
    Rectangle CloseBtn = new Rectangle(3, 2, 17, 17);
    Rectangle MinBtn = new Rectangle(23, 2, 17, 17);
    Rectangle MaxBtn = new Rectangle(43, 2, 17, 17);

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);

        State = MouseState.Down;
        Invalidate();
    }
    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (X > 3 && X < 20)
        {
            FindForm().Close();
        }
        else if (X > 23 && X < 40)
        {
            FindForm().WindowState = FormWindowState.Minimized;
        }
        else if (X > 43 && X < 60)
        {
            if (_EnableMaximize == true)
            {
                if (FindForm().WindowState == FormWindowState.Maximized)
                {
                    FindForm().WindowState = FormWindowState.Minimized;
                    FindForm().WindowState = FormWindowState.Normal;
                }
                else
                {
                    FindForm().WindowState = FormWindowState.Minimized;
                    FindForm().WindowState = FormWindowState.Maximized;
                }
            }
        }
        State = MouseState.Over;
        Invalidate();
    }
    protected override void OnMouseEnter(System.EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Over;
        Invalidate();
    }
    protected override void OnMouseLeave(System.EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        Invalidate();
    }
    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        X = e.Location.X;
        Invalidate();
    }
    #endregion
    #region  Properties

    bool _EnableMaximize = true;
    public bool EnableMaximize
    {
        get
        {
            return _EnableMaximize;
        }
        set
        {
            _EnableMaximize = value;
            if (_EnableMaximize == true)
            {
                this.Size = new Size(64, 22);
            }
            else
            {
                this.Size = new Size(44, 22);
            }
            Invalidate();
        }
    }

    #endregion

    public Ambiance_ControlBox()
    {
        SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer), true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Marlett", 7);
        Anchor = (System.Windows.Forms.AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (_EnableMaximize == true)
        {
            this.Size = new Size(64, 22);
        }
        else
        {
            this.Size = new Size(44, 22);
        }
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        // Auto-decide control location on the theme container
        Location = new Point(5, 13);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);

        base.OnPaint(e);
        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        LinearGradientBrush LGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90);
        G.FillEllipse(LGBClose, CloseBtn);
        G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
        G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle((int)6.5, 8, 0, 0));

        LinearGradientBrush LGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
        G.FillEllipse(LGBMinimize, MinBtn);
        G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
        G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, (int)4.4, 0, 0));

        if (_EnableMaximize == true)
        {
            LinearGradientBrush LGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
            G.FillEllipse(LGBMaximize, MaxBtn);
            G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
            G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
        }

        switch (State)
        {
            case MouseState.None:
                LinearGradientBrush xLGBClose_1 = new LinearGradientBrush(CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90);
                G.FillEllipse(xLGBClose_1, CloseBtn);
                G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
                G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle((int)6.5, 8, 0, 0));

                LinearGradientBrush xLGBMinimize_1 = new LinearGradientBrush(MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
                G.FillEllipse(xLGBMinimize_1, MinBtn);
                G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
                G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, (int)4.4, 0, 0));

                if (_EnableMaximize == true)
                {
                    LinearGradientBrush xLGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
                    G.FillEllipse(xLGBMaximize, MaxBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                    G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
                }
                break;
            case MouseState.Over:
                if (X > 3 && X < 20)
                {
                    LinearGradientBrush xLGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(248, 152, 124), Color.FromArgb(231, 92, 45), 90);
                    G.FillEllipse(xLGBClose, CloseBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
                    G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle((int)6.5, 8, 0, 0));
                }
                else if (X > 23 && X < 40)
                {
                    LinearGradientBrush xLGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90);
                    G.FillEllipse(xLGBMinimize, MinBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
                    G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, (int)4.4, 0, 0));
                }
                else if (X > 43 && X < 60)
                {
                    if (_EnableMaximize == true)
                    {
                        LinearGradientBrush xLGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90);
                        G.FillEllipse(xLGBMaximize, MaxBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                        G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
                    }
                }
                break;
        }

        e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
        G.Dispose();
        B.Dispose();
    }
}

#endregion
#region Button 1

class Ambiance_Button_1 : Control
{

    #region Variables

    private int MouseState;
    private GraphicsPath Shape;
    private LinearGradientBrush InactiveGB;
    private LinearGradientBrush PressedGB;
    private LinearGradientBrush PressedContourGB;
    private Rectangle R1;
    private Pen P1;
    private Pen P3;
    private Image _Image;
    private Size _ImageSize;
    private StringAlignment _TextAlignment = StringAlignment.Center;
    private Color _TextColor = Color.FromArgb(150, 150, 150);
    private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

    #endregion
    #region Image Designer

    private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
    {
        PointF MyPoint = default(PointF);
        switch (SF.Alignment)
        {
            case StringAlignment.Center:
                MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                break;
            case StringAlignment.Near:
                MyPoint.X = 2;
                break;
            case StringAlignment.Far:
                MyPoint.X = Area.Width - ImageArea.Width - 2;

                break;
        }

        switch (SF.LineAlignment)
        {
            case StringAlignment.Center:
                MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                break;
            case StringAlignment.Near:
                MyPoint.Y = 2;
                break;
            case StringAlignment.Far:
                MyPoint.Y = Area.Height - ImageArea.Height - 2;
                break;
        }
        return MyPoint;
    }

    private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
    {
        StringFormat SF = new StringFormat();
        switch (_ContentAlignment)
        {
            case ContentAlignment.MiddleCenter:
                SF.LineAlignment = StringAlignment.Center;
                SF.Alignment = StringAlignment.Center;
                break;
            case ContentAlignment.MiddleLeft:
                SF.LineAlignment = StringAlignment.Center;
                SF.Alignment = StringAlignment.Near;
                break;
            case ContentAlignment.MiddleRight:
                SF.LineAlignment = StringAlignment.Center;
                SF.Alignment = StringAlignment.Far;
                break;
            case ContentAlignment.TopCenter:
                SF.LineAlignment = StringAlignment.Near;
                SF.Alignment = StringAlignment.Center;
                break;
            case ContentAlignment.TopLeft:
                SF.LineAlignment = StringAlignment.Near;
                SF.Alignment = StringAlignment.Near;
                break;
            case ContentAlignment.TopRight:
                SF.LineAlignment = StringAlignment.Near;
                SF.Alignment = StringAlignment.Far;
                break;
            case ContentAlignment.BottomCenter:
                SF.LineAlignment = StringAlignment.Far;
                SF.Alignment = StringAlignment.Center;
                break;
            case ContentAlignment.BottomLeft:
                SF.LineAlignment = StringAlignment.Far;
                SF.Alignment = StringAlignment.Near;
                break;
            case ContentAlignment.BottomRight:
                SF.LineAlignment = StringAlignment.Far;
                SF.Alignment = StringAlignment.Far;
                break;
        }
        return SF;
    }

    #endregion
    #region Properties

    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
            {
                _ImageSize = Size.Empty;
            }
            else
            {
                _ImageSize = value.Size;
            }

            _Image = value;
            Invalidate();
        }
    }

    protected Size ImageSize
    {
        get { return _ImageSize; }
    }

    public ContentAlignment ImageAlign
    {
        get { return _ImageAlign; }
        set
        {
            _ImageAlign = value;
            Invalidate();
        }
    }

    public StringAlignment TextAlignment
    {
        get { return this._TextAlignment; }
        set
        {
            this._TextAlignment = value;
            this.Invalidate();
        }
    }

    public override Color ForeColor
    {
        get { return this._TextColor; }
        set
        {
            this._TextColor = value;
            this.Invalidate();
        }
    }

    #endregion
    #region EventArgs

    protected override void OnMouseUp(MouseEventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseUp(e);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        MouseState = 1;
        Focus();
        Invalidate();
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    #endregion

    public Ambiance_Button_1()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 12);
        ForeColor = Color.FromArgb(76, 76, 76);
        Size = new Size(177, 30);
        _TextAlignment = StringAlignment.Center;
        P1 = new Pen(Color.FromArgb(180, 180, 180));
        // P1 = Border color
    }

    protected override void OnResize(System.EventArgs e)
    {

        if (Width > 0 && Height > 0)
        {
            Shape = new GraphicsPath();
            R1 = new Rectangle(0, 0, Width, Height);

            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(253, 252, 252), Color.FromArgb(239, 237, 236), 90f);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(226, 226, 226), Color.FromArgb(237, 237, 237), 90f);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90f);

            P3 = new Pen(PressedContourGB);
        }

        var MyDrawer = Shape;
        MyDrawer.AddArc(0, 0, 10, 10, 180, 90);
        MyDrawer.AddArc(Width - 11, 0, 10, 10, -90, 90);
        MyDrawer.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        MyDrawer.AddArc(0, Height - 11, 10, 10, 90, 90);
        MyDrawer.CloseAllFigures();
        Invalidate();
        base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;
        PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

        switch (MouseState)
        {
            case 0:
                //Inactive
                G.FillPath(InactiveGB, Shape);
                // Fill button body with InactiveGB color gradient
                G.DrawPath(P1, Shape);
                // Draw button border [InactiveGB]
                if ((Image == null))
                {
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                else
                {
                    G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                break;
            case 1:
                //Pressed
                G.FillPath(PressedGB, Shape);
                // Fill button body with PressedGB color gradient
                G.DrawPath(P3, Shape);
                // Draw button border [PressedGB]

                if ((Image == null))
                {
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                else
                {
                    G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                break;
        }
        base.OnPaint(e);
    }
}

#endregion
#region Button 2

class Ambiance_Button_2 : Control
{

    #region Variables

    private int MouseState;
    private GraphicsPath Shape;
    private LinearGradientBrush InactiveGB;
    private LinearGradientBrush PressedGB;
    private LinearGradientBrush PressedContourGB;
    private Rectangle R1;
    private Pen P1;
    private Pen P3;
    private Image _Image;
    private Size _ImageSize;
    private StringAlignment _TextAlignment = StringAlignment.Center;
    private Color _TextColor = Color.FromArgb(150, 150, 150);
    private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

    #endregion
    #region Image Designer

    private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
    {
        PointF MyPoint = default(PointF);
        switch (SF.Alignment)
        {
            case StringAlignment.Center:
                MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                break;
            case StringAlignment.Near:
                MyPoint.X = 2;
                break;
            case StringAlignment.Far:
                MyPoint.X = Area.Width - ImageArea.Width - 2;

                break;
        }

        switch (SF.LineAlignment)
        {
            case StringAlignment.Center:
                MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                break;
            case StringAlignment.Near:
                MyPoint.Y = 2;
                break;
            case StringAlignment.Far:
                MyPoint.Y = Area.Height - ImageArea.Height - 2;
                break;
        }
        return MyPoint;
    }

    private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
    {
        StringFormat SF = new StringFormat();
        switch (_ContentAlignment)
        {
            case ContentAlignment.MiddleCenter:
                SF.LineAlignment = StringAlignment.Center;
                SF.Alignment = StringAlignment.Center;
                break;
            case ContentAlignment.MiddleLeft:
                SF.LineAlignment = StringAlignment.Center;
                SF.Alignment = StringAlignment.Near;
                break;
            case ContentAlignment.MiddleRight:
                SF.LineAlignment = StringAlignment.Center;
                SF.Alignment = StringAlignment.Far;
                break;
            case ContentAlignment.TopCenter:
                SF.LineAlignment = StringAlignment.Near;
                SF.Alignment = StringAlignment.Center;
                break;
            case ContentAlignment.TopLeft:
                SF.LineAlignment = StringAlignment.Near;
                SF.Alignment = StringAlignment.Near;
                break;
            case ContentAlignment.TopRight:
                SF.LineAlignment = StringAlignment.Near;
                SF.Alignment = StringAlignment.Far;
                break;
            case ContentAlignment.BottomCenter:
                SF.LineAlignment = StringAlignment.Far;
                SF.Alignment = StringAlignment.Center;
                break;
            case ContentAlignment.BottomLeft:
                SF.LineAlignment = StringAlignment.Far;
                SF.Alignment = StringAlignment.Near;
                break;
            case ContentAlignment.BottomRight:
                SF.LineAlignment = StringAlignment.Far;
                SF.Alignment = StringAlignment.Far;
                break;
        }
        return SF;
    }

    #endregion
    #region Properties

    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
            {
                _ImageSize = Size.Empty;
            }
            else
            {
                _ImageSize = value.Size;
            }

            _Image = value;
            Invalidate();
        }
    }

    protected Size ImageSize
    {
        get { return _ImageSize; }
    }

    public ContentAlignment ImageAlign
    {
        get { return _ImageAlign; }
        set
        {
            _ImageAlign = value;
            Invalidate();
        }
    }

    public StringAlignment TextAlignment
    {
        get { return this._TextAlignment; }
        set
        {
            this._TextAlignment = value;
            this.Invalidate();
        }
    }

    public override Color ForeColor
    {
        get { return this._TextColor; }
        set
        {
            this._TextColor = value;
            this.Invalidate();
        }
    }

    #endregion
    #region EventArgs

    protected override void OnMouseUp(MouseEventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseUp(e);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        MouseState = 1;
        Focus();
        Invalidate();
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        MouseState = 0;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    #endregion

    public Ambiance_Button_2()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 11f, FontStyle.Bold);
        ForeColor = Color.FromArgb(76, 76, 76);
        Size = new Size(177, 30);
        _TextAlignment = StringAlignment.Center;
        P1 = new Pen(Color.FromArgb(162, 120, 101));
        // P1 = Border color
    }

    protected override void OnResize(System.EventArgs e)
    {

        if (Width > 0 && Height > 0)
        {
            Shape = new GraphicsPath();
            R1 = new Rectangle(0, 0, Width, Height);

            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(253, 175, 143), Color.FromArgb(244, 146, 106), 90f);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(244, 146, 106), Color.FromArgb(244, 146, 106), 90f);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(162, 120, 101), Color.FromArgb(162, 120, 101), 90f);

            P3 = new Pen(PressedContourGB);
        }

        var MyDrawer = Shape;
        MyDrawer.AddArc(0, 0, 10, 10, 180, 90);
        MyDrawer.AddArc(Width - 11, 0, 10, 10, -90, 90);
        MyDrawer.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        MyDrawer.AddArc(0, Height - 11, 10, 10, 90, 90);
        MyDrawer.CloseAllFigures();
        Invalidate();
        base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;
        PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

        switch (MouseState)
        {
            case 0:
                //Inactive
                G.FillPath(InactiveGB, Shape);
                // Fill button body with InactiveGB color gradient
                G.DrawPath(P1, Shape);
                // Draw button border [InactiveGB]
                if ((Image == null))
                {
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                else
                {
                    G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                break;
            case 1:
                //Pressed
                G.FillPath(PressedGB, Shape);
                // Fill button body with PressedGB color gradient
                G.DrawPath(P3, Shape);
                // Draw button border [PressedGB]

                if ((Image == null))
                {
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                else
                {
                    G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
                }
                break;
        }
        base.OnPaint(e);
    }
}

#endregion
#region Label

class Ambiance_Label : Label
{

    public Ambiance_Label()
    {
        Font = new Font("Segoe UI", 11);
        ForeColor = Color.FromArgb(76, 76, 77);
        BackColor = Color.Transparent;
    }
}

#endregion
#region Link Label
class Ambiance_LinkLabel : LinkLabel
{

    public Ambiance_LinkLabel()
    {
        Font = new Font("Segoe UI", 11, FontStyle.Regular);
        BackColor = Color.Transparent;
        LinkColor = Color.FromArgb(240, 119, 70);
        ActiveLinkColor = Color.FromArgb(221, 72, 20);
        VisitedLinkColor = Color.FromArgb(240, 119, 70);
        LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
    }
}

#endregion
#region Header Label

class Ambiance_HeaderLabel : Label
{

    public Ambiance_HeaderLabel()
    {
        Font = new Font("Segoe UI", 11, FontStyle.Bold);
        ForeColor = Color.FromArgb(76, 76, 77);
        BackColor = Color.Transparent;
    }
}

#endregion
#region Separator

public class Ambiance_Separator : Control
{

    public Ambiance_Separator()
    {
        SetStyle(ControlStyles.ResizeRedraw, true);
        this.Size = new Size(120, 10);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), 0, 5, Width, 5);
        e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), 0, 6, Width, 6);
    }
}

#endregion
#region ProgressBar

public class Ambiance_ProgressBar : Control
{

    #region Enums 

    public enum Alignment
    {
        Right,
        Center
    }

    #endregion
    #region Variables 

    private int _Minimum;
    private int _Maximum = 100;
    private int _Value = 0;
    private Alignment ALN;
    private bool _DrawHatch;

    private bool _ShowPercentage;
    private GraphicsPath GP1;
    private GraphicsPath GP2;
    private GraphicsPath GP3;
    private Rectangle R1;
    private Rectangle R2;
    private LinearGradientBrush GB1;
    private LinearGradientBrush GB2;
    private int I1;

    #endregion
    #region Properties 

    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < 1)
                value = 1;
            if (value < _Value)
                _Value = value;
            _Maximum = value;
            Invalidate();
        }
    }

    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            _Minimum = value;

            if (value > _Maximum)
                _Maximum = value;
            if (value > _Value)
                _Value = value;

            Invalidate();
        }
    }

    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > _Maximum)
                value = Maximum;
            _Value = value;
            Invalidate();
        }
    }

    public Alignment ValueAlignment
    {
        get { return ALN; }
        set
        {
            ALN = value;
            Invalidate();
        }
    }

    public bool DrawHatch
    {
        get { return _DrawHatch; }
        set
        {
            _DrawHatch = value;
            Invalidate();
        }
    }

    public bool ShowPercentage
    {
        get { return _ShowPercentage; }
        set
        {
            _ShowPercentage = value;
            Invalidate();
        }
    }

    #endregion
    #region EventArgs

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Height = 20;
        Size minimumSize = new Size(58, 20);
        this.MinimumSize = minimumSize;
    }

    #endregion

    public Ambiance_ProgressBar()
    {
        _Maximum = 100;
        _ShowPercentage = true;
        _DrawHatch = true;
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);
        BackColor = Color.Transparent;
        DoubleBuffered = true;
    }

    public void Increment(int value)
    {
        this._Value += value;
        Invalidate();
    }

    public void Deincrement(int value)
    {
        this._Value -= value;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);

        G.Clear(Color.Transparent);
        G.SmoothingMode = SmoothingMode.HighQuality;

        GP1 = RoundRectangle.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 4);
        GP2 = RoundRectangle.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4);

        R1 = new Rectangle(0, 2, Width - 1, Height - 1);
        GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);

        // Draw inside background
        G.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), R1);
        G.SetClip(GP1);
        G.FillPath(new SolidBrush(Color.FromArgb(244, 241, 243)), RoundRectangle.RoundRect(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));


        I1 = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 3));
        if (I1 > 1)
        {
            GP3 = RoundRectangle.RoundRect(new Rectangle(1, 1, I1, Height - 3), 4);

            R2 = new Rectangle(1, 1, I1, Height - 3);
            GB2 = new LinearGradientBrush(R2, Color.FromArgb(214, 89, 37), Color.FromArgb(223, 118, 75), 90f);

            // Fill the value with its gradient
            G.FillPath(GB2, GP3);

            // Draw diagonal lines
            if (_DrawHatch == true)
            {
                for (var i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
                {
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(25, Color.White)), 10.0F), new Point(System.Convert.ToInt32(i), 0), new Point((int)(i - 10), Height));
                }
            }

            G.SetClip(GP3);
            G.SmoothingMode = SmoothingMode.None;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.ResetClip();
        }

        // Draw value as a string
        string DrawString = Convert.ToString(Convert.ToInt32(Value)) + "%";
        int textX = (int)(this.Width - G.MeasureString(DrawString, Font).Width - 1);
        int textY = (int)((this.Height / 2) - (System.Convert.ToInt32(G.MeasureString(DrawString, Font).Height / 2) - 2));

        if (_ShowPercentage == true)
        {
            switch (ValueAlignment)
            {
                case Alignment.Right:
                    G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.DimGray, new Point(textX, textY));
                    break;
                case Alignment.Center:
                    G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.DimGray, new Rectangle(0, 0, Width, Height + 2), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
        }

        // Draw border
        G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), GP2);

        e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
        G.Dispose();
        B.Dispose();
    }
}

#endregion
#region Progress Indicator

class Ambiance_ProgressIndicator : Control
{

    #region Variables

    private readonly SolidBrush BaseColor = new SolidBrush(Color.FromArgb(76, 76, 76));
    private readonly SolidBrush AnimationColor = new SolidBrush(Color.Gray);

    private readonly Timer AnimationSpeed = new Timer();
    private PointF[] FloatPoint;
    private BufferedGraphics BuffGraphics;
    private int IndicatorIndex;
    private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

    #endregion
    #region Custom Properties

    public Color P_BaseColor
    {
        get { return BaseColor.Color; }
        set { BaseColor.Color = value; }
    }

    public Color P_AnimationColor
    {
        get { return AnimationColor.Color; }
        set { AnimationColor.Color = value; }
    }

    public int P_AnimationSpeed
    {
        get { return AnimationSpeed.Interval; }
        set { AnimationSpeed.Interval = value; }
    }

    #endregion
    #region EventArgs

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        SetStandardSize();
        UpdateGraphics();
        SetPoints();
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        base.OnEnabledChanged(e);
        AnimationSpeed.Enabled = this.Enabled;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        AnimationSpeed.Tick += AnimationSpeed_Tick;
        AnimationSpeed.Start();
    }

    private void AnimationSpeed_Tick(object sender, EventArgs e)
    {
        if (IndicatorIndex.Equals(0))
        {
            IndicatorIndex = FloatPoint.Length - 1;
        }
        else
        {
            IndicatorIndex -= 1;
        }
        this.Invalidate(false);
    }

    #endregion

    public Ambiance_ProgressIndicator()
    {
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

        Size = new Size(80, 80);
        Text = string.Empty;
        MinimumSize = new Size(80, 80);
        SetPoints();
        AnimationSpeed.Interval = 100;
    }

    private void SetStandardSize()
    {
        int _Size = Math.Max(Width, Height);
        Size = new Size(_Size, _Size);
    }

    private void SetPoints()
    {
        Stack<PointF> stack = new Stack<PointF>();
        PointF startingFloatPoint = new PointF(((float)this.Width) / 2f, ((float)this.Height) / 2f);
        for (float i = 0f; i < 360f; i += 45f)
        {
            this.SetValue(startingFloatPoint, (int)Math.Round((double)((((double)this.Width) / 2.0) - 15.0)), (double)i);
            PointF endPoint = this.EndPoint;
            endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
            stack.Push(endPoint);
        }
        this.FloatPoint = stack.ToArray();
    }

    private void UpdateGraphics()
    {
        if ((this.Width > 0) && (this.Height > 0))
        {
            Size size2 = new Size(this.Width + 1, this.Height + 1);
            this.GraphicsContext.MaximumBuffer = size2;
            this.BuffGraphics = this.GraphicsContext.Allocate(this.CreateGraphics(), this.ClientRectangle);
            this.BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        this.BuffGraphics.Graphics.Clear(this.BackColor);
        int num2 = this.FloatPoint.Length - 1;
        for (int i = 0; i <= num2; i++)
        {
            if (this.IndicatorIndex == i)
            {
                this.BuffGraphics.Graphics.FillEllipse(this.AnimationColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
            }
            else
            {
                this.BuffGraphics.Graphics.FillEllipse(this.BaseColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
            }
        }
        this.BuffGraphics.Render(e.Graphics);
    }


    private double Rise;
    private double Run;
    private PointF _StartingFloatPoint;

    private X AssignValues<X>(ref X Run, X Length)
    {
        Run = Length;
        return Length;
    }

    private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
    {
        double CircleRadian = Math.PI * Angle / 180.0;

        _StartingFloatPoint = StartingFloatPoint;
        Rise = AssignValues(ref Run, Length);
        Rise = Math.Sin(CircleRadian) * Rise;
        Run = Math.Cos(CircleRadian) * Run;
    }

    private PointF EndPoint
    {
        get
        {
            float LocationX = Convert.ToSingle(_StartingFloatPoint.Y + Rise);
            float LocationY = Convert.ToSingle(_StartingFloatPoint.X + Run);

            return new PointF(LocationY, LocationX);
        }
    }
}

#endregion
#region  Toggle Button

[DefaultEvent("ToggledChanged")]
public class Ambiance_Toggle : Control
{

    #region  Enums

    public enum _Type
    {
        OnOff,
        YesNo,
        IO
    }

    #endregion
    #region  Variables

    public delegate void ToggledChangedEventHandler();
    private ToggledChangedEventHandler ToggledChangedEvent;

    public event ToggledChangedEventHandler ToggledChanged
    {
        add
        {
            ToggledChangedEvent = (ToggledChangedEventHandler)System.Delegate.Combine(ToggledChangedEvent, value);
        }
        remove
        {
            ToggledChangedEvent = (ToggledChangedEventHandler)System.Delegate.Remove(ToggledChangedEvent, value);
        }
    }

    private bool _Toggled;
    private _Type ToggleType;
    private Rectangle Bar;
    private Size cHandle = new Size(15, 20);

    #endregion
    #region  Properties

    public bool Toggled
    {
        get
        {
            return _Toggled;
        }
        set
        {
            _Toggled = value;
            Invalidate();
            if (ToggledChangedEvent != null)
                ToggledChangedEvent();
        }
    }

    public _Type Type
    {
        get
        {
            return ToggleType;
        }
        set
        {
            ToggleType = value;
            Invalidate();
        }
    }

    #endregion
    #region  EventArgs

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Width = 79;
        Height = 27;
    }

    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Toggled = !Toggled;
        Focus();
    }

    #endregion

    public Ambiance_Toggle()
    {
        SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint), true);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics G = e.Graphics;

        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Parent.BackColor);

        int SwitchXLoc = 3;
        Rectangle ControlRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
        GraphicsPath ControlPath = RoundRectangle.RoundRect(ControlRectangle, 4);

        LinearGradientBrush BackgroundLGB = default(LinearGradientBrush);
        if (_Toggled)
        {
            SwitchXLoc = 37;
            BackgroundLGB = new LinearGradientBrush(ControlRectangle, Color.FromArgb(231, 108, 58), Color.FromArgb(236, 113, 63), 90.0F);
        }
        else
        {
            SwitchXLoc = 0;
            BackgroundLGB = new LinearGradientBrush(ControlRectangle, Color.FromArgb(208, 208, 208), Color.FromArgb(226, 226, 226), 90.0F);
        }

        // Fill inside background gradient
        G.FillPath(BackgroundLGB, ControlPath);

        // Draw string
        switch (ToggleType)
        {
            case _Type.OnOff:
                if (Toggled)
                {
                    G.DrawString("ON", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    G.DrawString("OFF", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                break;
            case _Type.YesNo:
                if (Toggled)
                {
                    G.DrawString("YES", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    G.DrawString("NO", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                break;
            case _Type.IO:
                if (Toggled)
                {
                    G.DrawString("I", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else
                {
                    G.DrawString("O", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                break;
        }

        Rectangle SwitchRectangle = new Rectangle(SwitchXLoc, 0, Width - 38, Height);
        GraphicsPath SwitchPath = RoundRectangle.RoundRect(SwitchRectangle, 4);
        LinearGradientBrush SwitchButtonLGB = new LinearGradientBrush(SwitchRectangle, Color.FromArgb(253, 253, 253), Color.FromArgb(240, 238, 237), LinearGradientMode.Vertical);

        // Fill switch background gradient
        G.FillPath(SwitchButtonLGB, SwitchPath);

        // Draw borders
        if (_Toggled == true)
        {
            G.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), SwitchPath);
            G.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), ControlPath);
        }
        else
        {
            G.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), SwitchPath);
            G.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), ControlPath);
        }
    }
}

#endregion
#region CheckBox

[DefaultEvent("CheckedChanged")]
class Ambiance_CheckBox : Control
{

    #region Variables

    private GraphicsPath Shape;
    private LinearGradientBrush GB;
    private Rectangle R1;
    private Rectangle R2;
    private bool _Checked;
    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    #endregion
    #region Properties

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

    #endregion

    public Ambiance_CheckBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        DoubleBuffered = true;
        // Reduce control flicker
        Font = new Font("Segoe UI", 12);
        Size = new Size(171, 26);
    }

    protected override void OnClick(EventArgs e)
    {
        _Checked = !_Checked;
        if (CheckedChanged != null)
        {
            CheckedChanged(this);
        }
        Focus();
        Invalidate();
        base.OnClick(e);
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnResize(System.EventArgs e)
    {
        if (Width > 0 && Height > 0)
        {
            Shape = new GraphicsPath();

            R1 = new Rectangle(17, 0, Width, Height + 1);
            R2 = new Rectangle(0, 0, Width, Height);
            GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(213, 85, 32), Color.FromArgb(224, 123, 82), 90);

            var MyDrawer = Shape;
            MyDrawer.AddArc(0, 0, 7, 7, 180, 90);
            MyDrawer.AddArc(7, 0, 7, 7, -90, 90);
            MyDrawer.AddArc(7, 7, 7, 7, 0, 90);
            MyDrawer.AddArc(0, 7, 7, 7, 90, 90);
            MyDrawer.CloseAllFigures();
            Height = 19;
        }

        Invalidate();
        base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var MyDrawer = e.Graphics;
        MyDrawer.Clear(Parent.BackColor);
        MyDrawer.SmoothingMode = SmoothingMode.AntiAlias;

        MyDrawer.FillPath(GB, Shape);
        // Fill the body of the CheckBox
        MyDrawer.DrawPath(new Pen(Color.FromArgb(182, 88, 55)), Shape);
        // Draw the border

        MyDrawer.DrawString(Text, Font, new SolidBrush(Color.FromArgb(76, 76, 95)), new Rectangle(17, -1, Width, Height - 1), new StringFormat { LineAlignment = StringAlignment.Center });

        if (Checked)
        {
            MyDrawer.DrawString("ü", new Font("Wingdings", 12), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-2, 1, Width, Height + 2), new StringFormat { LineAlignment = StringAlignment.Center });
        }
        e.Dispose();
    }
}

#endregion
#region RadioButton

[DefaultEvent("CheckedChanged")]
class Ambiance_RadioButton : Control
{

    #region Enums

    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    #endregion
    #region Variables

    private bool _Checked;
    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    #endregion
    #region Properties

    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            InvalidateControls();
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            Invalidate();
        }
    }

    #endregion
    #region EventArgs

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Height = 15;
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        if (!_Checked)
            Checked = true;
        base.OnMouseDown(e);
        Focus();
    }

    #endregion

    public Ambiance_RadioButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 12);
        Width = 193;
    }

    private void InvalidateControls()
    {
        if (!IsHandleCreated || !_Checked)
            return;

        foreach (Control _Control in Parent.Controls)
        {
            if (!object.ReferenceEquals(_Control, this) && _Control is Ambiance_RadioButton)
            {
                ((Ambiance_RadioButton)_Control).Checked = false;
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var MyDrawer = e.Graphics;

        MyDrawer.Clear(Parent.BackColor);
        MyDrawer.SmoothingMode = SmoothingMode.AntiAlias;

        // Fill the body of the ellipse with a gradient
        LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), Color.FromArgb(213, 85, 32), Color.FromArgb(224, 123, 82), 90);
        MyDrawer.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));

        GraphicsPath GP = new GraphicsPath();
        GP.AddEllipse(new Rectangle(0, 0, 14, 14));
        MyDrawer.SetClip(GP);
        MyDrawer.ResetClip();

        // Draw ellipse border
        MyDrawer.DrawEllipse(new Pen(Color.FromArgb(182, 88, 55)), new Rectangle(new Point(0, 0), new Size(14, 14)));

        // Draw an ellipse inside the body
        if (_Checked)
        {
            SolidBrush EllipseColor = new SolidBrush(Color.FromArgb(255, 255, 255));
            MyDrawer.FillEllipse(EllipseColor, new Rectangle(new Point(4, 4), new Size(6, 6)));
        }
        MyDrawer.DrawString(Text, Font, new SolidBrush(Color.FromArgb(76, 76, 95)), 16, 7, new StringFormat { LineAlignment = StringAlignment.Center });
        e.Dispose();
    }
}

#endregion
#region  ComboBox

public class Ambiance_ComboBox : ComboBox
{

    #region  Variables

    private int _StartIndex = 0;
    private Color _HoverSelectionColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.

    #endregion
    #region  Custom Properties

    public int StartIndex
    {
        get
        {
            return _StartIndex;
        }
        set
        {
            _StartIndex = value;
            try
            {
                base.SelectedIndex = value;
            }
            catch
            {
            }
            Invalidate();
        }
    }

    public Color HoverSelectionColor
    {
        get
        {
            return _HoverSelectionColor;
        }
        set
        {
            _HoverSelectionColor = value;
            Invalidate();
        }
    }

    #endregion
    #region  EventArgs

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        base.OnDrawItem(e);
        LinearGradientBrush LGB = new LinearGradientBrush(e.Bounds, Color.FromArgb(246, 132, 85), Color.FromArgb(231, 108, 57), 90.0F);

        if (System.Convert.ToInt32((e.State & DrawItemState.Selected)) == (int)DrawItemState.Selected)
        {
            if (!(e.Index == -1))
            {
                e.Graphics.FillRectangle(LGB, e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.WhiteSmoke, e.Bounds);
            }
        }
        else
        {
            if (!(e.Index == -1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(242, 241, 240)), e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.DimGray, e.Bounds);
            }
        }
        LGB.Dispose();
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        SuspendLayout();
        Update();
        ResumeLayout();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
    }

    #endregion

    public Ambiance_ComboBox()
    {
        SetStyle((ControlStyles)(139286), true);
        SetStyle(ControlStyles.Selectable, false);

        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;

        BackColor = Color.FromArgb(246, 246, 246);
        ForeColor = Color.FromArgb(142, 142, 142);
        Size = new Size(135, 26);
        ItemHeight = 20;
        DropDownHeight = 100;
        Font = new Font("Segoe UI", 10, FontStyle.Regular);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        LinearGradientBrush LGB = default(LinearGradientBrush);
        GraphicsPath GP = default(GraphicsPath);

        e.Graphics.Clear(Parent.BackColor);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Create a curvy border
        GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, 5);
        // Fills the body of the rectangle with a gradient
        LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(253, 252, 252), Color.FromArgb(239, 237, 236), 90.0F);

        e.Graphics.SetClip(GP);
        e.Graphics.FillRectangle(LGB, ClientRectangle);
        e.Graphics.ResetClip();

        // Draw rectangle border
        e.Graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), GP);
        // Draw string
        e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(76, 76, 97)), new Rectangle(3, 0, Width - 20, Height), new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Near
        });
        e.Graphics.DrawString("6", new Font("Marlett", 13, FontStyle.Regular), new SolidBrush(Color.FromArgb(119, 119, 118)), new Rectangle(3, 0, Width - 4, Height), new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Far
        });
        e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), Width - 24, 4, Width - 24, this.Height - 5);
        e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), Width - 25, 4, Width - 25, this.Height - 5);

        GP.Dispose();
        LGB.Dispose();
    }
}

#endregion
#region  NumericUpDown

public class Ambiance_NumericUpDown : Control
{

    #region  Enums

    public enum _TextAlignment
    {
        Near,
        Center
    }

    #endregion
    #region  Variables

    private GraphicsPath Shape;
    private Pen P1;

    private long _Value;
    private long _Minimum;
    private long _Maximum;
    private int Xval;
    private bool KeyboardNum;
    private _TextAlignment MyStringAlignment;

    private Timer LongPressTimer = new Timer();

    #endregion
    #region  Properties

    public long Value
    {
        get
        {
            return _Value;
        }
        set
        {
            if (value <= _Maximum & value >= _Minimum)
            {
                _Value = value;
            }
            Invalidate();
        }
    }

    public long Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {
            if (value < _Maximum)
            {
                _Minimum = value;
            }
            if (_Value < _Minimum)
            {
                _Value = Minimum;
            }
            Invalidate();
        }
    }

    public long Maximum
    {
        get
        {
            return _Maximum;
        }
        set
        {
            if (value > _Minimum)
            {
                _Maximum = value;
            }
            if (_Value > _Maximum)
            {
                _Value = _Maximum;
            }
            Invalidate();
        }
    }

    public _TextAlignment TextAlignment
    {
        get
        {
            return MyStringAlignment;
        }
        set
        {
            MyStringAlignment = value;
            Invalidate();
        }
    }

    #endregion
    #region  EventArgs

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        Height = 28;
        MinimumSize = new Size(93, 28);
        Shape = new GraphicsPath();
        Shape.AddArc(0, 0, 10, 10, 180, 90);
        Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
        Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
        Shape.CloseAllFigures();
    }

    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        Xval = e.Location.X;
        Invalidate();

        if (e.X < Width - 50)
        {
            Cursor = Cursors.IBeam;
        }
        else
        {
            Cursor = Cursors.Default;
        }
        if (e.X > this.Width - 25 && e.X < this.Width - 10)
        {
            Cursor = Cursors.Hand;
        }
        if (e.X > this.Width - 44 && e.X < this.Width - 33)
        {
            Cursor = Cursors.Hand;
        }
    }

    private void ClickButton()
    {
        if (Xval > this.Width - 25 && Xval < this.Width - 10)
        {
            if ((Value + 1) <= _Maximum)
            {
                _Value++;
            }
        }
        else
        {
            if (Xval > this.Width - 44 && Xval < this.Width - 33)
            {
                if ((Value - 1) >= _Minimum)
                {
                    _Value--;
                }
            }
            KeyboardNum = !KeyboardNum;
        }
        Focus();
        Invalidate();
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseClick(e);
        ClickButton();
        LongPressTimer.Start();
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        LongPressTimer.Stop();
    }
    private void LongPressTimer_Tick(object sender, EventArgs e)
    {
        ClickButton();
    }
    protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        try
        {
            if (KeyboardNum == true)
            {
                _Value = long.Parse((_Value).ToString() + e.KeyChar.ToString().ToString());
            }
            if (_Value > _Maximum)
            {
                _Value = _Maximum;
            }
        }
        catch (Exception)
        {
        }
    }

    protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.KeyCode == Keys.Back)
        {
            string TemporaryValue = _Value.ToString();
            TemporaryValue = TemporaryValue.Remove(Convert.ToInt32(TemporaryValue.Length - 1));
            if (TemporaryValue.Length == 0)
            {
                TemporaryValue = "0";
            }
            _Value = Convert.ToInt32(TemporaryValue);
        }
        Invalidate();
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);
        if (e.Delta > 0)
        {
            if ((Value + 1) <= _Maximum)
            {
                _Value++;
            }
            Invalidate();
        }
        else
        {
            if ((Value - 1) >= _Minimum)
            {
                _Value--;
            }
            Invalidate();
        }
    }

    #endregion

    public Ambiance_NumericUpDown()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);

        P1 = new Pen(Color.FromArgb(180, 180, 180));
        BackColor = Color.Transparent;
        ForeColor = Color.FromArgb(76, 76, 76);
        _Minimum = 0;
        _Maximum = 100;
        Font = new Font("Tahoma", 11);
        Size = new Size(70, 28);
        MinimumSize = new Size(62, 28);
        DoubleBuffered = true;

        LongPressTimer.Tick += LongPressTimer_Tick;
        LongPressTimer.Interval = 300;
    }

    public void Increment(int Value)
    {
        this._Value += Value;
        Invalidate();
    }

    public void Decrement(int Value)
    {
        this._Value -= Value;
        Invalidate();
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);
        LinearGradientBrush BackgroundLGB = default(LinearGradientBrush);

        BackgroundLGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(246, 246, 246), Color.FromArgb(254, 254, 254), 90.0F);

        G.SmoothingMode = SmoothingMode.AntiAlias;

        G.Clear(Color.Transparent); // Set control background color
        G.FillPath(BackgroundLGB, Shape); // Draw background
        G.DrawPath(P1, Shape); // Draw border

        G.DrawString("+", new Font("Tahoma", 14), new SolidBrush(Color.FromArgb(75, 75, 75)), new Rectangle(Width - 25, 1, 19, 30));
        G.DrawLine(new Pen(Color.FromArgb(229, 228, 227)), Width - 28, 1, Width - 28, this.Height - 2);
        G.DrawString("-", new Font("Tahoma", 14), new SolidBrush(Color.FromArgb(75, 75, 75)), new Rectangle(Width - 44, 1, 19, 30));
        G.DrawLine(new Pen(Color.FromArgb(229, 228, 227)), Width - 48, 1, Width - 48, this.Height - 2);

        switch (MyStringAlignment)
        {
            case _TextAlignment.Near:
                G.DrawString(System.Convert.ToString(Value), Font, new SolidBrush(ForeColor), new Rectangle(5, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                break;
            case _TextAlignment.Center:
                G.DrawString(System.Convert.ToString(Value), Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                break;
        }
        e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
        G.Dispose();
        B.Dispose();
    }
}

#endregion
#region  TrackBar

[DefaultEvent("ValueChanged")]
public class Ambiance_TrackBar : Control
{

    #region  Enums

    public enum ValueDivisor
    {
        By1 = 1,
        By10 = 10,
        By100 = 100,
        By1000 = 1000
    }

    #endregion
    #region  Variables

    private GraphicsPath PipeBorder;
    private GraphicsPath FillValue;
    private Rectangle TrackBarHandleRect;
    private bool Cap;
    private int ValueDrawer;

    private Size ThumbSize = new Size(15, 15);
    private Rectangle TrackThumb;

    private int _Minimum = 0;
    private int _Maximum = 10;
    private int _Value = 0;

    private bool _DrawValueString = false;
    private bool _JumpToMouse = false;
    private ValueDivisor DividedValue = ValueDivisor.By1;

    #endregion
    #region  Properties

    public int Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {

            if (value >= _Maximum)
            {
                value = _Maximum - 10;
            }
            if (_Value < value)
            {
                _Value = value;
            }

            _Minimum = value;
            Invalidate();
        }
    }

    public int Maximum
    {
        get
        {
            return _Maximum;
        }
        set
        {

            if (value <= _Minimum)
            {
                value = _Minimum + 10;
            }
            if (_Value > value)
            {
                _Value = value;
            }

            _Maximum = value;
            Invalidate();
        }
    }

    public delegate void ValueChangedEventHandler();
    private ValueChangedEventHandler ValueChangedEvent;

    public event ValueChangedEventHandler ValueChanged
    {
        add
        {
            ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Combine(ValueChangedEvent, value);
        }
        remove
        {
            ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Remove(ValueChangedEvent, value);
        }
    }

    public int Value
    {
        get
        {
            return _Value;
        }
        set
        {
            if (_Value != value)
            {
                if (value < _Minimum)
                {
                    _Value = _Minimum;
                }
                else
                {
                    if (value > _Maximum)
                    {
                        _Value = _Maximum;
                    }
                    else
                    {
                        _Value = value;
                    }
                }
                Invalidate();
                if (ValueChangedEvent != null)
                    ValueChangedEvent();
            }
        }
    }

    public ValueDivisor ValueDivison
    {
        get
        {
            return DividedValue;
        }
        set
        {
            DividedValue = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    public float ValueToSet
    {
        get
        {
            return _Value / (int)DividedValue;
        }
        set
        {
            Value = (int)(value * (int)DividedValue);
        }
    }

    public bool JumpToMouse
    {
        get
        {
            return _JumpToMouse;
        }
        set
        {
            _JumpToMouse = value;
            Invalidate();
        }
    }

    public bool DrawValueString
    {
        get
        {
            return _DrawValueString;
        }
        set
        {
            _DrawValueString = value;
            if (_DrawValueString == true)
            {
                Height = 35;
            }
            else
            {
                Height = 22;
            }
            Invalidate();
        }
    }

    #endregion
    #region  EventArgs

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        checked
        {
            bool flag = this.Cap && e.X > -1 && e.X < this.Width + 1;
            if (flag)
            {
                this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
            }
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        bool flag = e.Button == MouseButtons.Left;
        checked
        {
            if (flag)
            {
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 11));
                this.TrackBarHandleRect = new Rectangle(this.ValueDrawer, 0, 25, 25);
                this.Cap = this.TrackBarHandleRect.Contains(e.Location);
                this.Focus();
                flag = this._JumpToMouse;
                if (flag)
                {
                    this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                }
            }
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Cap = false;
    }

    #endregion

    public Ambiance_TrackBar()
    {
        SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer), true);

        Size = new Size(80, 22);
        MinimumSize = new Size(47, 22);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (_DrawValueString == true)
        {
            Height = 35;
        }
        else
        {
            Height = 22;
        }
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics G = e.Graphics;
			
			G.Clear(Parent.BackColor);
			G.SmoothingMode = SmoothingMode.AntiAlias;
			TrackThumb = new Rectangle(8, 10, Width - 16, 2);
			PipeBorder = RoundRectangle.RoundRect(1, 8, Width - 3, 5, 2);
			
			try
			{
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 11));
			}
			catch (Exception)
			{
			}
			
			TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 10, 20);
			
			G.SetClip(PipeBorder); // Set the clipping region of this Graphics to the specified GraphicsPath
			G.FillPath(new SolidBrush(Color.FromArgb(221, 221, 221)), PipeBorder);
			FillValue = RoundRectangle.RoundRect(1, 8, TrackBarHandleRect.X + TrackBarHandleRect.Width - 4, 5, 2);
			
			G.ResetClip(); // Reset the clip region of this Graphics to an infinite region
			
			G.SmoothingMode = SmoothingMode.HighQuality;
			G.DrawPath(new Pen(Color.FromArgb(200, 200, 200)), PipeBorder); // Draw pipe border
			G.FillPath(new SolidBrush(Color.FromArgb(217, 99, 50)), FillValue);

            G.FillEllipse(new SolidBrush(Color.FromArgb(244, 244, 244)), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
            G.DrawEllipse(new Pen(Color.FromArgb(180, 180, 180)), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
			
			if (_DrawValueString == true)
			{
				G.DrawString(System.Convert.ToString(ValueToSet), Font, Brushes.DimGray, 1, 20);
			}
		}
}

#endregion
#region  Panel

public class Ambiance_Panel : ContainerControl
{
    public Ambiance_Panel()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.Opaque, false);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        this.Font = new Font("Tahoma", 9);
        this.BackColor = Color.White;
        G.SmoothingMode = SmoothingMode.AntiAlias;
        G.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Width, Height));
        G.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Width - 1, Height - 1));
        G.DrawRectangle(new Pen(Color.FromArgb(211, 208, 205)), 0, 0, Width - 1, Height - 1);
    }
}

#endregion
#region TextBox

[DefaultEvent("TextChanged")]
class Amiance_TextBox : Control
{
    #region Variables

    public TextBox AmbianceTB = new TextBox();
    private GraphicsPath Shape;
    private int _maxchars = 32767;
    private bool _ReadOnly;
    private bool _Multiline;
    private HorizontalAlignment ALNType;
    private bool isPasswordMasked = false;
    private Pen P1;
    private SolidBrush B1;

    #endregion
    #region Properties

    public HorizontalAlignment TextAlignment
    {
        get { return ALNType; }
        set
        {
            ALNType = value;
            Invalidate();
        }
    }
    public int MaxLength
    {
        get { return _maxchars; }
        set
        {
            _maxchars = value;
            AmbianceTB.MaxLength = MaxLength;
            Invalidate();
        }
    }

    public bool UseSystemPasswordChar
    {
        get { return isPasswordMasked; }
        set
        {
            AmbianceTB.UseSystemPasswordChar = UseSystemPasswordChar;
            isPasswordMasked = value;
            Invalidate();
        }
    }
    public bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (AmbianceTB != null)
            {
                AmbianceTB.ReadOnly = value;
            }
        }
    }
    public bool Multiline
    {
        get { return _Multiline; }
        set
        {
            _Multiline = value;
            if (AmbianceTB != null)
            {
                AmbianceTB.Multiline = value;

                if (value)
                {
                    AmbianceTB.Height = Height - 10;
                }
                else
                {
                    Height = AmbianceTB.Height + 10;
                }
            }
        }
    }

    #endregion
    #region EventArgs

    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        AmbianceTB.Text = Text;
        Invalidate();
    }

    protected override void OnForeColorChanged(System.EventArgs e)
    {
        base.OnForeColorChanged(e);
        AmbianceTB.ForeColor = ForeColor;
        Invalidate();
    }

    protected override void OnFontChanged(System.EventArgs e)
    {
        base.OnFontChanged(e);
        AmbianceTB.Font = Font;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    private void _OnKeyDown(object Obj, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            AmbianceTB.SelectAll();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.C)
        {
            AmbianceTB.Copy();
            e.SuppressKeyPress = true;
        }
    }

    private void _Enter(object Obj, EventArgs e)
    {
        P1 = new Pen(Color.FromArgb(205, 87, 40));
        Refresh();
    }

    private void _Leave(object Obj, EventArgs e)
    {
        P1 = new Pen(Color.FromArgb(180, 180, 180));
        Refresh();
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        if (_Multiline)
        {
            AmbianceTB.Height = Height - 10;
        }
        else
        {
            Height = AmbianceTB.Height + 10;
        }

        Shape = new GraphicsPath();
        var _with1 = Shape;
        _with1.AddArc(0, 0, 10, 10, 180, 90);
        _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
        _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
        _with1.CloseAllFigures();
    }

    protected override void OnGotFocus(System.EventArgs e)
    {
        base.OnGotFocus(e);
        AmbianceTB.Focus();
    }

    #endregion
    public void AddTextBox()
    {
        var _TB = AmbianceTB;
        _TB.Size = new Size(Width - 10, 33);
        _TB.Location = new Point(7, 4);
        _TB.Text = string.Empty;
        _TB.BorderStyle = BorderStyle.None;
        _TB.TextAlign = HorizontalAlignment.Left;
        _TB.Font = new Font("Tahoma", 11);
        _TB.UseSystemPasswordChar = UseSystemPasswordChar;
        _TB.Multiline = false;
        AmbianceTB.KeyDown += _OnKeyDown;
        AmbianceTB.Enter += _Enter;
        AmbianceTB.Leave += _Leave;
    }

    public Amiance_TextBox()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);

        AddTextBox();
        Controls.Add(AmbianceTB);

        P1 = new Pen(Color.FromArgb(180, 180, 180)); // P1 = Border color
        B1 = new SolidBrush(Color.White); // B1 = Rect Background color
        BackColor = Color.Transparent;
        ForeColor = Color.DimGray;

        Text = null;
        Font = new Font("Tahoma", 11);
        Size = new Size(135, 33);
        DoubleBuffered = true;
    }
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);

        G.SmoothingMode = SmoothingMode.AntiAlias;

        var _TB = AmbianceTB;
        _TB.Width = Width - 10;
        _TB.TextAlign = TextAlignment;
        _TB.UseSystemPasswordChar = UseSystemPasswordChar;

        G.Clear(Color.Transparent);
        G.FillPath(B1, Shape); // Draw background
        G.DrawPath(P1, Shape); // Draw border

        e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
        G.Dispose();
        B.Dispose();
    }

}

#endregion
#region RichTextBox

[DefaultEvent("TextChanged")]
class Ambiance_RichTextBox : Control
{

    #region Variables

    public RichTextBox AmbianceRTB = new RichTextBox();
    private bool _ReadOnly;
    private bool _WordWrap;
    private bool _AutoWordSelection;
    private GraphicsPath Shape;
    private Pen P1;

    #endregion
    #region Properties

    public override string Text
    {
        get { return AmbianceRTB.Text; }
        set
        {
            AmbianceRTB.Text = value;
            Invalidate();
        }
    }
    public bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (AmbianceRTB != null)
            {
                AmbianceRTB.ReadOnly = value;
            }
        }
    }
    public bool WordWrap
    {
        get { return _WordWrap; }
        set
        {
            _WordWrap = value;
            if (AmbianceRTB != null)
            {
                AmbianceRTB.WordWrap = value;
            }
        }
    }
    public bool AutoWordSelection
    {
        get { return _AutoWordSelection; }
        set
        {
            _AutoWordSelection = value;
            if (AmbianceRTB != null)
            {
                AmbianceRTB.AutoWordSelection = value;
            }
        }
    }
    #endregion
    #region EventArgs

    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        AmbianceRTB.Text = Text;
        Invalidate();
    }

    protected override void OnForeColorChanged(System.EventArgs e)
    {
        base.OnForeColorChanged(e);
        AmbianceRTB.ForeColor = ForeColor;
        Invalidate();
    }

    protected override void OnFontChanged(System.EventArgs e)
    {
        base.OnFontChanged(e);
        AmbianceRTB.Font = Font;
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    protected override void OnSizeChanged(System.EventArgs e)
    {
        base.OnSizeChanged(e);
        AmbianceRTB.Size = new Size(Width - 13, Height - 11);
    }

    private void _Enter(object Obj, EventArgs e)
    {
        P1 = new Pen(Color.FromArgb(205, 87, 40));
        Refresh();
    }

    private void _Leave(object Obj, EventArgs e)
    {
        P1 = new Pen(Color.FromArgb(180, 180, 180));
        Refresh();
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);

        Shape = new GraphicsPath();
        var _with1 = Shape;
        _with1.AddArc(0, 0, 10, 10, 180, 90);
        _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
        _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
        _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
        _with1.CloseAllFigures();
    }

    #endregion

    public void AddRichTextBox()
    {
        var _TB = AmbianceRTB;
        _TB.BackColor = Color.White;
        _TB.Size = new Size(Width - 10, 100);
        _TB.Location = new Point(7, 5);
        _TB.Text = string.Empty;
        _TB.BorderStyle = BorderStyle.None;
        _TB.Font = new Font("Tahoma", 10);
        _TB.Multiline = true;
        AmbianceRTB.Enter += _Enter;
        AmbianceRTB.Leave += _Leave;
    }

    public Ambiance_RichTextBox()
        : base()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);

        AddRichTextBox();
        Controls.Add(AmbianceRTB);
        BackColor = Color.Transparent;
        ForeColor = Color.DimGray;

        P1 = new Pen(Color.FromArgb(180, 180, 180)); // P1 = Border color
        Text = null;
        Font = new Font("Tahoma", 10);
        Size = new Size(150, 100);
        WordWrap = true;
        AutoWordSelection = false;
        DoubleBuffered = true;
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        Bitmap B = new Bitmap(this.Width, this.Height);
        Graphics G = Graphics.FromImage(B);
        G.SmoothingMode = SmoothingMode.AntiAlias;
        G.Clear(Color.Transparent);
        G.FillPath(Brushes.White, this.Shape);
        G.DrawPath(P1, this.Shape);
        G.Dispose();
        e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
        B.Dispose();
    }
}

#endregion
#region  ListBox

public class Ambiance_ListBox : ListBox
{

    public Ambiance_ListBox()
    {
        this.SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint), true);
        this.DrawMode = DrawMode.OwnerDrawFixed;
        IntegralHeight = false;
        ItemHeight = 18;
        Font = new Font("Seoge UI", 11, FontStyle.Regular);
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        base.OnDrawItem(e);
        e.DrawBackground();
        LinearGradientBrush LGB = new LinearGradientBrush(e.Bounds, Color.FromArgb(246, 132, 85), Color.FromArgb(231, 108, 57), 90.0F);
        if (System.Convert.ToInt32((e.State & DrawItemState.Selected)) == (int)DrawItemState.Selected)
        {
            e.Graphics.FillRectangle(LGB, e.Bounds);
        }
        using (SolidBrush b = new SolidBrush(e.ForeColor))
        {
            if (base.Items.Count == 0)
            {
                return;
            }
            else
            {
                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, e.Bounds);
            }
        }

        LGB.Dispose();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Region MyRegion = new Region(e.ClipRectangle);
        e.Graphics.FillRegion(new SolidBrush(this.BackColor), MyRegion);

        if (this.Items.Count > 0)
        {
            for (int i = 0; i <= this.Items.Count - 1; i++)
            {
                System.Drawing.Rectangle RegionRect = this.GetItemRectangle(i);
                if (e.ClipRectangle.IntersectsWith(RegionRect))
                {
                    if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == i) || (this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(i)) || (this.SelectionMode == SelectionMode.MultiExtended && this.SelectedIndices.Contains(i)))
                    {
                        OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font, RegionRect, i, DrawItemState.Selected, this.ForeColor, this.BackColor));
                    }
                    else
                    {
                        OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font, RegionRect, i, DrawItemState.Default, Color.FromArgb(60, 60, 60), this.BackColor));
                    }
                    MyRegion.Complement(RegionRect);
                }
            }
        }
    }
}

#endregion
#region  TabControl

public class Ambiance_TabControl : TabControl
{

    public Ambiance_TabControl()
    {
        SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint), true);
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();

        ItemSize = new Size(80, 24);
        Alignment = TabAlignment.Top;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle ItemBoundsRect = new Rectangle();
        G.Clear(Parent.BackColor);
        for (int TabIndex = 0; TabIndex <= TabCount - 1; TabIndex++)
        {
            ItemBoundsRect = GetTabRect(TabIndex);
            if (!(TabIndex == SelectedIndex))
            {
                G.DrawString(TabPages[TabIndex].Text, new Font(Font.Name, Font.Size - 2, FontStyle.Bold), new SolidBrush(Color.FromArgb(80, 76, 76)), new Rectangle(GetTabRect(TabIndex).Location, GetTabRect(TabIndex).Size), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }
        }

        // Draw container rectangle
        G.FillPath(new SolidBrush(Color.FromArgb(247, 246, 246)), RoundRectangle.RoundRect(0, 23, Width - 1, Height - 24, 2));
        G.DrawPath(new Pen(Color.FromArgb(201, 198, 195)), RoundRectangle.RoundRect(0, 23, Width - 1, Height - 24, 2));

        for (int ItemIndex = 0; ItemIndex <= TabCount - 1; ItemIndex++)
        {
            ItemBoundsRect = GetTabRect(ItemIndex);
            if (ItemIndex == SelectedIndex)
            {

                // Draw header tabs
                G.DrawPath(new Pen(Color.FromArgb(201, 198, 195)), RoundRectangle.RoundedTopRect(new Rectangle(new Point(ItemBoundsRect.X - 2, ItemBoundsRect.Y - 2), new Size(ItemBoundsRect.Width + 3, ItemBoundsRect.Height)), 7));
                G.FillPath(new SolidBrush(Color.FromArgb(247, 246, 246)), RoundRectangle.RoundedTopRect(new Rectangle(new Point(ItemBoundsRect.X - 1, ItemBoundsRect.Y - 1), new Size(ItemBoundsRect.Width + 2, ItemBoundsRect.Height)), 7));

                try
                {
                    G.DrawString(TabPages[ItemIndex].Text, new Font(Font.Name, Font.Size - 1, FontStyle.Bold), new SolidBrush(Color.FromArgb(80, 76, 76)), new Rectangle(GetTabRect(ItemIndex).Location, GetTabRect(ItemIndex).Size), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                    TabPages[ItemIndex].BackColor = Color.FromArgb(247, 246, 246);
                }
                catch
                {
                }
            }
        }
    }
}

#endregion