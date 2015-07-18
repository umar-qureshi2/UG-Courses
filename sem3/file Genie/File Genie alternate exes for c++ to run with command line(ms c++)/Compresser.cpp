#ifndef my_header_h
#define my_header_h

//////////////////////////////////////HEADERS///////////////////////////////

#include<iostream>
#include<string>
#include<sstream>//for stringstream
#include<fstream>
#include<vector>//for static stack
using namespace std;

using std::stringstream;





//////////////////////////////////GLOBALS///////////////////////////////////

std::string lookup[256];	//a Hash table for max of 256 distinct chars 
                           /*with theri ASCII values as keys*/
/////////////////////////////////STACK//////////////////////////////////////
/**
  *A stack class implemented using a vector as a dynamic array of integers
  *Also a vector konws its own size so indexs do not get out of range 
*/
class stack
{
private:
	vector<int> stackContainer;//vector helps in checking if index is out of range
	int top;

public:

	stack()
	{
		stackContainer.resize(255);
		top=0;
	}

	void push(int x){stackContainer[top++]=x;}
	int pop(){return stackContainer[top--];}
	bool isNotEmpty(){return top>-1;}
/**
  *takes 1 or 0 as an int 
  *converts it into a string that is placed at the corresponding hash value
  *of the chracter whose code it represents
  */
	void display(int c=0)
	{
		for(int i=0;i<top;i++)
		{
			cout<<stackContainer[i];
			lookup[c]+=char(stackContainer[i]+48);	//here stackContainer is container for stack elems; c=> the character for which the path is stored
		}
	}

}abc;

/////////////////////////////TREE NODE///////////////////////////////////

struct treeNode
{
	unsigned char ch;	//supposedly a character should be at a node
	treeNode *left,*right,*next;	//next is only used for priority queue type list
	int weight;			//for priority queue a node must have weight

	/////////////////////////////CONSTRUCTORS/////////////////////////////
/**
  *Default constructor
*/
	treeNode()
    {
              left=right=next=NULL;
              ch=0;
    }
/**
  *A consturctor that parses a treeNode pointer into a new treeNode
*/
	treeNode(treeNode *p)	//for copying from just a pointer
	{
		next=NULL;	//for insertion in PQ
		ch=p->ch;
		left=p->left;
		right=p->right;
		weight=p->weight;
	}

	/////////////////////////////////DISPLAY NODE(S)//////////////////////
 /**
  *Generates character code for each character from Huffman Tree
  *also displays character code along with the character itself after processing
  */
	void displayTree()		//displays tree if node is a parent, else only node is printed
	{
		if(this->left!=NULL)
		{
			abc.push(0);	//explicitly pusing '0' onto stack
			this->left->displayTree();
		}

		if(this->right!=NULL)
		{
			abc.push(1);
			this->right->displayTree();
		}

		if(this->ch>0 && this->ch<256) //leaf node i.e only it contains char, base case
		{
			abc.display(int(this->ch));	//the path for character is obtained from stack
			cout<<this->ch<<endl;
		}
		if(abc.isNotEmpty())
			abc.pop();	//then popping explicitly as we pushed '0' or '1'
	}
};

////////////////////////////MERGE TREE NODES///////////////////////////
/**
  *requires two non null treeNode pointers pointing to valid nodes
  *returns a new treeNode pointer containig a tree that has the aboves mentioned nodes as childeren
*/
treeNode* mTreeNodes(treeNode*l,treeNode*r)	//merges trees from forest--left and right subtree into a new tree
{
	treeNode *t=new treeNode;
   if(r==NULL)
   {
   	t->weight=l->weight;
      t->left=l;
      t->right=NULL;
      return t;
   }
	t->weight=l->weight+r->weight;
	if(l->weight<r->weight)
	{
		t->left=l;t->right=r;
	}
	else 
	{
		t->left=r;t->right=l;
	}
	return t;
}

///////////////LINKED LIST  Acting AS A  FROM PRIORITY QUEUE///////////////
/**
  *Priority Queue
  *it is not actually a priority queue but linked list used as PQ
*/

class PQ 
{
private:
	treeNode *head;		
	int size;

public:

	PQ()				//constructor
	{head=NULL;size=0;}

	////////////////////////////GET HEAD/////////////////////////////

	treeNode* getHead(){return head;}

	bool getSize1(){return size>1;}	//true if size>1

	//////////////////////////ENQUEUE////////////////////////////////

