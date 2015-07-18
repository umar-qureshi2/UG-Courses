#include<iostream>
#include<conio.h>
#include<windows.h>
using namespace std;
int main()
{
    for(int i=0;i<150;i++)
    {
            if(1%2==1)
            cout<<(char)255;
            if(i%2==0)
            cout<<(char)254;
            Sleep(100);
            cout<<"\b";
    }
    getch();
}
