include "emu8086.inc"

; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
    byte_array db 10h, 20h, 30h
    word_array dw 1000h, 2000h, 3000h
    sums dw 0,0

.code
    mov di,0
    mov ax,0
    mov bx,0
    mov cx,3
    
    lo:
        add al,byte_array[di]
        add di,1
        loop lo
        
    CALL PRINT_NUM        

ret

DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS