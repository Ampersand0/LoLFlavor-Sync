﻿Imports LoLFlavor_Sync.Domain
Imports LoLFlavor_Sync.DLBuilds

Namespace Global.LoLFlavor_Sync.SaveBuilds
    Public Interface ISaveBehaviour
        Sub SaveBuild(ByRef build As Build)
    End Interface
End Namespace
