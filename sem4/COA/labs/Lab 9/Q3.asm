
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt


org 100h

.data
 var  db 'Program for comparison of two numbers and display the smallest one',0dh,0ah,0ah,'$';
 var1 db 'Enter Two Integars :  $ ';
 var2 db 0dh,0ah,0ah,'smallest number is :  $ ';
 var3 db 0ah,0dh,0ah,'These numbers are equal $';
 
 
.code
       
mov ah,9
mov dx,offset var
int 21h

mov ah,9
mov dx,offset var1
int 21h

mov ah,1h
int 21h
mov bh,al 

mov ah,1h
int 21h
mov bl,al

cmp bh,bl 
je l2
jb l3


mov ah,9
mov dx,offset var2
int 21h        

mov dl,bl
mov ah,2h 
int 21h


ret

l3:        
mov ah,9
mov dx,offset var2
int 21h 

mov ah,2h
mov dl,bh 
int 21h

ret

l2:
mov ah,9
mov dx,offset var3
int 21h

ret