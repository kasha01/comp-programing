#ifndef MIN_DIFFERENCE_PAIR_H_INCLUDED
#define MIN_DIFFERENCE_PAIR_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/minimum-difference-pair/0
void mt()
{
    int t=0; cin >> t; vector<int> vec;
    while(t>0){
        t--;
        int n=0; int item=0;
        cin >> n;
        for(int i=0;i<n;i++){
            cin >> item;
            vec.push_back(item);
        }
        sort(vec.begin(), vec.end());

        int p=INT_MAX;
        for(int i=0;i<n-1;i++){
            p = min(p, vec[i+1] - vec[i]);
        }
        cout << p << endl;
        vec.clear();
    }
	return 0;
}

#endif // MIN_DIFFERENCE_PAIR_H_INCLUDED
