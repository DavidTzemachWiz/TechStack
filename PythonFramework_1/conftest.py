import pytest
from selenium import webdriver
from selenium.webdriver.chrome.options import Options as ChOptions
from selenium.webdriver.firefox.options import Options as FxOptions
from Utils.browser_commands import SeleniumCommands
def pytest_addoption(parser):
    # Add a command line option to pytest for specifying the browser
    parser.addoption(
        "--browser",  # Option name
        action="store",  # Store the provided value
        choices=["chrome", "firefox", "edge", "headlesschrome"],  # Accept 'chrome','headlesschrome', 'firefox', or 'edge' as valid values
        default="chrome",  # Default value if not provided
        help="Specify the browser to use (chrome, firefox, or edge)",  # Help message for users
    )

    # Add a command line option to pytest for specifying the environment
    parser.addoption(
        "--env",  # Option name
        action="store",  # Store the provided value
        choices=["staging", "production", "testing"],  # Accept 'staging', 'production', or 'testing' as valid values
        default="staging",  # Default value if not provided
        help="Specify the environment to run tests against (staging, production, or testing)",  # Help message for users
    )

@pytest.fixture(scope="class")
def test_setup(request):
    browser = request.config.getoption("--browser")
    if browser == 'chrome':
        driver = webdriver.Chrome()
    elif browser == 'firefox':
        driver = webdriver.Firefox()
    elif browser == 'edge':
        # Setup for Edge
        driver = webdriver.Edge()
    elif browser == 'headlesschrome':
        chrome_options = ChOptions()
        chrome_options.add_argument('--disable-gpu')
        chrome_options.add_argument('--no-sandbox')
        chrome_options.add_argument('--headless')
        driver = webdriver.Chrome(options=chrome_options)
    else:
        raise ValueError("Unsupported browser option specified")  # Explicitly raise ValueError for unsupported options
    selenium_commands = SeleniumCommands(driver)
    selenium_commands.get_current_url()
    request.cls.driver = driver
    selenium_commands.max_window()
    yield
    selenium_commands.close_browser()
    selenium_commands.quit_browser()
