// ConsoleApplication3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<conio.h>
using namespace std;
class xyz
{
private:
	int a;
	char ch;
public:
	xyz(int v,char vh);
	void display();
};
xyz::xyz(int v,char vh)
{
	a=v;
	ch=vh;
}
void xyz::display()
{
	cout<<"display is:\n\n"<<a<<"\n"<<ch;
}


int main()
{
	xyz cc(10,'x');
	cc.display();
	_getch();
	return 0;
}







