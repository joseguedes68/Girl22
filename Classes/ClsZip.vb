Imports System.IO
Imports System.IO.Compression


Public Class ClsZip


    'Public Shared Sub Main()
    '    Dim path As String = "test.txt"

    '    ' Create the text file if it doesn't already exist.
    '    If Not File.Exists(path) Then
    '        Console.WriteLine("Creating a new test.txt file")
    '        Dim text() As String = {"This is a test text file.", _
    '            "This file will be compressed and written to the disk.", _
    '            "Once the file is written, it can be decompressed", _
    '            "imports various compression tools.", _
    '            "The GZipStream and DeflateStream class use the same", _
    '            "compression algorithms, the primary difference is that", _
    '            "the GZipStream class includes a cyclic redundancy check", _
    '            "that can be useful for detecting data corruption.", _
    '            "One other side note: both the GZipStream and DeflateStream", _
    '            "classes operate on streams as opposed to file-based", _
    '            "compression data is read on a byte-by-byte basis, so it", _
    '            "is not possible to perform multiple passes to determine the", _
    '            "best compression method. Already compressed data can actually", _
    '            "increase in size if compressed with these classes."}

    '        File.WriteAllLines(path, text)
    '    End If

    '    Console.WriteLine("Contents of {0}", path)
    '    Console.WriteLine(File.ReadAllText(path))

    '    CompressFile(path)
    '    Console.WriteLine()

    '    UncompressFile(path + ".gz")
    '    Console.WriteLine()

    '    Console.WriteLine("Contents of {0}", path + ".gz.txt")
    '    Console.WriteLine(File.ReadAllText(path + ".gz.txt"))

    'End Sub

    Public Shared Sub CompressFile(ByVal pathOrigem As String, ByVal pathDestino As String)

        Try

            'TODO: NÃO ESTÁ A FICAR COM A EXTENSÃO NO FICHEIRO QUE FICA DENTRO DO ZIP

            'Dim bfileExists As Boolean = My.Computer.FileSystem.FileExists(xBackupPath + pathDestino)
            'If bfileExists Then
            '    EnviarEmail("ERRO ClsZip CompressFile FICHEIRO DE DESTINO JÁ EXISTE!!!")
            '    Exit Sub
            'End If

            Dim sourceFile As FileStream = File.OpenRead(pathOrigem)
            Dim destinationFile As FileStream = File.Create(pathDestino)
            Dim buffer(sourceFile.Length) As Byte
            sourceFile.Read(buffer, 0, buffer.Length)

            Using output As New GZipStream(destinationFile, CompressionMode.Compress)
                output.Write(buffer, 0, buffer.Length)
            End Using

            sourceFile.Close()
            destinationFile.Close()

        Catch ex As Exception
            ErroVB(ex.Message, "CompressFile")
        Finally

        End Try


    End Sub

    Public Shared Sub UncompressFile(ByVal path As String)
        Dim sourceFile As FileStream = File.OpenRead(path)
        'Dim destinationFile As FileStream = File.Create(path + ".txt")
        Dim destinationFile As FileStream = File.Create(path.Replace(".gz", ""))

        ' Because the uncompressed size of the file is unknown, 
        ' we are imports an arbitrary buffer size.
        Dim buffer(4096) As Byte
        Dim n As Integer

        Using input As New GZipStream(sourceFile, CompressionMode.Decompress, False)

            'Console.WriteLine("Decompressing {0} to {1}.", sourceFile.Name, _
            '    destinationFile.Name)

            n = input.Read(buffer, 0, buffer.Length)
            destinationFile.Write(buffer, 0, n)
        End Using

        ' Close the files.
        sourceFile.Close()
        destinationFile.Close()
    End Sub

    'Shared msg As String

    'Public Shared Function ReadAllBytesFromStream(ByVal stream As Stream, ByVal buffer() As Byte) As Integer
    '    ' Use this method is used to read all bytes from a stream.
    '    Dim offset As Integer = 0
    '    Dim totalCount As Integer = 0
    '    While True
    '        Dim bytesRead As Integer = stream.Read(buffer, offset, 100)
    '        If bytesRead = 0 Then
    '            Exit While
    '        End If
    '        offset += bytesRead
    '        totalCount += bytesRead
    '    End While
    '    Return totalCount
    'End Function 'ReadAllBytesFromStream

    'Public Shared Function CompareData(ByVal buf1() As Byte, ByVal len1 As Integer, ByVal buf2() As Byte, ByVal len2 As Integer) As Boolean
    '    ' Use this method to compare data from two different buffers.
    '    If len1 <> len2 Then
    '        msg = "Number of bytes in two buffer are different" & len1 & ":" & len2
    '        MsgBox(msg)
    '        Return False
    '    End If

    '    Dim i As Integer
    '    For i = 0 To len1 - 1
    '        If buf1(i) <> buf2(i) Then
    '            msg = "byte " & i & " is different " & buf1(i) & "|" & buf2(i)
    '            MsgBox(msg)
    '            Return False
    '        End If
    '    Next i
    '    msg = "All bytes compare."
    '    MsgBox(msg)
    '    Return True
    'End Function 'CompareData

    'Public Shared Sub GZipCompressDecompress(ByVal filename As String)
    '    msg = "Test compression and decompression on file " & filename
    '    MsgBox(msg)

    '    Dim infile As FileStream
    '    Try
    '        ' Open the file as a FileStream object.
    '        infile = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)
    '        Dim buffer(infile.Length - 1) As Byte
    '        ' Read the file to ensure it is readable.
    '        Dim count As Integer = infile.Read(buffer, 0, buffer.Length)
    '        If count <> buffer.Length Then
    '            infile.Close()
    '            msg = "Test Failed: Unable to read data from file"
    '            MsgBox(msg)
    '            Return
    '        End If

    '        infile.Close()
    '        Dim ms As New MemoryStream()
    '        ' Use the newly created memory stream for the compressed data.
    '        Dim compressedzipStream As New GZipStream(ms, CompressionMode.Compress, True)
    '        compressedzipStream.Write(buffer, 0, buffer.Length)
    '        ' Close the stream.
    '        compressedzipStream.Close()

    '        msg = "Original size: " & buffer.Length & ", Compressed size: " & ms.Length
    '        MsgBox(msg)

    '        ' Reset the memory stream position to begin decompression.
    '        ms.Position = 0
    '        Dim zipStream As New GZipStream(ms, CompressionMode.Decompress)
    '        Dim decompressedBuffer(buffer.Length + 100) As Byte
    '        ' Use the ReadAllBytesFromStream to read the stream.
    '        Dim totalCount As Integer = ReadAllBytesFromStream(zipStream, decompressedBuffer)
    '        msg = "Decompressed " & totalCount & " bytes"
    '        MsgBox(msg)

    '        If Not CompareData(buffer, buffer.Length, decompressedBuffer, totalCount) Then
    '            msg = "Error. The two buffers did not compare."
    '            MsgBox(msg)

    '        End If
    '        zipStream.Close()
    '    Catch e As Exception
    '        msg = "Error: The file being read contains invalid data."
    '        MsgBox(msg)
    '    End Try

    'End Sub 'GZipCompressDecompress

    'Public Shared Sub Main(ByVal args() As String)
    '    Dim usageText As String = "Usage: GZIPTEST <inputfilename>"
    '    'If no file name is specified, write usage text.
    '    If args.Length = 0 Then
    '        Console.WriteLine(usageText)
    '    Else
    '        If File.Exists(args(0)) Then
    '            GZipCompressDecompress(args(0))
    '        End If
    '    End If
    'End Sub 'Main


End Class
