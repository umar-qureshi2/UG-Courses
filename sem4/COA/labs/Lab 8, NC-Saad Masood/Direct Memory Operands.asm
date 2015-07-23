
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
varl db 10h

.code
mov al, [00010400]   ; store al to 20h
mov al ,varl         ; store al to 10h

ret