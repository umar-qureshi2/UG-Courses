//SNAKE
#include<iostream.h>
#include<conio.h>
#include<fstream.h>
#include<stdlib.h>
#include<dos.h>
/////////////////////////////
union REGS in,out;

		 int callmouse()
		 {
				  in.x.ax=1;
				  int86(51,&in,&out);
				  return 1;
		 }
		 void mouseposi(int &xpos,int &ypos,int &click)
		 {
				  in.x.ax=3;
				  int86(51,&in,&out);
				  click=out.x.bx;
				  xpos=out.x.cx;
				  ypos=out.x.dx;
		  }
		 int mousehide()
		 {
				  in.x.ax=2;
				  int86(51,&in,&out);
				  return 1;
		 }
		void menu()
		{
cout<<"\nÉÍ»";
cout<<"\nº º";
cout<<"\nº º";
cout<<"\nº ÈÍÍÍÍÍÍÍÍÍÍÍÍ»";
cout<<"\nº ÚÄÄÄÄÄÄÄÄÄÄÄ¿º";
cout<<"\nº ³ÉÍÍÍÍÍÍÍÍÍ»³º";
cout<<"\nº ³º  START  º³º";
cout<<"\nº ³ÈÍÍÍÍÍÍÍÍÍ¼³º";
cout<<"\nº ³ÉÍÍÍÍÍÍÍÍÍ»³º";
cout<<"\nº ³º  LOAD   º³º";
cout<<"\nº ³ÈÍÍÍÍÍÍÍÍÍ¼³º";
cout<<"\nº ³ÉÍÍÍÍÍÍÍÍÍ»³º";
cout<<"\nº ³º OPTIONS º³º";
cout<<"\nº ³ÈÍÍÍÍÍÍÍÍÍ¼³º";
cout<<"\nº ³ÉÍÍÍÍÍÍÍÍÍ»³º";
cout<<"\nº ³º  ABOUT  º³º";
cout<<"\nº ³ÈÍÍÍÍÍÍÍÍÍ¼³º";
cout<<"\nº ³ÉÍÍÍÍÍÍÍÍÍ»³º";
cout<<"\nº ³º  EXIT   º³º";
cout<<"\nº ³ÈÍÍÍÍÍÍÍÍÍ¼³º";
cout<<"\nº ÀÄÄÄÄÄÄÄÄÄÄÄÙº";
cout<<"\nº ÉÍÍÍÍÍÍÍÍÍÍÍÍ¼";
cout<<"\nº º";
cout<<"\nÈÍ¼";
		}
		int button(int x1,int x2,int y,int mouse_x,int mouse_y,int click)
		{
			for(x1;x1<=x2;x1++)
				if(mouse_x==x1&&mouse_y==y)
					if(click==1)
						return 1;
			return 0;
		}
/////////////////////////////
int level=90;//speed
/*void delay(int x)
{
	for(double i=0;i<22222*x;i++);
} */
class snake{
	int wall_x,wall_y;
	public:
	snake()
	{
		wall_x=1,wall_y=1;
	}
	////////////key-press start////////////////
	void keypress(int x,int y)
	{
		collision(x,y);
		gotoxy(x,y);
		char a=254;
		cout<<a;
		delay(level);//for laging

	}
	////////////key-press end//////////////////
	void borders();
	void collision(int &,int &);

	};
	int main_menu();
	void snake::collision(int &x,int &y)
	{
		fstream wall("wall.txt",ios::in);
		while(!wall.eof())
		{
		wall>>wall_x>>wall_y;
		if(wall_x==x&&wall_y==y)
		{
			gotoxy(13,10);
			cout<<"Foo Dead";
			sleep(5);
			main_menu();
		}
		}
		wall.close();
	}
	//////////////border-start/////////////////
	void snake::borders()
	{
		fstream wall("wall.txt",ios::in);
		char brick=219;
		while(!wall.eof())
		{
		wall>>wall_x>>wall_y;
		gotoxy(wall_x,wall_y);
		cout<<brick;
		}
		wall.close();
	}
/////////////////border-end///////////////
///////////////////////intro////////////////
void intro()
{
	fstream file("intro.txt",ios::in);
	int inx,iny;
	while(!file.eof())
	{
		file>>inx>>iny;
		gotoxy(inx,iny);
		delay(5);
		cout<<'0';
	}
	cout<<"\n\n\n\n\n\n\n\t\t1.START\n\t\t2.LOAD\n\t\t3.OPTIONS\n\t\t4.ABOUT\n\t\t5.EXIT";
}
//////////////////////intro-end//////////////////////
//******************************************************************
enum keys{RIGHT=77,LEFT=75,UP=72,DOWN=80,ESC=27}key;

