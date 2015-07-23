#include <iostream>
#include <fstream>
#include <conio.h>
#include <cstring.h>

int main () {
  ifstream myfile;
  string line;
  myfile.open ("example.txt");
	if (myfile) {
   while(!myfile.eof())
   {
  		//myfile >> line;
      getline(myfile,line);
      cout<<line<<endl;
      }
  	}
   else
   	cout<<"Failed";
  myfile.close();
  getch();
  return 0;
}