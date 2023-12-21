import pytest
import pytest_html
from selenium import webdriver
import os
from selenium.webdriver.chrome.options import Options as ChOptions
from selenium.webdriver.firefox.options import Options as FxOptions

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
    supported_browsers = ['chrome', 'headlesschrome', 'Edge', 'firefox']
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
    elif browser in ('headlesschrome'):
        chrome_options = ChOptions()
        chrome_options.add_argument('--disable-gpu')
        chrome_options.add_argument('--no-sandbox')
        chrome_options.add_argument('--headless')
        driver = webdriver.Chrome(options=chrome_options)
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

    import pytest_html

    # This code will modify the default HTML report, Pytest will check it prior to run the tests


## FOR: generating only pytest-html report
@pytest.hookimpl(hookwrapper=True)
def pytest_runtest_makereport(item, call):
    pytest_html = item.config.pluginmanager.getplugin("html")
    outcome = yield
    report = outcome.get_result()
    extra = getattr(report, "extra", [])
    if report.when == "call":
        # always add url to report
        xfail = hasattr(report, "wasxfail")
        # check if test failed
        if (report.skipped and xfail) or (report.failed and not xfail):
            is_frontend_test = True if 'init_driver' in item.fixturenames else False
            if is_frontend_test:
                results_dir = os.environ.get("RESULTS_DIR")
                if not results_dir:
                    raise Exception("Environment variable 'RESULTS_DIR' must be set.")

                screen_shot_path = os.path.join(results_dir, item.name + '.png')
                driver_fixture = item.funcargs['request']
                driver_fixture.cls.driver.save_screenshot(screen_shot_path)
                # only add additional html on failure
                # extra.append(pytest_html.extras.html('<div style="background:orange;">Additional HTML</div>'))
                extra.append(pytest_html.extras.image(screen_shot_path))

        report.extra = extra
