import json
from collections import defaultdict

# Load the JSON data
with open('deps_data.json', 'r') as f:
    deps = json.load(f)

fan_in = defaultdict(int)
fan_out = {}

# Analyze each module and its dependencies
for module, dependencies in deps.items():
    fan_out[module] = len(dependencies)
    for dep in dependencies:
        fan_in[dep] += 1

# Show results
print("\n📥 FAN-IN (Modules that depend on this module):")
for module, count in sorted(fan_in.items(), key=lambda x: x[1], reverse=True):
    print(f"{module}: {count}")

print("\n📤 FAN-OUT (Modules this module depends on):")
for module, count in sorted(fan_out.items(), key=lambda x: x[1], reverse=True):
    print(f"{module}: {count}")
