using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace LibraryUserinterface.Forms.Pages
{
    public class MainPage : BaseAppForm
    {
        private IButton _startButton => ElementFactory.GetButton(By.XPath("//a[contains(@class, 'start__link')]"), "Start the game");
        public MainPage() : base(By.XPath("//div[contains(@class, 'view__content')]"), nameof(MainPage)) { }

        public void StartGame() => _startButton.Click();
    }
}
