using System;

// https://www.geeksforgeeks.org/generate-all-possible-sorted-arrays-from-alternate-elements-of-two-given-arrays/
namespace misc
{
	public class generate_all_possible_sorted_arrays_from_alternate_elements_of_two_given_sorted_arrays
	{
		static int n;
		static int m;
		static int[] A;
		static int[] B;
		static int[] result;
		public static void driver ()
		{
			n = 3; m = 4;
			A = new int[3]{ 10, 15, 25 };
			B = new int[4]{ 1, 5, 20, 30 };
			result = new int[n + m];
			rc1(0,0,0,0,0);
		}

		static void rc1(int si, int sj, int x, int a, int b){
			for(int i=si;i<n;++i){
				if(A[i] > b){
					result[x] = A[i];
					rc2(i+1,sj,x+1,A[i],b);
				}
			}
		}

		static void rc2(int si, int sj, int x, int a, int b){
			for(int j=sj;j<m;++j){
				if(B[j] > a){
					result[x] = B[j];

					// print
					for(int k=0;k<=x;k++){
						Console.Write(result [k] + " ");
					}
					Console.WriteLine ();

					rc1 (si, j + 1, x + 1, a, B [j]);
				}
			}
		}
	}
}

