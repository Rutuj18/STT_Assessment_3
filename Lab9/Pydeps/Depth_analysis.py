import json

def build_graph(data):
    graph = {}
    for module, info in data.items():
        graph[module] = info.get("imports", [])
    return graph

def get_max_depth(graph, node, visited=None, memo=None):
    if visited is None:
        visited = set()
    if memo is None:
        memo = {}
    if node in memo:
        return memo[node]
    if node in visited:
        return 0  # avoid cycles
    visited.add(node)

    depth = 0
    for neighbor in graph.get(node, []):
        if neighbor in graph:  # internal deps only
            d = get_max_depth(graph, neighbor, visited.copy(), memo)
            depth = max(depth, 1 + d)
    memo[node] = depth
    return depth

# Load your JSON
with open("deps_data.json") as f:
    deps_data = json.load(f)

graph = build_graph(deps_data)

print("Dependency Depths:")
depths = {}
for module in graph:
    depth = get_max_depth(graph, module)
    depths[module] = depth
    print(f"  {module:30s} Depth: {depth}")

# Optional: show the module with the deepest chain
deepest = max(depths.items(), key=lambda x: x[1])
print(f"\nDeepest chain is from '{deepest[0]}' with depth {deepest[1]}")
