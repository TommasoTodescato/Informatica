#include <bits/stdc++.h>
using namespace std;

class Graph
{
public:
	int N;
	vector<vector<int>> adj;

	Graph(int n)
	{
		N = n;
		adj.resize(n);
	}

	void addEdge(int v, int w)
	{
		adj[v].push_back(w);
		adj[w].push_back(v);
	}

	void BFS(int start)
	{
		bool visited[N];
		int distance[N];
		queue<int> queue;
		visited[start] = true;
		distance[start] = 0;
		queue.push(start);
		while (!queue.empty())
		{
			int s = queue.front();
			queue.pop();
			for (auto &v : adj[s])
			{
				if (visited[v]) continue;

				visited[v] = true;
				distance[v] = distance[s] + 1;
				queue.push(v);
			}
		}
	}
};

typedef pair<int, int> p;
class WeightedGraph
{
public:
	int N;
	vector<vector<p>> adj;

	WeightedGraph(int n)
	{
		N = n;
		adj.resize(n);
	}

	void addEdge(int u, int v, int weight)
	{
		adj[u].push_back(make_pair(v, weight));
		adj[v].push_back(make_pair(u, weight));
	}

	void dijkstra(int start)
	{
		bool visited[N];
		int dist[N];
		priority_queue<p, vector<p>, greater<p>> q;

		dist[start] = 0;
		q.push({start, 0});
		while (!q.empty())
		{
			int node = q.top().first;
			q.pop();
			if (visited[node]) continue;
			visited[node] = true;

			for (auto &x : adj[node])
			{
				if (dist[x.first] <= dist[node] + x.second) continue;

				dist[x.first] = dist[node] + x.second;
				q.push({x.first, dist[x.first]});
			}
		}
	}
};