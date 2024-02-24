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

#Region " Constructors "

' New(DriveInfo)
' New(Char)

#End Region

#Region " Properties "

' Attributes As ReadOnlyCollection(Of SmartAttribute)
' IsHealthOk As Boolean

#End Region

#Region " Methods "

' Refresh()

#End Region

#End Region

#Region " Usage Examples "

' Dim SMART As New SMART("C"c)
' 
' Dim sb As New StringBuilder()
' For Each attr As SmartAttribute In SMART.Attributes.Values
' 
'     sb.AppendFormat("Id: {0:X2}, Name: {1,-30}, Current: {2,3}, Worst: {3,3}, Threshold: {4,3}, RAW: {5,12:X12}, IsHealthOk?: {6}",
'                     attr.Id, attr.Name,
'                     attr.CurrentValue, attr.WorstValue, attr.Threshold, attr.RawValue32,
'                     attr.IsHealthOk)
'     sb.AppendLine()
' 
' Next attr
' 
' Console.WriteLine(sb.ToString())

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing.Design
Imports System.IO
Imports System.Management

Imports DevCase.Core.Design
Imports DevCase.Core.IO.Tools

#End Region

#Region " SMART "

Namespace DevCase.Core.IO

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Represents the S.M.A.R.T. information of a hard drive.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim SMART As New SMART("C"c)
    ''' 
    ''' Dim sb As New StringBuilder()
    ''' For Each attr As SmartAttribute In SMART.Attributes
    ''' 
    '''     sb.AppendFormat("Id: {0:X2}, Name: {1,-30}, Current: {2,3}, Worst: {3,3}, Threshold: {4,3}, RAW: {5,12:X12}, IsHealthOk?: {6}",
    '''                     attr.Id, attr.Name,
    '''                     attr.CurrentValue, attr.WorstValue, attr.Threshold, attr.RawValue32,
    '''                     attr.IsHealthOk)
    '''     sb.AppendLine()
    ''' 
    ''' Next attr
    ''' 
    ''' Console.WriteLine(sb.ToString())
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    <Serializable>
    <Browsable(True)>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class SMART

#Region " Private Fields "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the Windows Plug and Play (PNP) device identifier of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private ReadOnly pnpDeviceId As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The Windows Plug and Play (PNP) device identifier of the hard drive, 
        ''' specifically formatted for the MSStorageDriver_* WMI classes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private instanceName As String

