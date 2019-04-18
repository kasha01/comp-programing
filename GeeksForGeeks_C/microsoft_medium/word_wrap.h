#ifndef WORD_WRAP_H_INCLUDED
#define WORD_WRAP_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/word-wrap/0

// NOT MY SOLUTION
// COURTESY OF knpakash --> https://auth.geeksforgeeks.org/user/knpakash/practice/
int cube(int a)
{
     return a*a;
}

void solve() {

    int i,j,k,t,n,l,b[105],w,c[105];

    t=1;

    while(t--)
    {
         n=4;
         l=6;
         int a[] = {3,2,2,5};

         memset(b,-1,sizeof(b));

         for(j=n-1;j>=0;j--)
         {
              w = l;
              for(i=j;i<n && w>=a[i];i++)
              {
                   if(i==n-1)
                   {
                      b[j] = 0;
                      c[j] = n-1;
//                      cout<<"<"<<b[j]<<">";
                   }
                   else{
                       w = w - a[i];
                       int d = b[i+1];
                       k =(cube(w) + b[i+1]);
                       if(b[j] == -1 || k<b[j])
                       {
                           b[j] = k;
                           c[j] = i;
//                           cout<<"<"<<b[j]<<">";
                       }
                       w--;
                   }
              }
         }

         for(i=0;i<n;)
         {
             cout<<i+1<<" "<<(c[i] + 1)<<" ";
             i = c[i]+1;
         }

         cout<<"\n";

    }
}



#endif // WORD_WRAP_H_INCLUDED
