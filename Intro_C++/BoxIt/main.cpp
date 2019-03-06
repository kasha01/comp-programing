#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

/* https://www.hackerrank.com/challenges/box-it */

int BoxesCreated,BoxesDestroyed;

class Box{

private:
    int l=0;
    int b =0;
    int h = 0;

public:
    Box(){
        BoxesCreated++;
    }

    Box(int a, int br, int c){
        l=a;b=br;h=c;
        BoxesCreated++;
    }
    Box(const Box& box){
        l=box.l;
        b=box.b;
        h=box.h;
        BoxesCreated++;
    }

    ~Box(void){
        BoxesDestroyed++;
    }

    int getLength(){return l;}
    int getBreadth(){return b;}
    int getHeight(){return h;}

    long long CalculateVolume(){
        /*if none of the RHF variables (l,b,h) are long long, then their product will be an int EVEN though the LFS
        is defined as a long long -return type- and if their product exceeded the int limit this will cause an overflow
        and return a bad value, thus we need to explicitly cast on of the variables to 1LL (long long) so their product will
        be long long*/
        return 1ll * l*b*h;
        }

    bool operator <(const Box &box){
        if(this->l < box.l){return true;}
        if(this->b < box.b && this->l == box.l){return true;}
        if(this->h<box.h && this->b == box.b && this->l == box.l){return true;}
        return false;
    }

    friend ostream &operator<<(ostream &os, Box box){
        return os << box.l << " " << box.b << " " << box.h;
    }
};

void check2()
{
int n;
cin>>n;
Box temp;
for(int i=0;i<n;i++)
    {
    int type;
    cin>>type;
    if(type ==1)
        {
            cout<<temp<<endl;
        }
        if(type == 2)
        {
            int l,b,h;
            cin>>l>>b>>h;
            Box NewBox(l,b,h);
            temp=NewBox;
            cout<<temp<<endl;
        }
        if(type==3)
        {
            int l,b,h;
            cin>>l>>b>>h;
            Box NewBox(l,b,h);
            if(NewBox<temp)
            {
                cout<<"Lesser"<<endl;
        }
            else
            {
                cout<<"Greater"<<endl;
            }
        }
        if(type==4)
        {
            cout<<temp.CalculateVolume()<<endl;
        }
        if(type==5)
        {
            Box NewBox(temp);
            cout<<NewBox<<endl;
        }

    }
}

int main()
{
    BoxesCreated = 0;
    BoxesDestroyed = 0;
    check2();
    cout<<"Boxes Created : "<<BoxesCreated<<endl<<"Boxes Destroyed : "<<BoxesDestroyed<<endl;
}
