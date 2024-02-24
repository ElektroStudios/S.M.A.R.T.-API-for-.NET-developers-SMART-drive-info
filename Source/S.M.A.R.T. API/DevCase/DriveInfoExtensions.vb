' This source-code is freely distributed as part of "DevCase Class Library for .NET developers".
' 
' Maybe you would like to consider to buy this powerful set of libraries to support me. 
' You can do loads of things with my apis for a big amount of diverse thematics.
' 
' Here is a link to the purchase page:
' https://codecanyon.net/item/elektrokit-class-library-for-net/19260282
' 
' Thank you.

#Region " Public Members Summary "

#Region " Functions "

' DriveInfo.GetDriveLetter() As Char

#End Region

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

#End Region

#Region " DriveInfo Extensions "

Namespace DevCase.Core.Extensions.[DriveInfo]

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains custom extension methods to use with <see cref="Global.System.IO.DriveInfo"/> type.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <HideModuleName>
    Public Module DriveInfoExtensions

#Region " Public Extension Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the drive letter of the source <see cref="Global.System.IO.DriveInfo"/>.
        ''' </summary>
        ''' ---------------------------------------------------------------------------------------------------- 
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim dInfo As DriveInfo = DriveInfo.GetDrives()(0)
        ''' Dim dLetter As Char = GetDriveLetter(dInfo)
        ''' 
        ''' Console.WriteLine(dLetter)
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source <see cref="Global.System.IO.DriveInfo"/>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting drive letter.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        <Extension>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetDriveLetter(ByVal sender As Global.System.IO.DriveInfo) As Char

            Return CChar(sender.Name.TrimEnd({"\"c, ":"c})) ' or using LINQ: Return sender.Name.First()

        End Function

#End Region

    End Module

End Namespace

#End Region
