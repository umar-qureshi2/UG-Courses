
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.code
mov dl,'s'
sub dl,32
mov ah,2h
int 21h

ret