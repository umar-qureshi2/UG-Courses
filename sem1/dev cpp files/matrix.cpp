#include <iostream>
#include <conio.h>
using namespace std;

void getResult(double a[100][100], double b[100][100], double mVal, double pVal, double nVal)
{
		for(int i=0; i<mVal; i++)
   	{
   		for(int j=0; j<pVal; j++)
      	{
      		double res = 0;
      		for(int k=0; k<nVal; k++)
         		res += a[i][k]*b[k][j];
            	cout<<res<<"\t";
      	}
      	cout<<endl;
   	}
}

int main()
{
double a[100][100];
double b[100][100];
double mValue;
double nValue;
double pValue;
char ans;
char response;

do{
cout<<"\t\tM A T R I X   M U L T I P L I C A T I O N\n\n\n";
cout<<"This program will compute the product of two matrices.\n";
cout<<"\nAmxn and Bnxp, \n\nwhere m and p less than or equal to n (m, p <= n )\n";
cout<<"To use the program, just follow what the program asks.";
cout<<"\n\n\nNOTE:\n\tTo type the value or entries of a matrix just follow this; ";
cout<<"\n\n\t  1. You can type like this 1 2 3 4 5 6 . . . n\n";
cout<<"\n\t  2. or you can type like this \n\n\t    a11 a12 . . . a1n\n\t    a21 a22 . . . a2n \n\t    . . .";
cout<<"\n\t    .\n\t    .\n\t    .\n\t    am1 am2 . . . amxn or nxp\n\n";
cout<<"\nMAXIMUM DIMENSIONS = 10 X 10 (RECOMMENDED)\n";
cout<<"\nYOU CAN ALSO USE UP TO 100 X 100 DIMENSIONS\n\n\n";
cout<<"Want to use the program? : \n";
cout<<"type 'y' to continue and press any key to EXIT then press ENTER: ";
cin>>response;

	if((response=='y')||(response=='Y'))
   {
 		cout<<"\n\nEnter the value of m: ";
		cin>>mValue;
      while(mValue<=0)
   	{
      	cout<<"\n\nINCORRECT dimension(s), no negative or zero dimension(s) in a matrix\n";
   		cout<<"\nEnter the value of m greater than "<<mValue<<" : ";
   		cin>>mValue;
   	}
		cout<<"\nEnter the value of p: ";
		cin>>pValue;
      while(pValue<=0)
   	{
      	cout<<"\n\nINCORRECT dimension(s), no negative or zero dimension(s) in a matrix\n";
   		cout<<"\nEnter the value of p greater than "<<pValue<<" : ";
   		cin>>pValue;
   	}
		cout<<"\nEnter the value of n: ";
		cin>>nValue;
      while(nValue<0)
   	{  nValue = 0;
   		cout<<"\nEnter the value of n greater than "<<nValue<<" and less than "<<pValue<<" or "<<mValue<<" : ";
      	cin>>nValue;
   	}
      while((nValue>mValue)||(nValue>pValue))
   	{
         if(mValue>pValue)
         {
 				cout<<"\nERROR:\n\tValue of n must be less than or equal to "<<pValue<<"\n\n";
 				cout<<"Enter the value of n: ";
				cin>>nValue;
         }
         else
         {
         	cout<<"\nERROR:\n\tValue of n must be less than or equal to "<<mValue<<"\n\n";
 				cout<<"Enter the value of n: ";
				cin>>nValue;
         }
 		}


				cout<<"\n\nEnter a matrix with this dimension(s) A "<<mValue<<"x"<<nValue<<": \n";
				cout<<"\n\nType "<<(nValue*mValue)<<" entries for matrix A: \n\n";

            for(int i=0; i<mValue; i++)
   			{
      			for(int j=0; j<nValue; j++)
      				cin>>a[i][j];
   			}

				cout<<"\nThe value of matrix A that you have entered: \n\n";
   			for(int i=0; i<mValue; i++)
   			{
      	  		for(int j=0; j<nValue; j++)
      				cout<<a[i][j]<<"\t";
         			cout<<endl;
   			}
				cout<<"\n\nEnter a matrix with this dimension(s) B "<<nValue<<"x"<<pValue<<": \n";
				cout<<"\n\nType "<<(nValue*pValue)<<" entries for matrix B: \n\n";

				for(int i=0; i<nValue; i++)
   			{
   				for(int j=0; j<pValue; j++)
      				cin>>b[i][j];
   			}
   			cout<<"\nThe value of matrix B that you have entered: \n\n";
   			for(int i=0; i<nValue; i++)
   			{
   				for(int j=0; j<pValue; j++)
    		  		cout<<b[i][j]<<"\t";
   		      	cout<<endl;
   			}
				cout<<"\n\n\nThe PRODUCT is: \n\n";
   			getResult(a,b,mValue,pValue,nValue);
      }
      else
      	break;

   cout<<"\n\nTry again? \n\nType y to try again and press any key to stop then press ENTER. : ";
   cin>>ans;
}while((ans=='y')||(ans=='Y'));
cout<<"\n\n\nThanks for using this program.";


cin.get();
cin.get();
return 0;
}
