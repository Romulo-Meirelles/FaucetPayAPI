Imports System.Net.Http
Imports FaucetPay.Models
Imports FaucetPay.Config

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

    Public Class HttpClientRequester
        Inherits RequesterBase
        Implements IDisposable

        Private ReadOnly _Client As HttpClient
        Private _DisposeClient As Boolean
        Public Sub New(ByVal Configuration As ApiConfig, ByVal Client As HttpClient)
            MyBase.New(Configuration)
            _Client = Client
        End Sub
        Public Overrides Async Function PostAsync(Of T As FaucetPayResponse)(Resource As String, Optional Parameters As Dictionary(Of String, String) = Nothing, Optional noThrow As Boolean = False) As Task(Of T)
            If Resource = "faucetlist" Then _Client.BaseAddress = New Uri(Configuration.BaseFaucetList)
            Dim Result = Await CreateRequestAsync(Resource, HttpMethod.Post, Parameters).ConfigureAwait(False)
            Dim Response = Await Result.Content.ReadAsStringAsync().ConfigureAwait(False)
            Dim Deserialized = Deserialize(Of T)(Response)
            HandleError(Deserialized.Status, Deserialized.Message, noThrow:=noThrow)
            Return Deserialized
        End Function
        Public Shared Sub ConfigureClient(Client As HttpClient, ByVal Configuration As ApiConfig)
            Client.BaseAddress = New Uri(Configuration.BaseUrl)
        End Sub
        Protected Friend Overridable Function CreateRequestAsync(ByVal Resource As String, ByVal Method As HttpMethod, ByVal Parameters As Dictionary(Of String, String)) As Task(Of HttpResponseMessage)
            Dim content = New FormUrlEncodedContent(CreateParameterPairs(Parameters))
            Return _Client.SendAsync(New HttpRequestMessage(Method, New Uri(Resource, UriKind.Relative)) With {.Content = content})
        End Function
        Public Shared Function Create(ByVal Config As ApiConfig, ByVal Optional Client As HttpClient = Nothing, ByVal Optional DisposeClient As Boolean = False) As HttpClientRequester
            If Client Is Nothing Then DisposeClient = True
            Client = If(Client, New HttpClient())
            HttpClientRequester.ConfigureClient(Client, Config)
            Return New HttpClientRequester(Config, Client) With {._DisposeClient = DisposeClient}
        End Function
        Public Sub Dispose() Implements IDisposable.Dispose
            If _DisposeClient Then _Client.Dispose()
        End Sub
    End Class
End Namespace
