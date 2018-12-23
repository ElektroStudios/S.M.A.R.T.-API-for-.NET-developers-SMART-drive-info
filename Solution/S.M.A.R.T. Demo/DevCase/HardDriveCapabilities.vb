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

#Region " HardDriveCapabilities "

Namespace DevCase.Core.IO

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Specifies a the capabilities (such as S.M.A.R.T. notification) of a hard drive.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' <see href="https://docs.microsoft.com/en-us/windows/desktop/cimwin32prov/win32-diskdrive"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    Public Enum HardDriveCapabilities As UShort

        Unknown = 0

        Other = 1

        SequentialAccess = 2

        RandomAccess = 3

        SupportsWriting = 4

        Encryption = 5

        Compression = 6

        SupportsRemoveableMedia = 7

        SupportsRemovableMedia

        ManualCleaning = 8

        AutomaticCleaning = 9

        SMARTNotification = 10

        SupportsDualSidedMedia = 11

        PredismountEjectNotRequired = 12

    End Enum

End Namespace

#End Region
