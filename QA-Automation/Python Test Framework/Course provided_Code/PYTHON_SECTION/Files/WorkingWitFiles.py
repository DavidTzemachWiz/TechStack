# The key here is to start with ./ = it will locate the file we need to load
sample_file = './sample_files/programming_language_wikipedia.txt'
names = ['user_1', 'user_2', 'User_3']
# Create a variable for the file and select mode 'r' open the file in read mode
with open(sample_file, 'w') as f:
    for i in names:
        f.write(i + '\n')

print(sample_file)

