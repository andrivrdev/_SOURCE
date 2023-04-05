;#DropDB DXApplication4EasyTest

#Application DXApplication4Win
#Application DXApplication4Blazor
#IfDef DXApplication4Win

*Action About...
 
*Action OK

#EndIf

#IfDef DXApplication4Blazor
!Action Navigation(My Details)
#EndIf
