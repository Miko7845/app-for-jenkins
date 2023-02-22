using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LibraryUserinterface.Forms.Pages
{
    public class PersonalDetailsPage : BaseAppForm
    {
        private ITextBox _firstNameField => ElementFactory.GetTextBox(By.XPath("//div[.='First name']//input"), "First name field");
        private ITextBox _surnameField => ElementFactory.GetTextBox(By.XPath("//div[.='Surname']//input"), "Surname field");
        private ITextBox _cityField => ElementFactory.GetTextBox(By.XPath("//div[.='City']//input"), "City field");
        private ITextBox _streetField => ElementFactory.GetTextBox(By.XPath("//div[.='Street']//input"), "Street field");
        private ITextBox _zipCodeField => ElementFactory.GetTextBox(By.XPath("//div[.='Zip']//input"), "Zip field");
        private IButton _cancelButton => ElementFactory.GetButton(By.XPath("//button[@class='button button--solid button--green']"), "Cancel button");
        private IButton _nextButton => ElementFactory.GetButton(By.XPath("//button[@class='button button--stroked button--white']"), "Next button");
        private IButton _numberUpStepperButton => ElementFactory.GetButton(By.XPath("//div[.='Number']//following-sibling::*//button[@class='numeric-stepper__button numeric-stepper__button--up']"), "Number numeric stepper up");
        private IButton _boxUpStepperButton => ElementFactory.GetButton(By.XPath("//div[.='Box']//following-sibling::*//button[@class='numeric-stepper__button numeric-stepper__button--up']"), "Box numeric stepper up");
        private IButton _showTitleListButton => ElementFactory.GetButton(By.XPath("//div[.='Title']//following-sibling::*//div[@class='dropdown__header']"), "Show Title List");
        private IButton _showCountryListButton => ElementFactory.GetButton(By.XPath("//div[.='Country']//following-sibling::*//*[@class='dropdown__header']"), "Show Country List");
        private IButton _showDayListButton => ElementFactory.GetButton(By.XPath("//div[.='Day' and @class='dropdown__header']"), "Show birthday days list button");
        private IButton _showMonthListButton => ElementFactory.GetButton(By.XPath("//div[.='Month' and @class='dropdown__header']"), "Show birthday month list button");
        private IButton _showYearListButton => ElementFactory.GetButton(By.XPath("//div[.='Year' and @class='dropdown__header']"), "Show birthday year list button");
        private IButton _gendersButton => ElementFactory.GetButton(By.XPath("//div[@class='toggle-button toggle-button--right']"), "Click to change gender ;)");
        private IList<IButton> _listOfTitles => ElementFactory.FindElements<IButton>(By.XPath("//div[.='Title']//following-sibling::*//div[@class='dropdown__list-item']"), "List of Titles");
        private IList<IButton> _listOfCountry => ElementFactory.FindElements<IButton>(By.XPath("//div[.='Country']//following-sibling::*//*[@class='dropdown__list']//div"), "List of Country");
        private IList<IButton> _listOfDays => ElementFactory.FindElements<IButton>(By.XPath("//div[.='Day']//following-sibling::*//*[@class='dropdown__list-item']"), "List of Days");
        private IList<IButton> _listOfMonth => ElementFactory.FindElements<IButton>(By.XPath("//div[.='Month']//following-sibling::*//*[@class='dropdown__list-item']"), "List of Months");
        private IList<IButton> _listOfYears => ElementFactory.FindElements<IButton>(By.XPath("//div[.='Year']//following-sibling::*//*[@class='dropdown__list-item']"), "List of Years");   
        private By _ageSlider => By.XPath("//div[@class='slider__handle']");

        public PersonalDetailsPage() : base(By.XPath("//button[@class='button button--stroked button--white']"), nameof(PersonalDetailsPage)) { }

        public void ClickToCancel() => _cancelButton.Click();
        private void ClickToNext() => _nextButton.WaitAndClick();
        private void SetFirstName(string firstName) => _firstNameField.ClearAndType(firstName);
        private void SetSurname(string surname) => _surnameField.ClearAndType(surname);
        private void SetCity(string city) => _cityField.ClearAndType(city);
        private void SetStreet(string street) => _streetField.ClearAndType(street);
        private void SetZip(int zip) => _zipCodeField.ClearAndType(zip.ToString());
        private void ClickToUpNumbers(int count) { for (int i = 0; i < count; i++) _numberUpStepperButton.Click(); }
        private void ClickToUpBoxes(int count) { for (int i = 0; i < count; i++) _boxUpStepperButton.Click(); }
        private void ClickToShowTitleList() => _showTitleListButton.Click();
        private void ClickToShowCountryList() => _showCountryListButton.ClickAndWait();
        private void ClickToShowDaysList() => _showDayListButton.Click();
        private void ClickToShowMonthList() => _showMonthListButton.Click();
        private void ClickToShowYearList() => _showYearListButton.Click();
        private void SelectTitleById(int id) => _listOfTitles.ElementAt(id).Click();
        private void SelectCountryById(int id) => _listOfCountry.ElementAt(id).Click();
        private void SelectDaysById(int day) => _listOfDays.Where(x => x.Text == day.ToString()).FirstOrDefault().Click();
        private void SelectMonth(string month) => _listOfMonth.Where(x => x.Text == month).FirstOrDefault().Click();
        private void SelectYearById(int year) => _listOfYears.Where(x => x.Text == year.ToString()).FirstOrDefault().Click();
        private void SelectGender(int i) { if (i == 0) _gendersButton.Click(); }
        private void SetAgeToSlider(int age)
        {
            var element = AqualityServices.Browser.Driver.FindElement(_ageSlider);
            AqualityServices.Browser.Driver.ExecuteScript($"arguments[0].setAttribute('style', 'left: {(double)age / 2}%;')", element);
            new Actions(AqualityServices.Browser.Driver).DragAndDropToOffset(element, 0, 0).Build().Perform();

        }

        public void FillTheForm(string firstName, string surname, string city, string street, int zip, int titleId, int countryId, int day, string month, int year, int numberCount, int boxesCount, int gender, int age)
        {
            SetFirstName(firstName);
            SetSurname(surname);
            SetCity(city);
            SetStreet(street);
            SetZip(zip);
            SetAgeToSlider(age);
            ClickToShowTitleList();
            SelectTitleById(titleId);
            ClickToShowCountryList();
            SelectCountryById(countryId);
            ClickToShowDaysList();
            SelectDaysById(day);
            ClickToShowMonthList();
            SelectMonth(month);
            ClickToShowYearList();
            SelectYearById(year);
            ClickToUpNumbers(numberCount);
            ClickToUpBoxes(boxesCount);
            SelectGender(gender);   
            ClickToNext();
        }
    }
}
