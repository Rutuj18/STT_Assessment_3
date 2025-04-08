import pandas as pd

# Load CSV
df = pd.read_csv("TypeMetrics.csv")  # Update path if needed
df.columns = [col.strip() for col in df.columns]

# Sort all classes by LCOM1 descending
sorted_by_lcom1 = df.sort_values(by="LCOM1", ascending=False)

# Optional: Save to CSV
sorted_by_lcom1.to_csv("all_classes_sorted_by_lcom1.csv", index=False)
