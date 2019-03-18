#ifndef EVENT_DIGITS_H_INCLUDED
#define EVENT_DIGITS_H_INCLUDED

// https://code.google.com/codejam/contest/9234486/dashboard

int arr[17];
int arr_inc[17];
int arr_dec[17];

uint64 get_my_num(int* ar, int c){
	uint64 mynum=0;
	for(int i=0;i<c;++i){
		mynum = mynum + (pow(10,i)*ar[i]);
	}
	return mynum;
}

uint64 get_result_inc(int odd_digit_index, int c, uint64 n){
    int odd_digit = arr_inc[odd_digit_index];
	uint64 result = 0;

    if(odd_digit != 9){
		// odd digit != 9 and it is not last digit
		arr_inc[odd_digit_index]++;

		// zeroize all digits before my odd_index_digit. closes number incremented from n will have all leading 0s
		// 227446--> 228000
		for(int i=0;i<odd_digit_index;++i){
			arr_inc[i]=0;
		}
		uint64 mynum = get_my_num(arr_inc,c);
		result = mynum-n;
    }
    else{
        // odd digit is 9
        arr_inc[odd_digit_index]=0;	// set 9 to 0 as I am incrementing
        odd_digit_index++;			// odd digit is now the next digit

        if(odd_digit_index==c){
			// if the odd digit was the last digit, so after incremneting, it overflowed to a new digit
            uint64 mynum = pow(10,c)*2;
            result = mynum - n;
        }
        else{
			// I have a new odd digit index now, recursively call the increment algo.
			arr_inc[odd_digit_index]++;	// since I incremented from 9. 1 was carried to the new odd_digit_index
            result = get_result_inc(odd_digit_index,c,n);
        }
    }
    return result;
}

uint64 get_result_dec(int odd_digit_index, int c, uint64 n){
    arr_dec[odd_digit_index]--;

    // make all leading digts 8. closes number decremented from n with all even digits will have all leading digits 8
    // 2472 --> 2468
    for(int i=0;i<odd_digit_index;++i){
        arr_dec[i]=8;
    }
    uint64 mynum = get_my_num(arr_dec,c);
    return n-mynum;
}

uint64 solve(uint64 n){

    uint64 remainder_after_odd_digit = 0;

    memset(arr,0,17*sizeof(int));
    memset(arr_inc,0,17*sizeof(int));
    memset(arr_dec,0,17*sizeof(int));

    int odd_index=-1;	//odd digit index
    int c=0;			// count of digits in a number

    uint64 n_orig = n;
    while(n_orig>0){
        int d = n_orig%10;
        arr[c] = d;
        arr_inc[c] = d;
        arr_dec[c] = d;
        if(d%2==1){
			odd_index = c;
        }
        n_orig=n_orig/10;
        ++c;
    }

	// no odd digit was found
	if(odd_index==-1){return 0;}

	if(c==1){
		// single digit
		return 1;
	}

    uint64 result_increment = 0;
    uint64 result_decrement = 0;

    result_increment = get_result_inc(odd_index,c,n);
    result_decrement = get_result_dec(odd_index,c,n);

	return min(result_decrement,result_increment);
}

void readfile(){
    ofstream fo; fo.open("output.txt");
    int T = 0;
    ifstream fin; fin.open("source.txt");
    fin >> T;
    uint64 n=0;
    for(int t=1; t<=T; ++t){
        fin >> n;
        fo << "Case #" << t << ": " << solve(n) << endl;
    }
}

void driver(){
	readfile();
	//cout << solve(0);
}

#endif // EVENT_DIGITS_H_INCLUDED
