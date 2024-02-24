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

#Region " Properties "

' ProcessorId() As String

' ProcessorSpeed As Integer

' ProcessorMaxSpeed As Integer

' MotherboardId() As String

' PrinterNames() As IEnumerable(Of String)

#End Region

#Region " Functions "

' GetDriveFreeSpace(Char) As Long

' GetDriveSize(Char) As Long

' GetDrivesInfoOf(DriveType) As IEnumerable(Of DriveInfo)

' GetDriveInfo(Char) As DriveInfo

' TryGetDriveInfo(Char, DriveInfo) As Boolean

' FormatDrive(Char, Boolean, Opt: DriveFileSystem, Opt: Integer, Opt: String, Opt: Boolean) As DriveFormatResult

' SetPrimaryScreenResolution(Integer, Integer)
' SetPrimaryScreenResolution(Size)

' GetHardDriveHandle(DriveInfo) As SafeFileHandle
' GetHardDriveHandle(Char) As SafeFileHandle

' GetWin32DiskDrive(DriveInfo) As ManagementObject
' GetWin32DiskDrive(Char) As ManagementObject

' GetWin32LogicalDisk(DriveInfo) As ManagementObject
' GetWin32LogicalDisk(Char) As ManagementObject

#End Region

#Region " Methods "

' BlockInput()
' UnblockInput()

#End Region

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System.Diagnostics
Imports System.IO
Imports System.Management
Imports System.Linq

#End Region

#Region " Devices Util "

