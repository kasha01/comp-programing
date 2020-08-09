#ifndef SHERLOCK_AND_PARENTHESES_H_INCLUDED
#define SHERLOCK_AND_PARENTHESES_H_INCLUDED

// https://code.google.com/codejam/contest/6304486/dashboard#s=p2
long long int solve(int r, int l)
{
    int n = min(r,l);

    if(n<=0){return 0;}

    long long int sum=0;
    for(int i=1;i<=n;++i){sum=sum+i;}

    return sum;
}

void readfile(){
    ofstream fo; fo.open("output.txt");
    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;
    long long int result = 0;
    for(int t=1; t<=tt; ++t){
        int R,L=0;
        fin >> L >> R;
        result = solve(R,L);

        fo << "Case #" << t << ": " << result << endl;
    }
}


#endif // SHERLOCK_AND_PARENTHESES_H_INCLUDED
