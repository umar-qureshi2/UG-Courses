
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h
.data
    var1 db 'Enter Lowercase character : ','$'
    space db 0dh,0ah,'$'
    var2 db 'Same Character in Uppercase : ','$'
    
.code
    mov dx,offset var1
    mov ah,09h           ;var1 string display
    INT 21h
    
    mov ah,1h            ;input character
    INT 21h
    
    sub al,32            ;subtract input character to 32 to make it Upper
    mov bl,al
    
    mov dx,offset space
    mov ah,09h           ;space string display
    INT 21h
    
    mov dx,offset var2
    mov ah,09h           ;var2 string display
    INT 21h
    
    
    mov dl,bl            ;Output same character in uppercase
    mov ah,2h
    INT 21h

ret