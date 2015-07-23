
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

include "emu8086.inc"  

org 100h
		
.data


.code

mov ax, 100
add ax, 5

CALL PRINT_NUM
		
ret

                
DEFINE_PRINT_NUM
DEFINE_PRINT_NUM_UNS 

end




