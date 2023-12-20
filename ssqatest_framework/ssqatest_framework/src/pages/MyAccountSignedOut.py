# import from the class locator file from locators folder
import logging as logger
from ssqatest_framework.src.pages.Locators.MyAccountSignedInLocator import MyAccountSignedInLocators
from ssqatest_framework.src.pages.Locators.MyAccountSignedOutLocator import MyAccountSignedOutLocators
from ssqatest_framework.src.SeleniumExtended import SeleniumExtended
from ssqatest_framework.src.helpers.config_helpers import get_base_url


class Invalid_Registration(MyAccountSignedOutLocators, MyAccountSignedInLocators):
    endpoint = '/my-account/'

    # Configure logging at the beginning of your script
    # initialize driver per page as we are going to create an object from the class
    def __init__(self, driver):
        self.driver = driver
        self.sl = SeleniumExtended(self.driver)
        logger.info("Driver initialization")

    def go_to_my_account(self):
        base_url = get_base_url()
        my_account_url = base_url + self.endpoint
        logger.info((f"going to url: {my_account_url}"))
        self.driver.get(my_account_url)

    def input_user_name(self, username):
        self.sl.wait_and_input_text(self.LOGIN_USER_NAME, username, 10)

    def input_user_pass(self, password):
        self.sl.wait_and_input_text(self.LOGIN_PASSWORD, password, 10)

    def click_Log_In_Buttong(self):
        self.sl.wait_and_click(self.LOGIN_BTN)
        logger.info("Clicking Log_in Button")

    def wait_until_error_is_displayed(self, exp_error):
        self.sl.wait_until_element_contains_text(self.FIND_ELEMENT_ERROR_FOR_INVALID_REGISTRATION, exp_error)

    def input_register_email(self, email):
        self.sl.wait_and_input_text(self.Email_ADRESS, email, 10)

    def input_register_pass(self, password):
        self.sl.wait_and_input_text(self.REG_PASSWORD, password, 10)

    def click_register_Buttong(self):
        self.sl.wait_and_click(self.REGISTER_BTN)
        logger.info("Clicking Log_in Button")

    def verify_user_is_signed_in(self):
        self.sl.wait_until_LogOut_is_visible(self.FIND_ELEMENT_LOG_OUT_VALID_REGISTRATION)