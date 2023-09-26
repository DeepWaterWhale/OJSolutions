# DFS in tree

tags: `dfs`, `lca`

## LCA algorithm

Ref [Lowest Common Ancestor](https://cp-algorithms.com/graph/lca.html).

Main idea is to use [DFS](dfs.md) to traverse the tree and get following data:

- `euler<NodeKey>[]`: node visiting history during DFS
- `first<NodeKey, int>`: the first occurrence of each node in `euler`
- `depth<NodeKey, int>`: the depth of each node

For any 2 nodes `u, v` *(assume first[u] < first[v])*, the DFS process is like:

1. first visit `u`
1. visiting the subtree whose root is `u`
1. let `p = u.Parent`, visiting `p` and some other nodes in the `p`'s subtree
1. like the previous step, keep going up until `lca(u, v)`
1. visiting some nodes in the subtree of `lca(u, v)` until reach to `v`

So `lca(u, v)` is the node in `euler[first[u]: first[v]]` with minimal depth, it's reduced to a [RMQ](../rmq.md) problem.