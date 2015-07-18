#include <iostream>
#include<conio.h>
using namespace std;
/*#define 
0 000000 g 010000 w 100000 M 110000 
1 000001 h 010001 x 100001 N 110001 
2 000010 i 010010 y 100010 O 110010 
3 000011 j 010011 z 100011 P 110011 
4 000100 k 010100 A 100100 Q 110100 
5 000101 l 010101 B 100101 R 110101 
6 000110 m 010110 C 100110 S 110110 
7 000111 n 010111 D 100111 T 110111 
8 001000 o 011000 E 101000 U 111000 
9 001001 p 011001 F 101001 V 111001 
a 001010 q 011010 G 101010 W 111010 
b 001011 r 011011 H 101011 X 111011 
c 001100 s 011100 I 101100 Y 111100 
d 001101 t 011101 J 101101 Z 111101 
e 001110 u 011110 K 101110 . (Dot) 111110 
f 001111 v 011111 L 101111 
#define - 111111 */

bool Strcmp(const char *a,const char *b)
{
     if(a[0]==b[2] && a[1]==b[3] && a[2]==b[4] && a[3]==b[5])return 1;
     else return 0;
}
int main()
{
    char table[64][9]=
    {    
            "0 000000","g 010000","w 100000","M 110000", 
            "1 000001","h 010001","x 100001","N 110001",
            "2 000010","i 010010","y 100010","O 110010",
            "3 000011","j 010011","z 100011","P 110011",
            "4 000100","k 010100","A 100100","Q 110100",
            "5 000101","l 010101","B 100101","R 110101",
            "6 000110","m 010110","C 100110","S 110110",
            "7 000111","n 010111","D 100111","T 110111",
            "8 001000","o 011000","E 101000","U 111000",
            "9 001001","p 011001","F 101001","V 111001",
            "a 001010","q 011010","G 101010","W 111010",
            "b 001011","r 011011","H 101011","X 111011",
            "c 001100","s 011100","I 101100","Y 111100",
            "d 001101","t 011101","J 101101","Z 111101",
            "e 001110","u 011110","K 101110",". 111110",
            "f 001111","v 011111","L 101111","- 111111"
    };
    char DTable[16][7]={"0 0000","8 1000","1 0001","9 1001","2 0010","A 1010",
                        "3 0011","B 1011","4 0100","C 1100","5 0101","D 1101",
                        "6 0110","E 1110","7 0111","F 1111"};
    char input_text[23]="e";
    char bit_list[133]={};
    char pieces[33][5]={};
    char encrypted[33]={};
    int k=0,l=0,m=0;
    cout<<"Enter Input Text for encryption"<<endl;
  //  cin.getline(input_text,23);
    for(int i=0;input_text[i]!='\0';i++)
    {
            for(int j=0;j<64;j++)
            {
                    if(input_text[i]==table[j][0])
                    {
                      for(int count=1,index=2;count<=6;count++,index++)
                      {
                              bit_list[k]=table[j][index];
                              k++;                              
                      }
                      break;
                    }
            }
    }
    bit_list[k]='\0';
    cout<<endl<<bit_list<<endl; 
    for(int i=0;i<33;i++)
    {
            for(int j=0;j<4;j++)
            {
                    pieces[i][j]='\0';
                    pieces[i][j]=bit_list[l];
                    l++;
            }
    }
    cout<<endl;
    for(int i=0;i<33;i++)
    {
        if(pieces[i][0]!='\0' && pieces[i][1]=='\0')
        {
          pieces[i][3]=pieces[i][0];
          pieces[i][0]=pieces[i][1]=pieces[i][2]='0';
        }
        else if(pieces[i][0]!='\0' && pieces[i][1]!='\0' && pieces[i][2]=='\0')
        {
             pieces[i][2]=pieces[i][0];
             pieces[i][3]=pieces[i][1];
             pieces[i][0]=pieces[i][1]='0';
        }
        else if(pieces[i][0]!='\0' && pieces[i][1]!='\0' && pieces[i][2]!='\0' && pieces[i][3]=='\0')
        {
             pieces[i][3]=pieces[i][2];
             pieces[i][2]=pieces[i][1];
             pieces[i][1]=pieces[i][0];
             pieces[i][0]='0';
        }
    }                        
                      
    for(int i=0;i<33;i++)
    {
            if(pieces[i][0]!='\0')
            {cout<<pieces[i];
            cout<<":";}
    }
    cout<<"\b ";  
    for(int i=0;i<33;i++)
    {
            for(int j=0;j<16;j++)
            {
                    if(Strcmp(pieces[i],DTable[j]))
                    {
                      encrypted[m]=DTable[j][0];
                      m++;
                      break;
                    }
            }                    
    }
    cout<<endl;
    for(int i=0;encrypted[i]!='\0';i++)
    {
            cout<<encrypted[i];
            if((i+1)%4==0)cout<<":";
    }
    char decrypt_it[41]="0011:0010";
    cout<<"Enter text for Decryption"<<endl;
  //  cin.getline(decrypt_it,41);
    cout<<endl<<decrypt_it;
    char Dbit_list[133]={};int n=0;
    for(int i=0;decrypt_it[i]!='\0' && i<41;i++)
    {
            if(decrypt_it[i]==':')continue;
            for(int j=0;j<16;j++)
            {
                    if(decrypt_it[i]==DTable[j][0])
                    {
                      Dbit_list[n]=DTable[j][2];n++;
                      Dbit_list[n]=DTable[j][3];n++;
                      Dbit_list[n]=DTable[j][4];n++;
                      Dbit_list[n]=DTable[j][5];n++;
                      break;
                    }
            }
    }
    cout<<endl;
    int index=0;
    char Defrag[22][7]={};
    for(int i=0;i<22;i++)
    {
            for(int j=0;j<6;j++)
            {
                    Defrag[i][j]=Dbit_list[index];
                    index++;
            
            }
    }
    for(int i=0;i<22;i++)
    {
            for(int j=0;j<64;j++)
            {
                    if(Defrag[i][0]==table[j][2],Defrag[i][1]==table[j][3],Defrag[i][2]==table[j][4],
                       Defrag[i][3]==table[j][5],Defrag[i][4]==table[j][6],Defrag[i][5]==table[j][7]
                       )
                    {
                        cout<<table[j][0];
                        break;
                    }
            }
    }


    _getch();
    return 0;
}
