#ifndef GRAPHTHEO_H_INCLUDED
#define GRAPHTHEO_H_INCLUDED

#include<queue>

using namespace std;

inline void BellmanFord(int graph[][100], int source, int verticesCount)
{
    int pred[verticesCount];
    int dist[verticesCount];

    //Init
    for (int i = 0; i < verticesCount; i++)
    {
        dist[i] = std::numeric_limits<int>::max();
        pred[i] = -1;
    }

    //Designated source
    dist[source] = 0;

    for (int i = 0; i < verticesCount - 1; i++)
    {
        for (int u = 0; u < verticesCount; u++)     //loop to all nodes
        {
            for (int v = 0; v < verticesCount; v++)  //loop thru all edges from u --> v
            {
                if (graph[u][v] != 0)
                {
                    if (dist[u] + graph[u][v] < dist[v])
                    {
                        int d = dist[u] + graph[u][v];
                        dist[v] = dist[u] + graph[u][v];
                        pred[v] = u;
                    }
                }
            }
        }
    }

    for (int u = 0; u < verticesCount; u++)     //loop to all nodes
    {
        for (int v = 0; v < verticesCount; v++)  //loop thru all edges from u --> v
        {
        if (graph[u][v] != 0)
            {
                if (dist[u] + graph[u][v] < dist[v])
                {
                   //throw error / Negative Cycle Detected
                   cout << "Negative Cycle Detected" << endl;
                   throw 20;
                }
            }
        }
    }

    cout << dist[99] << endl;
};


//https://www.hackerrank.com/challenges/bfsshortreach
class Node
{
public:
    int index;
    bool visisted;
    int data;
};

class Graph
{
public:
    vector<Node*> nodeslist;
    bool** matrix;
    int size; //number of nodes
    int* distance;

    Graph(int nodecount)
    {
        this->size = nodecount;
        matrix = new bool*[nodecount];
        for(int i=0; i< nodecount; i++){
            matrix[i] = new bool[nodecount];
            for(int j=0; j<nodecount; j++){
                matrix[i][j] = false;
            }
        }

        this->distance = new int[nodecount];


        // add nodes
        for (int i = 0; i < size; i++)
        {
            this->distance[i] = -1;
            Node* n = new Node();
            n->data = i+1;
            n->index = i;
            n->visisted=false;
            nodeslist.push_back(n);
        }
    };

    ~Graph(){
        delete[] distance;  //delete distance array of pointers
        for(int i=0 ; i< this->size ; i++){
            delete[] matrix[i];
            delete nodeslist[i];    //delete each pointer in the vector
        }
        delete[] matrix;
    }


    void connectNode(int n1, int n2)
    {
        this->matrix[n1 - 1][n2 - 1] = true;
        this->matrix[n2 - 1][n1 - 1] = true;
    }

    void BFS(int startNode)
    {
        queue<Node*> q;

        Node* n = nodeslist[startNode - 1];
        n->visisted = true;
        distance[startNode - 1] = 0;

        q.push(n);

        while (q.size() > 0)
        {
            Node* mynode = q.front();
            q.pop();
            Node* gn;
            while ((gn = genAdjacentNode(mynode)) != NULL)
            {
                gn->visisted = true;
                int ss = distance[mynode->index] ;
                distance[gn->index] = distance[mynode->index] + 6;
                q.push(gn);
            }
        }
    }

    void PrintDistances()
    {
        for(int i=0; i<this->size; i++)
        {
            if (this->distance[i] == 0) { continue; }
            cout << this->distance[i] << " ";
        }
    }

    Node* genAdjacentNode(Node* mynode)
    {
        Node* n;
        for (int i = 0; i < nodeslist.size(); i++)
        {
            n = nodeslist[i];
            if (n->index != mynode->index && n->visisted == false && (matrix[n->index][mynode->index]==true || matrix[mynode->index][n->index]==true))
            {
                distance[n->index] = 0;
                return n;
            }
        }
        return NULL;
    }
};

void bfsshortreachDriver(){
    Graph* gf = new Graph(4);
    gf->connectNode(1, 2);
    gf->connectNode(1, 3);
    gf->BFS(1);
    gf->PrintDistances();
    delete gf;
}

// END

#endif // GRAPHTHEO_H_INCLUDED
