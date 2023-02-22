using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using LibraryUserinterface.Forms.Pages;
using NUnit.Framework;
using NUnitTest.Constants;
using NUnitTest.Extensions;

namespace NUnitTest.Steps
{
    public class MainPageSteps
    {
        private readonly MainPage _mainPage = new MainPage();

        public void MainPageIsPresent() => _mainPage.AssertIsPresent();

        public void AcceptCookiesButtonIsDisplayed() => Assert.IsTrue(_mainPage.IsAcceptCookiesButtonDisplayed, "Accept cookies button should be displayed");

        public void AcceptCookiesButtonIsNotDisplayed() => AqualityServices.ConditionalWait.WaitForTrue(() => _mainPage.IsAcceptCookiesButtonDisplayed);

        public void AcceptCookies() => _mainPage.AcceptCookies();

        public void StartGame() => _mainPage.StartGame();

        public static void ScrollToTheFooter() => AqualityServices.Browser.ScrollWindowBy(0, GetFullPageHeight());

        public static int GetFullPageHeight() => (int)(long)AqualityServices.Browser.ExecuteScriptFromFile<long>(ResourceConstants.PathToGetFullPageHeightJS);
    }
}
