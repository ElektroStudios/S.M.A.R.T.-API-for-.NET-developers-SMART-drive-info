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

' New(Byte(), Byte(), Integer)

#End Region

#Region " Properties "

' CurrentValue As Integer
' Description As String
' FailureImminent As Boolean
' Flags As UShort
' Name As String
' RawValue32 As Integer
' RawValue64 As Long
' Threshold As Integer
' WorstValue As Integer

#End Region

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System.ComponentModel

#End Region

#Region " Smart Attribute "

Namespace DevCase.Core.IO

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Represents a S.M.A.R.T. attribute of a hard drive.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <Serializable>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class SmartAttribute

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the attribute identifier.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The attribute identifier.")>
        <DisplayName("Id.")>
        <Category("Entity")>
        Public ReadOnly Property Id As Byte

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the attribute name.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The attribute name.")>
        <Category("Entity")>
        <[ReadOnly](True)>
        Public Property Name As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the attribute description.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The attribute description.")>
        <Category("Entity")>
        <[ReadOnly](True)>
        Public Property Description As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the RAW (vendor specific) value as a 32-bit signed Integer.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The RAW (vendor specific) value as a 32-bit signed Integer.")>
        <DisplayName("RAW value")>
        <Category("Values")>
        Public ReadOnly Property RawValue32 As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the RAW (vendor specific) value as a 64-bit signed Integer.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Browsable(False)>
        <Description("The RAW (vendor specific) value as a 64-bit signed Integer.")>
        <DisplayName("RAW value (int64)")>
        <Category("Values")>
        Public ReadOnly Property RawValue64 As Long

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the current value.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The current value.")>
        <DisplayName("Current value")>
        <Category("Values")>
        Public ReadOnly Property CurrentValue As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the worst value.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The worst value.")>
        <DisplayName("Worst value")>
        <Category("Values")>
        Public ReadOnly Property WorstValue As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the threshold value.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("The threshold value.")>
        <Category("Values")>
        Public ReadOnly Property Threshold As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the flags.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Browsable(False)>
        <Description("The flags.")>
        <Category("Values")>
        Protected ReadOnly Property Flags As UShort

        '' Not used.
        'Public ReadOnly Property Advisory As Boolean
        '    Get
        '        Return (Me.Flags And &H1) = &H0
        '    End Get
        'End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value that determine whether the health status of this attribute is ok.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Description("A value that determine whether the health status of this attribute is ok.")>
        <DisplayName("Failure imminent?")>
        <Category("Status")>
        Public ReadOnly Property FailureImminent As Boolean
            Get
                Return (Me.Flags And &H1) = &H1
            End Get
        End Property

        '' Not used.
        'Public ReadOnly Property OnlineDataCollection As Boolean
        '    Get
        '        Return (Me.Flags And &H2) = &H2
        '    End Get
        'End Property

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="SmartAttribute"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="SmartAttribute"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="predictData">
        ''' The vendor-specific S.M.A.R.T. data from 'MSStorageDriver_FailurePredictData' WMI class.
        ''' </param>
        ''' 
        ''' <param name="predictThresholds">
        ''' The vendor-specific S.M.A.R.T. data from 'MSStorageDriver_FailurePredictThresholds' WMI class.
        ''' </param>
        ''' 
        ''' <param name="attributeIndex">
        ''' The index of the S.M.A.R.T. attribute to retrieve.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(ByVal predictData As Byte(), ByVal predictThresholds As Byte(), ByVal attributeIndex As Integer)

            Me.Id = predictData(attributeIndex * 12 + 2)
            Me.Flags = predictData(attributeIndex * 12 + 4) ' Least significant status byte, +3 most significant byte, but not used so ignored.
            Me.CurrentValue = predictData(attributeIndex * 12 + 5)
            Me.WorstValue = predictData(attributeIndex * 12 + 6)
            Me.RawValue32 = BitConverter.ToInt32(predictData, attributeIndex * 12 + 7)
            Me.RawValue64 = BitConverter.ToInt64(predictData, attributeIndex * 12 + 7)
            Me.Threshold = predictThresholds(attributeIndex * 12 + 3)

            Me.BuildNameAndDescription()

        End Sub

#End Region

#Region " Private Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Builds the <see cref="SmartAttribute.Name"/> and <see cref="SmartAttribute.Description"/> values, 
        ''' in English language.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Protected Overridable Sub BuildNameAndDescription()

            Select Case Me.Id

                Case 1
                    Me.Name = "Read Error Rate"
                    Me.Description = "Stores data related to the rate of hardware read errors that occurred when reading data from a disk surface. The raw value has different structure for different vendors and is often not meaningful as a decimal number."

                Case 2
                    Me.Name = "Throughput Performance"
                    Me.Description = "Overall (general) throughput performance of a hard disk drive. If the value of this attribute is decreasing there is a high probability that there is a problem with the disk."

                Case 3
                    Me.Name = "Spin-Up Time"
                    Me.Description = "Average time of spindle spin up (from zero RPM to fully operational [milliseconds])."

                Case 4
                    Me.Name = "Start/Stop Count"
                    Me.Description = "A tally of spindle start/stop cycles. The spindle turns on, and hence the count is increased, both when the hard disk is turned on after having before been turned entirely off (disconnected from power source) and when the hard disk returns from having previously been put to sleep mode."

                Case 5
                    Me.Name = "Reallocated Sectors Count"
                    Me.Description = "Count of reallocated sectors. The raw value represents a count of the bad sectors that have been found and remapped. Thus, the higher the attribute value, the more sectors the drive has had to reallocate. This value is primarily used as a metric of the life expectancy of the drive; a drive which has had any reallocations at all is significantly more likely to fail in the immediate months."

                Case 6
                    Me.Name = "Read Channel Margin"
                    Me.Description = "Margin of a channel while reading data. The function of this attribute is not specified."

                Case 7
                    Me.Name = "Seek Error Rate"
                    Me.Description = "(Vendor specific raw value.) Rate of seek errors of the magnetic heads. If there is a partial failure in the mechanical positioning system, then seek errors will arise. Such a failure may be due to numerous factors, such as damage to a servo, or thermal widening of the hard disk. The raw value has different structure for different vendors and is often not meaningful as a decimal number. "

                Case 8
                    Me.Name = "Seek Time Performance"
                    Me.Description = "Average performance of seek operations of the magnetic heads. If this attribute is decreasing, it is a sign of problems in the mechanical subsystem. "

                Case 9
                    Me.Name = "Power-On Hours Count"
                    Me.Description = "Count of hours in power-on state. The raw value of this attribute shows total count of hours (or minutes, or seconds, depending on manufacturer) in power-on state. By default, the total expected lifetime of a hard disk in perfect condition is defined as 5 years (running every day and night on all days). This is equal to 1825 days in 24/7 mode or 43800 hours."

                Case 10
                    Me.Name = "Spin Retry Count"
                    Me.Description = "Count of retry of spin start attempts. This attribute stores a total count of the spin start attempts to reach the fully operational speed (under the condition that the first attempt was unsuccessful). An increase of this attribute value is a sign of problems in the hard disk mechanical subsystem. "

                Case 11
                    Me.Name = "Calibration Retry Count"
                    Me.Description = "This attribute indicates the count that recalibration was requested (under the condition that the first attempt was unsuccessful). An increase of this attribute value is a sign of problems in the hard disk mechanical subsystem. "

                Case 12
                    Me.Name = "Power-On Cycle Count"
                    Me.Description = "This attribute indicates the count of full hard disk power on/off cycles. "

                Case 13
                    Me.Name = "Soft Read Error Rate"
                    Me.Description = "Uncorrected read errors reported to the operating system. "

                Case 184
                    Me.Name = "End-to-End Error / IOEDC"
                    Me.Description = "Count of parity errors which occur in the data path to the media via the drive's cache RAM."

                Case 187
                    Me.Name = "Reported Uncorrectable Errors"
                    Me.Description = "The count of errors that could not be recovered using hardware ECC."

                Case 188
                    Me.Name = "Command Timeout"
                    Me.Description = "The count of aborted operations due to HDD timeout. Normally this attribute value should be equal to zero."

                Case 189
                    Me.Name = "High Fly Writes"
                    Me.Description = "HDD manufacturers implement a flying height sensor that attempts to provide additional protections for write operations by detecting when a recording head is flying outside its normal operating range. If an unsafe fly height condition is encountered, the write process is stopped, and the information is rewritten or reallocated to a safe region of the hard drive. This attribute indicates the count of these errors detected over the lifetime of the drive. "

                Case 190
                    Me.Name = "Airflow Temperature"
                    Me.Description = "Value is equal to (100-temp. °C), allowing manufacturer to set a minimum threshold which corresponds to a maximum temperature. This also follows the convention of 100 being a best-case value and lower values being undesirable. However, some older drives may instead report raw Temperature (identical to 0xC2) or Temperature minus 50 here. "

                Case 191
                    Me.Name = "G-Sense Error Rate"
                    Me.Description = "The count of errors resulting from externally induced shock and vibration. "

                Case 192
                    Me.Name = "Power-off Retract Count"
                    Me.Description = "Number of power-off or emergency retract cycles."

                Case 193
                    Me.Name = "Load/Unload Cycle Count"
                    Me.Description = "Count of load/unload cycles into head landing zone position."

                Case 194
                    Me.Name = "Drive Temperature"
                    Me.Description = "Indicates the device temperature, if the appropriate sensor is fitted. Lowest byte of the raw value contains the exact temperature value (Celsius degrees)."

                Case 195
                    Me.Name = "Hardware ECC Recovered"
                    Me.Description = "(Vendor-specific raw value.) The raw value has different structure for different vendors and is often not meaningful as a decimal number. "

                Case 196
                    Me.Name = "Reallocation Event Count"
                    Me.Description = "Count of remap operations. The raw value of this attribute shows the total count of attempts to transfer data from reallocated sectors to a spare area. Both successful and unsuccessful attempts are counted."

                Case 197
                    Me.Name = "Current Pending Sector Count"
                    Me.Description = "Count of unstable sectors (waiting to be remapped, because of unrecoverable read errors). If an unstable sector is subsequently read successfully, the sector is remapped and this value is decreased. Read errors on a sector will not remap the sector immediately (since the correct value cannot be read and so the value to remap is not known, and also it might become readable later); instead, the drive firmware remembers that the sector needs to be remapped, and will remap it the next time it's written."

                Case 198
                    Me.Name = "Uncorrectable Sector Count"
                    Me.Description = "The total count of uncorrectable errors when reading/writing a sector. A rise in the value of this attribute indicates defects of the disk surface and/or problems in the mechanical subsystem."

                Case 199
                    Me.Name = "UltraDMA CRC Error Count"
                    Me.Description = "The count of errors in data transfer via the interface cable as determined by ICRC (Interface Cyclic Redundancy Check). "

                Case 200
                    Me.Name = "Write Error Rate"
                    Me.Description = "The total count of errors when writing a sector."

                Case 201
                    Me.Name = "Soft Read Error Rate"
                    Me.Description = "Count indicates the number of uncorrectable software read errors."

                Case 202
                    Me.Name = "Data Address Mark Errors"
                    Me.Description = "Count of Data Address Mark errors (or vendor-specific)."

                Case 203
                    Me.Name = "Run Out Cancel"
                    Me.Description = "The number of errors caused by incorrect checksum during the error correction."

                Case 204
                    Me.Name = "Soft ECC Correction"
                    Me.Description = "Count of errors corrected by the internal error correction software."

                Case 205
                    Me.Name = "Thermal Asperity Rate (TAR)"
                    Me.Description = "Count of errors due to high temperature."

                Case 206
                    Me.Name = "Flying Height"
                    Me.Description = "Height of heads above the disk surface. If too low, head crash is more likely; if too high, read/write errors are more likely."

                Case 207
                    Me.Name = "Spin High Current"
                    Me.Description = "Amount of surge current used to spin up the drive."

                Case 208
                    Me.Name = "Spin Buzz"
                    Me.Description = "Count of buzz routines needed to spin up the drive due to insufficient power."

                Case 209
                    Me.Name = "Offline Seek Performance"
                    Me.Description = "Drive’s seek performance during its internal tests."

                Case 211
                    Me.Name = "Vibration During Write"
                    Me.Description = "A recording of a vibration encountered during write operations."

                Case 212
                    Me.Name = "Shock During Write"
                    Me.Description = "A recording of shock encountered during write operations."

                Case 220
                    Me.Name = "Disk Shift"
                    Me.Description = "Distance the disk has shifted relative to the spindle (usually due to shock or temperature). Unit of measure is unknown."

                Case 221
                    Me.Name = "G-Sense Error Rate"
                    Me.Description = "The count of errors resulting from externally induced shock and vibration. "

                Case 222
                    Me.Name = "Loaded Hours"
                    Me.Description = "Time spent operating under data load (movement of magnetic head armature)."

                Case 223
                    Me.Name = "Load/Unload Retry Count"
                    Me.Description = "Count of times head changes position."

                Case 224
                    Me.Name = "Load Friction"
                    Me.Description = "Resistance caused by friction in mechanical parts while operating."

                Case 225
                    Me.Name = "Load/Unload Cycle Count"
                    Me.Description = "Total count of load cycles. Some drives use 193 (0xC1) for Load Cycle Count instead."

                Case 226
                    Me.Name = "Load-In Time"
                    Me.Description = "Total time of loading on the magnetic heads actuator (time not spent in parking area)."

                Case 227
                    Me.Name = "Torque Amplification Count"
                    Me.Description = "Count of attempts to compensate for platter speed variations."

                Case 228
                    Me.Name = "Power-Off Retract Count"
                    Me.Description = "The number of power-off cycles which are counted whenever there is a Retract Event and the heads are loaded off of the media such as when the machine is powered down, put to sleep, or is idle."

                Case 230
                    Me.Name = "GMR Head Amplitude"
                    Me.Description = "Amplitude of thrashing (repetitive head moving motions between operations). In solid-state drives, indicates whether usage trajectory is outpacing the expected life curve."

                Case 231
                    Me.Name = "Temperature"
                    Me.Description = "Indicates the approximate SSD life left, in terms of program/erase cycles or available reserved blocks. A normalized value of 100 represents a new drive, with a threshold value at 10 indicating a need for replacement. A value of 0 may mean that the drive is operating in read-only mode to allow data recovery."

                Case 240
                    Me.Name = "Head Flying Hours"
                    Me.Description = "Time spent during the positioning of the drive heads."

                Case 241
                    Me.Name = "Total LBAs Written"
                    Me.Description = "Total count of LBAs written. "

                Case 242
                    Me.Name = "Total LBAs Read"
                    Me.Description = "Total count of LBAs read."

                Case 250
                    Me.Name = "Read Error Retry Rate"
                    Me.Description = "Count of errors while reading from a disk."

                Case 251
                    Me.Name = "Minimum Spares Remaining"
                    Me.Description = "The Minimum Spares Remaining attribute indicates the number of remaining spare blocks as a percentage of the total number of spare blocks available."

                Case Else
                    Me.Name = String.Format("Vendor-specific ({0})", Me.Id)
                    Me.Description = String.Empty

            End Select

        End Sub

#End Region

    End Class

End Namespace

#End Region
