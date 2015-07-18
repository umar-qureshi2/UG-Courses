#include <iostream>
#include <conio.h>
#include <iomanip>
#include <stdio.h>
#include<process.h>
#include<windows.h>
#include<string>

using namespace std;

#define DIST     10
#define MONTHS   12

const char months[MONTHS][10]={"jan","feb","march","april",
							"may","june","july","aug","sep","oct","nov","dec"};

const char dist[DIST][5]={"RWP","LHR","ISB","BWP","KRH","FSB","MUL","PES","DGK","DIK"};

long double profit[DIST][MONTHS]={0};
long double sum=0;

void MSum()
{
	int i=0;
	cout<<"Enter Month Number"<<endl;
	cin>>i;
	if(i<1 || i>12)
	{
		cout<<"Error in input"<<endl;
		getch();
		return;
	}
	i--;
	for(int j=0;j<DIST;j++)
	{
		sum+=profit[j][i];
	}
	cout<<"Total Sum for "<<months[i]<<" is: "<<sum<<endl;
	getch();
}

void DSum()
{
	int i=0;
	char name[10];
	cout<<"Enter District Name"<<endl;
	cin>>name;
	for(i=0;strcmp(name,dist[i])!=0;i++);
	if(i<0 || i>12)
	{
		cout<<"Error in input"<<endl;
		getch();
		return;
	}
	for(int j=0;j<MONTHS;j++)
	{
		sum+=profit[i][j];
	}
	cout<<"Total Sum for "<<dist[i]<<" is: "<<sum<<endl;
	getch();
}

void Insertion()
{

	int i,j;char name[10];
	cout<<"Enter District Name"<<endl;
	cin>>name;
	for(i=0;strcmp(name,dist[i])!=0;i++);//if(strcmp(name,dist[i])==0)break;
	cout<<"Enter Month Number"<<endl;
	cin>>j;
	if(i<0 || j<1 || i>10 || j>12)       
	{

		cout<<"Problem in Entry"<<endl;
		getch();
		return;
	}
	
	cout<<"Enter Profit for "<<dist[i]<<" and month of "<<months[j-1]<<endl;
	cout<<"Enter profit above 100000"<<endl;
		while(1)
		{
			cin>>profit[i][j-1];
		//	scanf("%lf",&profit[i-1][j-1]);
			if(profit[i][j-1]>100000)break;
			else cout<<endl<<"!!You Entered Wrong Value!! Please Enter Again"<<endl;
		}		
}

void Print()
{
	int i,j;
	system("cls");
	cout<<endl<<"\t";
	for( i=0;i<MONTHS-6;i++)
		cout<<setfill(' ')<<setw(10)<<months[i];
	cout<<endl;
	for(i=0;i<DIST;i++)
	{
		cout<<setfill(' ')<<setw(10)<<dist[i];
		for( j=0;j<6;j++)
		{
			cout<<setfill(' ')<<setw(10)<<profit[i][j];
		}
		cout<<endl;
	}
	cout<<endl<<"\t";
	for(i=6;i<12;i++)
		cout<<setfill(' ')<<setw(10)<<months[i];
	cout<<endl;
	for(i=0;i<DIST;i++)
	{
			cout<<setfill(' ')<<setw(10)<<dist[i];
		for( j=6;j<12;j++)
		{
			cout<<setfill(' ')<<setw(10)<<profit[i][j];
		}
		cout<<endl;
	}
	system("pause");

}
void MonthWise()
{
		system("cls");
	int n;
	cout<<"Enter Number of Month"<<endl;
	scanf("%d",&n);
	if(n<1 || n>12)
	{
		cout<<"Error in entry "<<endl;
		return;
	}
	cout<<endl<<"\t\t"<<months[n-1]<<endl;
	for(int i=0;i<DIST;i++)
	{
		cout<<dist[i]<<"\t";
		cout<<profit[i][n-1]<<endl;
	}
	system("pause");
}


