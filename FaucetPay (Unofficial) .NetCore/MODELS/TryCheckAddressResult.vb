Namespace Models
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
    Public NotInheritable Class TryCheckAddressResult
        Friend Sub New(ByVal address As String, ByVal currency As String, ByVal isValidAddress As Boolean, ByVal response As CheckAddressResponse)
            Me.Address = address
            Me.Currency = currency
            Me.IsValidAddress = isValidAddress
            Me.Response = response
        End Sub

        Public ReadOnly Property Address As String
        Public Property Currency As String
        Public ReadOnly Property IsValidAddress As Boolean
        Public ReadOnly Property Response As CheckAddressResponse
    End Class
End Namespace
