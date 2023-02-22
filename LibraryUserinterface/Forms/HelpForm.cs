using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace LibraryUserinterface.Forms
{
    public class HelpForm : BaseAppForm
    {
        private IButton _sendToBottomButton => ElementFactory.GetButton(By.XPath("//button[contains(@class, 'send-to-bottom')]"), "Send to bottom button");

        public HelpForm() : base(By.XPath("//div[contains(@class, 'container')]//*[contains(@class, 'title')]"), nameof(HelpForm)) { }

        public void ClickToBottom()
        {
            _sendToBottomButton.Click();
            State.WaitForNotDisplayed();
        }
    }
}
