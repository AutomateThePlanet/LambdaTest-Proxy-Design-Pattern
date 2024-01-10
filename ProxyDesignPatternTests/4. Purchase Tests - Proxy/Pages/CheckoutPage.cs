using System.Threading;
using DecoratorDesignPatternTests.Models;

namespace DecoratorDesignPatternTests.FourthVersion;
public class CheckoutPage : WebPage
{
    public CheckoutPage(IWebDriver driver) 
        : base(driver)
    {
    }

    public IWebElement FirstNameInput => Driver.FindElement(By.Id("input-payment-firstname"));
    public IWebElement LastNameInput => Driver.FindElement(By.Id("input-payment-lastname"));
    public IWebElement EmailInput => Driver.FindElement(By.Id("input-payment-email"));
    public IWebElement TelephoneInput => Driver.FindElement(By.Id("input-payment-telephone"));
    public IWebElement PasswordInput => Driver.FindElement(By.Id("input-payment-password"));
    public IWebElement ConfirmPasswordInput => Driver.FindElement(By.Id("input-payment-confirm"));
    public IWebElement CompanyInput => Driver.FindElement(By.Id("input-payment-company"));
    public IWebElement Address1Input => Driver.FindElement(By.Id("input-payment-address-1"));
    public IWebElement Address2Input => Driver.FindElement(By.Id("input-payment-address-2"));
    public IWebElement CityInput => Driver.FindElement(By.Id("input-payment-city"));
    public IWebElement PostCodeInput => Driver.FindElement(By.Id("input-payment-postcode"));
    public IWebElement ShippingAddressCountrySelect => Driver.FindElement(By.Id("input-payment-country"));
    public IWebElement ShippingAddressCountryOption(string country) =>
        ShippingAddressCountrySelect.FindElement(By.XPath($".//option[contains(text(), '{country}')]"));
    public IWebElement BillingAddressRegionSelect => Driver.FindElement(By.Id("input-payment-zone"));
    public IWebElement BillingAddressRegionOption(string region) =>
        BillingAddressRegionSelect.FindElement(By.XPath($".//option[contains(text(), '{region}')]"));
    public IWebElement TermsAgreeCheckbox => Driver.FindElement(By.XPath("//input[@id='input-agree']//following-sibling::label"));
    public IWebElement ContinueButton => Driver.FindElement(By.XPath("//button[@id='button-save']"));
    public IWebElement TotalPrice => Driver.FindElements(By.XPath("//td[text()='Total:']/following-sibling::td/strong")).Last();

    public void FillUserDetails(UserDetails userDetails)
    {
        FirstNameInput.SendKeys(userDetails.FirstName);
        LastNameInput.SendKeys(userDetails.LastName);
        EmailInput.SendKeys(userDetails.Email);
        TelephoneInput.SendKeys(userDetails.Telephone);
        PasswordInput.SendKeys(userDetails.Password);
        ConfirmPasswordInput.SendKeys(userDetails.ConfirmPassword);
    }

    public void FillBillingAddress(BillingAddress billingAddress)
    {
        CompanyInput.SendKeys(billingAddress.Company);
        Address1Input.SendKeys(billingAddress.Address1);
        Address2Input.SendKeys(billingAddress.Address2);
        CityInput.SendKeys(billingAddress.City);
        PostCodeInput.SendKeys(billingAddress.PostCode);
        ShippingAddressCountrySelect.Click();
        ShippingAddressCountryOption(billingAddress.Country).Click();
        //Thread.Sleep(1000);
        //Driver.WaitForAjax();
        BillingAddressRegionSelect.Click();
        BillingAddressRegionOption(billingAddress.Region).Click();
    }

    public void AgreeToTerms()
    {
        //Driver.WaitForAjax();
        // TODO: Move to Driver as addition to FindElement as decoratr
        // TODO: Add addtional decorator for highlighting element
        //((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", TermsAgreeCheckbox);
        TermsAgreeCheckbox.Click();
    }

    public void ClickContinue()
    {
        ContinueButton.Click();
    }

    public void AssertTotalPrice(string expectedPrice)
    {
        Assert.That(TotalPrice.Text, Is.EqualTo(expectedPrice));
    }

    public void CompleteCheckout()
    {
        var continueButton = Driver.FindElement(By.XPath("//button[@id='button-save']"));
        continueButton.Click();
    }
}
