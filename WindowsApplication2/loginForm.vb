﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class loginForm
    Dim strConn As String = ConfigurationManager.ConnectionStrings("ProCarSale.My.MySettings.myCon").ConnectionString
    Dim strSql As String
    Dim Conn As New SqlConnection
    Dim mycomm As New SqlCommand
    Dim myDR As SqlDataReader
    Dim username, password, name, surname, status As String
    Private Sub conDB()
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
        Conn.ConnectionString = strConn
        Conn.Open()
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Call conDB()
        strSql = "select * from tbEmployee where empUsername = @username and empPassword=@password "
        mycomm = New SqlCommand(strSql, Conn)
        mycomm.CommandType = CommandType.Text
        mycomm.CommandTimeout = 15
        mycomm.Parameters.AddWithValue("username", txtUsername.Text)
        mycomm.Parameters.AddWithValue("password", txtPassword.Text)
        myDR = mycomm.ExecuteReader
        myDR.Read()
        If myDR.HasRows Then
            username = myDR.Item("empUsername")
            password = myDR.Item("empPassword")
            name = myDR.Item("empName")
            status = myDR.Item("empstatus")
            surname = myDR.Item("empSurname")
            MessageBox.Show("ยินดีต้อยรับคุณ " + name + "  " + surname + " เข้าสู่ระบบ", "เตือน!", MessageBoxButtons.OK)
            Me.Close()
        Else
            MessageBox.Show("Username หรือ Password ไม่ถูกต้อง กรุณาตรวจสอบใหม่ด้วยค่ะ", "เตือน!", MessageBoxButtons.OK)
            txtUsername.Clear()
            txtPassword.Clear()
          
        End If
        myDR.Close()
    End Sub

    Private Sub loginForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class