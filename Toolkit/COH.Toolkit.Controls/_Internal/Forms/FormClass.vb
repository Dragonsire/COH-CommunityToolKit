Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace MaterialSkin.Controls
    Public Class MaterialForm
        Inherits Form
        ' Implements IMaterialControl

        <Browsable(False)>
        Public Property Depth As Integer

        ' <Browsable(False)>
        ' Public ReadOnly Property SkinManager As MaterialSkinManager
        'Get
        ' Return MaterialSkinManager.Instance
        'End Get
        ' End Property

        <Browsable(False)>
        Public Property MouseState 'As MouseState

        Public Overloads Property FormBorderStyle As FormBorderStyle
            Get
                Return MyBase.FormBorderStyle
            End Get
            Set(ByVal value As FormBorderStyle)
                MyBase.FormBorderStyle = value
            End Set
        End Property
        Public Property Sizable As Boolean
        <DllImport("user32.dll")>
        Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function
        <DllImport("user32.dll")>
        Public Shared Function ReleaseCapture() As Boolean
        End Function
        <DllImport("user32.dll")>
        Public Shared Function TrackPopupMenuEx(ByVal hmenu As IntPtr, ByVal fuFlags As UInteger, ByVal x As Integer, ByVal y As Integer, ByVal hwnd As IntPtr, ByVal lptpm As IntPtr) As Integer
        End Function
        <DllImport("user32.dll")>
        Public Shared Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
        End Function
        <DllImport("user32.dll")>
        Public Shared Function MonitorFromWindow(ByVal hwnd As IntPtr, ByVal dwFlags As UInteger) As IntPtr
        End Function
        <DllImport("User32.dll", CharSet:=CharSet.Auto)>
        Public Shared Function GetMonitorInfo(ByVal hmonitor As HandleRef, <[In], Out> ByVal info As MONITORINFOEX) As Boolean
        End Function
        Public Const WM_NCLBUTTONDOWN As Integer = &HA1
            Public Const HT_CAPTION As Integer = &H2
            Public Const WM_MOUSEMOVE As Integer = &H200
            Public Const WM_LBUTTONDOWN As Integer = &H201
            Public Const WM_LBUTTONUP As Integer = &H202
            Public Const WM_LBUTTONDBLCLK As Integer = &H203
            Public Const WM_RBUTTONDOWN As Integer = &H204
            Private Const HTBOTTOMLEFT As Integer = 16
            Private Const HTBOTTOMRIGHT As Integer = 17
            Private Const HTLEFT As Integer = 10
            Private Const HTRIGHT As Integer = 11
            Private Const HTBOTTOM As Integer = 15
            Private Const HTTOP As Integer = 12
            Private Const HTTOPLEFT As Integer = 13
            Private Const HTTOPRIGHT As Integer = 14
            Private Const BORDER_WIDTH As Integer = 7
            Private _resizeDir As ResizeDirection
            Private _buttonState As ButtonState = ButtonState.None
            Private Const WMSZ_TOP As Integer = 3
            Private Const WMSZ_TOPLEFT As Integer = 4
            Private Const WMSZ_TOPRIGHT As Integer = 5
            Private Const WMSZ_LEFT As Integer = 1
            Private Const WMSZ_RIGHT As Integer = 2
            Private Const WMSZ_BOTTOM As Integer = 6
            Private Const WMSZ_BOTTOMLEFT As Integer = 7
            Private Const WMSZ_BOTTOMRIGHT As Integer = 8
            Private ReadOnly _resizingLocationsToCmd As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer) From {
                {HTTOP, WMSZ_TOP},
                {HTTOPLEFT, WMSZ_TOPLEFT},
                {HTTOPRIGHT, WMSZ_TOPRIGHT},
                {HTLEFT, WMSZ_LEFT},
                {HTRIGHT, WMSZ_RIGHT},
                {HTBOTTOM, WMSZ_BOTTOM},
                {HTBOTTOMLEFT, WMSZ_BOTTOMLEFT},
                {HTBOTTOMRIGHT, WMSZ_BOTTOMRIGHT}
            }
            Private Const STATUS_BAR_BUTTON_WIDTH As Integer = STATUS_BAR_HEIGHT
            Private Const STATUS_BAR_HEIGHT As Integer = 24
            Private Const ACTION_BAR_HEIGHT As Integer = 40
            Private Const TPM_LEFTALIGN As UInteger = &H0
            Private Const TPM_RETURNCMD As UInteger = &H100
            Private Const WM_SYSCOMMAND As Integer = &H112
            Private Const WS_MINIMIZEBOX As Integer = &H20000
            Private Const WS_SYSMENU As Integer = &H80000
            Private Const MONITOR_DEFAULTTONEAREST As Integer = 2

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto, Pack:=4)>
        Public Class MONITORINFOEX
            Public cbSize As Integer = Marshal.SizeOf(GetType(MONITORINFOEX))
            Public rcMonitor As RECT = New RECT()
            Public rcWork As RECT = New RECT()
            Public dwFlags As Integer = 0
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
            Public szDevice As Char() = New Char(31) {}
        End Class

        <StructLayout(LayoutKind.Sequential)>
        Public Structure RECT
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer

            Public Function Width() As Integer
                Return right - left
            End Function

            Public Function Height() As Integer
                Return bottom - top
            End Function
        End Structure

        Private Enum ResizeDirection
            BottomLeft
            Left
            Right
            BottomRight
            Bottom
            None
        End Enum

        Private Enum ButtonState
            XOver
            MaxOver
            MinOver
            XDown
            MaxDown
            MinDown
            None
        End Enum

        Private ReadOnly _resizeCursors As Cursor() = {Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeWE, Cursors.SizeNS}
        Private _minButtonBounds As Rectangle
        Private _maxButtonBounds As Rectangle
        Private _xButtonBounds As Rectangle
        Private _actionBarBounds As Rectangle
        Private _statusBarBounds As Rectangle
        Private _maximized As Boolean
        Private _previousSize As Size
        Private _previousLocation As Point
        Private _headerMouseDown As Boolean

        Public Sub New()
            FormBorderStyle = FormBorderStyle.None
            Sizable = True
            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
            Application.AddMessageFilter(New MouseMessageFilter())
            '  MouseMessageFilter.MouseMove += AddressOf OnGlobalMouseMove
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)
            If DesignMode OrElse IsDisposed Then Return

            If m.Msg = WM_LBUTTONDBLCLK Then
                MaximizeWindow(Not _maximized)
            ElseIf m.Msg = WM_MOUSEMOVE AndAlso _maximized AndAlso (_statusBarBounds.Contains(PointToClient(Cursor.Position)) OrElse _actionBarBounds.Contains(PointToClient(Cursor.Position))) AndAlso Not (_minButtonBounds.Contains(PointToClient(Cursor.Position)) OrElse _maxButtonBounds.Contains(PointToClient(Cursor.Position)) OrElse _xButtonBounds.Contains(PointToClient(Cursor.Position))) Then

                If _headerMouseDown Then
                    _maximized = False
                    _headerMouseDown = False
                    Dim mousePoint = PointToClient(Cursor.Position)

                    If mousePoint.X < Width / 2 Then
                        Location = If(mousePoint.X < _previousSize.Width / 2, New Point(Cursor.Position.X - mousePoint.X, Cursor.Position.Y - mousePoint.Y), New Point(Cursor.Position.X - _previousSize.Width / 2, Cursor.Position.Y - mousePoint.Y))
                    Else
                        Location = If(Width - mousePoint.X < _previousSize.Width / 2, New Point(Cursor.Position.X - _previousSize.Width + Width - mousePoint.X, Cursor.Position.Y - mousePoint.Y), New Point(Cursor.Position.X - _previousSize.Width / 2, Cursor.Position.Y - mousePoint.Y))
                    End If

                    Size = _previousSize
                    ReleaseCapture()
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
                End If
            ElseIf m.Msg = WM_LBUTTONDOWN AndAlso (_statusBarBounds.Contains(PointToClient(Cursor.Position)) OrElse _actionBarBounds.Contains(PointToClient(Cursor.Position))) AndAlso Not (_minButtonBounds.Contains(PointToClient(Cursor.Position)) OrElse _maxButtonBounds.Contains(PointToClient(Cursor.Position)) OrElse _xButtonBounds.Contains(PointToClient(Cursor.Position))) Then

                If Not _maximized Then
                    ReleaseCapture()
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
                Else
                    _headerMouseDown = True
                End If
            ElseIf m.Msg = WM_RBUTTONDOWN Then
                Dim cursorPos As Point = PointToClient(Cursor.Position)

                If _statusBarBounds.Contains(cursorPos) AndAlso Not _minButtonBounds.Contains(cursorPos) AndAlso Not _maxButtonBounds.Contains(cursorPos) AndAlso Not _xButtonBounds.Contains(cursorPos) Then
                    Dim id = TrackPopupMenuEx(GetSystemMenu(Handle, False), TPM_LEFTALIGN Or TPM_RETURNCMD, Cursor.Position.X, Cursor.Position.Y, Handle, IntPtr.Zero)
                    SendMessage(Handle, WM_SYSCOMMAND, id, 0)
                End If
            ElseIf m.Msg = WM_NCLBUTTONDOWN Then
                If Not Sizable Then Return
                Dim bFlag As Byte = 0
                If _resizingLocationsToCmd.ContainsKey(CInt(m.WParam)) Then bFlag = CByte(_resizingLocationsToCmd(CInt(m.WParam)))
                If bFlag <> 0 Then SendMessage(Handle, WM_SYSCOMMAND, &HF000 Or bFlag, CInt(m.LParam))
            ElseIf m.Msg = WM_LBUTTONUP Then
                _headerMouseDown = False
            End If
        End Sub

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim par = MyBase.CreateParams
                par.Style = par.Style Or WS_MINIMIZEBOX Or WS_SYSMENU
                Return par
            End Get
        End Property

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            If DesignMode Then Return
            UpdateButtons(e)
            If e.Button = MouseButtons.Left AndAlso Not _maximized Then ResizeForm(_resizeDir)
            MyBase.OnMouseDown(e)
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)
            If DesignMode Then Return
            _buttonState = ButtonState.None
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            If DesignMode Then Return

            If Sizable Then
                Dim isChildUnderMouse = GetChildAtPoint(e.Location) IsNot Nothing

                If e.Location.X < BORDER_WIDTH AndAlso e.Location.Y > Height - BORDER_WIDTH AndAlso Not isChildUnderMouse AndAlso Not _maximized Then
                    _resizeDir = ResizeDirection.BottomLeft
                    Cursor = Cursors.SizeNESW
                ElseIf e.Location.X < BORDER_WIDTH AndAlso Not isChildUnderMouse AndAlso Not _maximized Then
                    _resizeDir = ResizeDirection.Left
                    Cursor = Cursors.SizeWE
                ElseIf e.Location.X > Width - BORDER_WIDTH AndAlso e.Location.Y > Height - BORDER_WIDTH AndAlso Not isChildUnderMouse AndAlso Not _maximized Then
                    _resizeDir = ResizeDirection.BottomRight
                    Cursor = Cursors.SizeNWSE
                ElseIf e.Location.X > Width - BORDER_WIDTH AndAlso Not isChildUnderMouse AndAlso Not _maximized Then
                    _resizeDir = ResizeDirection.Right
                    Cursor = Cursors.SizeWE
                ElseIf e.Location.Y > Height - BORDER_WIDTH AndAlso Not isChildUnderMouse AndAlso Not _maximized Then
                    _resizeDir = ResizeDirection.Bottom
                    Cursor = Cursors.SizeNS
                Else
                    _resizeDir = ResizeDirection.None

                    If _resizeCursors.Contains(Cursor) Then
                        Cursor = Cursors.[Default]
                    End If
                End If
            End If

            UpdateButtons(e)
        End Sub

        Protected Sub OnGlobalMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If IsDisposed Then Return
            Dim clientCursorPos = PointToClient(e.Location)
            Dim newE = New MouseEventArgs(MouseButtons.None, 0, clientCursorPos.X, clientCursorPos.Y, 0)
            OnMouseMove(newE)
        End Sub

        Private Sub UpdateButtons(ByVal e As MouseEventArgs, ByVal Optional up As Boolean = False)
            If DesignMode Then Return
            Dim oldState = _buttonState
            Dim showMin As Boolean = MinimizeBox AndAlso ControlBox
            Dim showMax As Boolean = MaximizeBox AndAlso ControlBox

            If e.Button = MouseButtons.Left AndAlso Not up Then

                If showMin AndAlso Not showMax AndAlso _maxButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.MinDown
                ElseIf showMin AndAlso showMax AndAlso _minButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.MinDown
                ElseIf showMax AndAlso _maxButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.MaxDown
                ElseIf ControlBox AndAlso _xButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.XDown
                Else
                    _buttonState = ButtonState.None
                End If
            Else

                If showMin AndAlso Not showMax AndAlso _maxButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.MinOver
                    If oldState = ButtonState.MinDown AndAlso up Then WindowState = FormWindowState.Minimized
                ElseIf showMin AndAlso showMax AndAlso _minButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.MinOver
                    If oldState = ButtonState.MinDown AndAlso up Then WindowState = FormWindowState.Minimized
                ElseIf MaximizeBox AndAlso ControlBox AndAlso _maxButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.MaxOver
                    If oldState = ButtonState.MaxDown AndAlso up Then MaximizeWindow(Not _maximized)
                ElseIf ControlBox AndAlso _xButtonBounds.Contains(e.Location) Then
                    _buttonState = ButtonState.XOver
                    If oldState = ButtonState.XDown AndAlso up Then Close()
                Else
                    _buttonState = ButtonState.None
                End If
            End If

            If oldState <> _buttonState Then Invalidate()
        End Sub

        Private Sub MaximizeWindow(ByVal maximize As Boolean)
            If Not MaximizeBox OrElse Not ControlBox Then Return
            _maximized = maximize

            If maximize Then
                Dim monitorHandle = MonitorFromWindow(Handle, MONITOR_DEFAULTTONEAREST)
                Dim monitorInfo = New MONITORINFOEX()
                GetMonitorInfo(New HandleRef(Nothing, monitorHandle), monitorInfo)
                _previousSize = Size
                _previousLocation = Location
                Size = New Size(monitorInfo.rcWork.Width(), monitorInfo.rcWork.Height())
                Location = New Point(monitorInfo.rcWork.left, monitorInfo.rcWork.top)
            Else
                Size = _previousSize
                Location = _previousLocation
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If DesignMode Then Return
            UpdateButtons(e, True)
            MyBase.OnMouseUp(e)
            ReleaseCapture()
        End Sub

        Private Sub ResizeForm(ByVal direction As ResizeDirection)
            If DesignMode Then Return
            Dim dir = -1

            Select Case direction
                Case ResizeDirection.BottomLeft
                    dir = HTBOTTOMLEFT
                Case ResizeDirection.Left
                    dir = HTLEFT
                Case ResizeDirection.Right
                    dir = HTRIGHT
                Case ResizeDirection.BottomRight
                    dir = HTBOTTOMRIGHT
                Case ResizeDirection.Bottom
                    dir = HTBOTTOM
            End Select

            ReleaseCapture()

            If dir <> -1 Then
                SendMessage(Handle, WM_NCLBUTTONDOWN, dir, 0)
            End If
        End Sub

        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            ' _minButtonBounds = New Rectangle((Width - SkinManager.FORM_PADDING / 2) - 3 * STATUS_BAR_BUTTON_WIDTH, 0, STATUS_BAR_BUTTON_WIDTH, STATUS_BAR_HEIGHT)
            ' _maxButtonBounds = New Rectangle((Width - SkinManager.FORM_PADDING / 2) - 2 * STATUS_BAR_BUTTON_WIDTH, 0, STATUS_BAR_BUTTON_WIDTH, STATUS_BAR_HEIGHT)
            '_xButtonBounds = New Rectangle((Width - SkinManager.FORM_PADDING / 2) - STATUS_BAR_BUTTON_WIDTH, 0, STATUS_BAR_BUTTON_WIDTH, STATUS_BAR_HEIGHT)
            _statusBarBounds = New Rectangle(0, 0, Width, STATUS_BAR_HEIGHT)
            _actionBarBounds = New Rectangle(0, STATUS_BAR_HEIGHT, Width, ACTION_BAR_HEIGHT)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim g = e.Graphics
            g.TextRenderingHint = TextRenderingHint.AntiAlias
            ' g.Clear(SkinManager.GetApplicationBackgroundColor())
            'g.FillRectangle(SkinManager.ColorScheme.DarkPrimaryBrush, _statusBarBounds)
            'g.FillRectangle(SkinManager.ColorScheme.PrimaryBrush, _actionBarBounds)

            ' Using borderPen = New Pen(SkinManager.GetDividersColor(), 1)
            ' g.DrawLine(borderPen, New Point(0, _actionBarBounds.Bottom), New Point(0, Height - 2))
            ' g.DrawLine(borderPen, New Point(Width - 1, _actionBarBounds.Bottom), New Point(Width - 1, Height - 2))
            ' g.DrawLine(borderPen, New Point(0, Height - 1), New Point(Width - 1, Height - 1))
            ' End Using

            Dim showMin As Boolean = MinimizeBox AndAlso ControlBox
            Dim showMax As Boolean = MaximizeBox AndAlso ControlBox
            ' Dim hoverBrush = SkinManager.GetFlatButtonHoverBackgroundBrush()
            ' Dim downBrush = SkinManager.GetFlatButtonPressedBackgroundBrush()
            ' If _buttonState = ButtonState.MinOver AndAlso showMin Then g.FillRectangle(hoverBrush, If(showMax, _minButtonBounds, _maxButtonBounds))
            ' If _buttonState = ButtonState.MinDown AndAlso showMin Then g.FillRectangle(downBrush, If(showMax, _minButtonBounds, _maxButtonBounds))
            ' If _buttonState = ButtonState.MaxOver AndAlso showMax Then g.FillRectangle(hoverBrush, _maxButtonBounds)
            ' If _buttonState = ButtonState.MaxDown AndAlso showMax Then g.FillRectangle(downBrush, _maxButtonBounds)
            ' If _buttonState = ButtonState.XOver AndAlso ControlBox Then g.FillRectangle(hoverBrush, _xButtonBounds)
            ' If _buttonState = ButtonState.XDown AndAlso ControlBox Then g.FillRectangle(downBrush, _xButtonBounds)

            ' Using formButtonsPen = New Pen(SkinManager.ACTION_BAR_TEXT_SECONDARY, 2)

            If showMin Then
                    Dim x As Integer = If(showMax, _minButtonBounds.X, _maxButtonBounds.X)
                    Dim y As Integer = If(showMax, _minButtonBounds.Y, _maxButtonBounds.Y)
                ' g.DrawLine(formButtonsPen, x + CInt((_minButtonBounds.Width * 0.33)), y + CInt((_minButtonBounds.Height * 0.66)), x + CInt((_minButtonBounds.Width * 0.66)), y + CInt((_minButtonBounds.Height * 0.66)))
            End If

                If showMax Then
                '  g.DrawRectangle(formButtonsPen, _maxButtonBounds.X + CInt((_maxButtonBounds.Width * 0.33)), _maxButtonBounds.Y + CInt((_maxButtonBounds.Height * 0.36)), CInt((_maxButtonBounds.Width * 0.39)), CInt((_maxButtonBounds.Height * 0.31)))
            End If

                If ControlBox Then
                ' g.DrawLine(formButtonsPen, _xButtonBounds.X + CInt((_xButtonBounds.Width * 0.33)), _xButtonBounds.Y + CInt((_xButtonBounds.Height * 0.33)), _xButtonBounds.X + CInt((_xButtonBounds.Width * 0.66)), _xButtonBounds.Y + CInt((_xButtonBounds.Height * 0.66)))
                ' g.DrawLine(formButtonsPen, _xButtonBounds.X + CInt((_xButtonBounds.Width * 0.66)), _xButtonBounds.Y + CInt((_xButtonBounds.Height * 0.33)), _xButtonBounds.X + CInt((_xButtonBounds.Width * 0.33)), _xButtonBounds.Y + CInt((_xButtonBounds.Height * 0.66)))
            End If
            '  End Using

            '  g.DrawString(Text, SkinManager.ROBOTO_MEDIUM_12, SkinManager.ColorScheme.TextBrush, New Rectangle(SkinManager.FORM_PADDING, STATUS_BAR_HEIGHT, Width, ACTION_BAR_HEIGHT), New StringFormat With {
            '  .LineAlignment = StringAlignment.Center
            ' })
        End Sub
    End Class

    Public Class MouseMessageFilter
        ' Inherits IMessageFilter

        Private Const WM_MOUSEMOVE As Integer = &H200
        Public Shared Event MouseMove As MouseEventHandler

        Public Function PreFilterMessage(ByRef m As Message) As Boolean
            If m.Msg = WM_MOUSEMOVE Then

                'If MouseMove IsNot Nothing Then
                'Dim x As Integer = Control.MousePosition.X, y As Integer = Control.MousePosition.Y
                'MouseMove(Nothing, New MouseEventArgs(MouseButtons.None, 0, x, y, 0))
                'End If
            End If

            Return False
        End Function
    End Class
End Namespace
