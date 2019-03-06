#ifndef QUORA_AMAZON_MOST_QUEST_ONLINE_ASSESSMENT_H_INCLUDED
#define QUORA_AMAZON_MOST_QUEST_ONLINE_ASSESSMENT_H_INCLUDED

// https://www.quora.com/What-are-the-questions-asked-in-an-Amazon-Online-Test-in-HackerRank

// also Amazon Easy
// http://practice.geeksforgeeks.org/problems/maximum-repeating-number/0

// the idea here is, I mark the index of the array with k, see algo.doc
void most_frequent_number(){
    int n=6; int k = 3;

    int arr[] = { 2, 2, 1, 1, 0, 1};

    for(int i=0;i<n;i++){
        int a = arr[i]%k;
        arr[a] = arr[a] + k;
    }

    for(int i=0;i<n;i++){
        cout << arr[i] << " ";
    }

    cout << endl;

    int mynum = INT_MAX;
    int ii = INT_MAX;
    int mx = -1;
    for(int i=0;i<n;i++){
        int rep = arr[i]/k;
        if(rep > mx){
            mx = rep;
            ii = i;
        }
    }

    // restore array to normal
    for(int i=0;i<n;i++){
        arr[i] = arr[i]%k;
    }


    cout << ii << " is repeated:" << mx << " times";
}


// O(n)+(n logn) time, O(1) space ... using sorting
void most_frequent_number(){

    vector<int> vec = {1, 3, 4, 5, 2, 2, 3, 2, 1, 1};

    int sz = vec.size();

    if(sz==0){cout << 0; return 0;}

    sort(vec.begin(), vec.end());
    int gfreq=1; int gitem = -1;
    int freq = 1; int item = vec[0];
    for(int i=1;i<sz;i++){
        if(vec[i] == item){
            freq++;
            if(freq == gfreq){
                gitem = min(gitem, item);
            }else if(freq > gfreq){
                gfreq = freq;
                gitem = item;
            }
        }
        else{
            freq = 1; item = vec[i];
        }
    }

    cout << gitem << ":" << gfreq;

}


// http://practice.geeksforgeeks.org/problems/largest-number-in-k-swaps/0
void findMaximumNum(string str, int k, int z, string& mx)
{
    if(k == 0)
        return;

    int n = str.length();

    for (int i = z; i < n - 1; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (str[i] < str[j])
            {
                swap(str[i], str[j]);

                if (str.compare(mx) > 0)
                    mx = str;

                findMaximumNum(str, k - 1,i+1, mx);

                // backtrack
                swap(str[i], str[j]);
            }
        }
    }
}
void maximize_number_driver()
{
    string s = "9532";
    int k=2;
    string res = s; // to count for if no swapping is needed.
    findMaximumNum(s,k,0,res);
    cout << res;
}


void remove_dup_from_array_without_extra_space(){
    int arr[] = {1,2,2,3,4,4,4,5,5};

    int j=0; int t=arr[0];
    int n = sizeof(arr)/sizeof(arr[0]);
    for(int i=1;i<n;i++){
        if(t!=arr[i]){
            ++j;
            arr[j] = arr[i];
            t=arr[i];
        }
    }

    // size of new array is j+1
    for(int i=0; i<=j;i++){
        cout << arr[i] << " ";
    }
}

#endif // QUORA_AMAZON_MOST_QUEST_ONLINE_ASSESSMENT_H_INCLUDED
