﻿using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Telerik.Windows.Controls;
using WpfSamples.View;
using WpfSamples.View.Templates;
using WpfSamples.ViewModel;
using WpfSamples.WpfInfrastructure.Utils;

namespace WpfSamples
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Init();

            var view = new AttachConsoleView();
            view.Show();
        }

        private void Init()
        {
            StyleManager.ApplicationTheme = new Windows8Theme();

            // Применяет культуру системы к WPF
            LocalePatch.Init();
        }
    }
}