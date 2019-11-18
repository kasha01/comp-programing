#ifndef CIRCULAR_TOUR_INCLUDED
#define CIRCULAR_TOUR_INCLUDED

// https://practice.geeksforgeeks.org/problems/circular-tour/1
struct petrolPump
{
    int petrol;
    int distance;
};

bool solve(int s, int n, petrolPump* arr){
	int ii = s;
	int p =0;
	do {
		int d = arr[ii].distance;
		p=p+arr[ii].petrol;
		if(p<d){
			return false;
		}
		else{
			ii++;
			ii = ii % n;
			p=p-d;
		}
	} while(ii != s);
	return true;
}

void init()
{
	int n = 4;
	petrolPump p1;
	p1.petrol=4;p1.distance = 6;

	petrolPump p2;
	p2.petrol=6;p2.distance = 5;

	petrolPump p3;
	p3.petrol=7;p3.distance = 3;

	petrolPump p4;
	p4.petrol=4;p4.distance = 5;

	petrolPump arr[n];
	arr[0] = p1;
	arr[1] = p2;
	arr[2] = p3;
	arr[3] = p4;

	int ans = -1;
	for(int i=0;i<n;++i){
		bool b = solve(i,n,arr);
		if (b) {
			ans = i;
			break;
		}
	}
	cout << ans;
}


#endif // CIRCULAR_TOUR_INCLUDED
