!include "Package.nsh"

!include "MUI.nsh"

!define MUI_WELCOMEPAGE_TITLE "Application Title"
!define MUI_WELCOMEPAGE_TEXT "Application Description"

!insertmacro MUI_PAGE_DIRECTORY


Section "Main" SEC01
	SetOutPath $INSTDIR
	
SectionEnd