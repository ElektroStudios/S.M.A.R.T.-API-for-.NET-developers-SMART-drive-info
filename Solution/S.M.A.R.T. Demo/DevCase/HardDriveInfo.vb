' This source-code is freely distributed as part of "DevCase for .NET Framework" (previously known as "ElektroKit Framework for .NET").
' 
' Maybe you would like to consider to buy this powerful set of libraries to support me. 
' You can do loads of things with my apis for a big amount of diverse thematics.
' 
' Here is a link to the purchase page:
' https://codecanyon.net/item/elektrokit-class-library-for-net/19260282
' 
' Thank you.

#Region " Public Members Summary "

#Region " Constructors "

' New(DriveInfo)
' New(Char)

#End Region

#Region " Properties "

' AvailableFreeSpace As Long
' BlockSize As Long
' BytesPerSector As Integer
' Capabilities As HardDriveCapabilities
' DeviceId As String
' DriveFormat As String
' FirmwareRevision As String
' Index As Integer
' InterfaceType As HardDriveInterfaceType
' IsReady As Boolean
' MediaType As HardDriveType
' Model As String
' Name As String
' NumberOfBlocks As Long
' Partitions As Integer
' PnpDeviceId As String
' RootDirectory As DirectoryInfo
' SectorsPerTrack As Integer
' SerialNumber As String
' SMART As SMART
' TotalCylinders As Long
' TotalFreeSpace As Long
' TotalHeads As Integer
' TotalSectors As Long
' TotalSize As Long
' TotalTracks As Long
' TracksPerCylinder As Integer
' VolumeLabel As String

#End Region

#Region " Functions "

' GetDrives() As IEnumerable(Of HardDriveInfo)

#End Region

#Region " Methods "

' Refresh()

#End Region

#End Region

#Region " Usage Examples "

' Dim hdds As IEnumerable(Of HardDriveInfo) = HardDriveInfo.GetDrives()
'
' For Each hdd As HardDriveInfo In hdds
' 
'     ' System.IO.DriveInfo properties
'     Console.WriteLine("{0}: {1}", NameOf(hdd.Name), hdd.Name)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.RootDirectory), hdd.RootDirectory.FullName)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.VolumeLabel), hdd.VolumeLabel)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.DriveFormat), hdd.DriveFormat)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.IsReady), hdd.IsReady)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalSize), hdd.TotalSize)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.AvailableFreeSpace), hdd.AvailableFreeSpace)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalFreeSpace), hdd.TotalFreeSpace)
' 
'     ' Win32_DiskDrive properties
'     Console.WriteLine("{0}: {1}", NameOf(hdd.BytesPerSector), hdd.BytesPerSector)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.Capabilities), String.Join(", ", hdd.Capabilities))
'     Console.WriteLine("{0}: {1}", NameOf(hdd.DeviceId), hdd.DeviceId)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.FirmwareRevision), hdd.FirmwareRevision)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.Index), hdd.PhysicalIndex)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.InterfaceType), hdd.InterfaceType)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.MediaType), hdd.MediaType.ToString())
'     Console.WriteLine("{0}: {1}", NameOf(hdd.Model), hdd.Model)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.Partitions), hdd.Partitions)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.PnpDeviceId), hdd.PnpDeviceId)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.SectorsPerTrack), hdd.SectorsPerTrack)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.SerialNumber), hdd.SerialNumber)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalCylinders), hdd.TotalCylinders)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalHeads), hdd.TotalHeads)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalSectors), hdd.TotalSectors)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalTracks), hdd.TotalTracks)
'     Console.WriteLine("{0}: {1}", NameOf(hdd.TracksPerCylinder), hdd.TracksPerCylinder)
' 
'     ' S.M.A.R.T. Attributes
'     Console.WriteLine()
'     Console.WriteLine("S.M.A.R.T. Attributes:")
'     Dim sb As New StringBuilder()
'     For Each attr As SmartAttribute In hdd.SMART.Attributes
' 
'         sb.AppendFormat("Id: {0:X2}, Name: {1,-30}, Current: {2,3}, Worst: {3,3}, Threshold: {4,3}, RAW: {5,12:X12}, IsHealthOk?: {6}",
'                         attr.Id, attr.Name,
'                         attr.CurrentValue, attr.WorstValue, attr.Threshold, attr.RawValue32,
'                         attr.IsHealthOk)
'         sb.AppendLine()
' 
'     Next
'     Console.WriteLine(sb.ToString())
'     Console.WriteLine()
' 
' Next hdd

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System.IO
Imports System.Management

