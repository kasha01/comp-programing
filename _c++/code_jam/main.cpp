#include <bits/stdc++.h>
using namespace std;
typedef unsigned long long int uint64;

// https://code.google.com/codejam/contest/9234486/dashboard#s=p2&a=2

struct Key {
    char first, last;
    array<int, 26> freq;
};

bool operator== (const Key &a, const Key &b) {
    return a.first == b.first && a.last == b.last && a.freq == b.freq;
}

struct KeyHash {
    size_t operator()(const Key &k) const {
        size_t res = k.first + 31*k.last;
        for (int i : k.freq) res = 31*res + i;
        return res;
    }
};

Key MakeKey(const string &word) {
    Key key{word.front(), word.back(), {}};
    for (char ch : word) key.freq[ch - 'a']++;
    return key;
}

int Solve(const vector<string> &dictionary, const string &text) {
    unordered_map<Key, int, KeyHash> groups;
    unordered_set<int> word_lengths;
    for (const string &word : dictionary) {
        word_lengths.insert(word.size());
        groups[MakeKey(word)]++;
    }
    int answer = 0;
    for (int length : word_lengths) {
        if (length > text.size()) continue;
        Key key = {};
        int i = 0;
        for (; i < length - 1; ++i) {
            key.freq[text[i] - 'a']++;
        }
        for (; i < text.size(); ++i) {
            key.first = text[i - (length - 1)];
            key.last = text[i];
            key.freq[key.last - 'a']++;
            auto it = groups.find(key);
            if (it != groups.end()) {
                answer += it->second;
                groups.erase(it);
            }
            key.freq[key.first - 'a']--;
        }
    }
    return answer;
}

int main() {
  int T = 1;
  //cin >> T;
  for (int t = 1; t <= T; ++t) {
      int L = 5;
      //cin >> L;
      string arr[] = {"axpaj", "apxaj", "dnrbt","pjxdn","abd"};
      vector<string> dictionary;
      for (int i=0;i<L;++i) dictionary.push_back(arr[i]);
      char S1 = 'a', S2 = 'a';
      int N = 50, A = 1, B = 1, C = 1, D = 30;
      vector<int> X(N);
      X[0] = S1;
      X[1] = S2;
      for (int i = 2; i < N; ++i) X[i] = ((long long)A*X[i - 1] + (long long)B*X[i - 2] + C)%D;
      string S;
      S.resize(N);
      S[0] = S1;
      S[1] = S2;
      for (int i = 2; i < N; ++i) S[i] = char('a' + X[i]%26);
      cout << "Case #" << t << ": " << Solve(dictionary, S) << endl;
  }
}
