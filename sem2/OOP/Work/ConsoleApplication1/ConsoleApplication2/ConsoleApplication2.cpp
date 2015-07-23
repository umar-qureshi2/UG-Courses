// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<conio.h>
#include<stdio.h>

using namespace std;
class Base
{
public :
	Base()
		 {
			 cout<<"Base"<<endl;
		}
         Base(int i)
		 {
			 cout<<"Base"<<i<<endl;
		 }
        ~Base()
		{
			cout<<"Base Destructor"<<endl;
		}
};
class Derived:public Base
{
public:
	Derived()
		{
			cout<<"Derived"<<endl;
	  }
        Derived(int i):Base(i)
		{
			cout<<"Derived"<<i<<endl;
		}
       ~Derived()
	   {
		   cout<<"Derived Destructor"<<endl;
	   }
};
int main()
{
    Base b;
    Derived d(2);
    _getch();
	return 0;
	
}

