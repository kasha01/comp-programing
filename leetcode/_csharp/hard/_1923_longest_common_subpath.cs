using System;
using System.Collections.Generic;

// NOT MINE
// COURTESY OF tiwarishubham635
// https://leetcode.com/problems/longest-common-subpath/discuss/1319639/C%2B%2B-Easy-Solution-using-Rolling-Hash-with-Explanation

// Sources:
// https://www.youtube.com/watch?v=BQ9E-2umSWc
// https://www.youtube.com/watch?v=BfUejqd07yo

// https://leetcode.com/problems/longest-common-subpath/submissions/
namespace _csharp
{
	public class _1923_longest_common_subpath
	{
		public int LongestCommonSubpath(int n, int[][] paths) {
			// This is to speed up the process...I sort by path lengths so I can detect when a hash fails on short paths first versus wasting time on
			// rolling the hash on longer paths. Also it helps get the path with the shortest length which would be the maximum possible common path length
			Array.Sort(paths, (a,b) => SortByPathLength(a,b));

			int ans = 0;
			int lo = 1;
			int hi = paths[0].Length;

			// binary search on the longest hash length (1 - path[0].Length). 
			while(lo<=hi){
				int mid = lo + ((hi-lo)/2);
				if(hashMatch(mid, paths)){		// check if this length is valid.
					lo = mid + 1;
					ans = mid;
				}
				else{
					hi = mid - 1;
				}
			}

			return ans;
		}

		// Calculate hash. if this hash is matched in all paths, then hashLength is a valid common path length.
		private bool hashMatch(int hashLength, int[][] paths){
			long hash = 1; long _base=165131; int p0L = paths[0].Length;

			// calculate the furthest hash. i.e. for hashLength=3 -> base^2
			for(int i=0;i<hashLength-1;++i){
				// notice here I put (hashLength-1) because I want to calculate hash up to power (hashLength-1).
				// i.e if hashLength=3. I have powers (b^0, b^1, b^2). since b^0=1. so I just need b^1 and b^2. so that is two rotations.
				hash = getMod(hash*_base);
			}

			// calculate all rolling hashes of length hashLength of paths[0], paths[0] is my base for hashes lengths as it is the longest possible
			// common hash lenght I can get. anything hashLength > paths[0] won't match with paths[0]
			var hashMap = new Dictionary<long,int>();   // key: hash | value: count of matches
			long rollingHash = 0;
			for(int i=0;i<p0L;++i){
				rollingHash = getMod((rollingHash*_base) + paths[0][i]);    // rollingHash*base -> shift the hash by base and add new item paths[0][i]*(base^0) = paths[0][i]

				if(i>=hashLength-1){
					// I have a rolling hash equals in length to hashLength. save it in map.
					// notice I do if not already added. b/c for paths[0]={1,2,3,1,2,3} I can get legit duplicate hash of same length.
					if(!hashMap.ContainsKey(rollingHash))
						hashMap.Add(rollingHash,1);

					// subtract first item from rolling hash
					long excludedItemHash = paths[0][i-(hashLength-1)] * hash;
					rollingHash = getMod(rollingHash - excludedItemHash);
				}
			}

			// calculate rolling hash of all other paths.
			for(int k=1;k<paths.Length;++k){
				long rollingHash_2 = 0;
				int[] pp = paths[k]; bool hashFound=false;
				for(int i=0;i<pp.Length;++i){
					rollingHash_2 = getMod((rollingHash_2*_base) + pp[i]);

					if(i>=hashLength-1){
						// if hash doesn't exist in map, there is no need to add it as it has no match with any of paths[0] hashes.
						// hashMap[rollingHash_2] == k => because a single path can have duplicate hash, so this to avoid duplicate counts within
						// the same path. e.g [1,2,3,1,2,3] this is a valid duplicate hash of length 3.
						if(hashMap.ContainsKey(rollingHash_2) && hashMap[rollingHash_2] == k){
							hashFound = true;
							hashMap[rollingHash_2]++;
						}

						// this only applies to last path. I can check if the last path has a hash that exists in all other pathes 
						// (basically its count == paths) which means this hash exists in all paths, that means it is common among all paths.
						if(k==paths.Length-1 && hashMap.ContainsKey(rollingHash_2) && hashMap[rollingHash_2] == paths.Length)
							return true;

						// subtract first item from rolling hash
						long excludedItemHash = pp[i-(hashLength-1)] * hash;
						rollingHash_2 = getMod(rollingHash_2 - excludedItemHash);
					}
				}

				// if not a single matching hash was found for any of the rolling hashes of paths[k], no need to continue. 
				// return false for the entire process.
				if(!hashFound)
					return false;
			}

			// will never hit
			return false;
		}

		private long getMod(long x){
			long m=8417508174513;
			return ((x%m) + m)%m; // we do this because x can be negative when i roll the hash.
		}

		private static int SortByPathLength(int[] a, int[] b){
			if(a.Length < b.Length) return -1;
			if(a.Length > b.Length) return 1;

			return 0;
		}
	}
}

/*
 * How rolling hash is calculated: 
 * The main equations is: summation of[(arr[i] * base^p)%m] => (arr[0] * base^0)%m + (arr[1] * base^1)%m + (arr[2] * base^2)%m + ... (arr[n] * base^n)%m
 * but to make rolling easy. I will swap the power => (arr[0] * base^n)%m + (arr[1] * base^n-1)%m + (arr[2] * base^n-2)%m + ... (arr[n] * base^0)%m
 * To roll a hash of hash window equals 3: arr[0]*10^2 + arr[1]*10^1 + arr[2]*10^0 . 
 * I have to: subract arr[0] hash, shift the remainder by base, then add the new value
 * Notice: If I have 10 and I want to shift it by its base and add 1 to it => 10*10 + 1 = 101.
 * example: arr[0]*10^2 + arr[1]*10^1 + arr[2]*10^0 I want to shift it by removing arr[0] hash =>
 * subtract arr[0] hash: (arr[0]*10^2 + arr[1]*10^1 + arr[2]*10^0) - (arr[0]*10^2) = arr[1]*10^1 + arr[2]*10^0
 * shift hash by base => (arr[1]*10^1 + arr[2]*10^0)*10 = arr[1]*10^2 + arr[2]*10^1
 * add new value arr[3] hash which is arr[3]*10^0 => arr[1]*10^2 + arr[2]*10^1 + arr[3]*1 (notice 10^0 equals 1)
 * if I want to roll it again, I have to find the arr[1] hash, which is also (10^2), notice this piece of the hash (which i called furthest hash)
 * is constant, so I just need to find this one, and then multiply it by the item I am removing, shift by base, add new item.
 * 
 * How to find the furthest hash. Yes I can do Math.Pow(10,length_of_hash_window-1) = Math.Pow(10,2). but this can overflow if base is high. so i can use
 * a for-loop and keep multiple the base by itself and taking the mod on each loop. 3-loop iterations will get me: x*x*x = x^3.
 * 
 * The other part that confused me was calculating of initial rollinghash => rollingHash = getMod((rollingHash*_base) + paths[0][i]);
 * Basically this is like (((hash - item_remove)*base) + item_added)%m => no item is removed so => (((hash - 0)*base) + item_added)%m =>
 * ((hash*base) + item_added)%m. I am constantly shifting the already added items and add a new item on each for-loop rotation.
 * 
 * I don't know why base=165131 and mod=8417508174513 were chosen. but they work for large numbers. Ideally you want to choose your base equals to the
 * number of unique characters you have. So if this was a string match (26 unique characters), my base can be 29 or 31.
*/