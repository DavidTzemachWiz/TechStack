import time
from time import sleep

from selenium import webdriver
from selenium.webdriver.common.by import By

#Step 1: Open browser
driver = webdriver.Chrome()

#Step 2: Open A web page
driver.get("https://practicetestautomation.com/practice-test-login/")

#Step 3: Add credentials
username = driver.find_element(by=By.ID, value="username")
username.send_keys("student")


password = driver.find_element(by=By.ID, value="password")
password.send_keys("Password123")

#Submit
driver.find_element(by=By.ID, value="submit").click()
time.sleep(5)# Sleep for 3 second

#Verify URL with assertion
Site_url = driver.current_url
assert Site_url == "https://practicetestautomation.com/logged-in-successfully/"

#Verify new page contains expected text ('Congratulations' or 'successfully logged in')
Validate_Text = driver.find_element(by=By.CLASS_NAME, value="post-title")
assert Validate_Text.text == "Logged In Successfully"

#Verify button Log out is displayed and Enabled
Log_out_buton = driver.find_element(by=By.LINK_TEXT, value="Log out")
assert Log_out_buton.is_enabled()
assert Log_out_buton.is_displayed()

"""
if Log_out_buton.is_displayed() == True:
    print("BLADDDDDDDDDDDDDDDDDDDDD")
"""


