
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    count db 20
    wordList dw 1000h,2000h

.code
    mov al,count           ;al = 20
    mov bx,wordList        ;bx = 1000
    mov cx,wordList[2]     ;cx = 2000


ret