

from selenium import webdriver


driver = webdriver.Chrome()
driver.implicitly_wait(10)

driver.get('http://localhost:63342/Course%20provided_Code/QA-Automation/Python%20Test%20Framework/Course%20provided_Code/SELENIUM_SECTION/Waits/page_with_slow_image.html?_ijt=7i15qkvpf0dqbgjq4d3amgndte&_ij_reload=RELOAD_ON_SAVE')
my_image = driver.find_element('id', 'the_slow_image')
my_image.click()
print("Found image")