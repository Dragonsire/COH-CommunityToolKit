Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices

Namespace CodeManagement.Extentions.Draw
    <HideModuleName> Public Module HelperExtensions_Colors
        <Extension()> Public Function LightenColor(ByVal SourceColor As Color, ByVal ChangePercent As Single) As Color
            Return HelperFunctions.Draw.LightenColor(SourceColor, ChangePercent)
        End Function
        <Extension()> Public Function DarkenColor(ByVal SourceColor As Color, ByVal ChangePercent As Single) As Color
            Return HelperFunctions.Draw.DarkenColor(SourceColor, ChangePercent)
        End Function
    End Module
End Namespace

Namespace HelperFunctions.Draw
    <HideModuleName> Public Module HelperFunction_Colors

#Region "Adjust Brightness"
        Public Function LightenColor(ByVal SourceColor As Color, ByVal ChangePercent As Single) As Color
            Dim Amount As Single = SourceColor.GetBrightness
            Amount = (Amount + Amount * ChangePercent)
            If Amount > 1 Then
                Amount = 1
            ElseIf Amount <= 0 Then
                Amount = 0.1F
            End If
            Return CreateColor_FromHsl(SourceColor.A, SourceColor.GetHue(), SourceColor.GetSaturation(), Amount)
        End Function
        Public Function DarkenColor(ByVal SourceColor As Color, ByVal ChangePercent As Single) As Color
            Dim Amount As Single = SourceColor.GetBrightness
            Amount = (Amount - Amount * ChangePercent)
            If Amount > 1 Then
                Amount = 1
            ElseIf Amount < 0 Then
                Amount = 0
            End If
            Return CreateColor_FromHsl(SourceColor.A, SourceColor.GetHue(), SourceColor.GetSaturation(), Amount)
        End Function
#End Region

#Region "Create Color"
        Public Function AdjustValue_WithinThreshold(Min As Single, Max As Single, Value As Single) As Single
            If (Value < Min) Then
                Return 0
            ElseIf (Value > Max) Then
                Return 360
            End If
            Return Value
        End Function
        Public Function CreateColor_FromHsl(ByVal Alpha As Byte, ByVal ColorHue As Single, ByVal ColorSaturation As Single, ByVal Brightness As Single) As Color
            ColorHue = AdjustValue_WithinThreshold(0, 360, ColorHue)
            ColorSaturation = AdjustValue_WithinThreshold(0, 1, ColorSaturation)
            Brightness = AdjustValue_WithinThreshold(0, 1, Brightness)
            If ColorSaturation = 0 Then Return Color.FromArgb(Alpha, Convert.ToInt32(Brightness * 255), Convert.ToInt32(Brightness * 255), Convert.ToInt32(Brightness * 255))


            '//C = (1 - |2xBrightness - 1|) × Saturation
            '//X = C × (1 - |(Hue / 60°) mod 2 - 1|)
            '//m = L - C/2
            '//(R,G,B) = ((R'+m)×255, (G'+m)×255,(B'+m)×255)

            Dim fMax, fMid, fMin As Single
            Dim iSextant, iMax, iMid, iMin As Integer

            If (Brightness > 0.5) Then
                fMax = Brightness - (Brightness * ColorSaturation) + ColorSaturation
                fMin = Brightness + (Brightness * ColorSaturation) - ColorSaturation
            Else
                fMax = Brightness + (Brightness * ColorSaturation)
                fMin = Brightness - (Brightness * ColorSaturation)
            End If

            iSextant = CInt(Math.Floor(ColorHue / 60.0F))

            If ColorHue >= 300 Then ColorHue -= 360.0F
            ColorHue = ColorHue / 60.0F

            ''' 
            ColorHue -= 2.0F * CSng(Math.Floor(((iSextant + 1.0F) Mod 6.0F) / 2.0F))

            If 0 = iSextant Mod 2 Then
                fMid = ColorHue * (fMax - fMin) + fMin
            Else
                fMid = fMin - ColorHue * (fMax - fMin)
            End If

            iMax = Convert.ToInt32(fMax * 255)
            iMid = Convert.ToInt32(fMid * 255)
            iMin = Convert.ToInt32(fMin * 255)

            Return CreateColor_FromDegree(iSextant, Alpha, iMin, iMid, iMax)
        End Function
        Public Function CreateColor_FromDegree(Degree As Integer, Alpha As Integer, iMin As Integer, iMid As Integer, iMax As Integer) As Color
            Select Case Degree
                Case 1 '0 to 59
                    Return Color.FromArgb(Alpha, iMid, iMax, iMin)
                Case 2 '60 to 119
                    Return Color.FromArgb(Alpha, iMin, iMax, iMid)
                Case 3 '120 to 179
                    Return Color.FromArgb(Alpha, iMin, iMid, iMax)
                Case 4 '180 to 239
                    Return Color.FromArgb(Alpha, iMid, iMin, iMax)
                Case 5 '240 to 299
                    Return Color.FromArgb(Alpha, iMax, iMin, iMid)
                Case Else '300 to 360
                    Return Color.FromArgb(Alpha, iMax, iMid, iMin)
            End Select
        End Function
#End Region



    End Module
End Namespace
