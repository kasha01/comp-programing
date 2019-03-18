#ifndef LARGEST_WORD_IN_DIC_H_INCLUDED
#define LARGEST_WORD_IN_DIC_H_INCLUDED

// NOT MINE SOLUTION - TANKS TO RAVI KUMA
//http://practice.geeksforgeeks.org/problems/find-largest-word-in-dictionary/0
bool issubsequence(string str,string pattern)
{
	int n=str.length();
	int m=pattern.length();
	int j=0;
	for(int i=0;i<n&&j<m;i++)
	if(pattern[j]==str[i])
        j++;
	return (j==m);
}

void driver()
{
	int t;
	cin>>t;
	while(t--)
	{
		int x;
		cin>>x;
		string original;
		string arr[x+1];
		for(int i=0;i<x;i++)
		cin>>arr[i];
		cin>>original;
		int maxlength=0;
		string ans="";
		for(int i=0;i<x;i++)
		{
			if(issubsequence(original,arr[i])&&arr[i].length()>maxlength)
			{
				maxlength=arr[i].length();
				ans=arr[i];
			}
		}
		cout<<ans<<endl;
	}
}

#endif // LARGEST_WORD_IN_DIC_H_INCLUDED
