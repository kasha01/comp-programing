#ifndef GRAY_CODE_H_INCLUDED
#define GRAY_CODE_H_INCLUDED


void append_in_ordinary_pattern(string p, int n);
void append_in_reverse_pattern(string p, int n);

unsigned int binary_to_gray(unsigned int num)
{
    return num ^ (num >> 1);
};

unsigned int grayToBinary(unsigned int num)
{
    unsigned int mask;
    for (mask = num >> 1; mask != 0; mask = mask >> 1)
    {
        num = num ^ mask;
    }
    return num;
};


void append_in_ordinary_pattern(string p, int n){
    if(n==0){cout << p << " "; return;}
    append_in_ordinary_pattern(p + "0",n-1);
    append_in_reverse_pattern(p + "1", n-1);
};

void append_in_reverse_pattern(string p, int n){
    if(n==0){cout << p << " "; return;}
    append_in_ordinary_pattern(p + "1",n-1);
    append_in_reverse_pattern(p + "0", n-1);
};

void get_gray_code(int n){
    int m = append_in_ordinary_pattern("",n);
    cout >> m;
}

#endif // GRAY_CODE_H_INCLUDED
