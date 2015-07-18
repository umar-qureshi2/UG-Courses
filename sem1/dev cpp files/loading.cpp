#include<iostream>
#include<conio.h>
#include<windows.h>
using namespace std;
void print()
{
     for(int i=0;i<56;i++)
     {
     cout<<char(219);
     for(int j=0;j<1e7;j++);
     }  
}
int main()
{
    system("color 1F");char pl[]="PLEASE WAIT...";
     cout<<"\n\n\n\n\n\n\n\n\n\t\t\t   LOADING, ";
     for(int i=0;i<13;i++)
     { Sleep(100);
       cout<<pl[i];
     }
     cout<<"\n\t";
     print();cout<<"\n";
     getch();
     return 0;
}
