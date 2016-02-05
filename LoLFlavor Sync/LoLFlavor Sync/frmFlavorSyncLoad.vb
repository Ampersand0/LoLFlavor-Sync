﻿Imports LoLFlavor_Sync.Lib
Imports System.IO
Public Class frmFlavorSyncLoad
    Private LPD As Boolean?
    Public Property LoLPath As String
        Get
            Return Properties.LoLPath
        End Get
        Set(value As String)
            Properties.LoLPath = value
            fbdLoLPath.SelectedPath = value
            txtLoLPath.Text = value
        End Set
    End Property

    Private Sub FormLoad()
        Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        Me.AcceptButton = btnConfirm
        ToFromGarena(Properties.OptionUseGarena())
        InitAllChamps()

        If Not String.IsNullOrWhiteSpace(Properties.OptionLoLPath) AndAlso Properties.ValidLoLPath(Properties.OptionLoLPath) Then
            Me.LoLPath = Properties.OptionLoLPath
            LPD = True
        Else
            If String.IsNullOrWhiteSpace(Properties.DetectLoLPath()) Then
                ActiveControl = btnBrowse
                Me.LoLPath = Nothing
                chkSkip.Enabled = False
                LPD = False
            Else
                Me.LoLPath = Properties.DetectLoLPath()
                LPD = True
            End If
        End If
    End Sub

    Private Sub FormShown()
        Application.DoEvents()
        While LPD Is Nothing
            System.Threading.Thread.Sleep(30)
        End While

        If LPD = True Then
            If Properties.OptionSkipForm Then
                Me.Hide()
                ShowMainForm()
            Else
                chkSkip.Enabled = True
                ActiveControl = btnConfirm
            End If
        End If
    End Sub

    Private Sub ShowMainForm()
        If Properties.Garena Then Properties.DetectGarenaPath()
        Dim frm As New frmFlavorSyncMain
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub ToFromGarena(ByVal _Garena As Boolean)
        RemoveHandler chkGarena.CheckedChanged, AddressOf chkGarena_CheckedChanged
        chkGarena.Checked = _Garena
        AddHandler chkGarena.CheckedChanged, AddressOf chkGarena_CheckedChanged
        Properties.Garena = _Garena
        Properties.OptionUseGarena = _Garena

        If _Garena Then
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)"
            If Environment.Is64BitOperatingSystem Then
                Label2.Text = "Example: C:\Program Files (x86)\GarenaLoL"
            Else
                Label2.Text = "Example: C:\Program Files\GarenaLoL"
            End If
        Else
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
            Label2.Text = "Example: C:\Riot Games\League of Legends"
        End If

        If String.IsNullOrWhiteSpace(Properties.DetectLoLPath()) Then
            ActiveControl = btnBrowse
            Me.LoLPath = Nothing
            chkSkip.Enabled = False
        Else
            ActiveControl = btnConfirm
            Me.LoLPath = Properties.DetectLoLPath()
            chkSkip.Enabled = True
        End If
    End Sub

    Private Sub InitAllChamps()
        Dim Champions As New List(Of Champion)
        For Each arr As String() In GetChampList()
            If arr IsNot Nothing AndAlso arr.Length > 0 Then
                If arr.Length = 1 Then
                    Champions.Add(New Champion(arr(0)))
                ElseIf arr.Length >= 2 Then
                    Champions.Add(New Champion(arr(0), arr(1)))
                End If
            End If
        Next
        Properties.AllChampions = Champions
    End Sub

    Private Function GetChampList() As List(Of String())
        Dim lst As New List(Of String())
        lst.Add({"Aatrox"})
        lst.Add({"Ahri"})
        lst.Add({"Akali"})
        lst.Add({"Alistar"})
        lst.Add({"Amumu"})
        lst.Add({"Anivia"})
        lst.Add({"Annie"})
        lst.Add({"Ashe"})
        lst.Add({"Azir"})
        lst.Add({"Bard"})
        lst.Add({"Blitzcrank"})
        lst.Add({"Brand"})
        lst.Add({"Braum"})
        lst.Add({"Caitlyn"})
        lst.Add({"Cassiopeia"})
        lst.Add({"Chogath", "Cho'Gath"})
        lst.Add({"Corki"})
        lst.Add({"Darius"})
        lst.Add({"Diana"})
        lst.Add({"Draven"})
        lst.Add({"DrMundo", "Dr. Mundo"})
        lst.Add({"Ekko"})
        lst.Add({"Elise"})
        lst.Add({"Evelynn"})
        lst.Add({"Ezreal"})
        lst.Add({"FiddleSticks", "Fiddlesticks"})
        lst.Add({"Fiora"})
        lst.Add({"Fizz"})
        lst.Add({"Galio"})
        lst.Add({"Gangplank"})
        lst.Add({"Garen"})
        lst.Add({"Gnar"})
        lst.Add({"Gragas"})
        lst.Add({"Graves"})
        lst.Add({"Hecarim"})
        lst.Add({"Heimerdinger"})
        lst.Add({"Illaoi"})
        lst.Add({"Irelia"})
        lst.Add({"Janna"})
        lst.Add({"JarvanIV", "Jarvan IV"})
        lst.Add({"Jax"})
        lst.Add({"Jayce"})
        lst.Add({"Jinx"})
        lst.Add({"Jhin"})
        lst.Add({"Kalista"})
        lst.Add({"Karma"})
        lst.Add({"Karthus"})
        lst.Add({"Kassadin"})
        lst.Add({"Katarina"})
        lst.Add({"Kayle"})
        lst.Add({"Kennen"})
        lst.Add({"Khazix", "Kha'Zix"})
        lst.Add({"Kindred"})
        lst.Add({"KogMaw", "Kog'Maw"})
        lst.Add({"Leblanc", "LeBlanc"})
        lst.Add({"LeeSin", "Lee Sin"})
        lst.Add({"Leona"})
        lst.Add({"Lissandra"})
        lst.Add({"Lucian"})
        lst.Add({"Lulu"})
        lst.Add({"Lux"})
        lst.Add({"Malphite"})
        lst.Add({"Malzahar"})
        lst.Add({"Maokai"})
        lst.Add({"MasterYi", "Master Yi"})
        lst.Add({"MissFortune", "Miss Fortune"})
        lst.Add({"MonkeyKing", "Wukong"})
        lst.Add({"Mordekaiser"})
        lst.Add({"Morgana"})
        lst.Add({"Nami"})
        lst.Add({"Nasus"})
        lst.Add({"Nautilus"})
        lst.Add({"Nidalee"})
        lst.Add({"Nocturne"})
        lst.Add({"Nunu"})
        lst.Add({"Olaf"})
        lst.Add({"Orianna"})
        lst.Add({"Pantheon"})
        lst.Add({"Poppy"})
        lst.Add({"Quinn"})
        lst.Add({"Rammus"})
        lst.Add({"Reksai", "Rek'Sai"})
        lst.Add({"Renekton"})
        lst.Add({"Rengar"})
        lst.Add({"Riven"})
        lst.Add({"Rumble"})
        lst.Add({"Ryze"})
        lst.Add({"Sejuani"})
        lst.Add({"Shaco"})
        lst.Add({"Shen"})
        lst.Add({"Shyvana"})
        lst.Add({"Singed"})
        lst.Add({"Sion"})
        lst.Add({"Sivir"})
        lst.Add({"Skarner"})
        lst.Add({"Sona"})
        lst.Add({"Soraka"})
        lst.Add({"Swain"})
        lst.Add({"Syndra"})
        lst.Add({"TahmKench", "Tahm Kench"})
        lst.Add({"Talon"})
        lst.Add({"Taric"})
        lst.Add({"Teemo"})
        lst.Add({"Thresh"})
        lst.Add({"Tristana"})
        lst.Add({"Trundle"})
        lst.Add({"Tryndamere"})
        lst.Add({"TwistedFate", "Twisted Fate"})
        lst.Add({"Twitch"})
        lst.Add({"Udyr"})
        lst.Add({"Urgot"})
        lst.Add({"Varus"})
        lst.Add({"Vayne"})
        lst.Add({"Veigar"})
        lst.Add({"Velkoz", "Vel'Koz"})
        lst.Add({"Vi"})
        lst.Add({"Viktor"})
        lst.Add({"Vladimir"})
        lst.Add({"Volibear"})
        lst.Add({"Warwick"})
        lst.Add({"Xerath"})
        lst.Add({"XinZhao", "Xin Zhao"})
        lst.Add({"Yasuo"})
        lst.Add({"Yorick"})
        lst.Add({"Zac"})
        lst.Add({"Zed"})
        lst.Add({"Ziggs"})
        lst.Add({"Zilean"})
        lst.Add({"Zyra"})
        Return lst
    End Function

#Region "Event Handlers"
    Private Sub frmFlavorSyncLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormLoad()
    End Sub

    Private Sub frmFlavorSyncLoad_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FormShown()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdLoLPath.SelectedPath = Me.LoLPath
        If fbdLoLPath.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If Properties.ValidLoLPath(fbdLoLPath.SelectedPath) Then
            Me.LoLPath = fbdLoLPath.SelectedPath
            chkSkip.Enabled = True
        Else
            MessageBox.Show("Please select the League of Legends directory.", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If Properties.ValidLoLPath(Me.LoLPath) Then
            Properties.OptionSkipForm = chkSkip.Checked

            If Properties.OptionSkipForm Then
                Properties.OptionLoLPath = Properties.LoLPath
            Else
                Properties.OptionLoLPath = ""
            End If

            Me.Hide()
            ShowMainForm()
        Else
            MessageBox.Show("Please select the League of Legends directory.", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub chkGarena_CheckedChanged(sender As Object, e As EventArgs) Handles chkGarena.CheckedChanged
        ToFromGarena(chkGarena.Checked)
    End Sub
#End Region
End Class
