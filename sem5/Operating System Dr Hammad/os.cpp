#include <iostream.h>
#include <conio.h>

class variable
{
   private:
   	int var;

	public:

   variable()
   {
   var=0;
   }

	void producer()
   {
   	if(var <= 5)
      {
      	var++;
         cout<<"producer" <<var<<endl;
      }
   }
   void consumer()
{
	if(var>0)
   {
   	var--;
      cout<<"consumer" <<var<<endl;
   }
}
};



main()
{
	variable v1;
   v1.consumer();
	v1.producer();

   getche();
   return 0;
}