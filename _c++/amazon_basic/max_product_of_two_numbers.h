#ifndef MAX_PRODUCT_OF_TWO_NUMBERS_H_INCLUDED
#define MAX_PRODUCT_OF_TWO_NUMBERS_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/maximum-product-of-two-numbers/0
void mt()
{
    int t=0; cin >> t;
    vector<int> vec;
    while(t>0){
        t--;

        int n=0; cin >> n; int item=0;
        for(int i=0;i<n;i++){
            cin >> item;
            vec.push_back(item);
        }

        // sort
        sort(vec.begin(), vec.end());
        long long int p = vec[n-1] * vec[n-2];
        cout << p << endl;

        vec.clear();
    }
	return 0;
}

#endif // MAX_PRODUCT_OF_TWO_NUMBERS_H_INCLUDED