Imports DevCase.Core.IO.Tools

#End Region

#Region " HardDriveInfo "

Namespace DevCase.Core.IO

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Provides access to information on a hard drive.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim hdds As IEnumerable(Of HardDriveInfo) = HardDriveInfo.GetDrives()
    ''' 
    ''' For Each hdd As HardDriveInfo In hdds
    ''' 
    '''     ' System.IO.DriveInfo properties
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.Name), hdd.Name)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.RootDirectory), hdd.RootDirectory.FullName)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.VolumeLabel), hdd.VolumeLabel)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.DriveFormat), hdd.DriveFormat)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.IsReady), hdd.IsReady)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalSize), hdd.TotalSize)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.AvailableFreeSpace), hdd.AvailableFreeSpace)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalFreeSpace), hdd.TotalFreeSpace)
    ''' 
    '''     ' Win32_DiskDrive properties
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.BytesPerSector), hdd.BytesPerSector)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.Capabilities), String.Join(", ", hdd.Capabilities))
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.DeviceId), hdd.DeviceId)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.FirmwareRevision), hdd.FirmwareRevision)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.Index), hdd.PhysicalIndex)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.InterfaceType), hdd.InterfaceType)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.MediaType), hdd.MediaType.ToString())
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.Model), hdd.Model)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.Partitions), hdd.Partitions)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.PnpDeviceId), hdd.PnpDeviceId)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.SectorsPerTrack), hdd.SectorsPerTrack)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.SerialNumber), hdd.SerialNumber)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalCylinders), hdd.TotalCylinders)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalHeads), hdd.TotalHeads)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalSectors), hdd.TotalSectors)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TotalTracks), hdd.TotalTracks)
    '''     Console.WriteLine("{0}: {1}", NameOf(hdd.TracksPerCylinder), hdd.TracksPerCylinder)
    ''' 
    '''     ' S.M.A.R.T. Attributes
    '''     Console.WriteLine()
    '''     Console.WriteLine("S.M.A.R.T. Attributes:")
    '''     Dim sb As New StringBuilder()
    '''     For Each attr As SmartAttribute In hdd.SMART.Attributes
    ''' 
    '''         sb.AppendFormat("Id: {0:X2}, Name: {1,-30}, Current: {2,3}, Worst: {3,3}, Threshold: {4,3}, RAW: {5,12:X12}, IsHealthOk?: {6}",
    '''                         attr.Id, attr.Name,
    '''                         attr.CurrentValue, attr.WorstValue, attr.Threshold, attr.RawValue32,
    '''                         attr.IsHealthOk)
    '''         sb.AppendLine()
    ''' 
    '''     Next
    '''     Console.WriteLine(sb.ToString())
    '''     Console.WriteLine()
    ''' 
    ''' Next hdd
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    <TypeConverter(GetType(ExpandableObjectConverter))>
    <Category(NameOf(HardDriveInfo))>
    <Description("Provides access to information on a hard drive.")>
    <Serializable>
    Public Class HardDriveInfo

#Region " Private Fields "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The <see cref="System.IO.DriveInfo"/> instance that represents the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private ReadOnly driveInfo As DriveInfo

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A <see cref="ManagementObject"/> which wraps a instance of 'Win32_DiskDrive' WMI class for the specified hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private win32DiskDrive As ManagementObject

#End Region

#Region " Properties "

#Region " System.IO.DriveInfo "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the name of the hard drive, such as C:\.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The name of the hard drive, such as C:\.")>
        <Category("Filesystem")>
        Public ReadOnly Property Name As String
            Get
                Return Me.driveInfo.Name
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the name of the file system, such as NTFS or FAT32.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The name of the file system, such as NTFS or FAT32.")>
        <DisplayName("Drive Format")>
        <Category("Filesystem")>
        Public ReadOnly Property DriveFormat As String
            Get
                Return Me.driveInfo.DriveFormat
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value that indicates whether a drive is ready.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("A value that indicates whether a drive is ready.")>
        <DisplayName("Is Ready?")>
        <Category("Media")>
        Public ReadOnly Property IsReady As Boolean
            Get
                Return Me.driveInfo.IsReady
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the amount of available free space on a drive, in bytes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The amount of available free space on a drive, in bytes.")>
        <DisplayName("Available Free Space")>
        <Category("Size")>
        Public ReadOnly Property AvailableFreeSpace As Long
            Get
                Return Me.driveInfo.AvailableFreeSpace
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the total amount of free space available on a drive, in bytes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The total amount of free space available on a drive, in bytes.")>
        <DisplayName("Total Free Space")>
        <Category("Size")>
        Public ReadOnly Property TotalFreeSpace As Long
            Get
                Return Me.driveInfo.TotalFreeSpace
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the total size of storage space on a drive, in bytes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The total size of storage space on a drive, in bytes.")>
        <DisplayName("Total Size")>
        <Category("Size")>
        Public ReadOnly Property TotalSize As Long
            Get
                Return Me.driveInfo.TotalSize
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the root directory of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The root directory of the hard drive.")>
        <DisplayName("Root Directory")>
        <Category("Filesystem")>
        Public ReadOnly Property RootDirectory As DirectoryInfo
            Get
                Return Me.driveInfo.RootDirectory
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the volume label of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The volume label of the hard drive.")>
        <DisplayName("Volume Label")>
        <Category("Filesystem")>
        <[ReadOnly](True)>
        Public Property VolumeLabel As String
            Get
                Return Me.driveInfo.VolumeLabel
            End Get
            Set(value As String)
                Me.driveInfo.VolumeLabel = value
            End Set
        End Property

#End Region

#Region " Win32_DiskDrive (WMI class) "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the mumber of bytes in each sector for the physical disk drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The mumber of bytes in each sector for the physical disk drive")>
        <DisplayName("Bytes Per Sector")>
        <Category("Filesystem")>
        Public ReadOnly Property BytesPerSector As Integer
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.bytesPerSectorB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The mumber of bytes in each sector for the physical disk drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private bytesPerSectorB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the capabilities (such as S.M.A.R.T. notification) of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The capabilitie (such as S.M.A.R.T. notification) of the hard drive.")>
        <Browsable(False)>
        <[ReadOnly](True)>
        <Category("Media")>
        Public ReadOnly Property Capabilities As HardDriveCapabilities()
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.capabilitiesB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The capabilities (such as S.M.A.R.T. notification) of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private capabilitiesB As HardDriveCapabilities()

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the names of the capabilities (such as S.M.A.R.T. notification) of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The names of the capabilities (such as S.M.A.R.T. notification) of the hard drive")>
        <DisplayName(NameOf(HardDriveInfo.Capabilities))>
        <Category("Manufacturer")>
        Public ReadOnly Property CapabilitiesNames As String
            Get
                Return String.Join(", ", Me.Capabilities)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the unique identifier of the disk drive on the system.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The unique identifier of the disk drive on the system.")>
        <DisplayName("Device Id.")>
        <Category("Media")>
        Public ReadOnly Property DeviceId As String
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.deviceIdB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The unique identifier of the disk drive on the system.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private deviceIdB As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the revision for the hard drive firmware that is assigned by the manufacturer.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The revision for the hard drive firmware that is assigned by the manufacturer.")>
        <DisplayName("Firmware Revision")>
        <Category("Manufacturer")>
        Public ReadOnly Property FirmwareRevision As String
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.firmwareRevisionB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The revision for the hard drive firmware that is assigned by the manufacturer.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private firmwareRevisionB As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the physical drive index of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The physical drive index of the hard drive.")>
        <DisplayName("Index")>
        <Category("Media")>
        Public ReadOnly Property Index As Integer
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.indexB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The physical drive index of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private indexB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the interface type of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The interface type of the hard drive.")>
        <DisplayName("Interface Type")>
        <Category("Media")>
        Public ReadOnly Property InterfaceType As HardDriveInterfaceType
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.interfaceTypeB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The interface type of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private interfaceTypeB As HardDriveInterfaceType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the type of hard drive media.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The type of hard drive media.")>
        <DisplayName("Storage Type")>
        <Category("Media")>
        Public ReadOnly Property MediaType As DriveStorageType
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.mediaTypeB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The type of hard drive media.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private mediaTypeB As DriveStorageType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the manufacturer's model number of the disk drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The manufacturer's model number of the disk drive.")>
        <Category("Manufacturer")>
        Public ReadOnly Property Model As String
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.modelB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The manufacturer's model number of the disk drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private modelB As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the number of partitions on this hard drive that are recognized by the operating system.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The number of partitions on this hard drive that are recognized by the operating system.")>
        <DisplayName("Partitions")>
        <Category("Filesystem")>
        Public ReadOnly Property Partitions As Integer
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.partitionsB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The number of partitions on this hard drive that are recognized by the operating system.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private partitionsB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the Windows Plug and Play (PNP) device identifier of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The Windows Plug and Play (PNP) device identifier of the hard drive.")>
        <DisplayName("PNP Device Id.")>
        <Category("Media")>
        Public ReadOnly Property PnpDeviceId As String
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.pnpDeviceIdB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The Windows Plug and Play (PNP) device identifier of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private pnpDeviceIdB As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the number of sectors in each track for this hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The number of sectors in each track for this hard drive.")>
        <DisplayName("Sectors Per Track")>
        <Category("Filesystem")>
        Public ReadOnly Property SectorsPerTrack As Integer
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.sectorsPerTrackB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The number of sectors in each track for this hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private sectorsPerTrackB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the number allocated by the manufacturer to identify the physical media.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The number allocated by the manufacturer to identify the physical media.")>
        <DisplayName("Serial Number")>
        <Category("Manufacturer")>
        Public ReadOnly Property SerialNumber As String
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return If(Not Me.serialNumberB.Equals("0"), Me.serialNumberB, String.Empty)
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The number allocated by the manufacturer to identify the physical media.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private serialNumberB As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the total number of cylinders on the hard drive. 
        ''' <para></para>
        ''' Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. 
        ''' <para></para>
        ''' The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. 
        ''' <para></para>
        ''' Consult the manufacturer for accurate drive specifications.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The total number of cylinders on the hard drive.")>
        <DisplayName("Total Cylinders")>
        <Category("Filesystem")>
        Public ReadOnly Property TotalCylinders As Long
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.totalCylindersB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The total number of cylinders on the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private totalCylindersB As Long

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the total number of heads on the hard drive. 
        ''' <para></para>
        ''' Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. 
        ''' <para></para>
        ''' The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. 
        ''' <para></para>
        ''' Consult the manufacturer for accurate drive specifications.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The total number of heads on the hard drive.")>
        <DisplayName("Total Heads")>
        <Category("Filesystem")>
        Public ReadOnly Property TotalHeads As Integer
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.totalHeadsB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The Total number of heads on the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private totalHeadsB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the total number of sectors on the physical disk drive. 
        ''' <para></para>
        ''' Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. 
        ''' <para></para>
        ''' The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. 
        ''' <para></para>
        ''' Consult the manufacturer for accurate drive specifications.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The total number of sectors on the physical disk drive.")>
        <DisplayName("Total Sectors")>
        <Category("Filesystem")>
        Public ReadOnly Property TotalSectors As Long
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.totalSectorsB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The total number of sectors on the physical disk drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private totalSectorsB As Long

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the total number of tracks on the physical disk drive. 
        ''' <para></para>
        ''' Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. 
        ''' <para></para>
        ''' The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. 
        ''' <para></para>
        ''' Consult the manufacturer for accurate drive specifications.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The total number of tracks on the physical disk drive.")>
        <DisplayName("Total Tracks")>
        <Category("Filesystem")>
        Public ReadOnly Property TotalTracks As Long
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.totalTracksB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The total number of tracks on the physical disk drive
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private totalTracksB As Long

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the number of tracks in each cylinder on the physical disk drive. 
        ''' <para></para>
        ''' Note: the value for this property is obtained through extended functions of BIOS interrupt 13h. 
        ''' <para></para>
        ''' The value may be inaccurate if the drive uses a translation scheme to support high-capacity disk sizes. 
        ''' <para></para>
        ''' Consult the manufacturer for accurate drive specifications.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The number of tracks in each cylinder on the physical disk drive.")>
        <DisplayName("Tracks Per Cylinder")>
        <Category("Filesystem")>
        Public ReadOnly Property TracksPerCylinder As Integer
            Get
                If (Me.win32DiskDrive Is Nothing) Then
                    Me.BuildWin32DiskDriveProperties()
                End If
                Return Me.tracksPerCylinderB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The number of tracks in each cylinder on the physical disk drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private tracksPerCylinderB As Integer

#End Region

#Region " S.M.A.R.T. "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the S.M.A.R.T. information of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The S.M.A.R.T. information of the hard drive.")>
        <DisplayName("S.M.A.R.T.")>
        <Category("S.M.A.R.T.")>
        Public ReadOnly Property SMART As SMART
            Get
                If Not Me.Capabilities.Contains(HardDriveCapabilities.SMARTNotification) Then
                    Return Nothing
                End If
                If (Me.smartB Is Nothing) Then
                    Me.smartB = New SMART(Me.driveInfo)
                End If
                Return Me.smartB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing Field )
        ''' The S.M.A.R.T. information of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private smartB As SMART

