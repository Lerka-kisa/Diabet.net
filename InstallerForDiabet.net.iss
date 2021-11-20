; Имя приложения
#define   Name       "Diabeta.net"
; Версия приложения
#define   Version    "1.0"
; Фирма-разработчик
#define   Publisher  "Valeria Troshko"
; Сафт фирмы разработчика
#define   URL        "https://vk.com/lerka_kisa_mur"
; Имя исполняемого модуля
#define   ExeName    "Diabeta.net.exe"

[Setup]

; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{F3E2EDB6-78E8-4539-9C8B-A78F059D8647}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=D:\Доки\Уник\2 курс\2 сем\Сourse_project(С#)\Diabet.net
OutputBaseFileName=test-setup

; Файл иконки
SetupIconFile=D:\icon.ico

; Параметры сжатия
Compression=lzma
SolidCompression=yes

;------------------------------------------------------------------------------
;   Устанавливаем языки для процесса установки
;------------------------------------------------------------------------------
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "License_ENG.txt"
;Name: "russian"; MessagesFile: "C:\Program Files (x86)\Inno Setup 6\Languages\Russian.isl"; LicenseFile: "License_RUS.txt"


;------------------------------------------------------------------------------
;   Опционально - некоторые задачи, которые надо выполнить при установке
;------------------------------------------------------------------------------
[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


;------------------------------------------------------------------------------
;   Файлы, которые надо включить в пакет установщика
;------------------------------------------------------------------------------
[Files]

; Исполняемый файл
Source: "D:\Доки\Уник\2 курс\2 сем\Сourse_project(С#)\Diabet.net\Diabet.net\bin\Release\Diabet.net.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "D:\Доки\Уник\2 курс\2 сем\Сourse_project(С#)\Diabet.net\Diabet.net\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs


;------------------------------------------------------------------------------
;   Указываем установщику, где он должен взять иконки
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon




