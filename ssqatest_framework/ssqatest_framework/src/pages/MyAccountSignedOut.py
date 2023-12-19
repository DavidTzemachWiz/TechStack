# import from the class locator file from locators folder
from ssqatest_framework.src.pages.Locators.MyAccountSignedOutLocator import MyAccountSignedOutLocators
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait

# inherit from the MyAccountSignedOutLocator

class Invalid_Registration(MyAccountSignedOutLocators):

    # initialize driver per page as we are going to create an object from the class
    def __init__(self, driver):
        self.driver = driver

    def go_to_Account_Registration(self):
        pass

    def input_user_name(self, username):
        WebDriverWait(self.driver, 10).until(EC.visibility_of_element_located(self.LOGIN_USER_NAME)).send_keys(username)

    def input_user_pass(self, password):
        WebDriverWait(self.driver, 10).until(EC.visibility_of_element_located(self.LOGIN_PASSWORD)).send_keys(password)

    def click_Log_In_Buttong(self):
        WebDriverWait(self.driver, 10).until(EC.visibility_of_element_located(self.LOGIN_BTN)).click()