#End Region

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="HardDriveInfo"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="HardDriveInfo"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveInfo">
        ''' A <see cref="System.IO.DriveInfo"/> instance that represents the hard drive.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentException">
        ''' The specified drive is not a hard drive.
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(ByVal driveInfo As DriveInfo)

            If (driveInfo.DriveType <> System.IO.DriveType.Fixed) Then
                Throw New ArgumentException("The specified drive is not a hard drive.", paramName:=NameOf(driveInfo))
            End If

            Me.driveInfo = driveInfo

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="HardDriveInfo"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The letter of the hard drive, such as "C" or "D".
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(ByVal driveLetter As Char)
            Me.New(DeviceUtil.GetDriveInfo(driveLetter))
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Refreshes the hard drive properties of this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overridable Sub Refresh()
            Me.win32DiskDrive = Nothing
            Me.smartB = Nothing

            ' Note that is not required to refresh "Me.driveInfo" object.
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets all the hard drives of the current machine.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' An <see cref="IEnumerable(Of HardDriveInfo)"/> that contains all the hard drives of the current machine.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Shared Iterator Function GetDrives() As IEnumerable(Of HardDriveInfo)

            For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
                If (driveInfo.DriveType = System.IO.DriveType.Fixed) Then
                    Yield New HardDriveInfo(driveInfo)
                End If
            Next driveInfo

        End Function

