#ifndef EQUAL_TO_PRODUCT_H_INCLUDED
#define EQUAL_TO_PRODUCT_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/equal-to-product/0
void mt(){
    vector<int> v;
    std::sort(v.begin(),v.end());
    int sz = v.size();

    int flag = false;
    int p;
    int i=0; int j=sz-1;
    while(i<j){
        int pp = v[i]*v[j];
        if(pp>p){
            j--;
        }
        else if(pp<p){
            i++;
        }
        else if(pp==p){
            flag = true;
            break;
        }
    }

    cout << flag;
}

#endif // EQUAL_TO_PRODUCT_H_INCLUDED
