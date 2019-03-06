#include <iostream>
using namespace std;

/*see: https://www.hackerrank.com/challenges/cpp-variadics */

static int counter = 0;

template<bool...digits>
int reversed_binary_value(){
    if(counter == 64){counter = 0;}
    return counter++;
};

template <int n, bool...digits>
struct CheckValues {
  	static void check(int x, int y)
  	{
    	CheckValues<n-1, 0, digits...>::check(x, y);
    	CheckValues<n-1, 1, digits...>::check(x, y);
  	}};

template <bool...digits>            //Partial specialize on template argument: CheckValues with <0,
struct CheckValues<0, digits...> {  // CheckValues<0> , CheckValues<0,1>, CheckValues<0,1,1,1,0> - it has to start with zero
  	static void check(int x, int y)
  	{
    	int z = reversed_binary_value<digits...>(); //unpacking, <> says we have a template of bool...digits, () no param
    	std::cout << (z+64*y==x);
  	}
};

int main()
{
  	int t; std::cin >> t;

  	for (int i=0; i!=t; ++i) {
		int x, y;
    	cin >> x >> y;
    	CheckValues<6>::check(x, y);
    	cout << "\n";
  	}
}
