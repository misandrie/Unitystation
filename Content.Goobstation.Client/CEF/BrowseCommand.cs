using JetBrains.Annotations;
using Robust.Client.WebView;
using Robust.Shared.Console;

namespace Content.Goobstation.Client.CEF
{
    [UsedImplicitly]
    public sealed class BrowseCommand : IConsoleCommand
    {
        public string Command => "browse";
        public string Description => "";
        public string Help => "";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            // duckduckgo doesn't ask me to accept privacy policy, based.
            var url = args.Length >= 1 ? args[0] : "https://duckduckgo.com";

            var window = new BrowserWindow();

            window.Open();

            window.Browse(url);
        }
    }

    [UsedImplicitly]
    public sealed class BrowseWinCommand : IConsoleCommand
    {
        public string Command => "browsewin";
        public string Description => "";
        public string Help => "";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (args.Length != 1)
            {
                shell.WriteError("Incorrect amount of arguments! Must be a single one.");
                return;
            }

            var parameters = new BrowserWindowCreateParameters(1280, 720)
            {
                Url = args[0]
            };

            var cef = IoCManager.Resolve<IWebViewManager>();
            cef.CreateBrowserWindow(parameters);
        }
    }
}