#End Region

#Region " Private Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Builds the values for the related properties of Win32_DiskDrive WMI class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Private Sub BuildWin32DiskDriveProperties()

            Me.win32DiskDrive = DeviceUtil.GetWin32DiskDrive(Me.driveInfo)

            Me.bytesPerSectorB = CInt(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.BytesPerSector)))
            Me.deviceIdB = CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.DeviceId)))
            Me.firmwareRevisionB = CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.FirmwareRevision)))
            Me.indexB = CInt(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.Index)))
            Me.modelB = CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.Model))).Trim(" "c)
            Me.partitionsB = CInt(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.Partitions)))
            Me.pnpDeviceIdB = CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.PnpDeviceId)))
            Me.sectorsPerTrackB = CInt(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.SectorsPerTrack)))
            Me.serialNumberB = CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.SerialNumber))).Trim(" "c)
            Me.totalCylindersB = CLng(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.TotalCylinders)))
            Me.totalHeadsB = CInt(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.TotalHeads)))
            Me.totalSectorsB = CLng(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.TotalSectors)))
            Me.totalTracksB = CLng(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.TotalTracks)))
            Me.tracksPerCylinderB = CInt(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.TracksPerCylinder)))

            Dim capabilities As UShort() = DirectCast(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.Capabilities)), UShort())
            Me.capabilitiesB = Array.ConvertAll(capabilities, Function(value As UShort) DirectCast(value, HardDriveCapabilities))

            If Not [Enum].TryParse(Of HardDriveInterfaceType)(CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.InterfaceType))), True, Me.interfaceTypeB) Then
                Me.interfaceTypeB = HardDriveInterfaceType.IEEE1394 ' WMI value: "1394"
            End If

            If CStr(Me.win32DiskDrive.GetPropertyValue(NameOf(HardDriveInfo.MediaType))).ToLower().Contains("fixed") Then
                Me.mediaTypeB = DriveStorageType.InternalStorage
            Else
                Me.mediaTypeB = DriveStorageType.ExternalStorage
            End If

            Me.win32DiskDrive.Dispose()

        End Sub

#End Region

    End Class

End Namespace

#End Region
