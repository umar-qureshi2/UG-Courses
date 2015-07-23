
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    array db 2,16,4,22,13,19,42,64,44,88

.code
    mov bx,5            ;bx = 0005
    mov al,array[bx]    ;al = 13
ret