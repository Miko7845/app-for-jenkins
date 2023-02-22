using Aquality.Selenium.Browsers;
using LibraryUserinterface.Configurations;
using LibraryUserinterface.Forms.Pages;
using LibraryUserinterface.Forms;
using NUnit.Framework;
using NUnitTest.Steps;
using UserinterfaceTest.Tests;

namespace NUnitTest.Tests
{
    public abstract class BaseWebTest : BaseTest
    {
        public static void GoToPageStartPage() => AqualityServices.Browser.GoTo(Configuration.StartUrl);

        private MainPageSteps _mainPageSteps;
        private HelpForm _helpForm;
        private SignInPage _signInPage;
        private CookiesForm _cookiesForm;
        private protected MainPageSteps MainPageSteps => _mainPageSteps ??= new MainPageSteps();
        private protected HelpForm HelpForm => _helpForm ??= new HelpForm();
        private protected SignInPage SignInPage => _signInPage ??= new SignInPage();
        private protected CookiesForm CookiesForm => _cookiesForm ??= new CookiesForm();

        [TearDown]
        public void CleanUp()
        {
             if(AqualityServices.IsBrowserStarted) 
                AqualityServices.Browser.Quit();
        } 

        [SetUp]
        public new void Setup()
        {
            GoToPageStartPage();
            AqualityServices.Browser.Maximize();
            MainPageSteps.MainPageIsPresent();
            MainPageSteps.StartGame();
        }
    }
}
