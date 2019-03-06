#ifndef PRINT_ALL_POSSIBLE_STRINGS_H_INCLUDED
#define PRINT_ALL_POSSIBLE_STRINGS_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/print-all-possible-strings/1
// abc => ab c, a bc, a b c
void print(string prefix, string s){
    int n = s.length();
    for(int i=1;i<n;i++){
        string s1 = s.substr(0,n-i);
        string s2 = s.substr(n-i);
        cout << prefix << s1 << " " << s2 << endl;
        print(prefix + s1 + " ", s2);
    }
}

void driver(){
    string s = "abc";
    print("",s);
    cout << s << endl;  // initial case - print the entire string
}

#endif // PRINT_ALL_POSSIBLE_STRINGS_H_INCLUDED
