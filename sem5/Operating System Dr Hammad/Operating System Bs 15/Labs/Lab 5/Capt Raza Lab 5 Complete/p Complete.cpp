#include<iostream.h>
#include<stdio.h>
#include<conio.h>

struct pro
{
int id;
int ts;
bool block;
pro *next;
};

class execute
{
public:
	pro *front;

	execute()
   {
   front=NULL;
   }

   void add(int i,int t,bool b)
   {
   pro *p=new pro;
   p->id=i;
   p->ts=t;
   p->block=b;
   p->next=NULL;
   if(front==NULL)
   	{
	   front=p;
   	}
   else
	   {
   	pro *temp=front;

	   while(temp->next!=NULL)
   		{
         temp=temp->next;
         }
	   temp->next=p;
   	}
   }

   void remove()
   {
   if(!IsEmpty())
	  	front=front->next;
   }

   bool IsEmpty()
   {
   if(front==NULL)
   	return true;
   else
   	return false;
   }

   void show()
   {
   pro *temp=front;
   while(temp!=NULL)
   	{
      cout<<temp->id<<" - "<<temp->ts<<" - ";
      if(temp->block)
	      cout<<"Blocking";
      else
      	cout<<"Non Blocking";
      cout<<endl;
      temp=temp->next;
      }
   }
};

   void start(execute *e,execute *w)
   {
   while(!e->IsEmpty())
   	{
      e->show();
      cout<<endl;
      e->front->ts--;
      if(e->front->ts>0)
      	{
         if(e->front->block)
	         {
            w->add(e->front->id,e->front->ts,e->front->block);
            }
         else
         	e->add(e->front->id,e->front->ts,e->front->block);
         }
      e->remove();
      }

   cout<<endl<<"Now Processing Blocking One's"<<endl<<endl;

	while(!w->IsEmpty())
   	{
      w->show();
      cout<<endl;
      w->front->ts--;
      if(w->front->ts>0) 
      	{
        	w->add(w->front->id,w->front->ts,w->front->block);
         }
      w->remove();
      }
   }


void main(void)
{
execute ready,wait;
int ch,t;
for(int i=0;i<5;i++)
	{
   clrscr();
   cout<<"Enter time for process"<<i<<" in sec= ";
   cin>>t;
   cout<<"Is it Blocking"<<endl;
   cout<<"1.yes\n2.no\n";
   cout<<"Enter your choice= ";
   cin>>ch;
   if(ch==1)
   	ready.add(i,t,true);
   else
   	ready.add(i,t,false);
   }
clrscr();
cout<<"press any key to start processing...";
getch();
clrscr();
start(&ready,&wait);
getch();getch();
}