void food(int,int,int&);
int game(int =17,int =12,int =3);
void save(int,int,int);
void load();
void ESC_menu(int,int,int);
void options();
void about();
int main_menu()
{
{
int mouse_x,mouse_y,click;
				 clrscr();
				 callmouse();
				 menu();
				 do
				 {
						  mouseposi(mouse_x,mouse_y,click);
						  mouse_x/=8;mouse_y/=8;
						  if(button(4,12,7,mouse_x,mouse_y,click))//start game
								game();
						  if(button(4,12,10,mouse_x,mouse_y,click))//load game
								load();
						  if(button(4,12,13,mouse_x,mouse_y,click))//options game
								options();
						  if(button(4,12,16,mouse_x,mouse_y,click))//about game
								about();
						  if(button(4,12,19,mouse_x,mouse_y,click))//exit game
								exit(1);
				 }while(1);
				 mousehide();
}
return 0;
}
void about()
{
	clrscr();
	cout<<"OOP PROJECT\nMISS RABIA KHAN\n\n\nMOHSIN\nBASIT\nHAMZA\nESSAM";
	getch();
	main_menu();
}
void options()
{
	clrscr();
	cout<<"\nMANAGE SPEED";
	int key;
	while(key!=ESC)
	{

		gotoxy(1,1);
		cout<<"\nMANAGE SPEED";
		key=getch();
		if(key==UP)
		{
			cout<<"\nSPEED:"<<level;
			level--;
		}
		if(key==DOWN)
		{
			cout<<"\nSPEED:"<<level;
			level++;

		}
		cout<<"      ";
	}
	main_menu();
}

//******************************************************************
void ch_key(int &k,keys & key)
{
		if(k==RIGHT)
			if(key==LEFT)
				key=RIGHT;
		if(k==LEFT)
			if(key==RIGHT)
				key=LEFT;
		if(k==UP)
			if(key==DOWN)
				key=UP;
		if(k==DOWN)
			if(key==UP)
				key=DOWN;

		k=key;
}

int game(int xCO,int yCO,int s)
{
	clrscr();
	key=RIGHT;
	int k=RIGHT;
	int c=0,xCO_last[200]={0},yCO_last[200]={0};//counter,last loc of x,last loc of y
	snake s1;
	s1.borders();
	//******************************************************************
	while(key!=ESC)
	{
	////////////////////////  implemnetation of size n previous loc
	if(c==s)
		c=0;
	gotoxy(xCO_last[c],yCO_last[c]);
	cout<<' ';
	//////////////////////// previous loc save
		xCO_last[c]=xCO;
		yCO_last[c]=yCO;
	//******************************************************************

	if(kbhit())
	{
		key=getch();
		if(key==0)//because of enum
		key=getch();
		ch_key(k,key);
	}

	if(key==RIGHT)
		s1.keypress(++xCO,yCO); //>
	if(key==LEFT)
		s1.keypress(--xCO,yCO); //<
	if(key==UP)
		s1.keypress(xCO,--yCO); //^
	if(key==DOWN)
		s1.keypress(xCO,++yCO); //v
	if(key==ESC)
		ESC_menu(xCO,yCO,s);

	c++;  //index of previous loc array
	//////////////self-collision/////////////
	if(key==LEFT||key==RIGHT||key==UP||key==DOWN)//inplace of enum
	for(int i=0;i<s;i++)
		if(xCO==xCO_last[i]&&yCO==yCO_last[i])
			{
		gotoxy(13,10);
	    cout<<"Foo Dead";
	    sleep(5);
	    main_menu();
	 }
	/////////////self-collision end///////////

	food(xCO,yCO,s);
	}
	return 0;
}
void food(int xCO,int yCO,int &s)
{
	static int food_x=12,food_y=13;
	static int seed=0;
	static int score=0;
	/////////////food/////////////////////////
	srand(seed);
	gotoxy(food_x,food_y);
	cout<<char(15);
	gotoxy(40,20);
	cout<<"score:"<<score;
	if(xCO==food_x&&yCO==food_y)
		food_x=rand()%32+2,food_y=rand()%22+2,s++,score+=5;
	/////////////food-end//////////////////////
	seed++;//seed for rand()
}
void ESC_menu(int xCO,int yCO,int s)
{
	clrscr();
	cout<<"\nESC_MENU()\n";
	cout<<"\n1.RESUME\n2.SAVE\n3.LOAD\n4.main_menu()\n5.EXIT";
	int op;
	cin>>op;
	switch(op)
	{
		case 1:
			game(xCO,yCO,s);
			break;
		case 2:
			save(xCO,yCO,s);
			break;
		case 3:
			load();
			break;
		case 4:
			main_menu();
			break;
		case 5:
			exit(1);
			break;
	}
}
void save(int xCO,int yCO,int s)
{
	fstream save("save.txt",ios::out);
	save<<xCO<<' '<<yCO<<' '<<s;
	save.close();
	game(xCO,yCO,s);
}
void load()
{
	ifstream load;
	int xCO,yCO,s;
	load.open("save.txt") ;
	if(load)
	{
		load>>xCO>>yCO>>s;
		load.close();
		game(xCO,yCO,s);
	}
	else
	{
		cout<<"\n NO PREVIOUS SAVED DATA.";
		sleep(3);
		game(xCO,yCO,s);
	}
}
void main()
{
	main_menu();
}