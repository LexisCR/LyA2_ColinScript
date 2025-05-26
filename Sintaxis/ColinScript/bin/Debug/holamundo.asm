
.386
.model flat, stdcall
option casemap:none

STD_OUTPUT_HANDLE equ -11

.data
msg db 'Hola mundo',0
msgLen equ $ - msg

.code
extrn GetStdHandle@4 : proc
extrn WriteConsoleA@20 : proc
extrn ExitProcess@4 : proc

start:
    push STD_OUTPUT_HANDLE
    call GetStdHandle@4
    mov ebx, eax

    push 0
    push 0
    push msgLen
    push offset msg
    push ebx
    call WriteConsoleA@20

    push 0
    call ExitProcess@4
end start
