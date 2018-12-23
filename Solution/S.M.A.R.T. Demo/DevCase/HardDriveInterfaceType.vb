' This source-code is freely distributed as part of "DevCase for .NET Framework" (previously known as "ElektroKit Framework for .NET").
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

#Region " HardDriveInterfaceType "

Namespace DevCase.Core.IO

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies the interface type of a hard drive.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum HardDriveInterfaceType As Integer

        ''' <summary>
        ''' Hard Disk Controller (HDC) interface.
        ''' </summary>
        HDC

        ''' <summary>
        ''' Integrated Drive Electronics (IDE) interface.
        ''' </summary>
        IDE

        ''' <summary>
        ''' Institute of Electrical and Electronics Engineers (IEEE) 1394 interface.
        ''' </summary>
        IEEE1394

        ''' <summary>
        ''' Small Computer System Interface (SCSI).
        ''' </summary>
        SCSI

        ''' <summary>
        ''' Universal Serial Bus (USB) interface.
        ''' </summary>
        USB

    End Enum

End Namespace

#End Region
