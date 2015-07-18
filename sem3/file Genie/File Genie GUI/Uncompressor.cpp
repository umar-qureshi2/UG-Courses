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

std::string lookup[256];	
/**
*a Hash table for max of 256 distinct chars with theri ASCII values as keys
*/

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
	void push(int x){stackContainer[top++]=x;}//postfix because top initialized to zero
	int pop(){return stackContainer[top--];}
	bool isNotEmpty(){return top>-1;}

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
	treeNode *left,*right,*next,*parent;	//next is only used for priority queue type list
	int weight;			//for priority queue a node must have weight

	/////////////////////////////CONSTRUCTORS/////////////////////////////
/**
  *Default constructor
*/
	treeNode()
    {
               left=right=next=parent=NULL;
               ch=0;
    }
/**
  *A consturctor that parses a treeNode pointer into a new treeNode
*/
	treeNode(treeNode *p)	//for copying from just a pointer
	{
		next=NULL;	//for insertion in PQ
		parent = p->parent;	//for backward traversal
		ch=p->ch;
		left=p->left;
		right=p->right;
		weight=p->weight;
	}

	/////////////////////////////////DISPLAY NODE(S)//////////////////////

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


///////////////LINKED LIST Acting AS A FROM PRIORITY QUEUE///////////////
/**
  *Priority Queue
  *it is not actually a priority queue but linked list used as PQ
*/

class PQ //priority queue, it is not actually a priority queue but linked list used as PQ
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

	void enq(treeNode *p)	//enqueues a tree node based on weight
	{
		if(p==NULL)return;

		treeNode*t=head,*P=NULL;//P==>previous
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
			t=head;
            head=head->next;
			delete t;
		}
	}
};//QUEUE ENDS


/////////////////////////////GLOBAL FUNCTIONS///////////////////
/**
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


class Huffman
{
private:
	string fileName;
	string output;
	PQ *q;				//this will contain the huffman tree at its head
	const static int maxChars=256;	//as the program is only made for ascii and 2^8=256
	int count[maxChars];		//count to store frequencies of chars
	long double wrotes;        //records number of bits written
	unsigned char BitContainer;//a buffer of 1 byte
	unsigned char BitCounter;//a counter representing the bit being processed
public:

       Huffman(char name[]);
       void unHuff(char []);//Decompresses a file using the Huffman tree
       void HuffHuff();//generates huffman tree
	   ~Huffman()
       {
           delete q;
       }
};
/////////////////////////*Class Declaration for decompressing file class ends*/////////
/**
  *Requies a character array acting as a C-string representing the absolute path of the file to be Decompressed with .huff extension
  *Requires a file with the same na,e as the .huff file and .header extension cointaing a hash table of frequencies of symbols
  *creates a new Tree Node for each Active Symbol and enqueues it into the priority queue
*/
    Huffman::Huffman(char name[])
	{
		fileName = name;
		output = getPath(fileName);
		string read_from = output +"\\"+ getPiece(fileName) + ".header";

		ifstream reader(read_from.c_str(),ios::binary);
		reader.read(reinterpret_cast<char*>(&count[0]),maxChars*sizeof(*count));	//now table is read in count
		reader.close();

		q=new PQ;		//a new PQ for tree is created
		for(int i=0;i<maxChars;i++)
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
	void Huffman::HuffHuff()		//now it creates the huffman tree
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
/**
  *requires a generated huffman tree with its root in the Priority queue	
  *Discards first 15 bytes from bitpass adn the reads the next 8 bytes to a variable
  *this variable represents the no. of bits to read
  *Creates a .txt file in the directory of the .huff file
  *Also opens the .huff file in binary format
  *Now it reads a byte into a 1 byte buffer and the treverses the tree
  *according to the bit sequence 
  *every time it reaches a leaf it writes that character to the outptu file
  *if the counter representing the no of bits processed reaches zero
  *the next byte is read into the buffer and the counter is reset
  *if eof is reached or required no of bits has been processed the loop terminates
  *the files are closed and function exits.
*/
	void Huffman::unHuff(char password[25]="")
	{
		string password_in(password);
		char orig_password[25];
		string read_from = output +"\\"+ getPiece(fileName) + ".bitPass";
		ifstream pass(read_from.c_str(),ios::binary);
		pass.read(orig_password,25*sizeof(char));
		pass.read(reinterpret_cast<char *>(&wrotes),sizeof(wrotes));
		pass.close();

		//if(password_in!=string(orig_password))
		//{
			//cout<<"\n!!Passwords Do Not Match!!\n"<<endl;
            //return;
		//}
		string output_path = output +"\\"+ getPiece(fileName) + ".txt";
		ofstream out(output_path.c_str());
		ifstream in(fileName.c_str(),ios::binary);
		if(!in) 
          {
                cout<<"file not opened"<<endl;
                return;
          }
		
		treeNode *temp=q->getHead();		
		BitCounter=0;
		while(wrotes>0)	//the number of bytes written are read
		{			
			char c;			 
			if (BitCounter == 0)//refresh buffer when counter becomes zero
			{
				if (in.eof())
				{					
					return;
				}				
				in.get(c);//get a character from file
				BitContainer = static_cast<unsigned char>(c);//cast it and store in a bit buffer
				BitCounter = 8;//set counter to 8 to indicate no of bits to be processed
			}
			if (BitContainer & 0x80)//true if left most bit in the buffer is 1
			   temp=temp->right;//move right if 1	
			else
				temp=temp->left;//move left if 0
			BitContainer <<= 1;//shift the bit just proccessed so thhat next bit becomes ready
			BitCounter--;//decrement counter to indicate a bit has been processed
			
			if(temp->left==NULL && temp->right==NULL)	//leaf node
				{
					out<<temp->ch;/* outputs character at a leaf node to file and resets temp to root */
                    temp=q->getHead();
				}
				wrotes--;
				if(wrotes<0)//break loop when required number of bits has been read
					break;
				//}
		}

		out.close();
		in.close();
	}

int main(int argc,char *argv[])
{
	if(argc>1)
	{	
	Huffman read(argv[1]);
		//read.display();
		read.HuffHuff();	//builds the huffman tree
		if(argc>2)
			read.unHuff(argv[2]);
		else
			read.unHuff();
   }
	//	read.unHuffHuff();
	//read.q->head->displayTree();

}
