Public Class Index
   Inherits Page

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
         Server.Transfer("Chart.aspx")
      End If

   End Sub

End Class