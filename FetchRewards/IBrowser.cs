using System;
namespace FetchRewards
    {
    public interface IBrowser
        {
        public T NavigateTo<T>(string url) where T : IBasePage;
        public string GetAlertText();
        public IBrowser MaximzeWindow();
        void KillBrowser();
        }
    }