void DistWise()
{
		system("cls");
	int n;char name[10];
	cout<<"\nEnter District Name"<<endl;
	cin>>name;
	for(n=0;strcmp(name,dist[n])!=0;n++);
		if(n<1 || n>10)
	{
		cout<<"Error in entry "<<endl;
		return;
	}
	cout<<"\t\t"<<dist[n]<<endl;;
	for(int i=0;i<MONTHS;i++)
	{
		cout<<months[i]<<"\t\t";
		cout<<profit[n][i]<<endl;
	}

	system("pause");
}

void View()
{
		system("cls");
	int i,j;
	char name[10];
	cout<<"Enter District Name"<<endl;
	cin>>name;
	for(i=0;strcmp(name,dist[i])!=0;i++);
	cout<<"Enter Month Number"<<endl;
	cin>>j;
	if(i>=0 && j>0)
	cout<<"\nThe record for "<<dist[i]<<" and "<<months[j]<< " is: "<<profit[i][j-1]<<endl;
	system("pause");
}



void main()
{
/*	keybd_event(VK_MENU, 0x38, 0, 0);
	keybd_event(VK_RETURN, 0x1c, 0, 0);
	keybd_event(VK_RETURN, 0X1c, KEYEVENTF_KEYUP, 0);
	keybd_event(VK_MENU, 0x38, KEYEVENTF_KEYUP, 0); 
	system("color 1F");char pl[]="PLEASE WAIT...";
     cout<<"\n\n\n\n\n\n\n\n\n\t\t\t   LOADING, ";
     for(int qa=0;qa<13;qa++)
     { Sleep(100);
       cout<<pl[qa];
     }
     cout<<"\n\t";
	 for(int k=0;k<56;k++)
     {
     cout<<char(219);
     for(int j=0;j<1e7;j++);
     }
	 cout<<endl;system("pause");
	 system("cls");*/
	
	int c=0;
	int ch=0;
	cout<<"\n\n\n\n\t\t";SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 116);
	cout<<"Press '0' to continue with default values"<<endl;
	cin>>ch;
	for(int i=0;i<DIST;i++)
	{
		for(int j=0;j<MONTHS;j++)
		{
			if(ch==0)
				profit[i][j]=1;
			else
			{
			cout<<"Enter Profit for "<<dist[i]<<" and month of "<<months[j]<<endl;
			cout<<"enter profit above 100000"<<endl;
			while(1)
			{
				scanf("%lf",&profit[i][j]);
				if(profit[i][j]>100000)break;
				else cout<<endl<<"!!You Entered Wrong Value!!"<<endl;
			}
			}
		}
	}

	do
	{
		system("cls");
		cout<<"\t\tMain Menu"<<endl;
		cout<<"1: Insertion at a specific Location"<<endl;
		cout<<"2: Print Table"<<endl;
		cout<<"3: Month Wise Record"<<endl;
		cout<<"4: District Wise Record"<<endl;
		cout<<"5: View Specific Dist & Month"<<endl;
		cout<<"7: Sum of a Month for all districts"<<endl;
		cout<<"8: Sum of a district for all Months"<<endl;
		cout<<"9: Exit"<<endl;
		cout<<endl<<"Enter Your desired option"<<endl;
		scanf("%d",&c);
		switch(c)
		{
		case 0:
			exit(1);
		case 1:
			{
				Insertion();
				break;
			}
		case 2:
			{
				Print();
				break;
			}
		case 3:
			{

				MonthWise();
				break;
			}
		case 4:
			{
				DistWise();
				break;
			}
		case 5:
			{
				View();
				break;
			}
		case 6:
			{
				
				break;
			}
		case 7:
			{
				MSum();
				break;
			}
		case 8:
			{
				DSum();
				break;
			}

		default:
			cout<<"\nplease enter correct value"<<endl;
		}
	}while(c!=9);

}
