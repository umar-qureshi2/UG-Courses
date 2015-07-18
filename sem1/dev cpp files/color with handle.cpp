// color your text in Windows console mode
// colors are 0=black 1=blue 2=green and so on to 15=white  
// colorattribute = foreground + background * 16
// to get red text on yellow use 4 + 14*16 = 228
// light red on yellow would be 12 + 14*16 = 236
// a Dev-C++ tested console application by  vegaseat  07nov2004

#include <iostream>
#include <windows.h>   // WinApi header

using namespace std;    // std::cout, std::cin

int main()
{
keybd_event(VK_MENU, 0x38, 0, 0);
keybd_event(VK_RETURN, 0x1c, 0, 0);
keybd_event(VK_RETURN, 0X1c, KEYEVENTF_KEYUP, 0);
keybd_event(VK_MENU, 0x38, KEYEVENTF_KEYUP, 0); 
  HANDLE  hConsole;
	int k;
	
  hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
   for(k = 0; k < 255; k++)
  {
    // pick the colorattribute k you want
    SetConsoleTextAttribute(hConsole, k);
    cout << k << "\n I want to be nice today!" ;
    cin.get(); 
       
  }
  // you can loop k higher to see more color choices
 // SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_RED);

 // SetConsoleTextAttribute(hConsole, 155);  
 // cout<<"HELLO UMARS"<<endl<<"FDSFDSFS"<<endl<<"DSDSD";
  cin.get(); // wait
  return 0;
}
