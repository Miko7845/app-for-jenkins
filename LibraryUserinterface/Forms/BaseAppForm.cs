using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace LibraryUserinterface.Forms
{
    public class BaseAppForm : Form
    {
        private IButton AcceptCookiesButton => ElementFactory.GetButton(By.ClassName("cookies__button"), "Accept cookies");
        private ILabel _timer => ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'white timer')]"), "Timer");

        protected BaseAppForm(By locator, string name) : base(locator, name) { }

        public bool IsAcceptCookiesButtonDisplayed => AcceptCookiesButton.State.IsDisplayed;
        public void AcceptCookies() => AcceptCookiesButton.Click();
        public string GetTimer() => _timer.Text;
    }
}