	void enq(treeNode *p)	//enqueues a tree node based on weight as priority
	{
		if(p==NULL)return;

		treeNode*t=head,*P=NULL;
		while(t!=NULL && t->weight<p->weight){P=t;t=t->next;}
		p->next=t;
		if(P!=NULL)P->next=p;
		else head=p;
		size++;
	}

	/////////////////////////DEQUEUE////////////////////////////////
	treeNode* deq()
	{
		treeNode *t=head;
		head=head->next;
		size--;
		return t;
	}
////////////////////////DESTRUCTOR////////////////////////////

	~PQ()
	{
		for(treeNode *t=head;head!=NULL ;)
		{
			t=head;head=head->next;
			delete t;
		}
	}
};//QUEUE ENDS


/////////////////////////////GLOBAL FUNCTIONS///////////////////
/*
  *requires a string containing the absolute path of a file
  *returns a string containing the path to pointing to the directory of that file
*/
string getPath(string s)	//return path of directory for file
{
	int pos = s.rfind("\\");
	string temp = s.substr(0,pos);
	return temp;
}
/**
 *requires a string containing the absolute path of a file
 *Returns a string containing the name of that file
*/
string getPiece(string s)	//returns the file name from path/directory
{
	int pos = s.rfind("\\");
	int pos2 = s.rfind(".");
	string temp;
	for(int i=pos+1;i<pos2;i++)
		temp += s[i];
	return temp;
}

#endif	//header file ends


//////////////////////////////////HUFFMAN CLASS//////////////////////////////

class Huffman
{
private:
	string fileName;//input file
	string output;//output file directory
	long double wrotes;	//records number of bits written
	PQ *q;				//this will contain the huffman tree at its head
	const static int maxChars=256;	//as the program is only made for ascii and 2^8=256//although it may work for allowed sets of UNICODE
	int count[maxChars];		//count to store frequencies of chars
	unsigned char BitContainer;//a buffer of 1 byte
	unsigned char BitCounter;//a counter representing the bit being processed

public:
       Huffman(char name[]);
       void Huffman::writeOutHuff(char []);
       void HuffHuff();
       void Output1Bit(int bit,ofstream& out);
       void Compress1Element(string code,ofstream& out);
	/////////////////////////DESTRUCTOR//////////////////////////////////////
	~Huffman(){delete q;}
};

	////////////////////////////CONSTRUCTOR////////////////////////////////
/**
  *Requies a character array acting as a C-string representing the absolute path of the file to be compressed
  *Initaializes all class variables
  *Constructs a hash table representing the frequencies of each character
  *creates a new directory of the same name as the file in the same dir as the to be compressed file
  *creates a a file with the same name as the file to be compressed in the above mentioned directory with .header extension
  *writes the above mentioned hash table to file with extension .header
  *creates a new Tree Node for each Active Symbol and enqueues it into the priority queue
*/
	Huffman::Huffman(char name[])//inputs file name
	{
		wrotes=0;
		BitCounter=0;
		BitContainer=0;
		fileName = name;
		ifstream in(name);
		if(!in){cout<<"file not opened"<<endl;return;}//opens and checks for file, assumes it is in correct format

		std::stringstream buffer;	//creates an object of stringstream to store input buffer from file
		buffer<<in.rdbuf();
		std::string cont(buffer.str());	//now that input buffer is converted into string

		for(int i=0;i<maxChars;i++)count[i]=0;	//sets the frequency table to zero

		int len=cont.length();
		for(int i=0;i<len;i++)//loop for counting and storing frequencies of character from buffer
		{
			char ch=cont[i];
			int id=(int)ch;
			if(id>=1 && id<=254)
				count[id]++;
		}

		output = getPath(fileName) + '\\' + getPiece(fileName);
		string temp = "mkdir \"" + output + "\"";
		system(temp.c_str());//creates new folder for the files
		string output_path = output +"\\" + getPiece(fileName) + ".header";
		ofstream wr(output_path.c_str(),ios::binary);//creates the .header file
		wr.write(reinterpret_cast<const char *>(count),maxChars*sizeof(*count));
		/*
		  *writes hash table containg frequencies 
          *of each character at index coressponding to that chacracters ASCII value
        */
		wr.close();
		in.close();

		q=new PQ;		//a new PQ for tree is created
		for(int i=0;i<maxChars;i++)
        /*creates tree nodes for each Active Character and enqueues it into the Priority Queue*/
		{
			if(count[i]>0)
			{
				treeNode *t = new treeNode();
				t->ch = char(i);
				t->weight=count[i];
				q->enq(t);
			}
		}
	}
	/////////////////////HUFFMAN TREE CREATION//////////////////////////////
