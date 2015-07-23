
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt
   
org 100h

.data
var1 db 'Hello',,0dh,0ah,'World','$'

.code

	
	
	mov ah,09
	mov dx,offset var1
	INT 21H
	
	

ret




