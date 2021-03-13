using System;
namespace FetchRewards    {
    /// <summary>
    /// Interface for a Browser window
    /// </summary>
    public interface IBrowser        {
        public T NavigateTo<T>(string url) where T : IBasePage;
        public string GetAlertText();
        public IBrowser MaximzeWindow();
        void KillBrowser();        }    }