Namespace DevCase.Core.IO.Tools

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains devices related utilities.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class DeviceUtil

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="DeviceUtil"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns the corresponding <see cref="DriveInfo"/> for the specified drive letter.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim driveInfo As DriveInfo = GetDriveInfo("C"c)
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The drive letter, such as "C" or "D".
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting <see cref="DriveInfo"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentException">
        ''' No drive found with the specified drive letter.
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetDriveInfo(ByVal driveLetter As Char) As DriveInfo

            ' This function replaces "My.Computer.FileSystem.GetDriveInfo()", 
            ' which always returns an object even if there Is no mounted/mapped drive with the specified name/letter.

            Dim driveInfo As DriveInfo = DriveInfo.GetDrives.Where(Function(di) (String.Compare(DevCase.Core.Extensions.DriveInfo.GetDriveLetter(di), driveLetter, StringComparison.OrdinalIgnoreCase) = 0)).SingleOrDefault()
            If (driveInfo Is Nothing) Then
                Throw New ArgumentException("No drive found with the specified drive letter.", paramName:=NameOf(driveLetter))
            End If
            Return driveInfo

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a <see cref="ManagementObject"/> which wraps a instance of 'Win32_DiskDrive' WMI class for the specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim driveInfo As DriveInfo = My.Computer.FileSystem.GetDriveInfo("C"c)
        ''' Using win32DiskDrive As ManagementObject = GetWin32DiskDrive(driveInfo)
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("Name").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("Model").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("SerialNumber").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("DeviceID").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("PNPDeviceID").ToString())
        ''' End Using
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveInfo">
        ''' A <see cref="System.IO.DriveInfo"/> instance that represents the drive.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="ManagementObject"/> which wraps a instance of 'Win32_DiskDrive' WMI class for the specified drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetWin32DiskDrive(ByVal driveInfo As DriveInfo) As ManagementObject

            Dim connOptions As New ConnectionOptions With {
                .Impersonation = ImpersonationLevel.Impersonate,
                .EnablePrivileges = True
            }

            Dim scope As New ManagementScope(String.Format("\\{0}\ROOT\CIMV2", Environment.MachineName), connOptions)
            scope.Connect()

            Dim getOptions As New ObjectGetOptions With {
                .UseAmendedQualifiers = False
            }

            Dim driveLetter As Char = DevCase.Core.Extensions.DriveInfo.GetDriveLetter(driveInfo)
            Dim path As New ManagementPath(String.Format("Win32_LogicalDisk.DeviceId='{0}:'", driveLetter))

            Using logicalDisk As New ManagementObject(scope, path, getOptions),
                  diskPartitionCollection As ManagementObjectCollection = logicalDisk.GetRelated("Win32_DiskPartition"),
                  diskPartition As ManagementObject = DirectCast(diskPartitionCollection(0), ManagementObject),
                  diskDriveCollection As ManagementObjectCollection = diskPartition.GetRelated("Win32_DiskDrive")

                Return DirectCast(diskDriveCollection(0), ManagementObject)

            End Using

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a <see cref="ManagementObject"/> which wraps a instance of 'Win32_DiskDrive' WMI class for the specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Using win32DiskDrive As ManagementObject = GetWin32DiskDrive("C"c)
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("Name").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("Model").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("SerialNumber").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("DeviceID").ToString())
        '''     Console.WriteLine(win32DiskDrive.GetPropertyValue("PNPDeviceID").ToString())
        ''' End Using
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The drive letter, such as "C" or "D".
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="ManagementObject"/> which wraps a instance of 'Win32_DiskDrive' WMI class for the specified drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetWin32DiskDrive(ByVal driveLetter As Char) As ManagementObject

            Dim driveInfo As DriveInfo = DeviceUtil.GetDriveInfo(driveLetter)
            Return DeviceUtil.GetWin32DiskDrive(driveInfo)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a <see cref="ManagementObject"/> which wraps a instance of 'Win32_LogicalDisk' WMI class for the specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim driveInfo As DriveInfo = My.Computer.FileSystem.GetDriveInfo("C"c)
        ''' Using win32LogicalDisk As ManagementObject = GetWin32LogicalDisk(driveInfo)
        '''     Console.WriteLine(win32LogicalDisk.GetPropertyValue("Name").ToString())
        '''     Console.WriteLine(win32LogicalDisk.GetPropertyValue("FileSystem").ToString())
        ''' End Using
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveInfo">
        ''' A <see cref="System.IO.DriveInfo"/> instance that represents the drive.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="ManagementObject"/> which wraps a instance of 'Win32_LogicalDisk' WMI class for the specified drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetWin32LogicalDisk(ByVal driveInfo As DriveInfo) As ManagementObject

            Dim connOptions As New ConnectionOptions With {
                .Impersonation = ImpersonationLevel.Impersonate,
                .EnablePrivileges = True
            }

            Dim scope As New ManagementScope(String.Format("\\{0}\ROOT\CIMV2", Environment.MachineName), connOptions)
            scope.Connect()

            Dim getOptions As New ObjectGetOptions With {
                .UseAmendedQualifiers = False
            }

            Dim driveLetter As Char = DevCase.Core.Extensions.DriveInfo.GetDriveLetter(driveInfo)
            Dim path As New ManagementPath(String.Format("Win32_LogicalDisk.DeviceId='{0}:'", driveLetter))

            Return New ManagementObject(scope, path, getOptions)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a <see cref="ManagementObject"/> which wraps a instance of 'Win32_LogicalDisk' WMI class for the specified drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Using win32LogicalDisk As ManagementObject = GetWin32LogicalDisk("C"c)
        '''     Console.WriteLine(win32LogicalDisk.GetPropertyValue("Name").ToString())
        '''     Console.WriteLine(win32LogicalDisk.GetPropertyValue("FileSystem").ToString())
        ''' End Using
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The drive letter, such as "C" or "D".
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="ManagementObject"/> which wraps a instance of 'Win32_LogicalDisk' WMI class for the specified drive.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetWin32LogicalDisk(ByVal driveLetter As Char) As ManagementObject

            Dim driveInfo As DriveInfo = DeviceUtil.GetDriveInfo(driveLetter)
            Return DeviceUtil.GetWin32LogicalDisk(driveInfo)

        End Function

#End Region

    End Class

End Namespace

#End Region
