import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import Select
from selenium.common.exceptions import StaleElementReferenceException


class Component_DropDown:

# Initialize the WebDriver
    driver = webdriver.Chrome()

# Navigate to the URL
    url = 'https://automationteststore.com/index.php?rt=product/category&path=68'
    driver.get(url)

#Function that get the default value
def get_default_option_text(dropdown):
    try:


        # Create a Select object
        select_object = Select(dropdown)

        # Get the default or current selected option text
        default_option_text = select_object.first_selected_option.text

        return default_option_text

    except Exception as e:
        print(f"An error occurred: {e}")
        return None


# Function that print all items in a drop_down
def get_all_items_in_dropdown(driver):
    try:
        # Wait for the dropdown element to be present
        dropdown_present = WebDriverWait(driver, 10).until(
            EC.presence_of_element_located((By.ID, 'sort'))
        )

        # Create a Select object
        dropdown_object = Select(dropdown_present)

        # Get all options
        all_options = dropdown_object.options

        # Print all items in the dropdown
        for option in all_options:
            print(option.text)

    except Exception as e:
        print(f"An error occurred: {e}")
        
# Function to select dropdown option by index
    def item_Selection_By_Index(element_id, string_to_search, index):
        try:
            # Locate the dropdown element
            dropdown = driver.find_element(By.ID, element_id)
            select_object = Select(dropdown)

            # Check if the string is in the dropdown options
            if string_to_search in dropdown.text:
                # Select by index
                select_object.select_by_index(index)
            else:
                print("Drop-Down value is not available")
        except StaleElementReferenceException:
            print("Stale Element Reference Exception. Trying to locate the element again.")
            # Re-locate the dropdown element if StaleElementReferenceException occurs
            dropdown = driver.find_element(By.ID, element_id)
            select_object = Select(dropdown)

            if string_to_search in dropdown.text:
                select_object.select_by_index(index)
            else:
                print("Drop-Down value is not available")

    # Function to select dropdown option by value or visible text
    def item_Selection(element_id, string_to_search, value=None, visible_text=None):
        try:
            # Locate the dropdown element
            dropdown = driver.find_element(By.ID, element_id)
            select_object = Select(dropdown)

            # Check if 'value' or 'visible_text' is specified
            if value is not None:
                # Select by value
                select_object.select_by_value(value)
            elif visible_text is not None:
                # Select by visible text
                select_object.select_by_visible_text(visible_text)
            else:
                print("Specify either 'value' or 'visible_text' for selection.")
        except StaleElementReferenceException:
            print("Stale Element Reference Exception. Trying to locate the element again.")
            # Re-locate the dropdown element if StaleElementReferenceException occurs
            dropdown = driver.find_element(By.ID, element_id)
            select_object = Select(dropdown)

            if value is not None:
                select_object.select_by_value(value)
            elif visible_text is not None:
                select_object.select_by_visible_text(visible_text)
            else:
                print("Specify either 'value' or 'visible_text' for selection.")

    # Dropdown element ID
    my_dropdown_id = 'sort'

# Example usage
#item_Selection_By_Index(element_id=my_dropdown_id, string_to_search="Price Low > High", index=2)
#item_Selection(element_id=my_dropdown_id, string_to_search="Price Low > High", value="some_value")
#item_Selection(element_id=my_dropdown_id, string_to_search="Price Low > High", visible_text="Some Text")

