import pytest
from selenium import webdriver
from selenium.webdriver.common.by import By

@pytest.mark.usefixtures("init_driver")
class TestDummy():
   @pytest.mark.TR1
   def test_dummy_funct(self):
       assert 1==3



