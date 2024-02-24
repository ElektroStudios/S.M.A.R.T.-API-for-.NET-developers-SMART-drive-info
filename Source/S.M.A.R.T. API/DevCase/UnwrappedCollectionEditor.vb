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

#Region " Usage Examples "

' Public NotInheritable Class TestClass
' 
'     <Editor(GetType(UnwrappedCollectionEditor(Of TestItem)), GetType(UITypeEditor))>
'     <TypeConverter(GetType(CollectionEditor))>
'     Public ReadOnly Property TestCollection As ReadOnlyCollection(Of TestItem)
'         Get
'             Dim collection As New List(Of TestItem)
'             For i As Integer = 0 To 10
'                 collection.Add(New TestItem())
'             Next
'             Return collection.AsReadOnly()
'         End Get
'     End Property
' 
'     Public Sub New()
'     End Sub
' 
' End Class
' 
' Public NotInheritable Class TestItem
' 
'     <Category("Category 1")>
'     Public ReadOnly Property TestProperty1 As String = "Test"
' 
'     <Category("Category 2")>
'     Public ReadOnly Property TestProperty2 As String = "Test"
' 
'     <Category("Category 3")>
'     Public ReadOnly Property TestProperty3 As String = "Test"
' 
'     Public Sub New()
'     End Sub
' 
' End Class
' 
' ' Then, in another part of your source-code you will show the collection in a PropertyGrid control...:
' 
' Dim obj As New TestClass()
' Me.PropertyGrid1.SelectedObject = obj

#End Region

#Region " Imports "

Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Linq

#End Region

#Region " UnwrappedCollectionEditor "

Namespace DevCase.Core.Design

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Provides a user interface that unwraps the items of a collection from the 
    ''' default "Value" property that is shown in a standard <see cref="CollectionEditor"/>.
    ''' <para></para>
    ''' Use <see cref="UnwrappedCollectionEditor(Of T)"/> if you want to show a collection whose items are 
    ''' types with properties that have category attributes (<see cref="CategoryAttribute"/>) applied.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' Credits for Reza Aghaei's code: <see href="https://stackoverflow.com/a/53890224/1248295"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Public NotInheritable Class TestClass
    ''' 
    '''     &lt;Editor(GetType(UnwrappedCollectionEditor(Of TestItem)), GetType(UITypeEditor))&gt;
    '''     &lt;TypeConverter(GetType(CollectionEditor))&gt;
    '''     Public ReadOnly Property TestCollection As ReadOnlyCollection(Of TestItem)
    '''         Get
    '''             Dim collection As New List(Of TestItem)
    '''             For i As Integer = 0 To 10
    '''                 collection.Add(New TestItem())
    '''             Next
    '''             Return collection.AsReadOnly()
    '''         End Get
    '''     End Property
    ''' 
    '''     Public Sub New()
    '''     End Sub
    ''' 
    ''' End Class
    ''' 
    ''' Public NotInheritable Class TestItem
    ''' 
    '''     &lt;Category("Category 1")&gt;
    '''     Public ReadOnly Property TestProperty1 As String = "Test"
    ''' 
    '''     &lt;Category("Category 2")&gt;
    '''     Public ReadOnly Property TestProperty2 As String = "Test"
    ''' 
    '''     &lt;Category("Category 3")&gt;
    '''     Public ReadOnly Property TestProperty3 As String = "Test"
    ''' 
    '''     Public Sub New()
    '''     End Sub
    ''' 
    ''' End Class
    ''' 
    ''' ' Then, in another part of your source-code you will show the collection in a PropertyGrid control...:
    ''' 
    ''' Dim obj As New TestClass()
    ''' Me.PropertyGrid1.SelectedObject = obj
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <typeparam name="T">
    ''' The type.
    ''' </typeparam>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class UnwrappedCollectionEditor(Of T) : Inherits CollectionEditor

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="UnwrappedCollectionEditor(Of T)"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub New()
            MyBase.New(GetType(T))
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Edits the value of the specified object using the specified service provider and context.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="context">
        ''' An <see cref="ITypeDescriptorContext"/> that can be used to gain additional context information.
        ''' </param>
        ''' 
        ''' <param name="provider">
        ''' A service provider object through which editing services can be obtained.
        ''' </param>
        ''' 
        ''' <param name="value">
        ''' The object to edit the value of.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The new value of the object. 
        ''' If the value of the object has not changed, this should return the same object it was passed.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            Return MyBase.EditValue(context, provider, value)
        End Function

#End Region

#Region " Private Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Creates a new form to display and edit the current collection.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="CollectionForm"/> to provide as the user interface for editing the collection.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Protected Overrides Function CreateCollectionForm() As CollectionForm

            Dim cf As CollectionForm = MyBase.CreateCollectionForm()
            Dim pg As PropertyGrid = cf.Controls.Find("propertyBrowser", searchAllChildren:=True).OfType(Of PropertyGrid)().SingleOrDefault()
            Dim lb As ListBox = cf.Controls.Find("listbox", searchAllChildren:=True).OfType(Of ListBox)().SingleOrDefault()

            If (pg IsNot Nothing) AndAlso (lb IsNot Nothing) Then

                AddHandler pg.SelectedObjectsChanged,
                    New EventHandler(Sub(ByVal sender As Object, ByVal e As EventArgs)
                                         Dim obj As Object = lb.SelectedItem
                                         If (obj IsNot Nothing) Then ' Unwrap the item from "Value" property.
                                             Dim prop As PropertyInfo = obj.GetType().GetProperty("Value")
                                             If (prop IsNot Nothing) Then
                                                 pg.SelectedObject = DirectCast(prop.GetValue(obj), T)
                                             Else
                                                 Throw New NullReferenceException("Property 'Value' not found.")
                                             End If
                                         End If
                                     End Sub)

            End If

            Return cf

        End Function

#End Region

    End Class

End Namespace

#End Region
