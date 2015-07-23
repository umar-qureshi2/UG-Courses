include "emu8086.inc"
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    myArray DB 20 DUP (?)
    size = ($-myArray)
    sz db 0ah,0dh,'Size of the array is = $'

.code
    mov ah,09h
    mov dx, offset myArray
    INT 21h
    
    mov ax,size
    CALL PRINT_NUM
    
    mov ah,1h           ;getch
    INT 21h
    
ret

DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS
