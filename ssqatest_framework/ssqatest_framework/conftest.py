import pytest
from selenium import webdriver
import os

# This file will contain the fixture for all tests in the framework

"""
Pytest provides four levels of fixture scopes:

Function (Set up and torn down once for each test function)
Class (Set up and torn down once for each test class)
Module (Set up and torn down once for each test module/file)
Session (Set up and torn down once for each test session i.e comprising one or more test files)
"""


@pytest.fixture(scope="class")
def init_driver(request):
    # Create list of supported browsers
    supported_browsers = ['chrome', 'Edge', 'firefox']
    # os.environ in Python is a mapping object that represents the user’s environmental variables. It returns a dictionary having user’s environmental variable as key and their values as value.
    browser = os.environ.get('BROWSER', None)
    # Create error structure if user selct an unsupported browser
    if not browser:
        raise Exception("The env variable 'BROWSER' must be set.")

    browser = browser.lower()
    if browser not in supported_browsers:
        raise Exception(f"provided browser '{browser}' is not one of the supported."
                        f"Supported are: {supported_browsers}")

    if browser in ('chrome'):
        driver = webdriver.Chrome()
    elif browser in ('firefox'):
        driver = webdriver.Firefox()
    elif browser in ('Edge'):
        driver = webdriver.Edge()

    """
    The web_driver is being stored in the request variable at the class level for easy access during test execution.
    Execution of multiple test cases in a class with parameter scope set to "class" involves calling the driver function only once.
    """

    request.cls.driver = driver
    # yield statement suspends a function’s execution and sends a value back to the caller,Yield can produce a sequence of values. 
    yield
    driver.quit()
