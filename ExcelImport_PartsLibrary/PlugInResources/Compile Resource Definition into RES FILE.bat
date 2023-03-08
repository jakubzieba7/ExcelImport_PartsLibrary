
@Echo off
Echo .
Echo **************************************
Echo *  Creator : Anthony Roberson        *
Echo *  Date    : 20 November 2015        *
Echo *  Version : 1.1                     *
Echo **************************************

Echo .
Echo This Batch file will Compile the PlugInResourceDefinition.rc file into a RES FILE that can be used to dictate the resources contecnt of a DLL.
Echo .
Pause

Echo .
Echo .
ECHO STEP ONE - DELETE the previous resource file
Pause
@Echo ON
Del /F /Q PlugInResourcesFile.res
@Echo OFF

Echo .
Echo .
ECHO STEP TWO - COMPILE the NEW Resource File
Pause
RC /fo PlugInResourcesFile.res /v PlugInResourcesFile.rc
Pause
