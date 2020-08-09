#ifndef PAIRS_WITH_POSITIVE_NEGATIVE_VALUES_H_INCLUDED
#define PAIRS_WITH_POSITIVE_NEGATIVE_VALUES_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/pairs-with-positive-negative-values/0

// print pairs that have +x and -x, if there are duplicates skip them.
void mt()
{
    vector<int> vec = {4 ,8 ,9 ,-4 ,4 ,-4 ,-8 ,-9};
    int n = vec.size();

    sort(vec.begin(), vec.end());

    int pre_a=0; int pre_b=0;
    int a=0; // -ve side of numbers
    int b=0; // +ve side of numbers
    int i=0; int j=n-1;
    stack<int> res;

    while(i<j){
        a=vec[i]; b=vec[j];

        if(a>=0 || b<=0) {
            // all +ve or all -ve or i reached zero
            break;
        }
        else if(pre_a==a && pre_b==b){
            // duplicate numbers
            i++;j--;
            continue;
        }
        else if(abs(a)==b){
            pre_a = a; pre_b=b;
            res.push(b);
            i++;j--;
        }
        else if(abs(a)>b){
            i++;
        }
        else if(abs(a)<b){
            j--;
        }
    }

    if(res.empty()){
        cout << 0;
    }
    else{
        while(!res.empty()){
            int p = res.top();
            res.pop();
            cout << p*-1 << " " << p << " ";
        }
    }
    cout << endl;
}


#endif // PAIRS_WITH_POSITIVE_NEGATIVE_VALUES_H_INCLUDED
