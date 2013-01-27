Public Class Chart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
   Protected Sub btnLoad_Click(sender As Object, e As System.EventArgs) Handles BackButton.Click
      Server.Transfer("Index.aspx")
   End Sub
End Class