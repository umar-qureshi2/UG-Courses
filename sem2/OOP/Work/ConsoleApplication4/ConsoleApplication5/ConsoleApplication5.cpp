// ConsoleApplication5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<conio.h>
using namespace std;
class fraction
{
private:
	double num;
	double den;
public:
	fraction(int n,int d)
	{
		num=n;
		den=d;
	}
	void read()
	{
		cout<<"Enter num=";
		cin>>num;
		cout<<"\nEnter den=";
		cin>>den;
	}
	void add_frac(const fraction f)
	{
		cout<<"result is="<<(num*f.den + f.num*den)/(f.den*den)<<"\n\n";
	}
};
int main()
{
	fraction ff1(4,3),ff2(0,0);
	ff2.read();
	ff1.add_frac(ff2);
	_getch();
	return 0;

}