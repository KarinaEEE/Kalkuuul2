#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif


using Views;


namespace Kalkul
{
    public partial class App : Application
    {
        const int WindowWidth = 540;
        const int WindowHeight = 1000;

        public App()
        {
            InitializeComponent();
#if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, View) =>
            {
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowhandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId WindowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowhandle);
                AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(WindowId);
                appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            });
#endif


            MainPage = new KalkulPage();
        }
    }
}
