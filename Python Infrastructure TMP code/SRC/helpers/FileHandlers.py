class workingWithFiles:

    # Initiate a new class object with file path
    def __init__(self, file_path):
        self.file_path = file_path

    # Method 1: Get all content of a file
    def get_file_content(self):
        try:
            with open(self.file_path, 'r') as file:
                content = file.read()
                return content
        except FileNotFoundError:
            print(f"Error: File not found at {self.file_path}")
            return None
        except Exception as e:
            print(f"Error reading file: {e}")
            return None

    # Method 2: File Content sperated with Comma
    def file_content_with_comma(self):
        try:
            with open(self.file_path, 'r') as my_f:
                file_content = my_f.read()
                list_of_data = file_content.split('\n')
                return list_of_data
        except FileNotFoundError:
            print(f"Error: File not found at {self.file_path}")
            return None
        except Exception as e:
            print(f"Error reading file: {e}")
            return None

    # Method 3: Search Content in file
    def search_in_file(self, string_to_search):
        with open(self.file_path, 'r') as my_f:
            if string_to_search in my_f.read():
                return True
            else:
                return False

    # Will remove file content and add new data
    def write_to_file_without_append(self, data, mode='w'):
        try:
            with open(self.file_path, mode) as file:
                file.write(data)
                print(f"Data written to {self.file_path} successfully.")
        except Exception as e:
            print(f"Error writing to file: {e}")

    # Will remove file content and add new data
    def write_to_file_with_append(self, data, mode='a'):
        try:
            with open(self.file_path, mode) as file:
                file.write(data + '\n')
                print(f"Data written to {self.file_path} successfully.")
        except Exception as e:
            print(f"Error writing to file: {e}")


class action:
    FileReader = workingWithFiles('./FileForHelper.txt')
    result = FileReader.search_in_file('f')
    print(result)
