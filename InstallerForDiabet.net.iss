; ��� ����������
#define   Name       "Diabeta.net"
; ������ ����������
#define   Version    "1.0"
; �����-�����������
#define   Publisher  "Valeria Troshko"
; ���� ����� ������������
#define   URL        "https://vk.com/lerka_kisa_mur"
; ��� ������������ ������
#define   ExeName    "Diabeta.net.exe"

[Setup]

; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{F3E2EDB6-78E8-4539-9C8B-A78F059D8647}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=D:\����\����\2 ����\2 ���\�ourse_project(�#)\Diabet.net
OutputBaseFileName=test-setup

; ���� ������
SetupIconFile=D:\icon.ico

; ��������� ������
Compression=lzma
SolidCompression=yes

;------------------------------------------------------------------------------
;   ������������� ����� ��� �������� ���������
;------------------------------------------------------------------------------
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "License_ENG.txt"
;Name: "russian"; MessagesFile: "C:\Program Files (x86)\Inno Setup 6\Languages\Russian.isl"; LicenseFile: "License_RUS.txt"


;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


;------------------------------------------------------------------------------
;   �����, ������� ���� �������� � ����� �����������
;------------------------------------------------------------------------------
[Files]

; ����������� ����
Source: "D:\����\����\2 ����\2 ���\�ourse_project(�#)\Diabet.net\Diabet.net\bin\Release\Diabet.net.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "D:\����\����\2 ����\2 ���\�ourse_project(�#)\Diabet.net\Diabet.net\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs


;------------------------------------------------------------------------------
;   ��������� �����������, ��� �� ������ ����� ������
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon




