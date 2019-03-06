#ifndef MY_HASH_TABLE_H_INCLUDED
#define MY_HASH_TABLE_H_INCLUDED

class HashEntry
{
public:
    int value;
    int key;
    HashEntry* next;

    HashEntry(){}

    HashEntry(int k, int v){
        this->key = k;
        this->value = v;
        this->next = nullptr;
    }
};

class MyHashTable {
public:
    int size = 0;
    int tableSize = 4;
    int maxsize = 2;
    double threshold = 0.7f;
    HashEntry** table;

    MyHashTable(){
        table = new HashEntry*[tableSize];
        for(int i=0; i< tableSize; i++){
            table[i] = nullptr;
        }
    }

    void put(int k, int v){
        int hash = k%tableSize;
        HashEntry* entry = table[hash];
        HashEntry* prev = nullptr;

        while(entry!=nullptr && entry->key != k){
            prev = entry;
            entry = entry->next;
        }

        if(entry == nullptr){
            if(prev != nullptr)
                prev->next = entry;
            else
                table[hash] = new HashEntry(k,v);
        }else{
            entry->value = v;
        }
        size++;

        if(size > maxsize){
            resize_table();
        }
    }

    int get(int k){
        int hash = k%tableSize;
        HashEntry* entry = table[hash];

        while(entry != nullptr && entry->key != k){
            entry = entry->next;
        }

        if(entry == nullptr){
            return -1;
        }else{
            return entry->value;
        }
    }

    void removehash(int k){
        int hash = k%tableSize;
        HashEntry* entry = table[hash];
        HashEntry* prev = nullptr;

        while(entry != nullptr && entry->key != k){
            prev = entry;
            entry = entry->next;
        }

        if(entry != nullptr && entry->key == k){
            if(prev == nullptr){
                HashEntry* temp = entry->next;
                delete entry;
                table[hash] = temp;
            }
            else{
                prev->next = entry->next;
                delete entry;
            }
        }
    }

private:
    void resize_table(){
        int oldsize = tableSize;
        tableSize = tableSize*2;
        maxsize = tableSize*threshold;
        size = 0;

        HashEntry** oldtable = table;
        this->table = new HashEntry*[tableSize];  //array of hash entry pointers on the heap
        //HashEntry* ff = new HashEntry[10]; // array of hash entry on the heap

        for(int i=0; i<tableSize;i++){
            table[i] = nullptr;
        }

        for(int i=0 ;i<oldsize;i++){
            if(oldtable[i] != nullptr){
                HashEntry* ent = oldtable[i];
                int d = ent->value;
                put(ent->key, ent->value);
            }
        }
        delete[] oldtable;
    }
};


#endif // MY_HASH_TABLE_H_INCLUDED
