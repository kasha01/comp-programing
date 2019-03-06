#ifndef COMBINATION_SUM_2_H_INCLUDED
#define COMBINATION_SUM_2_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/combination-sum-part-2/0
// Given A = 10,1,2,7,6,1,5 and B(sum) 8,
// Solution: (1 1 6)(1 2 5)(1 7)(2 6)
ostringstream os;
set<string> mp;
vector<int> res;
void rc(vector<int> &arr, int sum, int s, int const &t, int const &n){
    for(int i=s;i<n;i++){
        int k = arr[i] + sum;

        if(k>t){
            return;
        }
        else if(k==t){
            res.push_back(arr[i]);
            int sz = res.size();
            string myst="";
            for(int j=0;j<sz;j++){
                os << res[j] << " ";
            }
            res.pop_back();
            myst = os.str();
            if(mp.find(myst) == mp.end()){
                mp.insert(myst);
            }
            os.str("");
            return;
        }
        else if(k<t){
            res.push_back(arr[i]);
            rc(arr, k,i+1,t,n);
            res.pop_back();
            continue;
        }
    }
}


void driver()
{
    vector<int> vec;
    int t=0; cin >> t;
    while(t>0){
        t--;
        vec.clear(); res.clear(); mp.clear();

        int item=0; int target=0; int n=0;

        cin >> n;
        for(int i=0;i<n;i++){
            cin >> item;
            vec.push_back(item);
        }

        cin >> target;

        sort(vec.begin(),vec.end());

        rc(vec,0,0,target,n);

        std::set<string>::iterator it;
        if(!mp.empty())
        {
            for(it = mp.begin(); it != mp.end(); it++){
                string mys = *(it);
                cout << "(" << mys.substr(0,mys.length()-1) << ")";
            }
            cout << endl;
        }
        else
        {
            cout << "Empty" << endl;
        }
    }
	return 0;
}

#endif // COMBINATION_SUM_2_H_INCLUDED
