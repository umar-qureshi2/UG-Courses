
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    aString db "ABCDEFG"

.code
    mov bx,offset aString   ;store the starting address of aString
    add bx,5                ;add 5 to starting address of aString
    mov dl,[bx]             ; dl = 46 i.e., F
ret