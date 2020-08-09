#ifndef LONGEST_EVEN_LENGTH_SUBSTRING_2K_H_INCLUDED
#define LONGEST_EVEN_LENGTH_SUBSTRING_2K_H_INCLUDED

// http://www.geeksforgeeks.org/longest-even-length-substring-sum-first-second-half/

int solve(const char* arr, int n)
{
    // i:mid point, j=left side start point, k=right side start point
    // keep expanding away from midpoint, j-- go left, k++ go right at equal place
    // so my right and left side length are always equal.
    int _count=0;
    for(int i=1; i<n;i++){
        int sumk=0; int sumj=0; int c=0; int j; int k;
        for(j=i-1, k=i; j>=0 && k<n; j--,k++){
            c++;
            sumj=sumj+arr[j];
            sumk=sumk+arr[k];

            if(sumj==sumk){
                _count = max(_count, c*2);
            }
        }
    }
    return _count;
}

void driver()
{
    string str="1538023";
    int n = str.length();
    const char* arr = str.c_str();
    int res = solve(arr, n);
    cout << res << endl;

    return 0;
}


#endif // LONGEST_EVEN_LENGTH_SUBSTRING_2K_H_INCLUDED
