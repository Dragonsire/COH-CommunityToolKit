Imports System.Runtime.InteropServices

Namespace HelperFunctions.WindowsEnviroment
    <HideModuleName> Public Module HelperFunction_WindowsEnviroment


#Region "Window Messages"
        <DllImport("user32.dll")>
        Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function
        <DllImport("user32.dll")>
        Public Function ReleaseCapture() As Boolean
        End Function
        <DllImport("user32.dll")>
        Public Function TrackPopupMenuEx(ByVal hmenu As IntPtr, ByVal fuFlags As UInteger, ByVal x As Integer, ByVal y As Integer, ByVal hwnd As IntPtr, ByVal lptpm As IntPtr) As Integer
        End Function
        <DllImport("user32.dll")>
        Public Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
        End Function
        <DllImport("user32.dll")>
        Public Function MonitorFromWindow(ByVal hwnd As IntPtr, ByVal dwFlags As UInteger) As IntPtr
        End Function
        <DllImport("User32.dll", CharSet:=CharSet.Auto)>
        Public Function GetMonitorInfo(ByVal hmonitor As HandleRef, <[In], Out> ByVal info As MONITORINFOEX) As Boolean
        End Function
#End Region

#Region "Enums"
        Public Enum ResizeDirection
            BottomLeft
            Left
            Right
            BottomRight
            Bottom
            None
        End Enum
        Public Enum CurrentButtonState
            XOver
            MaxOver
            MinOver
            XDown
            MaxDown
            MinDown
            None
        End Enum
        Public Enum MouseState
            HOVER
            DOWN
            OUT
        End Enum
#End Region

#Region "Constants"
        Public Const WM_NCLBUTTONDOWN As Integer = &HA1
        Public Const HT_CAPTION As Integer = &H2
        Public Const WM_MOUSEMOVE As Integer = &H200
        Public Const WM_LBUTTONDOWN As Integer = &H201
        Public Const WM_LBUTTONUP As Integer = &H202
        Public Const WM_LBUTTONDBLCLK As Integer = &H203
        Public Const WM_RBUTTONDOWN As Integer = &H204
        Public Const HTBOTTOMLEFT As Integer = 16
        Public Const HTBOTTOMRIGHT As Integer = 17
        Public Const HTLEFT As Integer = 10
        Public Const HTRIGHT As Integer = 11
        Public Const HTBOTTOM As Integer = 15
        Public Const HTTOP As Integer = 12
        Public Const HTTOPLEFT As Integer = 13
        Public Const HTTOPRIGHT As Integer = 14
        Public Const BORDER_WIDTH As Integer = 7
        Public Const WMSZ_TOP As Integer = 3
        Public Const WMSZ_TOPLEFT As Integer = 4
        Public Const WMSZ_TOPRIGHT As Integer = 5
        Public Const WMSZ_LEFT As Integer = 1
        Public Const WMSZ_RIGHT As Integer = 2
        Public Const WMSZ_BOTTOM As Integer = 6
        Public Const WMSZ_BOTTOMLEFT As Integer = 7
        Public Const WMSZ_BOTTOMRIGHT As Integer = 8
        Public ReadOnly _resizingLocationsToCmd As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer) From {
                {HTTOP, WMSZ_TOP},
                {HTTOPLEFT, WMSZ_TOPLEFT},
                {HTTOPRIGHT, WMSZ_TOPRIGHT},
                {HTLEFT, WMSZ_LEFT},
                {HTRIGHT, WMSZ_RIGHT},
                {HTBOTTOM, WMSZ_BOTTOM},
                {HTBOTTOMLEFT, WMSZ_BOTTOMLEFT},
                {HTBOTTOMRIGHT, WMSZ_BOTTOMRIGHT}
            }
        Public Const STATUS_BAR_BUTTON_WIDTH As Integer = STATUS_BAR_HEIGHT
        Public Const STATUS_BAR_HEIGHT As Integer = 24
        Public Const ACTION_BAR_HEIGHT As Integer = 40
        Public Const TPM_LEFTALIGN As UInteger = &H0
        Public Const TPM_RETURNCMD As UInteger = &H100
        Public Const WM_SYSCOMMAND As Integer = &H112
        Public Const WS_MINIMIZEBOX As Integer = &H20000
        Public Const WS_SYSMENU As Integer = &H80000
        Public Const MONITOR_DEFAULTTONEAREST As Integer = 2
#End Region

#Region "Structures"
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
        Public Class MouseMessageFilter
            ' Inherits IMessageFilter

            Public Const WM_MOUSEMOVE As Integer = &H200
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
#End Region

    End Module
End Namespace
