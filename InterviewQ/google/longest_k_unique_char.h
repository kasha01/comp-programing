#ifndef LONGEST_K_UNIQUE_CHAR_H_INCLUDED
#define LONGEST_K_UNIQUE_CHAR_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/longest-k-unique-characters-substring/0

int mt(string s, int k){
    int l = s.length();
    set<char> st;

    if(l<=0 || k <= 0){return -1;}

    int arr[l]; int mx=-1;

    for(int i=0; i<l; i++){
        int c = 0;
        st.clear(); int k1=0;
        for(int j=i; j>=0; j--){
            if(st.find(s[j])==st.end()){
                // does not exist - may be adding new character
                if(k1<k){
                    // still have room for an other character
                    st.insert(s[j]); k1++; c++;
                }
                else {
                    // no room for new char - stop
                    break;
                }
            }
            else{
                c++;
            }
        }
        if(k1==k){
            mx = max(mx, c);
        }
    }
    return max(mx,-1);
}


// MANY THANKS TO sunil maurya FOR THIS GREAT SOLUTION
int cnt[26]={0}; // count of each letter
int countchar;  // current count of unique characters

void addnewchar(char ch)
{
	int i,j;
	if(cnt[ch-'a']==0)
	{
		countchar++;
	}

	cnt[ch-'a']++;
}
void deletenewchar(char ch)
{
	int i,j;

	if(cnt[ch-'a']==1)
	{
		countchar--;
	}
	cnt[ch-'a']--;
}

// O(n)
best_solution()
{
	int t;
	cin>>t;
	while(t--)
	{
		string str;
		cin>>str;
		int k;
		cin>>k;
		for(int i=0;i<26;i++)
		cnt[i]=0;
		countchar=0;
		int i=0;
		int j=0;
		int len = str.length();
		int maxi =INT_MIN;
		while(i<len)
		{

			if(countchar<=k)
			{
				addnewchar(str[i]);
				if(countchar==k)
				{
					maxi = max(maxi,i-j+1);
					i++;
				}
				else
				i++;
			}
			else
			{
			    // keep deleting char, notice in deletenewchar, count on unique characters (countchar)
			    // will only decrement as soon as a char count drops to 1 so deleting it will make
			    // the occurance of that char to zero, at this point, j will be pointing to the index
			    // of the first char that was consumed to zero, therefore decrementing number of unique
			    // characters to less than k, so on the next tick of while loop, the new char at i can be
			    // added...and max length is i-j+1
				deletenewchar(str[j]);

				j++;
			}
		}

		if(maxi!=INT_MIN)
            cout<<maxi<<"\n";
		else
		{
		    cout<<"-1"<<"\n";
		}
	}
}

#endif // LONGEST_K_UNIQUE_CHAR_H_INCLUDED
