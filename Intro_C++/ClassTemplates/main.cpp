#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <cassert>

using namespace std;

/*see: https://www.hackerrank.com/challenges/c-class-templates */

template <class T>
class AddElements{
private:
    T num;
public:
    AddElements(T t){
        num = t;
    }
    T add(T num2){
        return num + num2;
    }
};

template<>
class AddElements<string>{
private:
    string s1;
public:
    AddElements(string arg){
        s1=arg;
    }
    string concatenate(string arg){
        return s1+arg;
    }
};

int main () {
  int n,i;
  cin >> n;
  for(i=0;i<n;i++) {
    string type;
    cin >> type;
    if(type=="float") {
        double element1,element2;
        cin >> element1 >> element2;
        AddElements<double> myfloat (element1);
        cout << myfloat.add(element2) << endl;
    }
    else if(type == "int") {
        int element1, element2;
        cin >> element1 >> element2;
        AddElements<int> myint (element1);
        cout << myint.add(element2) << endl;
    }
    else if(type == "string") {
        string element1, element2;
        cin >> element1 >> element2;
        AddElements<string> mystring (element1);
        cout << mystring.concatenate(element2) << endl;
    }
  }
  return 0;
}
