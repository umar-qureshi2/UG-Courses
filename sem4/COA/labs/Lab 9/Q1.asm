
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

include "emu8086.inc"

org 100h

.data
var1 db 'Program that reads five unsigned integers from user and display sum of those five integers',0ah,0dh,0ah,'$';
var2 db 'Enter Five Integers : $'
var3 db 0ah,0dh,0ah,'Sum is : $'
var db 0;

.code

mov dx,offset var1
mov ah,9h
INT 21h

mov dx,offset var2
mov ah,9h
INT 21h
                                            
mov cx,5
mov di,0

lp:
mov ah,1
INT 21h
sub al, 30h
mov var[di],al
inc di
loop lp

mov bl,0
mov di,0
mov cx,5

l2:
add bl,var[di]
inc di
loop l2

mov dx,offset var3
mov ah,9h 
INT 21h 
MOV ax, 0
mov al, bl
CALL PRINT_NUM

ret

DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS


ret




