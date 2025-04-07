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


# import json 

# # Load your JSON file
# with open("deps_data.json") as f:
#     data = json.load(f)

# # Extract module relationships
# graph = {mod: set(info.get("imports", [])) for mod, info in data.items()}
# reverse_graph = {mod: set(info.get("imported_by", [])) for mod, info in data.items()}
# all_modules = set(data.keys())

# ### 1. HIGHLY COUPLED MODULES (imported by many others)
# def find_highly_coupled(threshold=3):
#     return {mod: len(importers) for mod, importers in reverse_graph.items() if len(importers) >= threshold}

# ### 2. CYCLE DETECTION
# def find_cycles():
#     visited = set()
#     path = []

#     cycles = []

#     def dfs(module):
#         if module in path:
#             cycle = path[path.index(module):] + [module]
#             cycles.append(cycle)
#             return
#         if module in visited:
#             return
#         visited.add(module)
#         path.append(module)
#         for dep in graph.get(module, []):
#             if dep in all_modules:
#                 dfs(dep)
#         path.pop()

#     for mod in graph:
#         dfs(mod)

#     return cycles

# ### 3. UNUSED / DISCONNECTED MODULES
# def find_disconnected():
#     disconnected = []
#     for mod in all_modules:
#         imports = graph.get(mod, set())
#         imported_by = reverse_graph.get(mod, set())
#         if not imports and not imported_by:
#             disconnected.append(mod)
#     return disconnected

# # === RUN IT ===
# if __name__ == "__main__":
#     print("\n Highly Coupled Modules:")
#     for mod, count in sorted(find_highly_coupled().items(), key=lambda x: -x[1]):
#         print(f"{mod}: imported by {count} modules")

#     print("\n Cyclic Dependencies:")
#     cycles = find_cycles()
#     for cycle in cycles:
#         print((cycle))

#     print("\n Disconnected Modules:")
#     for mod in find_disconnected():
#         print(mod)

