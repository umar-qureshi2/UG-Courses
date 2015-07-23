
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

mov ax,6    ; ax = 0006
mov bx,8    ; bx = 0008
mov ax,bx   ; ax = 0008 
mov cl,al   ; cl = 08
mov si,ax   ; si = 0008


ret




