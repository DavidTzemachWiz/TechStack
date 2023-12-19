import pytest
from selenium import webdriver
from selenium.webdriver.common.by import By

@pytest.mark.usefixtures("init_driver")
class TestDummy():
    def test_dummy_funct(self):
        print("CreatechromeDriver")
        self.driver.get("http://www.google.com")



