#include<iostream>
#include<conio.h>
#include<windows.h>
#include<stdio.h>
#include<iomanip>
using namespace std;
#define SQR 2
int a[SQR][SQR]={0},b[SQR][SQR]={0},c[SQR][SQR]={0};
inline void assign(bool qq =1)
{
     for(int i=0;i<SQR;i++)
     {
             for(int j=0;j<SQR;j++)
             {
                     cout<<"Enter Element M("<<i+1<<","<<j+1<<"): ";
                     cin>>((qq)?(a[i][j]):(b[i][j]));
             }
     }
}
inline void Product()
{
for(int i=0; i<SQR; i++)
   	{
   		for(int j=0; j<SQR; j++)
      	{      		
      		for(int k=0; k<SQR;k++)
         		c[i][j] += a[i][k]*b[k][j];
        }
   	}

}
inline void Print()
{cout<<"\t\t\t";
     for(int i=0;i<SQR;i++)
     {
             for(int k=0;k<19;k++)cout<<(char)219;cout<<endl<<"\t\t\t"<<(char)219;
             for(int j=0;j<SQR;j++)
             {
                     cout<<setfill(' ')<<setw(8)<<c[i][j]<<(char)219;
             }cout<<endl<<"\t\t\t";
     }for(int k=0;k<19;k++)cout<<(char)219;
}

int main()
{
    cout<<"Enter Elements for Matrix 1:"<<endl;
    assign();
    cout<<"Enter Elements for Matrix 2:"<<endl;
    assign(0);
    cout<<"The Sum Matrix is:"<<endl;
    Product();
    Print();
    _getch();
    return EXIT_SUCCESS;
} 
       
