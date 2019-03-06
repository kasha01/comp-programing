#ifndef GOGOOLSTRING_H_INCLUDED
#define GOGOOLSTRING_H_INCLUDED


// https://code.google.com/codejam/contest/4374486/dashboard#s=p1
typedef unsigned long long int uint64;

int arr[] = {0,0,1,0,0,1,1,0,0,0,1,1,0,1,1};
//int arr[] = {0,0,1};

/*
notice that ever position that equals 2^n is a zero. digits at position 2,4,8 are all zeros.
this is the key. If k equals a position that is a power of 2. then k=0;
moreover, if can calculate other k, by:
1- find the nearest power of 2 (p) in which 2^p is equal or less than k
2- The position of that number is 2^p
3- Since the pattern is flipping and reversing, I need to find how many times k was flipped. so I keep
finding the distance between k and my mid_zero_position, so i can find the corresponding digit that was flipped to k
then I count the number how many times k was flipped.
*/
int solve(uint64 k){
	// k is the position of the digit i.e. k = index+1
	uint64 c = 0;
	uint64 k_orig = k;

	int p = 0;
	uint64 mid_zero_position = 0;

	p = floor(log2(k));
	mid_zero_position = pow(2,p);
	if(mid_zero_position == k_orig){
		k=0;
	}

    while(k>15){
        p = floor(log2(k));							// nearest power of 2 that is less than or equal k
		mid_zero_position = pow(2,p);					// if k = 5 ==> then p = 2 => mid_zero_position will equal 4
		k = (mid_zero_position - (k-mid_zero_position));
		if(mid_zero_position == k){
			k=0;break;		// if k was flipped from a mid_zero_position. I am good. break the program.
        }
		c++;		// how many times k was flipped
    }

	int result=0;

	// this is to handle when k was zeroized becaude k was flipped or it is a mid_zero_position.
	if(k==0){
		if(c%2==0){
			result = 0;		// if number of flips is even then k=0
		}
		else{
			result = 1;
		}
	}
	else{
		// handles if k is below 15 then I can use my base array and with the number of flips to determine my
		// original k value
		if(c%2 == 0){
			result = arr[k-1];
		}
		else{
			result = !arr[k-1];
		}
	}


    return result;
}

void readfile(){
	//pre = new uint64[y];
	//precompute();

    ofstream fo; fo.open("output.txt");
    int T = 0;
    uint64 k = 0;
    ifstream fin; fin.open("source.txt");
    fin >> T;
    for(int t=1; t<=T; ++t){
        fin >> k;
        int r = solve(k);
        fo << "Case #" << t << ": " << r << endl;
    }
}


#endif // GOGOOLSTRING_H_INCLUDED
