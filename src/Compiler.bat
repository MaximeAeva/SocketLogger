if exist ..\CameraLogSniffer.EXE DEL ..\CameraLogSniffer.EXE

C:\WINDOWS\Microsoft.NET\Framework64\v4.0.30319\csc.exe -nologo  /t:exe /out:..\CameraLogSniffer.EXE MainForm.Designer.cs MainForm.cs Program.cs
..\CameraLogSniffer.EXE

Pause