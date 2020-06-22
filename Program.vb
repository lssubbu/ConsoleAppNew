Imports System
Imports System.Globalization
Imports System.Text
Imports System.IO

'add comment 22jun20
Module Program

    Function _generateFileName(ByVal sequence As Integer) As String
        Dim currentDateTime As DateTime = DateTime.Now

        Return "test.txt"
        Return String.Format("{0}-{1:000}-{2:000}.txt",
                            currentDateTime.ToString("yyyyMMddHHmmss", New CultureInfo("en-US")),
                            currentDateTime.Millisecond,
                            sequence)
    End Function

    Sub Main(args As String())
        Try
            ' Create a folder named "inbox" under current directory
            ' to save the email retrieved.
            Dim localInbox As String = String.Format("{0}\inbox", Directory.GetCurrentDirectory())

            ' If the folder is not existed, create it.
            If Not Directory.Exists(localInbox) Then
                Directory.CreateDirectory(localInbox)
            End If
            Dim i As Integer
            i = 1

            Dim fileName As String = _generateFileName(i + 1)
            Dim fullPath As String = String.Format("{0}\{1}", localInbox, fileName)

            If System.IO.File.Exists(fullPath) = True Then

                Dim objWriter As New System.IO.StreamWriter(fullPath)

                objWriter.Write(DateTime.Now)
                objWriter.Close()


            Else

                'MessageBox.Show("File Does Not Exist")

            End If


            Console.WriteLine("Completed!")

        Catch ep As Exception
            Console.WriteLine(ep.Message)
        End Try
    End Sub
End Module
