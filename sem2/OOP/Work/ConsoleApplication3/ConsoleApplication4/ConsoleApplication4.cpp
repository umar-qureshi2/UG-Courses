// ConsoleApplication4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<conio.h>
using namespace std;
class addd
{
private:
	int a;
	int b;
public:
	addd();
	void input();
	void show_sum();
	void add_two_obj(addd,addd);
};

addd::addd()
{
	a=0;
	b=0;
}
void addd::input()
{
 cout<<"Enter first number=";
 cin>>a;
 cout<<"\n\n";
 cout<<"Enter second number=";
 cin>>b;
}
void addd::show_sum()
{
	cout<<"\n\nSum is="<<a+b<<"\n\n";
}
void addd::add_two_obj(addd xx,addd yy)
{
	cout<<"Sum is="<<xx.a+yy.a+xx.b+yy.b<<"\n\n";
}
int main()
{
	addd a,b,c;
	a.input();
	b.input();
	//a.show_sum();
	//b.show_sum();
	c.add_two_obj(a,b);
	_getch();
	return 0;
}