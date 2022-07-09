Imports System.Runtime.CompilerServices

Namespace Extensions
    ''' <summary>
    ''' *** MADE FOR GITHUB ***
    ''' WRITTEN BY ROMULO MEIRELLES.
    ''' UPWORK: https://www.upwork.com/freelancers/~01fcbc5039ac5766b4
    ''' CONTACT WHATSAPP: https://wa.me/message/KWIS3BYO6K24N1
    ''' CONTACT TELEGRAM: https://t.me/Romulo_Meirelles
    ''' GITHUB: https://github.com/Romulo-Meirelles
    ''' DISCORD: đąяķňέs§¢øďε#2786
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Module CryptocurrencyExtensions
        Private Const InaccuracyMessage As String = "Using double to store coin values is not recommended. This can lead to eventual inaccuracies. Please use a decimal value instead."

        <Extension()>
        Public Function ToSatoshi(ByVal coinValue As Decimal) As Long
            Return coinValue * 100000000D
        End Function

        <Extension()>
        Public Function ToSatoshi(ByVal coinValue As Double) As Long
            Return coinValue * 100000000
        End Function

        <Extension()>
        Public Function ToCoinValue(ByVal satoshiValue As Long) As Decimal
            Return satoshiValue / 100000000D
        End Function
    End Module
End Namespace
