import pytest
from selenium import webdriver
from selenium.webdriver.firefox.service import Service as FirefoxService
from webdriver_manager.firefox import GeckoDriverManager


@pytest.fixture(params=["chrome"])
def driver(request):
    browser = request.param
    print(f"creating {browser} browser")
    if browser == "chrome":
        driver = webdriver.Chrome()
    elif browser == "firefox":
        driver = webdriver.Firefox(service=FirefoxService(GeckoDriverManager().install()))
    else:
        raise TypeError(f"Expected 'chrome' or 'Firefox', but got {browser}")
    # set implicit wait time
    driver.implicitly_wait(10)
    driver.maximize_window()
    yield driver
    print(f"creating {browser} browser")
    driver.quit()


def pytest_addoption(parser):
    parser.addoption(
        "--browser", action="store", default="chrome", help="Browser (Chrome/FX) we want to use to run tests"
    )
