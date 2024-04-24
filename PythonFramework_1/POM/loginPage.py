from selenium.webdriver.common.by import By


class LoginPage:
    def __init__(self, driver):
        self.driver = driver

        # PAGE lLOCATORS
        self.username_textbox_XPATH = "//input[@name='username']"
        self.password_textbox_XPATH = "//input[@name='password']"
        self.LogIn_Button_CSS = "button.orangehrm-login-button"

    def enter_username(self, username):
        self.driver.find_element(By.XPATH, self.username_textbox_XPATH).clear()
        self.driver.find_element(By.XPATH, self.username_textbox_XPATH).send_keys(username)

    def enter_password(self, password):
        self.driver.find_element(By.XPATH, self.password_textbox_XPATH).clear()
        self.driver.find_element(By.XPATH, self.password_textbox_XPATH).send_keys(password)

    def ClickLogIn(self):
        self.driver.find_element(By.CSS_SELECTOR, self.LogIn_Button_CSS).click()
