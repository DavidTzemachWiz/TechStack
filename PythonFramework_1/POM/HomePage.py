from selenium.webdriver.common.by import By


class homePage():
    def __init__(self, driver):
        self.driver = driver

        # PAGE lLOCATORS
        self.Welcome_CSS = "p.oxd-userdropdown-name"
        self.Welcome_LINK_TEXT = "Logout"

    def clickWelcome(self):
        self.driver.find_element(By.CSS_SELECTOR, self.Welcome_CSS).click()

    def clickLogOut(self):
        self.driver.find_element(By.LINK_TEXT, self.Welcome_LINK_TEXT).click
