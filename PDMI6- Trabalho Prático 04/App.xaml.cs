// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

#if WINDOWS

#endif

namespace TodoApp.MAUI
{
    public partial class App : Application
    {
        const int WindowWidth = 400;
        const int WindowHeight = 800;

        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
#if WINDOWS

#endif
            });

            MainPage = new NavigationPage(new MainPage());
        }
    }
}