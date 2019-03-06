#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

/*see: https://www.hackerrank.com/challenges/c-tutorial-struct */

typedef struct{
    int age;
    string first_name;
    string last_name;
    int standard;
}Student;

int main()
{
    Student st;
    cin >> st.age >> st.first_name >> st.last_name >> st.standard;
    cout << st.age << " " << st.first_name << " " << st.last_name << " " << st.standard;

    cout << "Hello world!" << endl;
    return 0;
}
