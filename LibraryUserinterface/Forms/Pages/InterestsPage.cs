using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using LibraryUserinterface.Utilities;

namespace LibraryUserinterface.Forms.Pages
{
    public class InterestsPage : BaseAppForm
    {
        private IButton _nextButton => ElementFactory.GetButton(By.XPath("//button[contains(. , 'Next')]"), "To next button");
        private IButton _uploadImageButton => ElementFactory.GetButton(By.XPath("//a[contains(@class, 'upload-button')]"), "Upload any image");
        private ICheckBox _uncheckAllCheckbox => ElementFactory.GetCheckBox(By.XPath("//input[@id='interest_unselectall']/following-sibling::span"), "Uncheck all checkbox");
        private IList<ICheckBox> _listOfInterestsCheckBoxes => ElementFactory.FindElements<ICheckBox>(By.XPath("//div[@class='avatar-and-interests__interests-list__item']//span[@class='checkbox__box']"), "List of Checkbox");

        public InterestsPage() : base(By.XPath("//button[contains(. , 'Next')]"), nameof(InterestsPage)) { }

        private void ClickToNext() => _nextButton.Click();
        private void UncheckAll() => _uncheckAllCheckbox.Check();
        private void UploadFile() => _uploadImageButton.Click();
        private void FindAndSubmitFile(string path, string name) => DialogWindowHandler.UplaodFile(path, name);
        private void CheckInterestsById(List<int> numbers) 
        {
            foreach (var num in numbers) 
                _listOfInterestsCheckBoxes.ElementAt(num).Check(); 
        }

        public void FillTheForm(List<int> interestId, string filePath, string fileName)
        {
            UncheckAll();
            CheckInterestsById(interestId);
            UploadFile();
            FindAndSubmitFile(filePath, fileName);
            ClickToNext();
        }
    }
}