#End Region

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value that determine whether the health status of the hard drive is ok.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("A value that determine whether the health status of the hard drive is ok.")>
        <DisplayName("Is Health Ok?")>
        <Category("Status")>
        Public ReadOnly Property IsHealthOk As Boolean
            Get
                Return Me.isHealthOkB
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing field )
        ''' <para></para>
        ''' A value that determine whether the health status of the hard drive is ok.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private isHealthOkB As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the S.M.A.R.T. attributes of the hard drive.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The S.M.A.R.T. attributes of the hard drive.")>
        <DisplayName(NameOf(SMART.Attributes))>
        <Category("S.M.A.R.T.")>
        <TypeConverter(GetType(CollectionConverter))>
        <Editor(GetType(UnwrappedCollectionEditor(Of SmartAttribute)), GetType(UITypeEditor))>
        Public ReadOnly Property Attributes As ReadOnlyCollection(Of SmartAttribute)
            Get
                Return New ReadOnlyCollection(Of SmartAttribute)(Me.attributesB)
            End Get
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' (Backing Field)
        ''' <para></para>
        ''' The S.M.A.R.T. attributes of the hard drive.
        ''' </summary>
        Private attributesB As Collection(Of SmartAttribute)

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="SMART"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="SMART"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveInfo">
        ''' A <see cref="System.IO.DriveInfo"/> instance that represents the hard drive.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(ByVal driveinfo As DriveInfo)

            Me.pnpDeviceId = New HardDriveInfo(driveinfo).PnpDeviceId

            Me.BuildInstanceNameAndHealthIsOk()
            Me.BuildSmartAttributes()

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="SMART"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="driveLetter">
        ''' The hard drive letter, such as "C" or "D".
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
        <DebuggerStepThrough>
        Public Sub Refresh()
            Me.BuildInstanceNameAndHealthIsOk()
            Me.BuildSmartAttributes()
        End Sub

#End Region

#Region " Private Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Builds the values of <see cref="SMART.instanceName"/> and <see cref="SMART.isHealthOkB"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Private Sub BuildInstanceNameAndHealthIsOk()

            Dim scope As New ManagementScope("\root\wmi")
            Dim query As New ObjectQuery("Select * from MSStorageDriver_FailurePredictStatus")
            Dim enumOptions As New EnumerationOptions With {
                .DirectRead = True,
                .EnsureLocatable = False,
                .EnumerateDeep = False,
                .ReturnImmediately = True,
                .Rewindable = False,
                .UseAmendedQualifiers = False
            }

            Using mos As New ManagementObjectSearcher(scope, query, enumOptions),
                  moc As ManagementObjectCollection = mos.Get()

                For Each mo As ManagementObject In moc
                    Dim instanceName As String = CStr(mo.GetPropertyValue("InstanceName"))
                    Dim instanceNameRenamed As String = instanceName.Substring(0, instanceName.LastIndexOf("_"))

                    If String.Equals(instanceNameRenamed, Me.pnpDeviceId, StringComparison.OrdinalIgnoreCase) Then
                        Me.instanceName = instanceName
                        Me.isHealthOkB = Not CBool(mo.GetPropertyValue("PredictFailure"))
                    End If
                Next mo

            End Using

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Builds the S.M.A.R.T. attributes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://stackoverflow.com/questions/8663980/how-can-i-use-c-sharp-to-read-extended-smart-data/14894138#14894138"/>
        ''' <para></para>
        ''' <see href="http://www.know24.net/blog/C+WMI+HDD+SMART+Information.aspx"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Protected Overridable Sub BuildSmartAttributes()

            Me.attributesB = New Collection(Of SmartAttribute)()

            Dim enumOptions As New EnumerationOptions With {
                .DirectRead = True,
                .EnsureLocatable = False,
                .EnumerateDeep = False,
                .ReturnImmediately = True,
                .Rewindable = False,
                .UseAmendedQualifiers = False
            }

            Using dataSearcher As New ManagementObjectSearcher("\root\wmi", "Select * from MSStorageDriver_FailurePredictData", enumOptions),
                  dataCollection As ManagementObjectCollection = dataSearcher.Get()

                For Each data As ManagementObject In dataCollection

                    If String.Equals(CStr(data.Properties("InstanceName").Value), Me.instanceName, StringComparison.OrdinalIgnoreCase) Then

                        Dim dataRAW As Byte() = DirectCast(data.Properties("VendorSpecific").Value, Byte())

                        For index As Integer = 0 To 29

                            Dim id As Byte = dataRAW(index * 12 + 2)
                            If (id = 0) Then
                                Continue For
                            End If

                            Using thresholdSearcher As New ManagementObjectSearcher("\root\wmi", "Select * From MSStorageDriver_FailurePredictThresholds", enumOptions),
                                  thresholdCollection As ManagementObjectCollection = thresholdSearcher.Get()

                                For Each threshold As ManagementObject In thresholdCollection

                                    If String.Equals(CStr(threshold.Properties("InstanceName").Value), Me.instanceName, StringComparison.OrdinalIgnoreCase) Then
                                        Dim thresholdRAW As Byte() = DirectCast(threshold.Properties("VendorSpecific").Value, Byte())

                                        Dim attribute As New SmartAttribute(dataRAW, thresholdRAW, index)
                                        Me.attributesB.Add(attribute)
                                    End If

                                Next threshold

                            End Using

                        Next index

                    End If

                Next data

            End Using

        End Sub

#End Region

    End Class

End Namespace

#End Region
