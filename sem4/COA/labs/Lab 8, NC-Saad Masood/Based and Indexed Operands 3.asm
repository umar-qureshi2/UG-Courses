
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    array db 10h,20h,30h,40h

.code
    mov bx,1            ;bx = 0001 
    mov si,2            ;si = 0002
    mov al,array[bx]    ;al = 20
    add al,array[bx+1]  ;al = 20+30 = 50
    add al,array[bx+si] ;al = 50+40 = 90
    mov [153],al        ;store 90 at location offset 153
ret