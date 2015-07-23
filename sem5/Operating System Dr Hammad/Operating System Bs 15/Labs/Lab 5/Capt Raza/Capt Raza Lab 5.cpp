#include<iostream.h>
#include<stdio.h>
#include<conio.h>

struct pro
{
int id;
int ts;
pro *next;
};

class execute
{
pro *front;

public:

	execute()
   {
   front=NULL;
   }

   void add(int i,int t)
   {
   pro *p=new pro;
   p->id=i;
   p->ts=t;
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
      cout<<temp->id<<" - "<<temp->ts<<endl;
      temp=temp->next;
      }
   }

   void start()
   {
   while(!IsEmpty())
   	{
      show();
      cout<<endl;
      front->ts--;
      if(front->ts>0)
      	add(front->id,front->ts);
      remove();
      }
   }



};

void main(void)
{
execute e;
for(int i=0;i<3;i++)
	e.add(i,i+2);
e.start();
getch();
}

