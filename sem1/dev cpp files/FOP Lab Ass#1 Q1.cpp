#include<iostream>
#include<conio.h>
#include<windows.h>
#include<stdio.h>
using namespace std;
int main()
{
    int a=0,b=0;
    cout<<"Enter a 5-digit number: ";
    scanf("%5d",&a);
    while(a>0)
    {
              b+=a%10;
              a/=10;
    }
    cout<<"\nTotal Sum of 5 digits is: "<<b<<endl;
    _getch();
    return EXIT_SUCCESS;
}
