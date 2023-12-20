# import from the class locator file from locators folder
import logging as logger
from ssqatest_framework.src.pages.Locators.MyAccountSignedOutLocator import MyAccountSignedOutLocators
from ssqatest_framework.src.SeleniumExtended import SeleniumExtended
from ssqatest_framework.src.helpers.config_helpers import get_base_url


class Invalid_Registration(MyAccountSignedOutLocators):
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

