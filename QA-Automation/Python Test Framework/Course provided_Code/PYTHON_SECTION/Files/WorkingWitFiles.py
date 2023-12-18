# The key here is to start with ./ = it will locate the file we need to load
sample_file = './sample_files/programming_language_wikipedia.txt'
names = ['user_1', 'user_2', 'User_3']
personal_name = 'David Tzemach'
# Create a variable for the file and select mode 'r' open the file in read mode
with open(sample_file, 'a') as f: # open file in Append mode
        f.write(personal_name + '\n')

print(sample_file)

"""
#Result:
user_1
user_2
User_3
David Tzemach

"""
