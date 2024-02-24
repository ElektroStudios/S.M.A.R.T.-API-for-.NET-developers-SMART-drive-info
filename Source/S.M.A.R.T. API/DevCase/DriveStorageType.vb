' This source-code is freely distributed as part of "DevCase Class Library for .NET developers".
' 
' Maybe you would like to consider to buy this powerful set of libraries to support me. 
' You can do loads of things with my apis for a big amount of diverse thematics.
' 
' Here is a link to the purchase page:
' https://codecanyon.net/item/elektrokit-class-library-for-net/19260282
' 
' Thank you.

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " DriveStorageType "

Namespace DevCase.Core.IO

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies the storage type of a drive.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum DriveStorageType As Integer

        ''' <summary>
        ''' Drive storage is connected within the computer chassis. 
        ''' Usually the drive is a hard disk drive (HDD) or solid-state drive (SSD).
        ''' </summary>
        InternalStorage

        ''' <summary>
        ''' Drive storage is connected from outside the chassis, usually by USB or eSATA.
        ''' </summary>
        ExternalStorage

    End Enum

End Namespace

#End Region
