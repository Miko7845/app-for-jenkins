using Aquality.Selenium.Browsers;
using LibraryUserinterface.Forms;
using LibraryUserinterface.Forms.Pages;
using LibraryUserinterface.Utilities;
using NUnit.Framework;
using NUnitTest.Extensions;
using NUnitTest.Tests;

namespace UserinterfaceTest.Tests
{
    public class Tests : BaseWebTest
    {
        [Ignore("Ignore test - 1")]
        [Test(Description = "Test case 1")]
        [TestCase(5, 9)]
        public void TestCase_1(int emailDomainLength, int domainIdLength)
        {
            SignInPage.AssertIsPresent();
            SignInPage.FillTheForm(RandomData.GeneratePassword(), RandomData.GeneratePassword(), RandomData.GetRandomString(emailDomainLength), RandomData.GetRandomInt(0, domainIdLength));

            var _interestsPage = new InterestsPage();
            _interestsPage.AssertIsPresent();
            _interestsPage.FillTheForm(RandomData.GetListOfUniqueNumbers(), AqualityServices.Browser.DownloadDirectory, @"image.jpg");

            var _personalDetailsPage = new PersonalDetailsPage();
            _personalDetailsPage.AssertIsPresent();

            #region ---Card 3 actions(Полностью рабочий код)
            //var date = RandomData.GetRandomDay();
            //var age = DateTime.Today.Year - date.Year;
            //if (date.Date > DateTime.Today.AddYears(-age)) age--;
            //var genderIndex = RandomData.GetRandomInt(0, 1);
            //personalDetailPage.FillTheForm(RandomData.GetRandomString(7), RandomData.GetRandomString(7), RandomData.GetRandomString(5),
            //   RandomData.GetRandomString(10), RandomData.GetRandomInt(10000, 99999), genderIndex, RandomData.GetRandomInt(0, 235),
            //   date.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month), date.Year, RandomData.GetRandomInt(0, 20),
            //   RandomData.GetRandomInt(0, 20), RandomData.GetRandomInt(0, 1), age);
            #endregion 
        }

        [Test(Description = "Test case 2")]
        public void TestCase_2()
        {
            SignInPage.AssertIsPresent();
            HelpForm.ClickToBottom();
            Assert.IsTrue(HelpForm.State.WaitForNotDisplayed(), "The Help form is still displayed.");
        }

        [Test(Description = "Test case 3")]
        public void TestCase_3()
        {
            SignInPage.AssertIsPresent();
            CookiesForm.Close();
            Assert.IsFalse(CookiesForm.State.IsDisplayed, "The Cookies form is still displayed.");
        }

        [Test(Description = "Test case 4")]
        public void TestCase_4()
        {
            SignInPage.AssertIsPresent();
            Assert.IsTrue(SignInPage.GetTimer().StartsWith("00:00"), "The data does not match.");
        }
    }
}