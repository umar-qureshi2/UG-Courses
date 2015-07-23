
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

.data
	array db 10,20,30,40
	
.code
	mov al, array       ;al = 0A
	mov bl, array+1     ;bl = 14
	mov cl, array+2     ;cl = 1E
	mov dl,array+3      ;dl = 28

ret