#include<iostream>
#include<conio.h>
using namespace std;
int main()
{  
    bool press =0;
    cout<<"ENTER YOUR PETITION"<<endl;
    char defalt[100]="umar, please answer the following question;" ,c='\0' ,answer[100]="";
    while(c!=':')
    {
            c=getch();
            if(c=='.' && (!press))
            {
                      press=1;
                      for(int l=0;answer[l-1]!='.';l++) 
                      {                     
                          answer[l]=getch();
                          cout<<defalt[l];
                      }
                      cout<<'\b';                                        
            }
            else cout<<c;           
    }
    cout<<endl<<"Now Enter Your Qurestion: \n";cin>>defalt;     
    cout<<endl<<"The Answer is :"<<answer<<endl;
    _getch();
     return EXIT_SUCCESS;
}
