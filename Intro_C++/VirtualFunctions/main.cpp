#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

/* https://www.hackerrank.com/challenges/virtual-functions */

class Person{
public:
    string name="";
    int age =0;
    int cur_id=0;
    virtual void putdata() = 0;
    virtual void getdata() = 0;
};

class Professor : public Person{
public:
    string publications;
    static int obj_count;
    Professor(){
        obj_count++;
        cur_id = obj_count;
    }
    void getdata(){
        cin >> name >> age >> publications;
    }
    void putdata(){
        cout << name << " " << age << " " << publications << " " << cur_id << endl;
    }
};

class Student : public Person{
private:
    int sum = 0;
public:
    int marks[6];
    static int obj_count;
    Student(){
        obj_count++;
        cur_id = obj_count;
    }
    void getdata(){
        cin >> name >> age;
        for(int i=0;i<6;i++){
            cin >> marks[i];
        }
    }
    void putdata(){
        sum = 0;
        for(int i=0;i<6;i++){
            sum = sum + marks[i];
        }
        cout << name << " " << age << " " << sum << " " << cur_id << endl;
    }
};

int Student::obj_count = 0;
int Professor::obj_count=0;

int main(){

    int n, val;
    cin>>n; //The number of objects that is going to be created.
    Person *per[n];

    for(int i = 0;i < n;i++){

        cin>>val;
        if(val == 1){
            // If val is 1 current object is of type Professor
            per[i] = new Professor;

        }
        else per[i] = new Student; // Else the current object is of type Student

        per[i]->getdata(); // Get the data from the user.

    }

    for(int i=0;i<n;i++)
        per[i]->putdata(); // Print the required output for each object.

    return 0;
}
