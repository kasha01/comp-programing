#ifndef COMBINATION_SUM_H_INCLUDED
#define COMBINATION_SUM_H_INCLUDED

//find all unique combinations in A where the sum is equal to B.
// The same repeated number may be chosen from A unlimited number of times.

//https://practice.geeksforgeeks.org/problems/combination-sum/0
vector<vector<int>> grand_vec;
void bt(int n, int const m, int sum, int const gsum, vector<int> const &origvec, vector<int> &vec){

    for(int i=n;i<m;i++){
        int sum_so_far = origvec[i] + sum;
        if(sum_so_far == gsum){
            vec.push_back(origvec[i]);
            grand_vec.push_back(vec);
            vec.pop_back();
            return;
        }
        else if(sum_so_far < gsum){
            vec.push_back(origvec[i]);
            bt(i,m,sum_so_far,gsum,origvec,vec);
            if(!vec.empty()){vec.pop_back();}
        }
        else{
            // i passed the limit
            //if(!vec.empty()){vec.pop_back();}
            return;
        }
    }
}

void print_result(vector<vector<int>> grand_vec, int const &N){
    for(int i=0;i<N;i++){
        vector<int> v = grand_vec[i];
        cout << '(';
        for(int j=0;j<v.size()-1;j++){
            cout << v[j] << " ";
        }
        cout << v[v.size()-1] << ')';
    }

}

void driver(){

    int x = 6;
    vector<int> vec = {6 ,5 ,7 ,1 ,8 ,2 ,9 ,9 ,7 ,7 ,9};
    int n= vec.size();

    // sort
    sort(vec.begin(), vec.end());

    // remove duplicates
    int j=0;
    for(int i=0;i<n;i++){
        if(vec[i] != vec[j]){
            vec[j+1] = vec[i];
            j++;
        }
    }
    vec.resize(j+1);
    n = vec.size();

    vector<int> temp;
    bt(0,n,0,x,vec,temp);


    int N = grand_vec.size();

    if(grand_vec.empty()){
        cout << "Empty" << endl;
    }
    else{
        //print_result(grand_vec,N);
        for(int i=0;i<N;i++){
            int vv = grand_vec[i].size();
            for(int j=0;j<vv;j++){
                cout << grand_vec[i][j] << " ";
            }
            cout << endl;
        }
    }
}


#endif // COMBINATION_SUM_H_INCLUDED
