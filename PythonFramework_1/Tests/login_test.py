import time
import pytest
from selenium import webdriver
from selenium.webdriver.chrome.service import Service  # Import Service class
from webdriver_manager.chrome import ChromeDriverManager  # Import ChromeDriverManager class
from POM.loginPage import LoginPage  # Import LoginPage class from POM package
from POM.HomePage import homePage  # Import homePage class from POM package
import Utils
from Utils import utils as test_attributes  # Import test attributes from Utils package



@pytest.mark.usefixtures("test_setup")  # Use the test_setup fixture defined in conftest.py
class TestLogin():
    # Test case for login functionality
    def test_login(self):
        driver = self.driver  # Get the WebDriver instance from the test_setup fixture
        driver.get(test_attributes.URL)  # Navigate to the specified URL
        time.sleep(5)  # Wait for 5 seconds (optional)
        login_page_object = LoginPage(driver)  # Create LoginPage object
        login_page_object.enter_username(test_attributes.USERNAME)  # Enter username
        login_page_object.enter_password(test_attributes.PASSWORD)  # Enter password
        login_page_object.ClickLogIn()  # Click the login button

    # Test case for logout functionality
    @pytest.mark.smoke
    def test_logout(self):
        driver = self.driver  # Get the WebDriver instance from the test_setup fixture
        home_page_object = homePage(driver)  # Create HomePage object
        time.sleep(5)  # Wait for 5 seconds (optional)
        home_page_object.clickWelcome()  # Click the welcome message
        time.sleep(3)  # Wait for 3 seconds (optional)
        home_page_object.clickLogOut()  # Click the logout button


