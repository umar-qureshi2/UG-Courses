
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    aWord dw 1234

.code
    mov bx, offset aWord



ret