/**
  *Requires that all Tree Nodes representing Active Characters have been created
  *And Enqueued into the Priorty Queue
  *Generates a huffman tree by combining the nodes in th PQ
  *the root of the tree is at the head of the priorty queue
*/
	void Huffman:: HuffHuff()		//now it creates the huffman tree
	{
   	if(!(q->getSize1())) //single element
         q->enq(mTreeNodes(q->deq(),NULL));
		while(q->getSize1())
		{
			q->enq(mTreeNodes(q->deq(),q->deq()));
		}
		cout<<"\n\n\t\tLegend Tree along with char at end\n"<<endl;
		q->getHead()->displayTree();
		system("pause");
	}
/////////////////////////////////////////////////////////////////////////
/**
  *a function that writes the bits to the output file
  *takes an intger represent the bit value to be writted as argument
  *An of stream objects that has an opened file assocated with it is also required by refrence
  *a bit value of -1 indicated that the buffer be filled with required padding bits and then written
*/
void Huffman::Output1Bit(int bit,ofstream& out)
{
	if (BitCounter == 8 || bit == -1)
	{
			while (BitCounter <8)//for padding bits
		{
			BitContainer=BitContainer << 1;
			BitCounter += 1;
			
		}
		out.put(BitContainer);
		//out.write(reinterpret_cast<const char *>(&BitContainer),sizeof(unsigned char));
		BitCounter = 0;
		BitContainer=BitContainer << 7;		
	}
	if(bit==-1) 
		return;
	BitContainer = (BitContainer << 1) | bit;
	BitCounter++;
	wrotes++;
}
////////////////////////////////////////////////////////////////////////
/**
  *Requires a string containing a valid character code representing a character
  *Requires a ofstream object with an opened file associated with it
  *Writes the code consisting of bits to the file thrugh the ofstream object
*/
void Huffman::Compress1Element(string code,ofstream& out)
{
     int i=0;
	 static int count=0;
	while(code[i]!='\0')
	{

		if (code[i]=='0')
			Output1Bit(0,out);
		else if(code[i]=='1')
			Output1Bit(1,out);
	    i++;
		count++;
    }
}

	/////////////////////WRITES THE COMPRESSED FILE///////////////////////////
/**
  *creates the .huff binary file
  *opens the file that is tobe compressed
  *reads the input file into a buffer and then closes it
  *runs a loop for the number of bytes in buffered
  *calls the 'Compress1Element' function to compress each byte
  *calls 'Output1Bit' with -1 as argument to write the last byte with padding
  */
void Huffman::writeOutHuff(char pass[25]="")
{
		string output_path = output +"\\"+ getPiece(fileName) + ".huff";	//path for output file
		ofstream out(output_path.c_str(),ios::binary);
		ifstream in(fileName.c_str());
		if(!in){cout<<"file not opened"<<endl;return;}	//opens input file

		std::stringstream buffer;
		buffer<<in.rdbuf();
		std::string cont(buffer.str());
		in.close();			//reads all the file into memory and closes it. it depends on OS whether the file is on pagefile.sys

		int len=cont.size();
		
		for(int i=0;i<len;i++)
		{
			int size=lookup[int(cont[i])].size();
			if(size>0)
			{
				Compress1Element(lookup[int(cont[i])],out);//calls compress element to write the code to file
								
			}				
				
		}
		Output1Bit(-1,out);//writes any bits still contained in the buffer after adding padding if required
		out.close();	//the compressed file is closed
		string output_path1 = output +"\\"+ getPiece(fileName) + ".bitPass";	//opens header for storing bytes written
		ofstream reopen(output_path1.c_str(),ios::binary);
		reopen.write(pass,25*sizeof(char));
		reopen.write(reinterpret_cast<const char *>(&wrotes),sizeof(wrotes));
		reopen.close();

	}




int main(int argc,char *argv[])
{
	if(argc>1)
	{
		Huffman read(argv[1]);
		read.HuffHuff();	//builds the huffman tree
		if(argc>2)
		read.writeOutHuff(argv[2]);
		else
		read.writeOutHuff();
	}
}
