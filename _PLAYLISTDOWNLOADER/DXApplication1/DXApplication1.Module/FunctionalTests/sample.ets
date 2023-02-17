;#DropDB DXApplication1EasyTest

#Application DXApplication1Win
#Application DXApplication1Blazor
#IfDef DXApplication1Win

*Action About...
 
*Action OK

#EndIf

#IfDef DXApplication1Blazor
!Action Navigation(My Details)
#EndIf
