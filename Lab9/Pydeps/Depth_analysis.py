import json

# Load JSON data
with open("deps_data.json", "r") as f:
    data = json.load(f)

# Build graph of internal imports only
graph = {
    module: [imp for imp in info.get("imports", []) if imp in data]
    for module, info in data.items()
}

depth_cache = {}

def max_depth(module, visited=None):
    if visited is None:
        visited = set()
    if module in depth_cache:
        return depth_cache[module]
    if module in visited:
        # Cycle detected
        return 0
    visited.add(module)
    if not graph[module]:
        depth = 1
    else:
        depth = 1 + max(max_depth(dep, visited.copy()) for dep in graph[module])
    depth_cache[module] = depth
    return depth

# Compute max depth
max_overall_depth = 0
deepest_chain_root = None
for mod in graph:
    depth = max_depth(mod)
    if depth > max_overall_depth:
        max_overall_depth = depth
        deepest_chain_root = mod

print(f"Max Import Depth: {max_overall_depth}")
print(f"Root Module of Deepest Chain: {deepest_chain_root}")



