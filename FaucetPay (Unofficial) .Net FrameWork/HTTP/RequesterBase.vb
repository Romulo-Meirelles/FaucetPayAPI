Imports FaucetPay.Models
Imports FaucetPay.Config
Imports FaucetPay.Exceptions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization


Namespace Http
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
    Public MustInherit Class RequesterBase
        Implements IRequester
        Public Sub New(ByVal configuration As ApiConfig)
            Me.Configuration = configuration
            configuration.Check()
        End Sub

        Private Shared ReadOnly Settings As JsonSerializerSettings = New JsonSerializerSettings With {
                .ContractResolver = New DefaultContractResolver With {
                .NamingStrategy = New SnakeCaseNamingStrategy()
                        }
                    }

        Protected Overridable Function Deserialize(Of T)(json As String) As T
            Return JsonConvert.DeserializeObject(Of T)(json, Settings)
        End Function
        Protected Overridable Function Serialize(ByVal obj As Object) As String
            Return JsonConvert.SerializeObject(obj, Settings)
        End Function

        Protected Iterator Function CreateParameterPairs(ByVal Optional source As IEnumerable(Of KeyValuePair(Of String, String)) = Nothing) As IEnumerable(Of KeyValuePair(Of String, String))
            Yield New KeyValuePair(Of String, String)("api_key", Configuration.ApiKey)
            If source Is Nothing Then Return
            For Each item In source
                Yield item
            Next
        End Function
        Public ReadOnly Property Configuration As ApiConfig Implements IRequester.Configuration

        Public Shared Sub HandleError(ByVal statusCode As Integer, ByVal message As String, ByVal Optional innerException As Exception = Nothing, ByVal Optional noThrow As Boolean = False)
            If noThrow Then Return
            If statusCode >= 200 AndAlso statusCode <= 299 Then Return ' Success!
            Throw New FaucetPayException(message, statusCode, innerException)
        End Sub

        Public MustOverride Function PostAsync(Of T As FaucetPayResponse)(ByVal resource As String, ByVal Optional parameters As Dictionary(Of String, String) = Nothing, ByVal Optional noThrow As Boolean = False) As Task(Of T) Implements IRequester.PostAsync
    End Class
End Namespace
