using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace LibraryUserinterface.Forms
{
    public class CookiesForm : BaseAppForm
    {
        private IButton _closeCookieButton => ElementFactory.GetButton(By.XPath("//button[contains(. , 'Not really, no')]"), "Close cookies button");

        public CookiesForm() : base(By.XPath("//div[@class='cookies']"), nameof(CookiesForm)) { }

        public void Close() => _closeCookieButton.Click();
    }
}
