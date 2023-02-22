using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace LibraryUserinterface.Forms.Pages
{
    public class SignInPage : BaseAppForm
    {
        private ITextBox _passwordField => ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'login-form')]//input[contains(@placeholder, 'Password')]"), "Password field");
        private ITextBox _emailField => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Your email']"), "Email field");
        private ITextBox _emailDomainField => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Domain']"), "Email field");
        private ICheckBox _termsCheckbox => ElementFactory.GetCheckBox(By.XPath("//*[contains(@id, 'accept-terms-conditions')]//following-sibling::span"), "Do not accept terms");
        private IButton _nextButton => ElementFactory.GetButton(By.XPath("//a[contains(. , 'Next')]"), "To next button");
        private IButton _showListButton => ElementFactory.GetButton(By.XPath("//div[@class='dropdown__header']"), "Show List");
        private IList<IButton> _listOfDomain => ElementFactory.FindElements<IButton>(By.XPath("//div[@class='dropdown__list-item']"), "List of domain");

        public SignInPage() : base(By.XPath("//a[contains(. , 'Next')]"), nameof(SignInPage)) { }

        private void ClickToNext() => _nextButton.WaitAndClick();
        private void SetPassword(string pass) => _passwordField.ClearAndType(pass);
        private void SetEmail(string email) => _emailField.ClearAndType(email);
        private void SetEmailDomain(string emailDomain) => _emailDomainField.ClearAndType(emailDomain);
        private void CheckToAcceptTerms() => _termsCheckbox.Check();
        private void ShowDomainList() => _showListButton.Click();
        private void SelectDomainById(int id) => _listOfDomain.ElementAt(id).Click();

        public void FillTheForm(string pass, string email, string emailDomain, int domainId)
        {
            SetPassword(pass);
            SetEmail(email);
            SetEmailDomain(emailDomain);
            CheckToAcceptTerms();
            ShowDomainList();
            SelectDomainById(domainId);
            ClickToNext();
        }
    }
}
