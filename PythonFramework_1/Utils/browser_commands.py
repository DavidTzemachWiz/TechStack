from selenium.webdriver.remote.webdriver import WebDriver
from selenium.common.exceptions import WebDriverException

# Define a class to encapsulate Selenium commands
class SeleniumCommands:
    # Initialize the class with a WebDriver instance
    def __init__(self, driver: WebDriver):
        self.driver = driver

    # Method to navigate back in the browser history
    def go_back(self):
        try:
            self.driver.back()
            print("Navigated back successfully.")
        except WebDriverException as e:
            print(f"Error navigating back: {e}")

    # Method to navigate forward in the browser history
    def go_forward(self):
        try:
            self.driver.forward()
            print("Navigated forward successfully.")
        except WebDriverException as e:
            print(f"Error navigating forward: {e}")

    # Method to close the current browser window
    def close_browser(self):
        try:
            self.driver.close()
            print("Closed the current browser window successfully.")
        except WebDriverException as e:
            print(f"Error closing the browser window: {e}")

    # Method to maximize the current browser window
    def max_window(self):
        try:
            self.driver.maximize_window()
            print("Maximized window successfully.")
        except WebDriverException as e:
            print(f"Error maximizing the browser window: {e}")

    # Method to quit the entire browser session
    def quit_browser(self):
        try:
            self.driver.quit()
            print("Quitted the browser session successfully.")
        except WebDriverException as e:
            print(f"Error quitting the browser session: {e}")

    # Method to get the title of the current page
    def get_page_title(self):
        try:
            title = self.driver.title
            print(f"Page title: {title}")
            return title
        except WebDriverException as e:
            print(f"Error getting page title: {e}")
            return None

    # Method to get the URL of the current page
    def get_current_url(self):
        try:
            url = self.driver.current_url
            print(f"Current URL: {url}")
            return url
        except WebDriverException as e:
            print(f"Error getting current URL: {e}")
            return None
