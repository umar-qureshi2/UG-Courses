
; You may customize this and other start-up templates; 
; The location of this template is c:\emu8086\inc\0_com_template.txt

org 100h

MOV    AX, 1212h   ; store 1212h in AX.
MOV    BX, 3434h   ; store 3434h in BX
PUSH   AX          ; store value of AX in stack.
PUSH   BX          ; store value of BX in stack.
POP    AX          ; set AX to original value of BX.
POP    BX          ; set BX to original value of AX.
RET
END