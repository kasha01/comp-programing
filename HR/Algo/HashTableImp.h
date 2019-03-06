#ifndef HASHTABLEIMP_H_INCLUDED
#define HASHTABLEIMP_H_INCLUDED


class HashTableEntry{
public:
    int key;
    int value;

    HashTableEntry(int k, int v){
        this->key = k;
        this->value = v;
    }
};

//open addressing
class MyHashTable{

    HashTableEntry* table[128];
    //HashTableEntry** table[128];
    int hsize = 128;
public:
    MyHashTable(){
        //table = new HashTableEntry*[128]; // he used this in example, in case the hash size is huge so it is better to put
        // on heap
        for(int i = 0; i<128; i++){
            table[i] = nullptr;
        }
    }

    void put(int k, int v){
        //generate Hash
        int myhash = k%hsize;
        while(table[myhash] != nullptr && table[myhash]->key != k){
            myhash = (myhash+1)%hsize;
        }

        if(table[myhash] == nullptr){
            table[myhash] = new HashTableEntry(k,v);
        }else{
            table[myhash]->value = v;
        }
    };

    int get(int k){
        int myhash = k%hsize;
        while(table[myhash] != NULL && table[myhash]->key != k){
            myhash = (myhash + 1)%hsize;
        }

        if(table[myhash]==nullptr){
            return -1;
        }
        else if(table[myhash]->key == k){
            return table[myhash]->value;
        }
    };
};

#endif // HASHTABLEIMP_H_INCLUDED
