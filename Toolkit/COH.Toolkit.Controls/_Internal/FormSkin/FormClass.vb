﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports COH.Controls
Imports COH.Controls.Configuration
Imports COH.Controls.FormSkinRegion
Imports COH.HelperFunctions.WindowsEnviroment

Namespace MaterialSkin.Controls
    Public Class ToolkitForm
        Inherits Form

#Region "Properties"
        Private pFormSkin As FormSkin
        Private rRenderingEnabled As Boolean
#End Region


#Region "Properties"
        <Browsable(False)> Public Property Depth As Integer
        <Browsable(False)> Public Property MouseState As MouseState
        Public Overloads Property FormBorderStyle As FormBorderStyle
            Get
                Return MyBase.FormBorderStyle
            End Get
            Set(ByVal value As FormBorderStyle)
                MyBase.FormBorderStyle = value
            End Set
        End Property
        Public Property Sizable As Boolean
        Private ReadOnly _resizeCursors As Cursor() = {Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeWE, Cursors.SizeNS}

        Private _statusBarBounds As Rectangle
        Private _maximized As Boolean
        Private _previousSize As Size
        Private _previousLocation As Point
        Private _headerMouseDown As Boolean
        Private _resizeDir As ResizeDirection
        Private _CurrentButtonState As CurrentButtonState = CurrentButtonState.None
#End Region

#Region "Create New Instance"
        Public Sub New()
            FormBorderStyle = FormBorderStyle.None
            Sizable = True
            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
            Application.AddMessageFilter(New MouseMessageFilter())
            '  MouseMessageFilter.MouseMove += AddressOf OnGlobalMouseMove
        End Sub
#End Region

#Region "Checks"
        Private Function RenderingEnabled() As Boolean
            If DesignMode Then Return False
            If pFormSkin Is Nothing Then Return False
            Return rRenderingEnabled
        End Function
#End Region

#Region "Form Events"
        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            If RenderingEnabled() = False Then Exit Sub
            pFormSkin.Calculate_DrawableLocations(ClientRectangle)
        End Sub
#End Region

#Region "Mouse Events"
        Private Sub WindowEvent_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If RenderingEnabled() = False Then Exit Sub
            pFormSkin.ProcessMouseEvent_MouseMove(Me, e)
        End Sub
        Private Sub WindowEvent_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If RenderingEnabled() = False Then Exit Sub
            pFormSkin.ProcessMouseEvent_MouseDown(Me, e)
        End Sub
        Private Sub WindowEvent_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            If RenderingEnabled() = False Then Exit Sub
            pFormSkin.ProcessMouseEvent_MouseUp(Me, e)
        End Sub
        Private Sub WindowEvent_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            If RenderingEnabled() = False Then Exit Sub
            pFormSkin.ProcessMouseEvent_MouseLeave(Me, e)
        End Sub
        Private Sub WindowEvent_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
            If RenderingEnabled() = False Then Exit Sub
            pFormSkin.ProcessMouseEvent_MouseHover(Me, e)
        End Sub
#End Region



















































#Region "Window Buttons"
        Private Sub UpdateButtons(ByVal e As MouseEventArgs, ByVal Optional MouseUp As Boolean = False)
            If DesignMode Then Return
            Dim oldState = _CurrentButtonState
            Dim showMin As Boolean = MinimizeBox AndAlso ControlBox
            Dim showMax As Boolean = MaximizeBox AndAlso ControlBox


            If oldState <> _CurrentButtonState Then Invalidate()
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
#End Region

#Region "Mouse Messages - Overrides"
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            If DesignMode Then Return
            UpdateButtons(e)
            If e.Button = MouseButtons.Left AndAlso Not _maximized Then ResizeForm(_resizeDir)
            MyBase.OnMouseDown(e)
        End Sub
        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)
            If DesignMode Then Return
            _CurrentButtonState = CurrentButtonState.None
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
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If DesignMode Then Return
            UpdateButtons(e, True)
            MyBase.OnMouseUp(e)
            ReleaseCapture()
        End Sub
        Protected Sub OnGlobalMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If IsDisposed Then Return
            Dim clientCursorPos = PointToClient(e.Location)
            Dim newE = New MouseEventArgs(MouseButtons.None, 0, clientCursorPos.X, clientCursorPos.Y, 0)
            OnMouseMove(newE)
        End Sub
#End Region

#Region "Window Messages - Overrides"
        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)
            If DesignMode OrElse IsDisposed Then Return

            If m.Msg = WM_LBUTTONDBLCLK Then
                MaximizeWindow(Not _maximized)
            ElseIf m.Msg = WM_MOUSEMOVE AndAlso _maximized AndAlso (_statusBarBounds.Contains(PointToClient(Cursor.Position)) OrElse pFormSkin.TitleBar.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position))) AndAlso Not (pFormSkin.Button_Min.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position)) OrElse pFormSkin.Button_Max.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position)) OrElse pFormSkin.Button_Close.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position))) Then

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
            ElseIf m.Msg = WM_LBUTTONDOWN AndAlso (_statusBarBounds.Contains(PointToClient(Cursor.Position)) OrElse pFormSkin.TitleBar.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position))) AndAlso Not (pFormSkin.Button_Min.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position)) OrElse pFormSkin.Button_Max.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position)) OrElse pFormSkin.Button_Close.Check_MouseLocation_WithinDrawArea(PointToClient(Cursor.Position))) Then

                If Not _maximized Then
                    ReleaseCapture()
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
                Else
                    _headerMouseDown = True
                End If
            ElseIf m.Msg = WM_RBUTTONDOWN Then
                Dim cursorPos As Point = PointToClient(Cursor.Position)

                If _statusBarBounds.Contains(cursorPos) AndAlso Not pFormSkin.Button_Min.Check_MouseLocation_WithinDrawArea(cursorPos) AndAlso Not pFormSkin.Button_Max.Check_MouseLocation_WithinDrawArea(cursorPos) AndAlso Not pFormSkin.Button_Close.Check_MouseLocation_WithinDrawArea(cursorPos) Then
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
#End Region

#Region "Drawing"
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
            ' If _CurrentButtonState = CurrentButtonState.MinOver AndAlso showMin Then g.FillRectangle(hoverBrush, If(showMax, _minButtonBounds, _maxButtonBounds))
            ' If _CurrentButtonState = CurrentButtonState.MinDown AndAlso showMin Then g.FillRectangle(downBrush, If(showMax, _minButtonBounds, _maxButtonBounds))
            ' If _CurrentButtonState = CurrentButtonState.MaxOver AndAlso showMax Then g.FillRectangle(hoverBrush, _maxButtonBounds)
            ' If _CurrentButtonState = CurrentButtonState.MaxDown AndAlso showMax Then g.FillRectangle(downBrush, _maxButtonBounds)
            ' If _CurrentButtonState = CurrentButtonState.XOver AndAlso ControlBox Then g.FillRectangle(hoverBrush, _xButtonBounds)
            ' If _CurrentButtonState = CurrentButtonState.XDown AndAlso ControlBox Then g.FillRectangle(downBrush, _xButtonBounds)

            ' Using formButtonsPen = New Pen(SkinManager.ACTION_BAR_TEXT_SECONDARY, 2)

            If showMin Then
                ' D 'im x As Integer = If(showMax, pButton_Min.X, pButton_Max.X)
                ' Dim y As Integer = If(showMax, pButton_Min.Y, pButton_Max.Y)
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
#End Region
    End Class
End Namespace