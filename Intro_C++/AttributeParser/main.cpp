#include <vector>
#include <iostream>
#include <algorithm>
#include<string>
#include<sstream>

using namespace std;

/* https://www.hackerrank.com/challenges/attribute-parser */

class Attribute{
public:
    Attribute(string n, string v){
        name = n;
        value = v;
    }
    string name;
    string value;
};

class Node {
public:
    Node(string n, Node* p){
        name = n;
        parent = p;
    };

    Node* AddNode(string n, Node* p){
        Node* current = new Node(n,p);
        nodes.push_back(current);
        return current;
    }

    void AddAtt(string n,string v){
        Attribute* atr = new Attribute(n,v);
        att.push_back(atr);
    };

    string name;
    vector<Node*> nodes;
    vector<Attribute*> att;
    Node* parent;
};

class Tree{
public:
    Node* root;

};

int main() {

//Declarations
    int h =0; int q = 0;
    string s = "";          // Tokenized String
    string x = "";          // a token
    string _name = "";
    string _value = "";
    string ot = "";
    string result = "";
    string st="";
    vector<string> myinput;
    vector<string> mycommands;
    Tree tree;

    //Mocked input
    h=10; q=10;
    myinput = {
    "<a value = \"GoodVal\">",
    "<b value = \"BadVal\" size = \"10\">",
    "</b>",
    "<c height = \"auto\">",
    "<d size = \"3\">",
    "<e strength = \"2\">",
    "</e>",
    "</d>",
    "</c>",
    "</a>"
    };
    mycommands = {
    "a~value",
    "b~value",
    "a.b~size",
    "a.b~value",
    "a.b.c~height",
    "a.c~height",
    "a.d.e~strength",
    "a.c.d.e~strength",
    "d~sze",
    "a.c.d~size"
    };

/*
    //STDIN
    cin >> h >> q;
    cin.ignore(numeric_limits<streamsize>::max(),'\n');
    for(int i=0;i<h;i++){
        //Get Input HRML
        getline(cin,st);
        myinput.push_back(st);
    }
    for(int i=0;i<q;i++){
        //Get Commands to HRML
        getline(cin,st);
        mycommands.push_back(st);
    }
*/

    tree.root = new Node("ROOT",NULL);   // Tree has one ROOT, all other nodes falls under the ROOT node
    Node* cur = tree.root;

    //Parse Input HRML
    for(int j=0; j<h;j++){
     s = myinput[j];
     s = s.substr(1,s.length()-2); //Exclude the opening and closing brackets < >
     std::istringstream ss(s);
     int i = 0;
     x = "";
         while(!ss.eof()){
            getline(ss,x,' ');

            if(i==0){
                // First Element is always a tag name - Check if it is an opening or a closing Tag
                if(x.find('/') == string::npos){
                    // Then it is an opening Tag as in "<tag1>"
                    cur = cur->AddNode(x,cur);
                }
                else{
                    // it is a closing Tag as in "</tag1>"
                    cur = cur->parent;
                }
            }else if (i==1){
                // input stream is an attribute name
                _name = x;
            }
            else if(i==3){
                // input stream is an attribute value, - i=2 is the equal sign-
                _value = x.substr(1,x.length()-2);  //Exclude the quotation marks
                cur->AddAtt(_name,_value);          // Add attribute to the node
                i = 0;                              // Reset counter , next coming string could be another attribute
            }
             i++;
        }
    }

    //Parse Commands
    for(int i=0; i<q;i++){
        cur = tree.root;            //Reset Current Node to the Root
        ot = mycommands[i];         // Get the command
        size_t tild = ot.find('~');

    //Get only the Tags in the command (a.b.c~height --> a,b,c)
    string ott = ot.substr(0,tild);
    std::istringstream ss(ott);
    while(!ss.eof()){
        getline(ss,x,'.');                      //Delimiter for tags is '.'
        for(int k=0;k<cur->nodes.size();k++){   //Find the node in the Tree corresponding to the tag name requested
            if(cur->nodes[k]->name == x){
                cur = cur->nodes[k];
                break;
            }
        }
    }

    result = "";    //Reset the result buffer;

    // Check if node found is the last node in command (i.e. for command a.b.c~height, the found node name is 'c')
    if(cur->name != x){
            // If not, cout Not Found!, continue to next command
            cout << "Not Found!" << endl;
            continue;
        }

    ott = ot.substr(tild+1);                    // Get the requested Attribute from the command
    for(int k=0;k<cur->att.size();k++){         // Loop through attribute list of the found designated node
            if(cur->att[k]->name == ott){
                result = cur->att[k]->value;    // Attribute is found - Get Attribute value
                break;
            }
        }

  // Print result to stdout
  if(result != ""){
    cout << result << endl;
  }else{
    cout << "Not Found!" << endl;
  }

 }  //End of Commands Loop

  // Free memory - delete nodes - not needed
  cur = tree.root;
  for(int i = 0; i< cur->nodes.size();i++){
    delete cur->nodes[i];
  }

  return 0;
}
