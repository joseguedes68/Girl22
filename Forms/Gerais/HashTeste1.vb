

Imports System.Security.Cryptography
Imports System.Text



Public Class HashTeste1


    Dim textbytes, encryptedtextbytes As Byte()
    Dim rsa As New RSACryptoServiceProvider
    Dim encoder As New UTF8Encoding



    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click




        Dim privateKey As RSACryptoServiceProvider
        Dim sPrivateKeyXML As String


        privateKey = New RSACryptoServiceProvider
        sPrivateKeyXML = "<RSAKeyValue><Modulus>3ItTS1J+IHGJb2tQja56bH+HGBvFSIjsjaeIYzoI7OMChzMp5lAhIiHktaEHsAAmcRc1iXnOKAmuS9z8zFdLPzf9ttv6QKEmjIQ4tnfMVhGUJDeTMUC4TQJw27JlULtzJUKVz9euO3MPnKy3ukzwm43VEpVac4YZajOAvrdZay8=</Modulus><Exponent>AQAB</Exponent><P>+kBhf6S9JjCqa04PG6ypd1eWS4Dw3DOJJbJSysl+wb3O2cc9IHtAjwFB017os+6/cr7yKbroeYGDj6h9Fph7TQ==</P><Q>4Zw/zX40f6lBukpWnp5MpzlHUDbTvdImx6gFWmGwMOZDmJFlGFIwUBA2UakWQ+cHHFL9EJs3AWvTomIQxNBqaw==</Q><DP>7taLNxuvOsevnoH9gVgk1TXOx3jkaAT3m/a5dbkhNR9GUCsLd/iqANIeVPF7/l6acZUz4gf04CJvwaf42pvk8Q==</DP><DQ>MEjKduZNwgytXntOcoAak6d0lbxGMNfrKMvS6XcCyFRfnyVu53efk2ME3RE9DKdDJFK2inlNmmZDUvt970FTpQ==</DQ><InverseQ>7b4zw48bMEc6KXwNFUTAysQTKJ9Nc8bVSDPju2LKOaAlGmIfgX+gbXJ8t0H78g7C59j9K6RIirKLoieiJBLLVw==</InverseQ><D>mVrcMX0MLP0l5u8FVW+kuzs2MiJlXVmwu5NqOC1LtYTo5iBCm17Om1BcG5v8n3qLQIo19QFYw+hvZVsmAeUVcXZVnwrzVn1RvBXwfhQ4GQL/HSMVQgjsHGRkglc6u/FJZDiewdE/WD3uM3KSVL4J6V+5SyVn7hTSseiLSdA2AGk=</D></RSAKeyValue>"

        textbytes = encoder.GetBytes(sPrivateKeyXML)
        privateKey.FromXmlString(sPrivateKeyXML)

        Dim buffer As Byte() = Encoding.GetEncoding("Windows-1252").GetBytes(Me.TextBox1.Text)
        Dim signature As Byte() = privateKey.SignData(buffer, "SHA1")

        TextBox2.Text = Convert.ToBase64String(signature)

    End Sub



End Class