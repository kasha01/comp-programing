#ifndef JUMPING_NUMBERS_H_INCLUDED
#define JUMPING_NUMBERS_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/jumping-numbers/0
// k=50 ==> 0 1 10 12 2 21 23 3 32 34 4 43 45 5 6 7 8 9
vector<int> vec;
void dp(int bnum, int n, int k){
    int num1=-1; int num2=-1;
    if(n>0 && n<10){
        num1 = (bnum*10)+n-1;
    }
    if(n>=0 && n<9){
        num2 = (bnum*10)+n+1;
    }

    if(num1!=-1 && num1<=k){
        vec.push_back(num1);
        dp(num1,n-1,k);
    }
    if(num2!=-1 && num2<=k){
        vec.push_back(num2);
        dp(num2,n+1,k);
    }
}

// using recurssion. does not sort by digits
void dp_driver(){
    int k=89384; vec.push_back(0);
    for(int i=1;i<10;i++){
        if(i<=k){
            vec.push_back(i);
            dp(i,i,k);
        }
    }

    for(int i=0;i<vec.size(); i++){
        cout << vec[i] << " ";
    }
}

// does sorting - it passes the unit tests
void mt()
{
    vector<int> v;
    int k=50;queue<int> q;
    cout << 0 << " ";
    for(int i=1;i<=9;i++){
        if(i>k){continue;}
        q.push(i);

        while(!q.empty()){
            int num1=-1; int num2=-1;
            int base=q.front(); q.pop();
            //v.push_back(base);
            cout << base << " ";
            int n1=(base%10)-1; int n2=(base%10)+1;
            if(n1>=0 && n1<10){
                num1 = (base*10) + n1;
            }
            if(n2>=0 && n2<10){
                num2 = (base*10) + n2;
            }

            if(num1!=-1 && num1<=k){
                q.push(num1);
            }
            if(num2!=-1 && num2<=k){
                q.push(num2);
            }
        }
    }

    // not needed. I am printing result right after queue pop
    for(int i=0; i<v.size(); i++){
        cout << v[i] << " ";
    }
}


#endif // JUMPING_NUMBERS_H_INCLUDED
