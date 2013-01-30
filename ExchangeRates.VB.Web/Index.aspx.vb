Imports ExchangeRates.DataService
Imports Microsoft.Practices.Unity
Imports ExchangeRates.DataService.IoC

Public Class Index
    Inherits Page
    Public _manager As IManager
    Public chartModel As ChartModel

    Public Sub New()
        Me.New(Nothing)

    End Sub

    Public Sub New(ByVal manager As IManager)
        Dim instance = ModelContainer.Instance.Resolve(Of IManager)()
        _manager = If(manager, instance)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


    End Sub

    Protected Sub btnLoad_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim sd = DateTime.Parse(StartDate.Text)
        Dim en = DateTime.Parse(EndDate.Text)
        If sd > en Then
            ErrorLabel.Text = "Start Date must be smaller or equal to the end date"
        ElseIf sd > DateTime.Now Or en > DateTime.Now Then
            ErrorLabel.Text = "Selected date should not be from future."
        ElseIf list1.SelectedValue = list2.SelectedValue Then
            ErrorLabel.Text = "Please select different currencies for comapring."
        ElseIf sd <= en.AddDays(-60) Then
            ErrorLabel.Text = "Please select dates in the range of 60 days."
        Else
            chartModel = _manager.GetRateCollection(StartDate.Text, EndDate.Text,
                                                                                list1.SelectedValue, list2.SelectedValue)
            Session("ChartM") = chartModel
            Server.Transfer("Chart.aspx")
        End If

    End Sub

End Class