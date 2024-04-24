import  os

# QA Env
URL = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"
USERNAME = "Admin"
PASSWORD = "admin123"

#Dev Env
URL_Dev = ""
USERNAME_Dev = ""
PASSWORD_Dev = ""


def getcurrent_Directory():
    # Get the current working directory
    current_directory = os.getcwd()
    print("Current working directory:", current_directory)
    # Join a folder name to the current directory to get the full path
    folder_path = os.path.join(current_directory, "folder_name")
    print("Folder path:", folder_path)
