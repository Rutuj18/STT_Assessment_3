import pandas as pd
import matplotlib.pyplot as plt

# Load the CSV
df = pd.read_csv('TypeMetrics.csv')

# List of selected class names
selected_classes = [
    'AbstractInstant', 'AbstractDateTime', 'AbstractInterval', 'AbstractDuration',
    'BaseDuration', 'BaseLocal', 'BaseSingleFieldPeriod', 'Days'
]

# Filter the DataFrame for selected classes
filtered_df = df[df['Type Name'].isin(selected_classes)][['Type Name', 'LCOM1', 'LCOM4', 'YALCOM']]

# Save the filtered table for report use
filtered_df.to_csv("SelectedClassesLCOM.csv", index=False)

# Plotting the LCOM metrics
plt.figure(figsize=(12, 6))
bar_width = 0.25
index = range(len(filtered_df))

# Bars for each metric
plt.bar(index, filtered_df['LCOM1'], bar_width, label='LCOM1')
plt.bar([i + bar_width for i in index], filtered_df['LCOM4'], bar_width, label='LCOM4')
plt.bar([i + bar_width * 2 for i in index], filtered_df['YALCOM'], bar_width, label='YALCOM')

# Labels and settings
plt.xlabel('Class Name')
plt.ylabel('Metric Value')
plt.title('LCOM Comparison for Selected Classes')
plt.xticks([i + bar_width for i in index], filtered_df['Type Name'], rotation=45)
plt.legend()
plt.tight_layout()

# Save the graph
plt.savefig("cohesion_comparison_chart.png")
plt.show()
